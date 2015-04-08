using System.Collections;

namespace Xenon.Core.Coroutines
{
    /// <summary>
    /// Executes and manages coroutines
    /// </summary>
    public interface ICoroutineManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        void Run(IEnumerable source);
    }
}