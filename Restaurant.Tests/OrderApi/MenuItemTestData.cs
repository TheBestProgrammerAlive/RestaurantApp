using System.Collections;
using Domain.Entities;

namespace Tests.OrderApi;

public class MenuItemTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var items = Tests.TestMenuData.AvailableBaseMenuItems.ToArray();
        yield return [ items ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}