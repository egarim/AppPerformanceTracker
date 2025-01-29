using System.Reflection;
using System;

using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppPerformanceTracker.Contracts
{
    //public class MethodExecutionDto
    //{
    //    public string AppId { get; set; }
    //    public string MethodName { get; set; }
    //    public string DeclaringType { get; set; }
    //    public string FullName { get; set; }
    //    public DateTime ExecutionTime { get; set; }
    //    public double DurationMs { get; set; }
    //    public DateTime Date { get; set; }

    //    public static MethodExecutionDto Create(string AppId,MethodBase method, TimeSpan duration,DateTime dateTime)
    //    {
    //        return new MethodExecutionDto
    //        {
    //            MethodName = method.Name,
    //            DeclaringType = method.DeclaringType?.FullName ?? "Unknown",
    //            FullName = $"{method.DeclaringType?.FullName ?? "Unknown"}.{method.Name}",
    //            ExecutionTime = DateTime.UtcNow,
    //            DurationMs = duration.TotalMilliseconds,
    //            Date = dateTime,
    //            AppId = AppId
    //        };
    //    }
    //}

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

        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonProperty("declaringType")]
        public string DeclaringType { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("executionTime")]
        public DateTime ExecutionTime { get; set; }

        [JsonProperty("durationMs")]
        public double DurationMs { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("parameters")]
        public List<MethodParameterDto> Parameters { get; set; }

        public static MethodExecutionDto Create(string AppId, MethodBase method, TimeSpan duration, DateTime dateTime)
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

        public static MethodExecutionDto Create(string AppId, MethodBase method, object[] parameterValues, TimeSpan duration, DateTime dateTime)
        {
            var dto = new MethodExecutionDto
            {
                MethodName = method.Name,
                DeclaringType = method.DeclaringType?.FullName ?? "Unknown",
                FullName = $"{method.DeclaringType?.FullName ?? "Unknown"}.{method.Name}",
                ExecutionTime = DateTime.UtcNow,
                DurationMs = duration.TotalMilliseconds,
                Date = dateTime,
                AppId = AppId,
               
            };

            var parameters = method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i < parameterValues.Length)
                {
                    var paramName = parameters[i].Name;
                    var paramValue = parameterValues[i].ToString();
                    var paramType = parameters[i].ParameterType;
                    MethodParameterDto methodParameterDto = new() { Name = paramName, Value = paramValue, Type = paramType.FullName };
                    dto.Parameters.Add(methodParameterDto);
                }
            }

            return dto;
        }
    }


}
