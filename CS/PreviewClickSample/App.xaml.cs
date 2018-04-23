using System;
using System.Collections.Generic;
using System.Windows;
using DevExpress.Xpf.Printing.Service;

namespace PreviewClickSample {
    public partial class App : Application {

        public App() {
            this.Startup += this.Application_Startup;
            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e) {
            PrintingServiceKnownTypeContainer.RegisterKnownType(typeof(List<int>));
            if(string.Compare("file", Host.Source.Scheme, StringComparison.InvariantCultureIgnoreCase) == 0) {
                const string message = "Please make sure that the Web project of this solution is the starting project.";
                MessageBox.Show(message);
                return;
            }
            this.RootVisual = new MainPage();
        }
    }
}
