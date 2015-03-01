namespace Xenon.Core.States
{
    /// <summary>
    /// A <see cref="Transition"/>'s state
    /// </summary>
    public enum TransitionState : byte
    {
        /// <summary>
        /// Moves the transition toward the end of the timeline t(x)
        /// </summary>
        Forward = 0, 
        /// <summary>
        /// Moves the transition backwards toward t(0)
        /// </summary>
        Backward
    }
}