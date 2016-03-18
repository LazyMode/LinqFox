using System;
using System.Collections.Generic;

static partial class DictEx
{
    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
    {
        TValue value;
        source.TryGetValue(key, out value);

        return value;
    }
    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source,
        TKey key, TValue @default)
    {
        TValue value;
        if (source.TryGetValue(key, out value))
            return value;

        return @default;
    }

    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source,
        TKey key, Func<TKey, TValue> factory)
    {
        TValue value;
        if (source.TryGetValue(key, out value))
            return value;

        return factory(key);
    }
    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source,
        TKey key, Func<TValue> factory)
    {
        TValue value;
        if (source.TryGetValue(key, out value))
            return value;

        return factory();
    }

    public static bool TryGetFirst<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dicts,
        TKey key, out TValue value)
    {
        foreach (var dict in dicts)
        {
            if (dict.TryGetValue(key, out value))
                return true;
        }

        value = default(TValue);
        return false;
    }
    public static bool TryGetFirst<TKey, TValue>(TKey key, out TValue value,
        params IDictionary<TKey, TValue>[] dicts)
    => dicts.TryGetFirst(key, out value);

    public static TValue GetFirstOrDefault<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dicts,
        TKey key, TValue @default = default(TValue))
    {
        TValue value;
        foreach (var dict in dicts)
        {
            if (dict.TryGetValue(key, out value))
                return value;
        }

        return @default;
    }
    public static TValue GetFirstOrDefault<TKey, TValue>(TKey key, TValue @default,
        params IDictionary<TKey, TValue>[] dicts)
    => dicts.GetFirstOrDefault(key, @default);
    public static TValue GetFirstOrDefault<TKey, TValue>(TKey key,
        params IDictionary<TKey, TValue>[] dicts)
    => dicts.GetFirstOrDefault(key);

    public static TValue GetFirstOrDefault<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dicts,
        TKey key, Func<TKey, TValue> factory)
    {
        TValue value;
        foreach (var dict in dicts)
        {
            if (dict.TryGetValue(key, out value))
                return value;
        }

        return factory(key);
    }
    public static TValue GetFirstOrDefault<TKey, TValue>(TKey key, Func<TKey, TValue> factory,
        params IDictionary<TKey, TValue>[] dicts)
    => dicts.GetFirstOrDefault(key, factory);

    public static TValue GetFirstOrDefault<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dicts,
        TKey key, Func<TValue> factory)
    {
        TValue value;
        foreach (var dict in dicts)
        {
            if (dict.TryGetValue(key, out value))
                return value;
        }

        return factory();
    }
    public static TValue GetFirstOrDefault<TKey, TValue>(TKey key, Func<TValue> factory,
        params IDictionary<TKey, TValue>[] dicts)
    => dicts.GetFirstOrDefault(key, factory);
}
