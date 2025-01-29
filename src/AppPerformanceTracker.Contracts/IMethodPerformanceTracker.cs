using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace AppPerformanceTracker.Contracts
{
    public interface IMethodPerformanceTracker
    {
        IEnumerable<MethodExecutionDto> GetExecutions();
        void RecordExecution(string AppId,string SessionId, MethodBase method, object[] parameters, TimeSpan duration, DateTime dateTime);
    }

}
