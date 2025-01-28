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
            }
         

        }
    }
}
