' Developer Express Code Central Example:
' How to create a drill-down report
' 
' This example demonstrates how to create a drill-down report. In this example, a
' master-detail report is created, in which the detail section for each category
' can be expanded or collapsed within the same preview window by clicking the
' appropriate link.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E769


Imports Microsoft.VisualBasic
Imports System
Namespace PreviewClickSample.Web
	Partial Public Class XtraReport1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
			Me.xrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
			Me.lbShowHide = New DevExpress.XtraReports.UI.XRLabel()
			Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
			Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
			Me.nwindDataSet1 = New PreviewClickSample.Web.nwindDataSet()
			Me.categoriesTableAdapter = New PreviewClickSample.Web.nwindDataSetTableAdapters.CategoriesTableAdapter()
			Me.DetailReport = New DevExpress.XtraReports.UI.DetailReportBand()
			Me.Detail1 = New DevExpress.XtraReports.UI.DetailBand()
			Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
			Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
			Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
			Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
			Me.xrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
			Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
			Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
			Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
			Me.xrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
			Me.xrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
			Me.xrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
			Me.productsTableAdapter = New PreviewClickSample.Web.nwindDataSetTableAdapters.ProductsTableAdapter()
			Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
			Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
			Me.expandedValuesParameter = New DevExpress.XtraReports.Parameters.Parameter()
			CType(Me.nwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' Detail
			' 
			Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() { Me.xrPictureBox1, Me.lbShowHide, Me.xrLabel2, Me.xrLabel1})
			Me.Detail.HeightF = 117F
			Me.Detail.Name = "Detail"
			Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F)
			Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			' 
			' xrPictureBox1
			' 
			Me.xrPictureBox1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() { New DevExpress.XtraReports.UI.XRBinding("Image", Nothing, "Categories.Picture")})
			Me.xrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(517F, 17F)
			Me.xrPictureBox1.Name = "xrPictureBox1"
			Me.xrPictureBox1.SizeF = New System.Drawing.SizeF(125F, 89F)
			Me.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
			' 
			' lbShowHide
			' 
			Me.lbShowHide.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() { New DevExpress.XtraReports.UI.XRBinding("Tag", Nothing, "Categories.CategoryID")})
			Me.lbShowHide.Font = New System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Underline)
			Me.lbShowHide.ForeColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(0))))), (CInt(Fix((CByte(128))))), (CInt(Fix((CByte(192))))))
			Me.lbShowHide.LocationFloat = New DevExpress.Utils.PointFloat(8F, 83F)
			Me.lbShowHide.Name = "lbShowHide"
			Me.lbShowHide.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.lbShowHide.SizeF = New System.Drawing.SizeF(100F, 25F)
			Me.lbShowHide.StylePriority.UseFont = False
			Me.lbShowHide.StylePriority.UseForeColor = False
			Me.lbShowHide.StylePriority.UseTextAlignment = False
			Me.lbShowHide.Text = "Show Detail"
			Me.lbShowHide.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
'			Me.lbShowHide.BeforePrint += New System.Drawing.Printing.PrintEventHandler(Me.lbShowHide_BeforePrint);
			' 
			' xrLabel2
			' 
			Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() { New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Categories.Description")})
			Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic)
			Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(8F, 50F)
			Me.xrLabel2.Name = "xrLabel2"
			Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrLabel2.SizeF = New System.Drawing.SizeF(492F, 25F)
			Me.xrLabel2.StylePriority.UseFont = False
			Me.xrLabel2.StylePriority.UseTextAlignment = False
			Me.xrLabel2.Text = "xrLabel2"
			Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			' 
			' xrLabel1
			' 
			Me.xrLabel1.BackColor = System.Drawing.Color.White
			Me.xrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() { New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Categories.CategoryName")})
			Me.xrLabel1.Font = New System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold)
			Me.xrLabel1.ForeColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(0))))), (CInt(Fix((CByte(128))))), (CInt(Fix((CByte(192))))))
			Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(8F, 17F)
			Me.xrLabel1.Name = "xrLabel1"
			Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrLabel1.SizeF = New System.Drawing.SizeF(492F, 25F)
			Me.xrLabel1.StylePriority.UseBackColor = False
			Me.xrLabel1.StylePriority.UseFont = False
			Me.xrLabel1.StylePriority.UseForeColor = False
			Me.xrLabel1.Text = "xrLabel1"
			' 
			' nwindDataSet1
			' 
			Me.nwindDataSet1.DataSetName = "nwindDataSet"
			Me.nwindDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			' 
			' categoriesTableAdapter
			' 
			Me.categoriesTableAdapter.ClearBeforeFill = True
			' 
			' DetailReport
			' 
			Me.DetailReport.Bands.AddRange(New DevExpress.XtraReports.UI.Band() { Me.Detail1, Me.GroupHeader1})
			Me.DetailReport.DataAdapter = Me.productsTableAdapter
			Me.DetailReport.DataMember = "Categories.CategoriesProducts"
			Me.DetailReport.DataSource = Me.nwindDataSet1
			Me.DetailReport.Level = 0
			Me.DetailReport.Name = "DetailReport"
'			Me.DetailReport.BeforePrint += New System.Drawing.Printing.PrintEventHandler(Me.DetailReport_BeforePrint);
			' 
			' Detail1
			' 
			Me.Detail1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() { Me.xrTable1})
			Me.Detail1.HeightF = 25F
			Me.Detail1.Name = "Detail1"
			' 
			' xrTable1
			' 
			Me.xrTable1.Borders = (CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide))
			Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(8F, 0F)
			Me.xrTable1.Name = "xrTable1"
			Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() { Me.xrTableRow1})
			Me.xrTable1.SizeF = New System.Drawing.SizeF(625F, 25F)
			Me.xrTable1.StylePriority.UseBorders = False
			' 
			' xrTableRow1
			' 
			Me.xrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() { Me.xrTableCell1, Me.xrTableCell2, Me.xrTableCell3})
			Me.xrTableRow1.Name = "xrTableRow1"
			Me.xrTableRow1.Weight = 1R
			' 
			' xrTableCell1
			' 
			Me.xrTableCell1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() { New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Categories.CategoriesProducts.ProductName")})
			Me.xrTableCell1.Name = "xrTableCell1"
			Me.xrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrTableCell1.StylePriority.UseTextAlignment = False
			Me.xrTableCell1.Text = "xrTableCell1"
			Me.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.xrTableCell1.Weight = 0.3296R
			' 
			' xrTableCell2
			' 
			Me.xrTableCell2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() { New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Categories.CategoriesProducts.QuantityPerUnit")})
			Me.xrTableCell2.Name = "xrTableCell2"
			Me.xrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrTableCell2.StylePriority.UseTextAlignment = False
			Me.xrTableCell2.Text = "xrTableCell2"
			Me.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.xrTableCell2.Weight = 0.3296R
			' 
			' xrTableCell3
			' 
			Me.xrTableCell3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() { New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Categories.CategoriesProducts.UnitPrice", "{0:$0.00}")})
			Me.xrTableCell3.Name = "xrTableCell3"
			Me.xrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrTableCell3.StylePriority.UseTextAlignment = False
			Me.xrTableCell3.Text = "xrTableCell3"
			Me.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
			Me.xrTableCell3.Weight = 0.3408R
			' 
			' GroupHeader1
			' 
			Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() { Me.xrTable2})
			Me.GroupHeader1.HeightF = 25F
			Me.GroupHeader1.Name = "GroupHeader1"
			' 
			' xrTable2
			' 
			Me.xrTable2.Borders = (CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) Or DevExpress.XtraPrinting.BorderSide.Right) Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide))
			Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(8F, 0F)
			Me.xrTable2.Name = "xrTable2"
			Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() { Me.xrTableRow2})
			Me.xrTable2.SizeF = New System.Drawing.SizeF(625F, 25F)
			Me.xrTable2.StylePriority.UseBorders = False
			' 
			' xrTableRow2
			' 
			Me.xrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() { Me.xrTableCell4, Me.xrTableCell5, Me.xrTableCell6})
			Me.xrTableRow2.Name = "xrTableRow2"
			Me.xrTableRow2.Weight = 1R
			' 
			' xrTableCell4
			' 
			Me.xrTableCell4.Font = New System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold)
			Me.xrTableCell4.Name = "xrTableCell4"
			Me.xrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrTableCell4.StylePriority.UseFont = False
			Me.xrTableCell4.StylePriority.UseTextAlignment = False
			Me.xrTableCell4.Text = "Product Name"
			Me.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
			Me.xrTableCell4.Weight = 0.3296R
			' 
			' xrTableCell5
			' 
			Me.xrTableCell5.Font = New System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold)
			Me.xrTableCell5.Name = "xrTableCell5"
			Me.xrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrTableCell5.StylePriority.UseFont = False
			Me.xrTableCell5.StylePriority.UseTextAlignment = False
			Me.xrTableCell5.Text = "Quantity Per Unit"
			Me.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
			Me.xrTableCell5.Weight = 0.3296R
			' 
			' xrTableCell6
			' 
			Me.xrTableCell6.Font = New System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold)
			Me.xrTableCell6.Name = "xrTableCell6"
			Me.xrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F)
			Me.xrTableCell6.StylePriority.UseFont = False
			Me.xrTableCell6.StylePriority.UseTextAlignment = False
			Me.xrTableCell6.Text = "Unit Price"
			Me.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
			Me.xrTableCell6.Weight = 0.3408R
			' 
			' productsTableAdapter
			' 
			Me.productsTableAdapter.ClearBeforeFill = True
			' 
			' topMarginBand1
			' 
			Me.topMarginBand1.Name = "topMarginBand1"
			' 
			' bottomMarginBand1
			' 
			Me.bottomMarginBand1.Name = "bottomMarginBand1"
			' 
			' expandedValuesParameter
			' 
			Me.expandedValuesParameter.Name = "expandedValuesParameter"
			Me.expandedValuesParameter.Value = ""
			Me.expandedValuesParameter.Visible = False
			' 
			' XtraReport1
			' 
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() { Me.Detail, Me.DetailReport, Me.topMarginBand1, Me.bottomMarginBand1})
			Me.DataAdapter = Me.categoriesTableAdapter
			Me.DataMember = "Categories"
			Me.DataSource = Me.nwindDataSet1
			Me.DrawGrid = False
			Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() { Me.expandedValuesParameter})
			Me.Version = "11.1"
			CType(Me.nwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private Detail As DevExpress.XtraReports.UI.DetailBand
		Private nwindDataSet1 As nwindDataSet
		Private categoriesTableAdapter As nwindDataSetTableAdapters.CategoriesTableAdapter
		Private WithEvents DetailReport As DevExpress.XtraReports.UI.DetailReportBand
		Private Detail1 As DevExpress.XtraReports.UI.DetailBand
		Private productsTableAdapter As nwindDataSetTableAdapters.ProductsTableAdapter
		Private xrLabel2 As DevExpress.XtraReports.UI.XRLabel
		Private xrLabel1 As DevExpress.XtraReports.UI.XRLabel
		Private xrTable1 As DevExpress.XtraReports.UI.XRTable
		Private xrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
		Private xrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
		Private xrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
		Private xrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
		Private GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
		Private xrTable2 As DevExpress.XtraReports.UI.XRTable
		Private xrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
		Private xrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
		Private xrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
		Private xrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
		Private WithEvents lbShowHide As DevExpress.XtraReports.UI.XRLabel
		Private xrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
		Private topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
		Private bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
		Private expandedValuesParameter As DevExpress.XtraReports.Parameters.Parameter
	End Class
End Namespace
