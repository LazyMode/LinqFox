#if !NET20
using System;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(Func<>))]
[assembly: TypeForwardedTo(typeof(Func<,>))]
[assembly: TypeForwardedTo(typeof(Func<,,>))]
#else
namespace System
{
#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
    public
#endif
    delegate TResult Func<out TResult>();

#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
    public
#endif
    delegate TResult Func<in T, out TResult>(T arg);

#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
    public
#endif
    delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
}
#endif
