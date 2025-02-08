namespace AYTEmployees.MicroEvent;
public interface IHandle<TMessage>
{
    void Handle(TMessage message);
}