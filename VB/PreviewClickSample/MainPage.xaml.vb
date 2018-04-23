Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Controls
Imports System.Windows.Input
Imports DevExpress.Xpf.Printing
' ...

Namespace PreviewClickSample
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ReportPreviewModel_PreviewMouseMove(ByVal sender As Object, ByVal e As PreviewClickEventArgs)
			If e.ElementTag IsNot Nothing AndAlso (Not e.ElementTag.Equals(String.Empty)) Then
				e.Control.Cursor = Cursors.Hand
			End If
		End Sub

		Private Sub ReportPreviewModel_PreviewClick(ByVal sender As Object, ByVal e As PreviewClickEventArgs)
			If e.ElementTag <> String.Empty Then
				Dim model As ReportPreviewModel = CType(sender, ReportPreviewModel)
				Dim expandedValues As List(Of Integer) = CType(model.Parameters("expandedValuesParameter").Value, List(Of Integer))
				Dim index As Integer
				If (Not Integer.TryParse(e.ElementTag, index)) Then
					Return
				End If
				If expandedValues.Contains(index) Then
					expandedValues.Remove(index)
				Else
					expandedValues.Add(index)
				End If
				model.CreateDocument()
			End If
		End Sub
	End Class
End Namespace
