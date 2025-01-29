using AppPerformanceTracker.Contracts;
using AppPerformanceTracker.Module.BusinessObjects;
using DevExpress.CodeParser.Diagnostics;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPerformanceTracker.Module.Controllers
{
    public class ParseLogController : ViewController
    {
        SimpleAction parse;
        public ParseLogController() : base()
        {

            this.TargetObjectType = typeof(AppLogFile);
            this.TargetViewType = ViewType.DetailView;
            // Target required Views (use the TargetXXX properties) and create their Actions.
            parse = new SimpleAction(this, "Parse", "View");
            parse.Execute += parse_Execute;
            
        }
        private void parse_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var CurrentAppLogFile = this.View.CurrentObject as AppLogFile;
            MemoryStream stream = new();
            CurrentAppLogFile.LogFile.SaveToStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var FromBase64 = Convert.FromBase64String(line);
                    var TextLine = Encoding.UTF8.GetString(FromBase64);
                    var LineData = JsonConvert.DeserializeObject<MethodExecutionDto>(TextLine);

                    var CurrentMethodExecution = this.View.ObjectSpace.CreateObject<MethodExecution>();
                    CurrentMethodExecution.AppId = LineData.AppId;
                    CurrentMethodExecution.SessionId = LineData.SessionId;
                    CurrentMethodExecution.Date = LineData.Date;
                    CurrentMethodExecution.DurationMs = LineData.DurationMs;
                    CurrentMethodExecution.MethodName = LineData.MethodName;
                    CurrentMethodExecution.DeclaringType = LineData.DeclaringType;
                    CurrentMethodExecution.FullName = LineData.FullName;
                    CurrentMethodExecution.MethodName = LineData.MethodName;
                    CurrentMethodExecution.ExecutionTime = TimeOnly.FromTimeSpan(LineData.ExecutionTime);
                }
            }

            this.View.ObjectSpace.CommitChanges();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }
}
