﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AppPerformanceTracker.Contracts
{
    public abstract class PatchBase
    {

        //HACK the prefix and postfix methods should be declared on the concrete class


        protected static List<IMethodPerformanceTracker> trackers = new List<IMethodPerformanceTracker>();
        // This method tells Harmony which methods to patch

        protected static void LogExecutionTime(MethodBase method, object[] args, long elapsedMs)
        {
            try
            {
                if (method?.DeclaringType != null)
                {
                    string message = $"{method.DeclaringType.Name}.{method.Name} took {elapsedMs}ms to execute";
                    foreach (IMethodPerformanceTracker item in trackers)
                    {
                        item.RecordExecution("XafApp",_SessionId, method, args, TimeSpan.FromMilliseconds(elapsedMs), DateTime.UtcNow);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LogExecutionTime: {ex.Message}");
            }
        }
        protected static string _SessionId { get; set; }
        public static void Init(string SessionId,params IMethodPerformanceTracker[] Trackers)
        {
            _SessionId = SessionId;
            trackers.Clear();
            trackers.AddRange(Trackers);
        }

    }
}
