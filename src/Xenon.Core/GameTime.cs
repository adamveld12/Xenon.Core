using System;
using System.Globalization;

namespace Xenon.Core
{
    /// <summary>
    /// A simple structure that represents the current frame's timeing statistics
    /// </summary>
    public sealed class GameTime
    {
        #region Fields

        private static readonly GameTime _zero = default(GameTime);

        private const string _format = "Elapsed Frame Time: {0}\r\nTotal Game Time: {1}\r\nLast Update Ran Slow: {2}";

        private readonly bool _isRunningSlowly;
        private readonly TimeSpan _elapsed;
        private readonly TimeSpan _total;
        private readonly float _totalSeconds;
        private readonly float _totalMilliseconds;

        #endregion

        /// <summary>
        /// Initializes a new instance of <see cref="GameTime"/>
        /// </summary>
        /// <param name="total"></param>
        /// <param name="elapsed"></param>
        /// <param name="isRunningSlowly"></param>
        public GameTime(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            _total = total;
            _elapsed = elapsed;
            _isRunningSlowly = isRunningSlowly;

            _totalSeconds = (float)_total.TotalSeconds;
            _totalMilliseconds = (float)_total.TotalMilliseconds;
        }

        #region Methods

        /// <summary>
        /// A human readable representation of this structure
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format(CultureInfo.CurrentCulture, _format,
                                                             _elapsed.TotalMilliseconds, 
                                                             _total, 
                                                             _isRunningSlowly);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the total seconds of the last update
        /// </summary>
        public float TotalSeconds
        {
            get { return _totalSeconds; }
        }

        /// <summary>
        /// Gets the total milliseconds of the last update 
        /// </summary>
        public float TotalMilliseconds 
        {
            get { return _totalMilliseconds; }
        }

        /// <summary>
        /// How much time has elapsed on the last frame
        /// </summary>
        public TimeSpan ElapsedGameTime
        {
            get { return _elapsed; }
        }

        /// <summary>
        /// How much time has elapsed since the engine has started
        /// </summary>
        public TimeSpan TotalGameTime
        {
            get { return _total; }
        }

        /// <summary>
        /// If the last update took longer than the target elapsed
        /// </summary>
        public bool IsRunningSlowly
        {
            get { return _isRunningSlowly; }
        }

        /// <summary>
        /// Gets a <see cref="GameTime"/>
        /// </summary>
        public static GameTime Zero
        {
            get { return _zero; }
        }


        #endregion
    }
}
