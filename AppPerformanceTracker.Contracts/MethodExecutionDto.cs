using System.Reflection;
using System;

using System.Collections.Generic;

namespace AppPerformanceTracker.Contracts
{
    public class MethodExecutionDto
    {
        public string AppId { get; set; }
        public string MethodName { get; set; }
        public string DeclaringType { get; set; }
        public string FullName { get; set; }
        public DateTime ExecutionTime { get; set; }
        public double DurationMs { get; set; }
        public DateTime Date { get; set; }

        public static MethodExecutionDto Create(string AppId,MethodBase method, TimeSpan duration,DateTime dateTime)
        {
            return new MethodExecutionDto
            {
                MethodName = method.Name,
                DeclaringType = method.DeclaringType?.FullName ?? "Unknown",
                FullName = $"{method.DeclaringType?.FullName ?? "Unknown"}.{method.Name}",
                ExecutionTime = DateTime.UtcNow,
                DurationMs = duration.TotalMilliseconds,
                Date = dateTime,
                AppId = AppId
            };
        }
    }

}
