using System.Collections.Generic;

#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
public
#endif
static class DictExRefTricks
{
    public static bool TryGetFirst<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dicts,
        TKey key, ref TValue value)
    {
        foreach (var dict in dicts)
        {
            if (dict.TryGetValue(key, out value))
                return true;
        }

        return false;
    }
    public static bool TryGetFirst<TKey, TValue>(TKey key, ref TValue value,
        params IDictionary<TKey, TValue>[] dicts)
    => dicts.TryGetFirst(key, ref value);

    public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> source,
        TKey key, ref TValue value)
    {
        TValue tmp;
        if (source.TryGetValue(key, out tmp))
        {
            value = tmp;
            return true;
        }

        return false;
    }
}
