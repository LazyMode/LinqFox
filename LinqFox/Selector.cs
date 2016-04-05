#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
public
#endif
delegate TResult Selector<out TResult>();

#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
public
#endif
delegate TResult Selector<in T, out TResult>(T arg);

#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
public
#endif
delegate TResult Selector<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
