using System.Collections;
using Restaurant.Application.Common.Dtos;
using Restaurant.Application.Common.Mapping;

namespace Tests.RestaurantController;

public class RestaurantControllerTestData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        // Use centralized test data to keep consistency across the project
        foreach (var item in Tests.TestMenuData.AvailableBaseMenuItems)
        {
            MenuItemDto dto = item.ToDto();
            yield return new object[] { dto };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}