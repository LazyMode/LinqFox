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
        Assert.True(dict0.IsCoveredBy(dict1));
        Assert.True(dict1.IsCoveredBy(dict0));

        var dict2 = new Dict
        {
            { "A", 1 },
        };
        Assert.False(dict2.IsCoveredBy(dict1));
        Assert.False(dict1.IsCoveredBy(dict2));

        var dict3 = new Dict(StringComparer.OrdinalIgnoreCase)
        {
            { "a", 1 },
        };
        Assert.True(dict1.IsCoveredBy(dict3));
        Assert.True(dict2.IsCoveredBy(dict3));
        Assert.True(dict3.IsCoveredBy(dict1));
        Assert.False(dict3.IsCoveredBy(dict2));

        var dict4 = new Dict
        {
            { "a", 1 },
            { "A", 1 },
        };
        Assert.True(dict4.IsCoveredBy(dict3));
        Assert.True(dict3.IsCoveredBy(dict4));

        var dict5 = new Dict
        {
            { "A", 1 },
            { "b", new object() },
        };
        Assert.True(dict2.IsCoveredBy(dict5));
        Assert.False(dict3.IsCoveredBy(dict5));
    }
}
