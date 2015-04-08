using System.Collections;
using System.Collections.Generic;

namespace Xenon.Core.Coroutines
{
    internal class RoutineHandle
    {
        private readonly IEnumerator _routines;

        public RoutineHandle(IEnumerable routines)
        {
            _routines = routines.GetEnumerator();
        }

        public void Update(GameTime gameTime)
        {

            // maybe do some nifty type detection here 
            // float values are total seconds
            // bool value of false should halt coroutine execution
            // int value skips x number of frames
            var routine = _routines.Current as Routine;

            if (routine == null || routine.Done)
                Step();
            else 
                routine.Update(gameTime);
        }

        public void Step()
        {
            if (_routines.MoveNext())
            {
                var routine = _routines.Current as Routine;

                if(routine != null)
                    routine.Execute();
            }
        }

        public bool Done
        {
            get { return !_routines.MoveNext(); } 
        }

    }
}