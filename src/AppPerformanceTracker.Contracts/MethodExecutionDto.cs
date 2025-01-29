using System.Reflection;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppPerformanceTracker.Contracts
{
    public class MethodParameterDto
    {
        [JsonConstructor]
        public MethodParameterDto()
        {
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class MethodExecutionDto
    {
        public MethodExecutionDto()
        {
            Parameters = new List<MethodParameterDto>();
        }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonProperty("declaringType")]
        public string DeclaringType { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("executionTime")]
        public TimeSpan ExecutionTime { get; set; }

        [JsonProperty("durationMs")]
        public double DurationMs { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("parameters")]
        public List<MethodParameterDto> Parameters { get; set; }

        public static MethodExecutionDto Create(string appId, string sessionId, MethodBase method, object[] parameterValues, TimeSpan duration, DateTime dateTime)
        {
            var dto = new MethodExecutionDto
            {
                MethodName = method?.Name ?? "Unknown",
                SessionId = sessionId ?? "Unknown",
                DeclaringType = method?.DeclaringType?.FullName ?? "Unknown",
                FullName = $"{method?.DeclaringType?.FullName ?? "Unknown"}.{method?.Name ?? "Unknown"}",
                ExecutionTime = DateTime.UtcNow.TimeOfDay,
                DurationMs = duration.TotalMilliseconds,
                Date = dateTime,
                AppId = appId ?? "Unknown",
            };

            var parameters = method?.GetParameters() ?? Array.Empty<ParameterInfo>();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i < parameterValues?.Length)
                {
                    var paramName = parameters[i].Name ?? "Unknown";
                    var paramValue = parameterValues[i]?.ToString() ?? "null";
                    var paramType = parameters[i].ParameterType;
                    MethodParameterDto methodParameterDto = new() { Name = paramName, Value = paramValue, Type = paramType.FullName ?? "Unknown" };
                    dto.Parameters.Add(methodParameterDto);
                }
            }

            return dto;
        }
    }
}
