using System;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
// ...

namespace CommVisibility {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a report object.
            XtraReport1 report = new XtraReport1();

            // Get the report's printing system.
            PrintingSystem ps = report.PrintingSystem;

            // Hide the Watermark toolbar button, and also the Watermark menu item.
            if(ps.GetCommandVisibility(PrintingSystemCommand.Watermark) != CommandVisibility.None) {
                ps.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
            }

            // Show the Document Map toolbar button and menu item.
            ps.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.All);

            // Make the "Export to Csv" and "Export to Txt" commands visible.
            ps.SetCommandVisibility(new PrintingSystemCommand[] { PrintingSystemCommand.ExportCsv, PrintingSystemCommand.ExportTxt }, CommandVisibility.All);

            // Show the report's preview.
            report.CreateDocument();
            ps.PreviewFormEx.Show();
        }

    }
}