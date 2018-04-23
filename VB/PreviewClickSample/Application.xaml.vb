Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports DevExpress.Xpf.Printing.ServiceModel

Namespace PreviewClickSample
	Partial Public Class App
		Inherits Application

		Public Sub New()
			AddHandler Me.Startup, AddressOf Application_Startup
			InitializeComponent()
		End Sub

		Private Sub Application_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			PrintingServiceKnownTypeContainer.RegisterKnownType(GetType(List(Of Integer)))
			If String.Compare("file", Host.Source.Scheme, StringComparison.InvariantCultureIgnoreCase) = 0 Then
				Const message As String = "Please make sure that the Web project of this solution is the starting project."
				MessageBox.Show(message)
				Return
			End If
			Me.RootVisual = New MainPage()
		End Sub
	End Class
End Namespace
