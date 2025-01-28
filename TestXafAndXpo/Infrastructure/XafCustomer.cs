using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace TestXafAndXpo.Infrastructure
{
    [DefaultClassOptions]

    public class XafCustomer : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public XafCustomer(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        decimal maxCredit;
        bool active;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        public bool Active
        {
            get => active;
            set => SetPropertyValue(nameof(Active), ref active, value);
        }


        public decimal MaxCredit
        {
            get => maxCredit;
            set => SetPropertyValue(nameof(MaxCredit), ref maxCredit, value);
        }


        [Association("Customer-Invoices")]
        public XPCollection<XafInvoice> Invoices
        {
            get
            {
                return GetCollection<XafInvoice>(nameof(Invoices));
            }
        }

    }
}
