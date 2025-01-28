using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace AppPerformanceTracker.Module.BusinessObjects {
    [DefaultClassOptions]
    public class MethodExecution : BaseObject { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://docs.devexpress.com/eXpressAppFramework/113146/business-model-design-orm/business-model-design-with-xpo/base-persistent-classes).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public MethodExecution(Session session)
            : base(session) {
        }
        public override void AfterConstruction() {
            base.AfterConstruction();
            // Place your initialization code here (https://docs.devexpress.com/eXpressAppFramework/112834/getting-started/in-depth-tutorial-winforms-webforms/business-model-design/initialize-a-property-after-creating-an-object-xpo?v=22.1).
        }
        private string appId;
        [Size(100)]
        public string AppId
        {
            get => appId;
            set => SetPropertyValue(nameof(AppId), ref appId, value);
        }

        private string methodName;
        [Size(500)]
        public string MethodName
        {
            get => methodName;
            set => SetPropertyValue(nameof(MethodName), ref methodName, value);
        }

        private string declaringType;
        [Size(500)]
        public string DeclaringType
        {
            get => declaringType;
            set => SetPropertyValue(nameof(DeclaringType), ref declaringType, value);
        }

        private string fullName;
        [Size(500)]
        public string FullName
        {
            get => fullName;
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
        }

        private DateTime executionTime;
        public DateTime ExecutionTime
        {
            get => executionTime;
            set => SetPropertyValue(nameof(ExecutionTime), ref executionTime, value);
        }

        private double durationMs;
        public double DurationMs
        {
            get => durationMs;
            set => SetPropertyValue(nameof(DurationMs), ref durationMs, value);
        }

        private DateTime date;
        public DateTime Date
        {
            get => date;
            set => SetPropertyValue(nameof(Date), ref date, value);
        }

    }
}