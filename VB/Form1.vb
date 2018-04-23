Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
' ...

Namespace CommVisibility
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a report instance, assigned to a Print Tool.
			Dim pt As New ReportPrintTool(New XtraReport1())

			' Get the Print Tool's printing system.
			Dim ps As PrintingSystemBase = pt.PrintingSystem

			' Hide the Watermark toolbar button, and also the Watermark menu item.
			If ps.GetCommandVisibility(PrintingSystemCommand.Watermark) <> CommandVisibility.None Then
				ps.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None)
			End If

			' Show the Document Map toolbar button and menu item.
			ps.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.All)

			' Make the "Export to Csv" and "Export to Txt" commands visible.
			ps.SetCommandVisibility(New PrintingSystemCommand() { PrintingSystemCommand.ExportCsv, PrintingSystemCommand.ExportTxt }, CommandVisibility.All)

			' Show the report's preview.
			pt.ShowPreview()
		End Sub

	End Class
End Namespace