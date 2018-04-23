Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows.Input
Imports DevExpress.Xpf.Printing
' ...

Namespace PreviewClickSample
	Public Class MainPageViewModel
		Private privatePreviewModel As ReportServicePreviewModel
		Public Property PreviewModel() As ReportServicePreviewModel
			Get
				Return privatePreviewModel
			End Get
			Private Set(ByVal value As ReportServicePreviewModel)
				privatePreviewModel = value
			End Set
		End Property

		Public Sub New()
			PreviewModel = New ReportServicePreviewModel("../ReportService.svc") With {.ReportName = "PreviewClickSample.Web.XtraReport1, PreviewClickSample.Web"}
			AddHandler PreviewModel.PreviewMouseMove, AddressOf PreviewModel_PreviewMouseMove
			AddHandler PreviewModel.PreviewClick, AddressOf PreviewModel_PreviewClick
		End Sub

		Private Sub PreviewModel_PreviewMouseMove(ByVal sender As Object, ByVal e As PreviewClickEventArgs)
			If (Not String.IsNullOrEmpty(e.ElementTag)) Then
				e.Element.Cursor = Cursors.Hand
			End If
		End Sub

		Private Sub PreviewModel_PreviewClick(ByVal sender As Object, ByVal e As PreviewClickEventArgs)
			Dim index As Integer
			If (Not Integer.TryParse(e.ElementTag, index)) Then
				Return
			End If
			Dim expandedValues = CType(PreviewModel.Parameters("expandedValuesParameter").Value, List(Of Integer))
			If expandedValues.Contains(index) Then
				expandedValues.Remove(index)
			Else
				expandedValues.Add(index)
			End If
			PreviewModel.CreateDocument()
		End Sub
	End Class
End Namespace
