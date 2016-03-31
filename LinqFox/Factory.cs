#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
public
#endif
delegate TResult Factory<out TResult>();

#if EXPOSE_EVERYTHING || EXPOSE_LINQFOX
public
#endif
delegate TResult Factory<in T, out TResult>(T arg);