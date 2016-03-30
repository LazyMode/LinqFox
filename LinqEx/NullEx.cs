#if NETFX_CORE || WINDOWS_UWP || UWP || UAP || dNFx || NetFramework || NET || Silverlight || SILVERLIGHT || SL

using System;

static partial class NullEx
{
    public static object ToDBValue<T>(this T value)
    {
        object o = value;

        if (o == null)
            return DBNull.Value;

        return o;
    }

    public static T ToCLValue<T>(this object value, T @default = default(T))
    {
        if (value == null)
            return @default;

        if (value is DBNull)
            value = null;

        return (T)value;
    }

    public static T ToCLValue<T>(this object value, Func<T> factory)
    {
        if (value == null)
            return factory();

        if (value is DBNull)
            value = null;

        return (T)value;
    }
}

#endif
