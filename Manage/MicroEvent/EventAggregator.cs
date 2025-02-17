﻿namespace AYTEmployees.MicroEvent;
public class EventAggregator : IEventAggregator
{
    private readonly object _lock = new();
    public void Clear<T>()
    {
        lock (_lock)
        {
            ListHelpersClass<T>.AsyncActions.Clear();
            ListHelpersClass<T>.RegularActions.Clear();
        }
    }
    public bool HandlerAsyncExistsFor<T>(string arguments = "")
    {
        lock (_lock)
        {
            return ListHelpersClass<T>.AsyncActions.Any(x => x.Tag == arguments && x.IsDead == false);
        }
    }
    public bool HandlerRegularExistsFor<T>(string arguments = "")
    {
        lock (_lock)
        {
            return ListHelpersClass<T>.RegularActions.Any(x => x.Tag == arguments && x.IsDead == false);
        }
    }
    public void PublishAll<T>(T message, string arguments = "")
    {
        List<CustomRegularAction<T>> list;
        lock (_lock)
        {
            list = ListHelpersClass<T>.RegularActions.Where(xx => xx.Tag == arguments).ToList();
        }
        //has to allow to publish to all even if nobody is subscribing (because of clock solitaire).  if nobody is subscribing, just ignore.
        //if (list.Count == 0)
        //{
        //    throw new Exception($"There was nobody subscribing to type {typeof(T)}");
        //}
        foreach (var item in list)
        {
            if (item.Action is null)
            {
                throw new Exception($"The subscriber never invoked an action for Publish.  The message was {typeof(T)}");
            }
            item.Action.Invoke(message);
            if (item.IsDead)
            {
                lock (_lock)
                {
                    ListHelpersClass<T>.RegularActions.Remove(item); //because it is now dead.
                }
            }
        }
    }
    public void Publish<T>(T message, string arguments = "")
    {
        List<CustomRegularAction<T>> list;
        lock (_lock)
        {
            list = ListHelpersClass<T>.RegularActions.Where(xx => xx.Tag == arguments).ToList();
        }
        if (list.Count > 1)
        {
            throw new Exception($"Duplicates are not allowed for Publish.  The message was {typeof(T)} and the arguments was {arguments}");
        }
        //if (list.Count == 0)
        //{
        //    throw new Exception($"There is nobody subscribing for Publish.  The message was {typeof(T)} and the arguments was {arguments}");
        //}
        var item = list.SingleOrDefault();
        if (item is not null)
        {
            //its possible that if you publish and nobody is there then should do nothing
            //to help with the blazor mvvm stuff.
            if (item.Action is null)
            {
                throw new Exception($"The subscriber never invoked an action for Publish.  The message was {typeof(T)} and the arguments was {arguments}");
            }
            item.Action.Invoke(message);
            if (item.IsDead)
            {
                lock (_lock)
                {
                    ListHelpersClass<T>.RegularActions.Remove(item); //because it is now dead.
                }
            }
        }
    }
    public async Task PublishAllAsync<T>(T message, string arguments = "")
    {
        List<CustomAsyncAction<T>> list;
        lock (_lock)
        {
            list = ListHelpersClass<T>.AsyncActions.Where(xx => xx.Tag == arguments).ToList();
        }
        //if nobody is subscribing, then just ignore.  because there can be cases where you publish but the listeners has not been set up yet.
        //if (list.Count == 0)
        //{
        //    throw new Exception($"There was nobody subscribing to type {typeof(T)}");
        //}
        foreach (var item in list)
        {
            if (item.Action is null)
            {
                throw new Exception($"The subscriber never invoked an action for PublishAsync.  The message was {typeof(T)}");
            }
            await item.Action.Invoke(message);
            if (item.IsDead)
            {
                lock (_lock)
                {
                    ListHelpersClass<T>.AsyncActions.Remove(item); //because it is now dead.
                }
            }
        }
    }
    public async Task PublishAsync<T>(T message, string arguments = "") //hopefully this simple.
    {
        List<CustomAsyncAction<T>> list;
        lock (_lock)
        {
            list = ListHelpersClass<T>.AsyncActions.Where(xx => xx.Tag == arguments).ToList();
        }
        if (list.Count > 1)
        {
            throw new Exception($"Duplicates are not allowed for PublishAsync.  The message was {typeof(T)} and the arguments was {arguments}");
        }
        //if (list.Count == 0)
        //{
        //    throw new Exception($"There is nobody subscribing for PublishAsync.  The message was {typeof(T)} and the arguments was {arguments}");
        //}
        var item = list.SingleOrDefault();
        if (item is not null)
        {
            if (item.Action is null)
            {
                throw new Exception($"The subscriber never invoked an action for PublishAsync.  The message was {typeof(T)} and the arguments was {arguments}");
            }
            await item.Action.Invoke(message);
            if (item.IsDead)
            {
                lock (_lock)
                {
                    ListHelpersClass<T>.AsyncActions.Remove(item); //because it is now dead.
                }
            }
        }
    }
    public void Subscribe<T>(object subscriber, Action<T> action, string tag)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        lock (_lock)
        {
            if (ListHelpersClass<T>.RegularActions.Any(xx => xx.Matches(subscriber) && xx.Tag == tag))
            {
                return;
            }
            CustomRegularAction<T> customs = new(subscriber);
            customs.Tag = tag;
            customs.Action = action;
            ListHelpersClass<T>.RegularActions.Add(customs);
        }
    }
    public void Subscribe<T>(object subscriber, Func<T, Task> action, string tag)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        lock (_lock)
        {
            if (ListHelpersClass<T>.AsyncActions.Any(xx => xx.Matches(subscriber) && xx.Tag == tag))
            {
                return;
            }
            CustomAsyncAction<T> customs = new(subscriber);
            customs.Tag = tag;
            customs.Action = action;
            ListHelpersClass<T>.AsyncActions.Add(customs);
        }
    }
    public void UnsubscribeSingle<T>(object subscriber, string tag = "")
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        lock (_lock)
        {
            var lists1 = ListHelpersClass<T>.RegularActions.Where(xx => xx.Matches(subscriber) && xx.Tag == tag).ToList();
            foreach (var item in lists1)
            {
                ListHelpersClass<T>.RegularActions.Remove(item);
            }
            var lists2 = ListHelpersClass<T>.AsyncActions.Where(xx => xx.Matches(subscriber) && xx.Tag == tag).ToList();
            foreach (var item in lists2)
            {
                ListHelpersClass<T>.AsyncActions.Remove(item);
            }
        }
    }
    public void UnsubscribeAll<T>(object subscriber)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        lock (_lock)
        {
            var lists1 = ListHelpersClass<T>.RegularActions.Where(xx => xx.Matches(subscriber)).ToList();
            foreach (var item in lists1)
            {
                ListHelpersClass<T>.RegularActions.Remove(item);
            }
            var lists2 = ListHelpersClass<T>.AsyncActions.Where(xx => xx.Matches(subscriber)).ToList();
            foreach (var item in lists2)
            {
                ListHelpersClass<T>.AsyncActions.Remove(item);
            }
        }
    }
}