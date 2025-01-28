using AppPerformanceTracker.Contracts;
using DevExpress.ExpressApp;
using DevExpress.XtraPrinting;
using HarmonyLib;
using System.Diagnostics;
using System.Reflection;

namespace AppPerformanceTracker.Xaf
{
    [HarmonyPatch]
    public class ControllerMethodPatch
    {
        // This method tells Harmony which methods to patch
        static IEnumerable<MethodBase> TargetMethods()
        {
            try
            {
                var methods = new List<MethodBase>();

                // Get all types that inherit from Controller
                var controllerTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.IsDynamic) // Skip dynamic assemblies
                    .SelectMany(a =>
                    {
                        try
                        {
                            return a.GetTypes();
                        }
                        catch
                        {
                            return Array.Empty<Type>();
                        }
                    })
                    .Where(t => typeof(Controller).IsAssignableFrom(t) &&
                               !t.IsAbstract &&
                               !t.IsGenericType);

                foreach (var type in controllerTypes)
                {
                    try
                    {
                        var typeMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public |
                                                        BindingFlags.Instance |
                                                        BindingFlags.DeclaredOnly)
                            .Where(m => !m.IsGenericMethod &&
                                      !m.ContainsGenericParameters &&
                                      !m.GetParameters().Any(p => p.ParameterType.IsGenericType));

                        methods.AddRange(typeMethods);
                    }
                    catch
                    {
                        continue;
                    }
                }

                return methods;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in TargetMethods: {ex.Message}");
                return Array.Empty<MethodBase>();
            }
        }

        // Prefix method to start timing
        static void Prefix(ref Stopwatch __state)
        {
            __state = Stopwatch.StartNew();
        }

        // Postfix method to stop timing and log
        static void Postfix(MethodBase __originalMethod, Stopwatch __state)
        {
            try
            {
                if (__state != null && __originalMethod != null)
                {
                    __state.Stop();
                    long elapsedMs = __state.ElapsedMilliseconds;
                    LogExecutionTime(__originalMethod, elapsedMs);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in Postfix: {ex.Message}");
            }
        }

        static List<IMethodPerformanceTracker> trackers = new List<IMethodPerformanceTracker>();

        public static void Init(params IMethodPerformanceTracker[] Trackers)
        {
            trackers.Clear();
            trackers.AddRange(Trackers);
        }

        private static void LogExecutionTime(MethodBase method, long elapsedMs)
        {
            try
            {
                if (method?.DeclaringType != null)
                {
                    string message = $"{method.DeclaringType.Name}.{method.Name} took {elapsedMs}ms to execute";
                    foreach (IMethodPerformanceTracker item in trackers)
                    {
                        item.RecordExecution("XafApp", method, TimeSpan.FromMilliseconds(elapsedMs), DateTime.UtcNow);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LogExecutionTime: {ex.Message}");
            }
        }
    }

}
