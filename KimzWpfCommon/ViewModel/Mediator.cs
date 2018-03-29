using KimzWpfCommon.Utils;
using System;
using System.Collections.Generic;

namespace KimzWpfCommon.ViewModel
{
    public sealed class Mediator<TMessage>
    {
        private readonly Dictionary<TMessage, List<WeakReferenceWrapper>> _actions =
            new Dictionary<TMessage, List<WeakReferenceWrapper>>();

        public Mediator()
        {

        }

        public void Register<TParameter>(TMessage message, object receiver, Action<TParameter> action)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            lock (this._actions)
            {
                if (!this._actions.ContainsKey(message))
                {
                    this._actions[message] = new List<WeakReferenceWrapper>();
                }

                this._actions[message].Add(new WeakReferenceWrapper(receiver, action));
            }
        }

            public void Unregister<TParameter>(TMessage message, object receiver, Action<TParameter> action)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            lock (this._actions)
            {
                if (this._actions.ContainsKey(message))
                {
                    List<WeakReferenceWrapper> actionlist = this._actions[message];

                    actionlist.Remove(new WeakReferenceWrapper(receiver, action));

                    if (actionlist.Count == 0)
                    {
                        this._actions.Remove(message);
                    }
                }
            }
        }

        public void Send<TParameter>(TMessage message, TParameter parameter)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            lock (this._actions)
            {
                if (this._actions.ContainsKey(message))
                {
                    List<WeakReferenceWrapper> actionslist = this._actions[message];

                    foreach (var action in actionslist)
                    {
                        action.Action.DynamicInvoke(parameter);
                    }
                }
            }
        }
    }
}
