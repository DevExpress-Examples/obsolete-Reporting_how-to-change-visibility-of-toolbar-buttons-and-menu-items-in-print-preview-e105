Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
' ...

Namespace WindowsFormsApplication1
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private report As XtraReport1

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            report = New XtraReport1()
            documentViewer1.PrintingSystem = report.PrintingSystem
            ' Get the printing system of the document viewer control.
            Dim ps As PrintingSystemBase = documentViewer1.PrintingSystem

            ' Hide the Watermark toolbar button, and also the Watermark menu item.
            If ps.GetCommandVisibility(PrintingSystemCommand.Watermark) <> CommandVisibility.None Then
                ps.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None)
            End If

            ' Show the Document Map toolbar button and menu item.
            ps.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.All)

            ' Make the "Export to Csv" and "Export to Txt" commands visible.
            ps.SetCommandVisibility(New PrintingSystemCommand() { PrintingSystemCommand.ExportCsv, PrintingSystemCommand.ExportTxt }, CommandVisibility.All)

            ' Create the document.
            report.CreateDocument()
        End Sub
    End Class
End Namespace
