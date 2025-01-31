using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace AppPerformanceTracker.Contracts
{
    public class FileMethodPerformanceTracker : MethodPerformanceTracker
    {
        private static FileMethodPerformanceTracker _instance;
        private static readonly object _instanceLock = new object();
        private readonly string _logFilePath;
        private static  StreamWriter _streamWriter;

   
        private FileMethodPerformanceTracker(string logFilePath)
        {
            _logFilePath = logFilePath ?? Path.Combine(Directory.GetCurrentDirectory(), "execution_log.txt");
            _streamWriter = new StreamWriter(new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.Read, 4096, true));
        }

        public static FileMethodPerformanceTracker Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        throw new InvalidOperationException("Instance not initialized. Call InitializeInstance first.");
                    }
                    return _instance;
                }
            }
        }

        public static void InitializeInstance(string logFilePath = null)
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new FileMethodPerformanceTracker(logFilePath);
                }
                else
                {
                    throw new InvalidOperationException("Instance already initialized.");
                }
            }
        }

        public override void RecordExecution(string AppId,string SessionId, MethodBase method, object[] parameters, TimeSpan duration, DateTime dateTime)
        {
            base.RecordExecution(AppId,SessionId, method, parameters, duration, dateTime);

            MethodExecutionDto execution = MethodExecutionDto.Create(AppId, SessionId, method, parameters, duration, dateTime);

            var logEntry = JsonConvert.SerializeObject(execution);
            var encodedLogEntry = Convert.ToBase64String(Encoding.UTF8.GetBytes(logEntry));

            lock (_lockObject)
            {
                WriteLogEntryAsync(encodedLogEntry).ConfigureAwait(false);
            }
        }

        private async Task WriteLogEntryAsync(string logEntry)
        {
            await _streamWriter.WriteLineAsync(logEntry);
            await _streamWriter.FlushAsync();
        }

        ~FileMethodPerformanceTracker()
        {
            _streamWriter?.Dispose();
        }
    }
}
