using System;

namespace Xenon.Core.Coroutines
{
    /// <summary>
    /// Pauses execution of a coroutine for the specified interval
    /// </summary>
    public class Wait : Routine
    {
        /// <summary>
        /// Waits until the next game loop iteration to continue execution
        /// </summary>
        /// <returns></returns>
        public static Wait ForNextUpdate()
        {
            return new Wait {
                Interval = TimeSpan.FromMilliseconds(0)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static Wait Seconds(double seconds)
        {
            return new Wait {
                Interval = TimeSpan.FromSeconds(seconds)
            };
        }

        private TimeSpan _elapsed;

        /// <summary>
        /// 
        /// </summary>
        public Wait()
        {
            Interval = TimeSpan.Zero;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            _elapsed = TimeSpan.Zero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            _elapsed = _elapsed.Add(gameTime.ElapsedGameTime);

            if (_elapsed.TotalMilliseconds >= Interval.TotalMilliseconds)
                Done = true;
        }


        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Interval { get; set; }
    }
}