using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Xenon.Core
{
    /// <summary>
    /// A central hub for firing events to multiple listeners
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        private readonly IDictionary<Type, IList<object>> _listeners = new Dictionary<Type, IList<object>>();

        #region Lifecylce 
        
        ~EventAggregator()
        {
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool managedDispose)
        {
            if (managedDispose)
            {
                GC.SuppressFinalize(this);
                _listeners.Clear();
            }
        }

        #endregion

        /// <summary>
        /// Sends a message to all of the listeners
        /// </summary>
        /// <param name="message"></param>
        /// <typeparam name="TMessage"></typeparam>
        public void SendMessage<TMessage>(TMessage message = default(TMessage)) where TMessage : struct
        {
            var messageType = typeof (TMessage);
            IList<object> handlerList;

            if (_listeners.TryGetValue(messageType, out handlerList))
                handlerList.Select(handler => (handler as IEventHandler<TMessage>))
                           .ForEach(stronglyTypedHandler => stronglyTypedHandler.Handle(message));
        }

        /// <summary>
        /// Subscribes a <see cref="IEventHandler{TEventType}"/> to this <see cref="IEventAggregator"/>
        /// </summary>
        /// <typeparam name="TEventType"></typeparam>
        public void Subscribe<TEventType>(IEventHandler<TEventType> eventHandler) where TEventType : struct
        {
            var messageType = typeof (TEventType);

            if (!_listeners.ContainsKey(messageType)) 
                _listeners.Add(messageType, new List<object>(16));

            _listeners[messageType].Add(eventHandler);
        }

        /// <summary>
        /// Removes a subscription from the <see cref="IEventAggregator"/>
        /// </summary>
        /// <param name="eventHandler"></param>
        /// <typeparam name="TEventType"></typeparam>
        public void Unsubscribe<TEventType>(IEventHandler<TEventType> eventHandler) where TEventType : struct
        {
            var messageType = typeof (TEventType);
            IList<object> handlerList;

            if (_listeners.TryGetValue(messageType, out handlerList))
            {
                Debug.Assert(handlerList.Remove(eventHandler));
            }
        }

        /// <summary>
        /// Clears all subscriptions
        /// </summary>
        public void Clear()
        {
            _listeners.Clear();
        }
    }
}