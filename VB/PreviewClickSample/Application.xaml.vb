Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports DevExpress.Xpf.Printing
' ...

Namespace PreviewClickSample
	Partial Public Class App
		Inherits Application

		Public Sub New()
			AddHandler Me.Startup, AddressOf Application_Startup
			InitializeComponent()
		End Sub

		Private Sub Application_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			ServiceKnownTypeProvider.Register(GetType(List(Of Integer)))

			Me.RootVisual = New MainPage()
		End Sub
	End Class
End Namespace
