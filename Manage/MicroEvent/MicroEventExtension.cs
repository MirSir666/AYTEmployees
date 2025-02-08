namespace AYTEmployees.MicroEvent;
public static class MicroEventExtension
{
    //public static IEventAggregator? Aggregator { get; set; }
    public static IServiceCollection UseMicroEvent(this IServiceCollection builder)
    {
  
        builder.AddSingleton<IEventAggregator, EventAggregator>();
        return builder;
    }
}