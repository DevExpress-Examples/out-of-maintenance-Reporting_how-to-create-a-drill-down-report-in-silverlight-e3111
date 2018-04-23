Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI
' ...

Namespace PreviewClickSample.Web
	Partial Public Class XtraReport1
		Inherits XtraReport
		Public Sub New()
			InitializeComponent()
			expandedValuesParameter.Type = GetType(List(Of Integer))
			expandedValuesParameter.Value = New List(Of Integer)()
		End Sub

		Private Const sShowDetail As String = "Show Detail"
		Private Const sHideDetail As String = "Hide Detail"

		Private ReadOnly Property ExpandedValues() As List(Of Integer)
			Get
				Return CType(expandedValuesParameter.Value, List(Of Integer))
			End Get
		End Property

		Private Function ShouldShowDetail(ByVal catID As Integer) As Boolean
			Return ExpandedValues.Contains(catID)
		End Function

		Private Sub lbShowHide_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles lbShowHide.BeforePrint
            Dim label As XRLabel = CType(sender, XRLabel)
            label.Text = If(ShouldShowDetail(CInt(label.Tag)), sHideDetail, sShowDetail)
		End Sub

		Private Sub DetailReport_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles DetailReport.BeforePrint
            e.Cancel = Not ShouldShowDetail(CInt(GetCurrentColumnValue("CategoryID")))
		End Sub
	End Class
End Namespace
