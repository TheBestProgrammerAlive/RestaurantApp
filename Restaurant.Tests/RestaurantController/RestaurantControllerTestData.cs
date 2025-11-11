using System.Collections;
using Domain.Entities;

namespace Tests.RestaurantController;

public class RestaurantControllerTestData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        // Use centralized test data to keep consistency across the project
        foreach (var item in Tests.TestMenuData.AvailableBaseMenuItems)
        {
            yield return new object[] { item };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}