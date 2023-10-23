using DevExpress.Charts.Model;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XafNewObjectLookup.Module.BusinessObjects;

namespace XafNewObjectLookup.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class NewObjectViewController : WinNewObjectViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public NewObjectViewController()
        {
            InitializeComponent();
           

            // Target required Views (via the TargetXXX properties) and create their Actions.
        }


        protected override void OnObjectCreated(object newObject, IObjectSpace objectSpace)
        {
            base.OnObjectCreated(newObject, objectSpace);
            if(newObject is Entity)
            {
                if (this.View.Id == "Entity_LookupListView_Customers")
                {
                    ((Entity)newObject).EntityType = EntityType.Customer;
                    return;
                }
                if (this.View.Id == "Entity_LookupListView_Vendor")
                {
                    ((Entity)newObject).EntityType = EntityType.Vendor;
                    return;
                }
            }
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            if(this.View.Id== "Entity_LookupListView_Customers")
            {
                var EntityOption=this.NewObjectAction.Items.FirstOrDefault(i => i.Caption == "Entity");
                var VendorOption = this.NewObjectAction.Items.FirstOrDefault(i => i.Caption == "Vendor");
                this.NewObjectAction.Items.Remove(EntityOption);
                this.NewObjectAction.Items.Remove(VendorOption);
               
                
            }
            if (this.View.Id == "Entity_LookupListView_Vendor")
            {
                var EntityOption = this.NewObjectAction.Items.FirstOrDefault(i => i.Caption == "Entity");
                var CustomerOption = this.NewObjectAction.Items.FirstOrDefault(i => i.Caption == "Customer");
                this.NewObjectAction.Items.Remove(EntityOption);
                this.NewObjectAction.Items.Remove(CustomerOption);


            }
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
           
        }
    }
}
