Imports DevExpress.Xpf.Printing
Imports System.Windows.Input
Imports System.Collections.Generic
' ...

Public Class MainPageViewModel
    Public Property PreviewModel As ReportPreviewModel

    Public Sub New()
        PreviewModel = New ReportPreviewModel("../ReportService.svc") With {
            .ReportName = "PreviewClickSample.Web.XtraReport1, PreviewClickSample.Web"
        }

        AddHandler PreviewModel.PreviewMouseMove, AddressOf PreviewModel_PreviewMouseMove
        AddHandler PreviewModel.PreviewClick, AddressOf PreviewModel_PreviewClick
    End Sub

    Sub PreviewModel_PreviewMouseMove(ByVal sender As Object, ByVal e As PreviewClickEventArgs)
        If Not String.IsNullOrEmpty(e.ElementTag) Then
            e.Element.Cursor = Cursors.Hand
        End If
    End Sub

    Sub PreviewModel_PreviewClick(ByVal sender As Object, ByVal e As PreviewClickEventArgs)
        Dim index As Integer
        If Not Integer.TryParse(e.ElementTag, index) Then
            Return
        End If
        Dim model As ReportPreviewModel = CType(sender, ReportPreviewModel)
        Dim expandedValues As List(Of Integer) = CType(model.Parameters("expandedValuesParameter").Value, List(Of Integer))
        If expandedValues.Contains(index) Then
            expandedValues.Remove(index)
        Else
            expandedValues.Add(index)
        End If
        model.CreateDocument()
    End Sub
End Class
