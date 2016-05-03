extern alias ex;

using System;
using System.Linq;
using Xunit;

using Dict = System.Collections.Generic.Dictionary<string, object>;

using ex;

public class DictExTests
{
    [Fact]
    public void ForComparing()
    {
        var dict0 = new Dict
        {
            { "a", 1 },
        };
        var dict1 = new Dict
        {
            { "a", 1 },
        };
        Assert.True(dict0.IsEquivalentOf(dict1));

        var dict2 = new Dict
        {
            { "A", 1 },
        };
        Assert.False(dict2.IsEquivalentOf(dict1));

        var dict3 = new Dict(StringComparer.OrdinalIgnoreCase)
        {
            { "a", 1 },
        };
        Assert.True(dict3.IsSupersetOf(dict1));
        Assert.True(dict3.IsSupersetOf(dict2));
        Assert.True(dict3.IsSubsetOf(dict1));
        Assert.False(dict3.IsSubsetOf(dict2));

        var dict4 = new Dict
        {
            { "a", 1 },
            { "A", 1 },
        };
        Assert.True(dict4.IsEquivalentOf(dict3));

        var dict5 = new Dict
        {
            { "A", 1 },
            { "b", new object() },
        };
        Assert.True(dict5.IsSupersetOf(dict2));
        Assert.False(dict5.IsSupersetOf(dict3));
    }
}
