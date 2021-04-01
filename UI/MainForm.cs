using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        private readonly Controller controller;
        public MainForm()
        {
            InitializeComponent();
            this.controller = new Controller();
        }

        private void Button_ReadCSV_Click(object sender, System.EventArgs e)
        {
            richTextBox_Output.Lines = controller.ReadCSV();
        }

        private void Button_OpenImportFolder_Click(object sender, System.EventArgs e)
        {
            controller.OpenImportFolder();
        }

        private void Button_About_Click(object sender, System.EventArgs e)
        {
            controller.About();
        }

        private void Button_OpenExportFolder_Click(object sender, System.EventArgs e)
        {
            controller.OpenExportFolder();
        }
    }
}
