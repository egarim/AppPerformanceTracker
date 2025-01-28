using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Xpo;
using TestXafAndXpo.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace TestXafAndXpo
{
    public class Tests
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




            application.Modules.Add(testModule);




            application.Setup("TestApplication", objectSpaceProvider);
            IObjectSpace objectSpace = objectSpaceProvider.CreateObjectSpace();
            customer = objectSpace.CreateObject<XafCustomer>();
            controller = new InvoiceController();
            detailView = application.CreateDetailView(objectSpace, customer);
            controller.SetView(detailView);
        }

        [Test]
        public void TestBusinessObject()
        {
            var CurrentObject = controller.View.CurrentObject;

            var apperanceController= application.CreateController<AppearanceController>();



            Assert.IsNotNull(CurrentObject);
        }
    }
}