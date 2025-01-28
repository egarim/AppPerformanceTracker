using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXafAndXpo.Infrastructure
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public class InvoiceController : ViewController
    {



        public SimpleAction MyAction
        {
            get { return this.SaSetActive; }
            private set
            {
                this.SaSetActive = value;
            }
        }
        private DevExpress.ExpressApp.Actions.SimpleAction saSetActive;
        private DevExpress.ExpressApp.Actions.SimpleAction SaModifySave;
        private DevExpress.ExpressApp.Actions.ParametrizedAction parametrizedAction1;
        private DevExpress.ExpressApp.Actions.SingleChoiceAction singleChoiceAction1;
        private DevExpress.ExpressApp.Actions.SingleChoiceAction singleChoiceActionFromCode;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction popup;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction popupWindowShowAction1;
        private DevExpress.ExpressApp.Actions.SimpleAction PostInvoice;
        public InvoiceController()
        {

   
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem1 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem2 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem3 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem4 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem5 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem6 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem7 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem8 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem9 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem10 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem11 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.SaSetActive = new DevExpress.ExpressApp.Actions.SimpleAction();
            this.SaModifySave = new DevExpress.ExpressApp.Actions.SimpleAction();
            this.parametrizedAction1 = new DevExpress.ExpressApp.Actions.ParametrizedAction();
            this.singleChoiceAction1 = new DevExpress.ExpressApp.Actions.SingleChoiceAction();
            this.SingleChoiceActionFromCode = new DevExpress.ExpressApp.Actions.SingleChoiceAction();
            this.popup = new DevExpress.ExpressApp.Actions.PopupWindowShowAction();
            this.popupWindowShowAction1 = new DevExpress.ExpressApp.Actions.PopupWindowShowAction();
            this.PostInvoice = new DevExpress.ExpressApp.Actions.SimpleAction();
            // 
            // saSetActive
            // 
            this.SaSetActive.Caption = "Set Active";
            this.SaSetActive.ConfirmationMessage = null;
            this.SaSetActive.Id = "InvoiceControllerSaSetActive";
            this.SaSetActive.ImageName = "database-icon";
            this.SaSetActive.ToolTip = null;
            this.SaSetActive.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saSetActive_Execute);
            // 
            // SaModifySave
            // 
            this.SaModifySave.Caption = "Lets Change the caption";
            this.SaModifySave.Category = "Tools";
            this.SaModifySave.ConfirmationMessage = "Are you sure ?";
            this.SaModifySave.Id = "ThisIsMyId";
            this.SaModifySave.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Caption;
            this.SaModifySave.ToolTip = null;
            this.SaModifySave.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.SaModifySave_Execute);
            // 
            // parametrizedAction1
            // 
            this.parametrizedAction1.Caption = "Select Date";
            this.parametrizedAction1.ConfirmationMessage = null;
            this.parametrizedAction1.Id = "parametrizedAction1";
            this.parametrizedAction1.NullValuePrompt = null;
            this.parametrizedAction1.ShortCaption = null;
            this.parametrizedAction1.ToolTip = null;
            this.parametrizedAction1.ValueType = typeof(System.DateTime);
            this.parametrizedAction1.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.parametrizedAction1_Execute);
            // 
            // singleChoiceAction1
            // 
            this.singleChoiceAction1.Caption = "Select your department";
            this.singleChoiceAction1.ConfirmationMessage = null;
            this.singleChoiceAction1.Id = "389bfca2-4b4d-4546-89f5-aee9c5d2a8ff";
            choiceActionItem1.Caption = "Entry 1";
            choiceActionItem1.Id = "Entry 1";
            choiceActionItem1.ImageName = null;
            choiceActionItem2.Caption = "Entry 1";
            choiceActionItem2.Id = "Entry 1";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            choiceActionItem3.Caption = "Entry 2";
            choiceActionItem3.Id = "Entry 2";
            choiceActionItem3.ImageName = null;
            choiceActionItem3.Shortcut = null;
            choiceActionItem3.ToolTip = null;
            choiceActionItem4.Caption = "Entry 3";
            choiceActionItem4.Id = "Entry 3";
            choiceActionItem4.ImageName = null;
            choiceActionItem4.Shortcut = null;
            choiceActionItem4.ToolTip = null;
            choiceActionItem5.Caption = "Entry 4";
            choiceActionItem5.Id = "Entry 4";
            choiceActionItem5.ImageName = null;
            choiceActionItem5.Shortcut = null;
            choiceActionItem5.ToolTip = null;
            choiceActionItem6.Caption = "Entry 5";
            choiceActionItem6.Id = "Entry 5";
            choiceActionItem6.ImageName = null;
            choiceActionItem6.Shortcut = null;
            choiceActionItem6.ToolTip = null;
            choiceActionItem1.Items.Add(choiceActionItem2);
            choiceActionItem1.Items.Add(choiceActionItem3);
            choiceActionItem1.Items.Add(choiceActionItem4);
            choiceActionItem1.Items.Add(choiceActionItem5);
            choiceActionItem1.Items.Add(choiceActionItem6);
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem7.Caption = "Entry 2";
            choiceActionItem7.Id = "Entry 2";
            choiceActionItem7.ImageName = null;
            choiceActionItem8.Caption = "Entry 1";
            choiceActionItem8.Id = "Entry 1";
            choiceActionItem8.ImageName = null;
            choiceActionItem8.Shortcut = null;
            choiceActionItem8.ToolTip = null;
            choiceActionItem7.Items.Add(choiceActionItem8);
            choiceActionItem7.Shortcut = null;
            choiceActionItem7.ToolTip = null;
            choiceActionItem9.Caption = "Entry 3";
            choiceActionItem9.Id = "Entry 3";
            choiceActionItem9.ImageName = null;
            choiceActionItem10.Caption = "Entry 1";
            choiceActionItem10.Id = "Entry 1";
            choiceActionItem10.ImageName = null;
            choiceActionItem10.Shortcut = null;
            choiceActionItem10.ToolTip = null;
            choiceActionItem11.Caption = "Entry 2";
            choiceActionItem11.Id = "Entry 2";
            choiceActionItem11.ImageName = null;
            choiceActionItem11.Shortcut = null;
            choiceActionItem11.ToolTip = null;
            choiceActionItem9.Items.Add(choiceActionItem10);
            choiceActionItem9.Items.Add(choiceActionItem11);
            choiceActionItem9.Shortcut = null;
            choiceActionItem9.ToolTip = null;
            this.singleChoiceAction1.Items.Add(choiceActionItem1);
            this.singleChoiceAction1.Items.Add(choiceActionItem7);
            this.singleChoiceAction1.Items.Add(choiceActionItem9);
            this.singleChoiceAction1.ToolTip = null;
            this.singleChoiceAction1.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.singleChoiceAction1_Execute);
            // 
            // singleChoiceActionFromCode
            // 
            this.SingleChoiceActionFromCode.Caption = "Dynamic Choices";
            this.SingleChoiceActionFromCode.ConfirmationMessage = null;
            this.SingleChoiceActionFromCode.Id = "f258be60-6c28-4ea3-b892-eb8dd59b5e30";
            this.SingleChoiceActionFromCode.ToolTip = null;
            this.SingleChoiceActionFromCode.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.singleChoiceActionFromCode_Execute);
            // 
            // popup
            // 
            this.popup.AcceptButtonCaption = null;
            this.popup.CancelButtonCaption = null;
            this.popup.Caption = "Show customer Detail";
            this.popup.ConfirmationMessage = null;
            this.popup.Id = "55b53d66-5681-43fe-bf56-ca983c996a16";
            this.popup.ToolTip = null;
            this.popup.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.popup_CustomizePopupWindowParams);
            this.popup.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.popup_Execute);
            // 
            // popupWindowShowAction1
            // 
            this.popupWindowShowAction1.AcceptButtonCaption = null;
            this.popupWindowShowAction1.CancelButtonCaption = null;
            this.popupWindowShowAction1.Caption = "Show List";
            this.popupWindowShowAction1.ConfirmationMessage = null;
            this.popupWindowShowAction1.Id = "ff3999d3-2a6a-4a77-ae27-5a5b39d68647";
            this.popupWindowShowAction1.ToolTip = null;
            this.popupWindowShowAction1.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.popupWindowShowAction1_CustomizePopupWindowParams);
            // 
            // PostInvoice
            // 
            this.PostInvoice.Caption = "Post Invoice";
            this.PostInvoice.ConfirmationMessage = null;
            this.PostInvoice.Id = "00a40cde-6d52-4c61-8364-fe8a92dca626";
            this.PostInvoice.TargetObjectsCriteria = "IsPosted=false";
            this.PostInvoice.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.PostInvoice.ToolTip = null;
            this.PostInvoice.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.PostInvoice_Execute);
            // 
            // InvoiceController
            // 
            this.Actions.Add(this.SaSetActive);
            this.Actions.Add(this.SaModifySave);
            this.Actions.Add(this.parametrizedAction1);
            this.Actions.Add(this.singleChoiceAction1);
            this.Actions.Add(this.SingleChoiceActionFromCode);
            this.Actions.Add(this.popup);
            this.Actions.Add(this.popupWindowShowAction1);
            this.Actions.Add(this.PostInvoice);
            this.TargetObjectType = typeof(XafInvoice);
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        public SimpleAction SaSetActive { get => saSetActive; set => saSetActive = value; }
        public SingleChoiceAction SingleChoiceActionFromCode { get => singleChoiceActionFromCode; set => singleChoiceActionFromCode = value; }
        protected override void OnActivated()
        {
            base.OnActivated();
            this.SingleChoiceActionFromCode.Items.Add(new ChoiceActionItem("Option 1", this.ObjectSpace.FindObject<XafCustomer>(null)));
            this.SingleChoiceActionFromCode.Items.Add(new ChoiceActionItem("Option 2", new DateTime(2020, 1, 1)));
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
            this.SingleChoiceActionFromCode.Items.Clear();
        }

        private void saSetActive_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var Instance = e.CurrentObject as XafCustomer;
            Instance.Active = true;
            //BoLogic.CreateInvoice()

            //Instance.Invoices

            //var invoices=this.ObjectSpace.CreateCollection(typeof(Invoice));

            //here is where you should put complex code
        }

        private void SaModifySave_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            //HACK you can locate actions and controller on this document https://docs.devexpress.com/eXpressAppFramework/113141/concepts/controllers-and-actions/built-in-controllers-and-actions/built-in-controllers-and-actions-in-the-system-module#modificationscontroller
            var modificationController = this.Frame.GetController<ModificationsController>();
            modificationController.SaveAction.Caption = "Guardar";
        }

        private void parametrizedAction1_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            var StringValue = e.ParameterCurrentValue as string;
        }

        private void singleChoiceAction1_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var SelectedChoice = e.SelectedChoiceActionItem;
            var Parent = SelectedChoice.ParentItem;
        }

        private void singleChoiceActionFromCode_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var Data = e.SelectedChoiceActionItem.Data;
        }

        DetailView customerView;
        private void popup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var CurrentInvoice = this.View.CurrentObject as XafInvoice;
            var CustomerOs = this.Application.CreateObjectSpace();
            customerView = this.Application.CreateDetailView(CustomerOs, CustomerOs.GetObject(CurrentInvoice.Customer));
            e.View = customerView;
        }

        private void popup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var Instance = customerView.CurrentObject as XafCustomer;
            //TODO do whatever i want
        }

        private void popupWindowShowAction1_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {


            e.View = this.Application.CreateListView(typeof(XafCustomer), true);
        }
        void NEwActivated(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PostInvoice_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var CurrentInvoice = this.View.CurrentObject as XafInvoice;
            CurrentInvoice.IsPosted = true;
            if (this.View.ObjectSpace.IsModified)
                this.View.ObjectSpace.CommitChanges();
        }
    }
}
