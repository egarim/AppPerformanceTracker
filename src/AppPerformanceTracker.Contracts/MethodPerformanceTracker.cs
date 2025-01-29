using Newtonsoft.Json;
using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;


namespace AppPerformanceTracker.Contracts
{
    public class MethodPerformanceTracker : IMethodPerformanceTracker
    {
        private readonly Queue<MethodExecutionDto> _executionLog = new Queue<MethodExecutionDto>();
        protected readonly object _lockObject = new object();

    

        public IEnumerable<MethodExecutionDto> GetExecutions()
        {
            lock (_lockObject)
            {
                return _executionLog.ToArray();
            }
        }

 

    

        public virtual void RecordExecution(string AppId,string SessionId, MethodBase method, object[] parameters, TimeSpan duration, DateTime dateTime)
        {
            var execution = MethodExecutionDto.Create(AppId, SessionId, method, parameters, duration, dateTime);
            
            //TODO remove after test
            var json = JsonConvert.SerializeObject(execution, Formatting.Indented);
            Debug.WriteLine($"Serialized JSON: {json}");


            lock (_lockObject)
            {
                _executionLog.Enqueue(execution);
            }
        }
    }
}
