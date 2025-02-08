namespace AYTEmployees.MicroEvent;
public interface IHandleAsync<TMessage>
{
    Task HandleAsync(TMessage message);
}