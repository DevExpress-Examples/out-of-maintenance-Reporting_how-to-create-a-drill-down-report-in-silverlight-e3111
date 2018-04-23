using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
// ...

namespace PreviewClickSample.Web {
    public partial class XtraReport1 : XtraReport {
        public XtraReport1() {
            InitializeComponent();
            expandedValuesParameter.Type = typeof(List<int>);
            expandedValuesParameter.Value = new List<int>();
        }

        const string sShowDetail = "Show Detail";
        const string sHideDetail = "Hide Detail";

        List<int> ExpandedValues {
            get {
                return (List<int>)expandedValuesParameter.Value;
            }
        }

        bool ShouldShowDetail(int catID) {
            return ExpandedValues.Contains(catID);
        }

        private void lbShowHide_BeforePrint(object sender, PrintEventArgs e) {
            XRLabel label = (XRLabel)sender;
            if (ShouldShowDetail((int)label.Tag)) {
                label.Text = sHideDetail;
            }
            else {
                label.Text = sShowDetail;
            }
        }

        private void DetailReport_BeforePrint(object sender, PrintEventArgs e) {
            e.Cancel = !ShouldShowDetail((int)GetCurrentColumnValue("CategoryID"));
        }
    }
}
