using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppPerformanceTracker.Contracts
{
    public class FileMethodPerformanceTracker : MethodPerformanceTracker, IDisposable
    {
        private static FileMethodPerformanceTracker _instance;
        private static readonly object _instanceLock = new object();
        private readonly string _logFilePath;
        private readonly StreamWriter _streamWriter;
        private bool _disposed = false;

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

        public override void RecordExecution(string appId, string sessionId, MethodBase method, object[] parameters, TimeSpan duration, DateTime dateTime)
        {
            base.RecordExecution(appId, sessionId, method, parameters, duration, dateTime);

            MethodExecutionDto execution = MethodExecutionDto.Create(appId, sessionId, method, parameters, duration, dateTime);

            var logEntry = JsonConvert.SerializeObject(execution);
            var encodedLogEntry = Convert.ToBase64String(Encoding.UTF8.GetBytes(logEntry));

            lock (_lockObject)
            {
                WriteLogEntryAsync(encodedLogEntry).ConfigureAwait(false);
            }
        }

        private async Task WriteLogEntryAsync(string logEntry)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(FileMethodPerformanceTracker));

            await _streamWriter.WriteLineAsync(logEntry);
            await _streamWriter.FlushAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _streamWriter?.Dispose();
                }
                _disposed = true;
            }
        }

        ~FileMethodPerformanceTracker()
        {
            Dispose(false);
        }
    }
}
