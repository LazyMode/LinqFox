extern alias ex;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using ex;
//using static ex::EnumerableEx;

public class EnumerableExTest
{
    class EnumerableThrowsInvalidOperationException0
        : IEnumerable<char>
    {
        public IEnumerator<char> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
    class EnumerableThrowsInvalidOperationException
        : IEnumerable<char>
    {
        public IEnumerator<char> GetEnumerator()
        {
            yield return 'c';
            throw new InvalidOperationException();
            yield return 'c';
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

    [Fact]
    public void ExAllTest()
    {
        var sss = "aaskjfhkaehff".Select(c => Tuple.Create(c)).ToList();
        foreach(var c in sss)
        {
            if (char.IsWhiteSpace(c.Item1))
                throw new Exception();
        }

        Assert.True("".All());
        Assert.True("".All(c => true, true));
        Assert.True("".All(c => true, false));

        var e = new EnumerableThrowsInvalidOperationException();

        Assert.False(e.All(true));
        Assert.False(e.All(c => true, true));
        Assert.Throws<InvalidOperationException>(() => e.All());
        Assert.Throws<InvalidOperationException>(() => e.All());
        Assert.Throws<InvalidOperationException>(() => e.All(false));
        Assert.Throws<InvalidOperationException>(() => e.All(c => true));
        Assert.Throws<InvalidOperationException>(() => e.All(c => true, false));
    }
    [Fact]
    public void ExAnyTest()
    {
        Assert.False("".Any());
        Assert.False("".Any(c => true, true));
        Assert.False("".Any(c => true, false));

        IEnumerable<char> e = new EnumerableThrowsInvalidOperationException();

        Assert.True(e.Any(true));
        Assert.True(e.Any(c => true, true));

        e = new EnumerableThrowsInvalidOperationException0();

        Assert.False(e.Any(true));
        Assert.False(e.Any(c => true, true));
        Assert.Throws<InvalidOperationException>(() => e.Any());
        Assert.Throws<InvalidOperationException>(() => e.Any(false));
        Assert.Throws<InvalidOperationException>(() => e.Any(c => true));
        Assert.Throws<InvalidOperationException>(() => e.Any(c => true, false));
    }

    [Fact]
    public void SequenceEqualTest()
    {
        Assert.True("".SequenceEqual(""));
        Assert.True("1".SequenceEqual("1"));
        Assert.False("12".SequenceEqual("1"));
        Assert.False("1".SequenceEqual("12"));
        Assert.False("123".SequenceEqual("1b3"));

        Func<char, char, bool> test = null;

        //Assert.True("".SequenceEqual("", test));
        Assert.True("1".SequenceEqual("1", test));
        //Assert.False("12".SequenceEqual("1", test));
        //Assert.False("1".SequenceEqual("12", test));
        Assert.False("123".SequenceEqual("1b3", test));

        test = (a, b) => a == b;

        //Assert.True("".SequenceEqual("", test));
        Assert.True("1".SequenceEqual("1", test));
        //Assert.False("12".SequenceEqual("1", test));
        //Assert.False("1".SequenceEqual("12", test));
        Assert.False("123".SequenceEqual("1b3", test));

        test = (a, b) => a != b;

        //Assert.True("".SequenceEqual("", test));
        Assert.False("1".SequenceEqual("1", test));
        //Assert.False("12".SequenceEqual("1", test));
        //Assert.False("1".SequenceEqual("12", test));
        Assert.True("222".SequenceEqual("bbb", test));

        test = (a, b) => true;

        //Assert.True("".SequenceEqual("", test));
        Assert.True("1".SequenceEqual("1", test));
        //Assert.False("12".SequenceEqual("1", test));
        //Assert.False("1".SequenceEqual("12", test));
        Assert.True("123".SequenceEqual("1b3", test));

        test = (a, b) => false;

        //Assert.True("".SequenceEqual("", test));
        Assert.False("1".SequenceEqual("1", test));
        //Assert.False("12".SequenceEqual("1", test));
        //Assert.False("1".SequenceEqual("12", test));
        Assert.False("123".SequenceEqual("1b3", test));

        Assert.Throws<ArgumentNullException>(() => "".SequenceEqual(default(string), (a, b) => true));
        Assert.Throws<NullReferenceException>(() => default(string).SequenceEqual("", (a, b) => true));
    }

    [Fact]
    public void ZipFullTest()
    {
        Assert.True(new[] { "1a", "2b", "3c" }.SequenceEqual("123".ZipFull("abc", (a, b) => new string(new[] { a, b }))));

        Func<char, char, int> selector = null;
        Assert.Throws<ArgumentNullException>(() => "".ZipFull("", selector).All());
        selector = (a, b) => (a * char.MaxValue + 1) + b;
        Assert.Throws<ArgumentNullException>(() => "".ZipFull(default(string), selector).All());
        Assert.Throws<NullReferenceException>(() => default(string).ZipFull("", selector).All());

        Assert.Throws<InvalidOperationException>(() => "1234".ZipFull("abc", selector).All());
        Assert.Throws<InvalidOperationException>(() => "123".ZipFull("abcd", selector).All());
    }
}
