using System;

namespace KyCMS.Common.Job
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// Executes the specified execution state.
        /// </summary>
        /// <param name="executionState">State of the execution.</param>
        void Execute(object executionState);
        /// <summary>
        /// Errors the specified e.
        /// </summary>
        /// <param name="e">The e.</param>
        void Error(Exception e);
    }
}
