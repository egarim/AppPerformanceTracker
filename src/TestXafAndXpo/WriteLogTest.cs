using AppPerformanceTracker.Contracts;
using AppPerformanceTracker.Xaf;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Xpo;
using TestXafAndXpo.Infrastructure;


namespace TestXafAndXpo
{
    public class WriteLogTest
    {
        private ViewController controller;
        private DetailView detailView;
        XafCustomer? customer;
        TestApplication application;

        [TearDown]
        public void TearDown()
        {
            detailView?.Dispose();
            controller?.Dispose();
            application?.Dispose();
        }
        [SetUp]
        public virtual void SetUp()
        {
            XPObjectSpaceProvider objectSpaceProvider =
           new XPObjectSpaceProvider(new MemoryDataStoreProvider());
            application = new TestApplication();
            var testModule = new TestModule();

            // Replace the line causing the error with the correct initialization method
            FileMethodPerformanceTracker.InitializeInstance(null);
            ControllerMethodPatch.Init(FileMethodPerformanceTracker.Instance);
          

            XafPerformanceTracker xafPerformanceTracker = new XafPerformanceTracker();
            xafPerformanceTracker.Init("TestApplication");


            application.Modules.Add(testModule);




            application.Setup("TestApplication", objectSpaceProvider);
            IObjectSpace objectSpace = objectSpaceProvider.CreateObjectSpace();
            customer = objectSpace.CreateObject<XafCustomer>();
            controller = new InvoiceController();
            detailView = application.CreateDetailView(objectSpace, customer);
            controller.SetView(detailView);
        }

        [Test]
        public void MethodToLog()
        {
            var CurrentObject = controller.View.CurrentObject;

            var appearanceController= application.CreateController<AppearanceController>();



            Assert.IsNotNull(CurrentObject);
        }
  
    }
}