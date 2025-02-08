namespace AYTEmployees.MicroEvent;
//i think this version will need to be static.  otherwise, the entire event aggravation has to be generic but can't do that though.
internal static class ListHelpersClass<T>
{
    public static List<CustomAsyncAction<T>> AsyncActions { get; set; } = new();
    public static List<CustomRegularAction<T>> RegularActions { get; set; } = new();
    
}