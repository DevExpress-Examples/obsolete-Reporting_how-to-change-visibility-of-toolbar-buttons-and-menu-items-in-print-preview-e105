using System;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
// ...

namespace CommVisibility {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a report instance, assigned to a Print Tool.
            ReportPrintTool pt = new ReportPrintTool(new XtraReport1());

            // Get the Print Tool's printing system.
            PrintingSystemBase ps = pt.PrintingSystem;

            // Hide the Watermark toolbar button, and also the Watermark menu item.
            if (ps.GetCommandVisibility(PrintingSystemCommand.Watermark) != CommandVisibility.None) {
                ps.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
            }

            // Show the Document Map toolbar button and menu item.
            ps.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.All);

            // Make the "Export to Csv" and "Export to Txt" commands visible.
            ps.SetCommandVisibility(new PrintingSystemCommand[] 
    { PrintingSystemCommand.ExportCsv, PrintingSystemCommand.ExportTxt }, CommandVisibility.All);

            // Show the report's preview.
            pt.ShowPreview();
        }

    }
}