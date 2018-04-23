using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Printing;
// ...

namespace PreviewClickSample {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        private void ReportPreviewModel_PreviewMouseMove(object sender, PreviewClickEventArgs e) {
            if (e.ElementTag != null && !e.ElementTag.Equals(string.Empty)) {
                e.Element.Cursor = Cursors.Hand;
            }
        }

        private void ReportPreviewModel_PreviewClick(object sender, PreviewClickEventArgs e) {
            if (e.ElementTag != string.Empty) {
                ReportPreviewModel model = (ReportPreviewModel)sender;
                List<int> expandedValues = (List<int>)model.Parameters["expandedValuesParameter"].Value;
                int index;
                if (!int.TryParse(e.ElementTag, out index))
                    return;
                if (expandedValues.Contains(index)) {
                    expandedValues.Remove(index);
                }
                else {
                    expandedValues.Add(index);
                }
                model.CreateDocument();
            }
        }
    }
}
