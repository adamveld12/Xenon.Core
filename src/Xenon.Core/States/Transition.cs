using System;
using System.Security.Cryptography.X509Certificates;

namespace Xenon.Core.States
{
    /// <summary>
    /// An interpolation from a start to end at some point in time
    /// </summary>
    public class Transition
    {
        private TimeSpan _time;
        private TimeSpan _currentTime;
        private bool _playing ;

        /// <summary>
        /// Initializes a new instance of <see cref="Transition"/>
        /// </summary>
        public Transition()
        {
            _currentTime = TimeSpan.Zero;
            _time = TimeSpan.FromSeconds(1);
            _playing = true;

            State = TransitionState.Forward;
        }

        /// <summary>
        /// Define custom interpolation functions here
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        protected virtual float Interpolate(float current, float target, float percent)
        {
            return MathHelper.Lerp(current, target, percent);
        }

        /// <summary>
        /// Rewinds the <see cref="Transition"/>
        /// </summary>
        public void Rewind()
        { _currentTime = TimeSpan.Zero; }

        /// <summary>
        /// Advances the <see cref="Transition"/>
        /// </summary>
        public void AdvanceToEnd()
        { _currentTime = _time; }

        /// <summary>
        /// Stops the <see cref="Transition"/>
        /// </summary>
        public void Pause()
        { _playing = false; }

        /// <summary>
        /// Plays the Transition
        /// </summary>
        public void Play()
        { _playing = true; }

        /// <summary>
        /// Updates the transition based on the current state
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (_playing)
            {
                var elapsed = gameTime.TotalMilliseconds;
                var currentMilis = (float)_currentTime.TotalMilliseconds;
                var target = (float)(State == TransitionState.Forward ? _time : TimeSpan.Zero).TotalMilliseconds; 

                var result = Interpolate(currentMilis, target, elapsed/target);

                if (MathHelper.FuzzyEquals(result, target)) Pause();

                _currentTime = TimeSpan.FromMilliseconds(MathHelper.Clamp(result, 0, target));
            }
        }

        /// <summary>
        /// Get or set the current state
        /// </summary>
        public TransitionState State { get; set; }

        /// <summary>
        /// The percentage completed of this transition
        /// </summary>
        public float Percent
        {
            get { return (float)(_currentTime.TotalMilliseconds/_time.TotalMilliseconds); }
        }

        /// <summary>
        /// The current time in the current <see cref="Transition"/>
        /// </summary>
        public TimeSpan CurrentTime
        {
            get { return _currentTime; }
        }
    }
}