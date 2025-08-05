using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Restaurant.Api;

namespace Tests.RestaurantController;

public class RestaurantEndpointsTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
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

        var items = await response.Content.ReadFromJsonAsync<IReadOnlyCollection<BaseMenuItem>>(_jsonOptions);
        Assert.NotNull(items);

        Assert.Equal(Menu.AvailableBaseMenuItems.Count, items!.Count);

        // A quick sanity check on one element
        var firstExpected = Menu.AvailableBaseMenuItems.First();
        Assert.Contains(items, i => i.Id == firstExpected.Id && i.Name == firstExpected.Name);
    }

    [Fact]
    public async Task GetMenuItem_ReturnsItem_WhenValidData()
    {
        // arrange
        var existingId = Menu.AvailableBaseMenuItems.First().Id;

        // act
        var response = await _client.GetAsync($"/menu-items/{existingId}");

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var item = await response.Content.ReadFromJsonAsync<BaseMenuItem>(_jsonOptions);
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
}