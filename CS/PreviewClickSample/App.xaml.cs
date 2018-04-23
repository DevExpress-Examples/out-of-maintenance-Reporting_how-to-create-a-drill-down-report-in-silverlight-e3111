using System.Collections.Generic;
using System.Windows;
using DevExpress.Xpf.Printing;
// ...

namespace PreviewClickSample {
    public partial class App : Application {

        public App() {
            this.Startup += this.Application_Startup;
            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e) {
            ServiceKnownTypeProvider.Register(typeof(List<int>));

            this.RootVisual = new MainPage();
        }
    }
}
