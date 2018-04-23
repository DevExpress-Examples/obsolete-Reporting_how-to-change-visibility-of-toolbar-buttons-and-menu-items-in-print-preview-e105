using System;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
// ...

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        XtraReport1 report;

        private void Form1_Load(object sender, EventArgs e) {
            report = new XtraReport1();
            documentViewer1.PrintingSystem = report.PrintingSystem;
            // Get the printing system of the document viewer control.
            PrintingSystemBase ps = documentViewer1.PrintingSystem;

            // Hide the Watermark toolbar button, and also the Watermark menu item.
            if(ps.GetCommandVisibility(PrintingSystemCommand.Watermark) != CommandVisibility.None) {
                ps.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
            }

            // Show the Document Map toolbar button and menu item.
            ps.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.All);

            // Make the "Export to Csv" and "Export to Txt" commands visible.
            ps.SetCommandVisibility(new PrintingSystemCommand[] { PrintingSystemCommand.ExportCsv, PrintingSystemCommand.ExportTxt }, CommandVisibility.All);

            // Create the document.
            report.CreateDocument();
        }
    }
}
