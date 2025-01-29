using System;

namespace AppPerformanceTracker.Contracts
{
    public class MethodStatisticsDto
    {
        public string AppId { get; set; }
        public string MethodFullName { get; set; }
        public string MethodName { get; set; }
        public string DeclaringType { get; set; }
        public int ExecutionCount { get; set; }
        public double AverageDurationMs { get; set; }
        public double MinDurationMs { get; set; }
        public double MaxDurationMs { get; set; }
        public double MedianDurationMs { get; set; }
        public DateTime FirstExecution { get; set; }
        public DateTime LastExecution { get; set; }
    }
}
