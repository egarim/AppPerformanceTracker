using AppPerformanceTracker.Xaf;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXafAndXpo.Infrastructure;
using Newtonsoft.Json;
using DevExpress.CodeParser;
using AppPerformanceTracker.Contracts;
using System.Diagnostics;

namespace TestXafAndXpo
{
    public class RadLogTest
    {
   

        [TearDown]
        public void TearDown()
        {
        
        }
        [SetUp]
        public virtual void SetUp()
        {
          
        }

        [Test]
        public void LogToMethodData()
        {


            var Log = File.ReadAllLines("execution_log.txt");
            foreach (string item in Log)
            {
                var FromBase64=  Convert.FromBase64String(item);
                var TextLine=Encoding.UTF8.GetString(FromBase64);
                var Line = JsonConvert.DeserializeObject<MethodExecutionDto>(TextLine);
                Debug.WriteLine(Line.Parameters.Count);
            }
         

        }

        [Test]
        public void SimpleLogToMethodData()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None
            };

            var Log = File.ReadAllLines("execution_log.txt");
            foreach (string item in Log)
            {
                var FromBase64 = Convert.FromBase64String(item);
                var TextLine = Encoding.UTF8.GetString(FromBase64);

                // Log the JSON string to see what we're trying to deserialize
                Debug.WriteLine($"Attempting to deserialize: {TextLine}");

                var Line = JsonConvert.DeserializeObject<MethodExecutionDto>(TextLine, settings);
                Debug.WriteLine($"Parameters count: {Line?.Parameters?.Count ?? 0}");
            }
        }

    }
}
