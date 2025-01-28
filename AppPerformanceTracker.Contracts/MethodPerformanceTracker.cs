using System.Reflection;
using System;

using System.Collections.Generic;

namespace AppPerformanceTracker.Contracts
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    namespace AppPerformanceTracker.Contracts
    {
        public class MethodPerformanceTracker
        {
            private readonly Queue<MethodExecutionDto> _executionLog = new Queue<MethodExecutionDto>();
            private readonly object _lockObject = new object();

            public void RecordExecution(string AppId,MethodBase method, TimeSpan duration,DateTime dateTime)
            {
                var execution = MethodExecutionDto.Create(AppId,method, duration, dateTime);
                lock (_lockObject)
                {
                    _executionLog.Enqueue(execution);
                }
            }

            public IEnumerable<MethodExecutionDto> GetExecutions()
            {
                lock (_lockObject)
                {
                    return _executionLog.ToArray();
                }
            }

            public IEnumerable<MethodStatisticsDto> GetStatistics()
            {
                IEnumerable<MethodExecutionDto> executions;
                lock (_lockObject)
                {
                    executions = _executionLog.ToArray();
                }

                return executions
                    .GroupBy(e => e.FullName)
                    .Select(group => new MethodStatisticsDto
                    {
                        MethodFullName = group.Key,
                        MethodName = group.First().MethodName,
                        DeclaringType = group.First().DeclaringType,
                        ExecutionCount = group.Count(),
                        AverageDurationMs = group.Average(e => e.DurationMs),
                        MinDurationMs = group.Min(e => e.DurationMs),
                        MaxDurationMs = group.Max(e => e.DurationMs),
                        FirstExecution = group.Min(e => e.ExecutionTime),
                        LastExecution = group.Max(e => e.ExecutionTime),
                        MedianDurationMs = CalculateMedian(group.Select(e => e.DurationMs))
                    });
            }

            private static double CalculateMedian(IEnumerable<double> values)
            {
                var sorted = values.OrderBy(v => v).ToList();
                int count = sorted.Count;
                int mid = count / 2;
                return count % 2 == 0
                    ? (sorted[mid - 1] + sorted[mid]) / 2
                    : sorted[mid];
            }
        }
    }
}
