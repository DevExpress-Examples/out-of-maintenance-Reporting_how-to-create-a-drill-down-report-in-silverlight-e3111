using System.Collections.Generic;
using System.Windows.Input;
using DevExpress.Xpf.Printing;
// ...

namespace PreviewClickSample {
    public class MainPageViewModel {
        public ReportPreviewModel PreviewModel { get; private set; }

        public MainPageViewModel() {
            PreviewModel = new ReportPreviewModel("../ReportService.svc") {
                ReportName = "PreviewClickSample.Web.XtraReport1, PreviewClickSample.Web",
            };
            PreviewModel.PreviewMouseMove += PreviewModel_PreviewMouseMove;
            PreviewModel.PreviewClick += PreviewModel_PreviewClick;
        }
        
        void PreviewModel_PreviewMouseMove(object sender, PreviewClickEventArgs e) {
            if(!string.IsNullOrEmpty(e.ElementTag)) {
                e.Element.Cursor = Cursors.Hand;
            }
        }

        void PreviewModel_PreviewClick(object sender, PreviewClickEventArgs e) {
            int index;
            if(!int.TryParse(e.ElementTag, out index)) {
                return;
            }
            var expandedValues = (List<int>)PreviewModel.Parameters["expandedValuesParameter"].Value;
            if(expandedValues.Contains(index)) {
                expandedValues.Remove(index);
            } else {
                expandedValues.Add(index);
            }
            PreviewModel.CreateDocument();
        }
    }
}
