using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Restaurant.Api;

namespace Tests.RestaurantController;

public class RestaurantEndpointsTests(TestWebAppFactory factory)
    : IClassFixture<TestWebAppFactory>
{
    private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetAllMenuItems_ReturnsFullList_WhenValidData()
    {
        // arrange
        // act
        var response = await _client.GetAsync("/menu-items");

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var items = await response.Content.ReadFromJsonAsync<IReadOnlyCollection<MenuItem>>(_jsonOptions);
        Assert.NotNull(items);

        Assert.Equal(Tests.TestMenuData.AvailableBaseMenuItems.Count, items!.Count);

        // A quick sanity check on one element
        var firstExpected = Tests.TestMenuData.AvailableBaseMenuItems.First();
        Assert.Contains(items, i => i.Id == firstExpected.Id && i.Name == firstExpected.Name);
    }

    [Fact]
    public async Task GetMenuItem_ReturnsItem_WhenValidData()
    {
        // arrange
        var existingId = Tests.TestMenuData.AvailableBaseMenuItems.First().Id;

        // act
        var response = await _client.GetAsync($"/menu-items/{existingId}");

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var item = await response.Content.ReadFromJsonAsync<MenuItem>(_jsonOptions);
        Assert.NotNull(item);
        Assert.Equal(existingId, item!.Id);
    }

    [Fact]
    public async Task GetMenuItem_UnknownId_Returns404()
    {
        // arrange
        var unknownId = Guid.NewGuid(); // guaranteed not to be in the static list

        // act
        var response = await _client.GetAsync($"/menu-items/{unknownId}");

        // assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Theory]
    [ClassData(typeof(RestaurantControllerTestData))]
    public async Task PostMenuItem_ReturnsCreated_WhenValidData(MenuItem menuItem)
    {
        // arrange
        // act
        var response = await _client.PostAsJsonAsync("/menu-items", menuItem);
        // assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task PostMenuItem_ReturnsBadRequest_WhenInvalidData()
    {
        // arrange: send invalid payload directly to avoid domain constructor validation throwing
        var payload = new { id = Guid.NewGuid(), name = "", basePrice = -1m, defaultIngredients = Array.Empty<object>() };

        // act
        var response = await _client.PostAsJsonAsync("/menu-items", payload);

        // assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}