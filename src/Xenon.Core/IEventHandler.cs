namespace Xenon.Core
{
    /// <summary>
    /// Listens to events that are fired from an <see cref="IEventAggregator"/>
    /// Forcing struct here ensures that all handlers get a copy of the message 
    /// and that high frequency message passing doesn't create unecessary garbage
    /// </summary>
    public interface IEventHandler<in TMessageType> where TMessageType : struct
    {
        /// <summary>
        /// Handles a message
        /// </summary>
        /// <param name="message"></param>
        void Handle(TMessageType message = default(TMessageType));
    }
}