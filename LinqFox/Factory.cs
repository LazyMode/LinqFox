#if PUBLIC
public
#endif
delegate TResult Factory<out TResult>();

#if PUBLIC
public
#endif
delegate TResult Factory<in T, out TResult>(T arg);