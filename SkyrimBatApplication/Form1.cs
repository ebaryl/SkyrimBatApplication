using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SkyrimBatManager;
using System.Diagnostics.Eventing.Reader;

namespace SkyrimBatApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (autoProfilescheckBox.Checked)
            {
                Utility.FindProfileDirectory();
                txtProfilesFolderPath.Text = Program.FoundPluginsTxtDirectoryPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtProfilesFolderPath.Text = Settings.Default.profilesFolderPath;
            txtModsFolderPath.Text = Settings.Default.modsFolderPath;
            autoProfilescheckBox.Checked = Settings.Default.autoProfileCheckBox;
            comboBoxGame.Text = Settings.Default.ChoosenGame;
            Program.ChoosenGame = Settings.Default.ChoosenGame;
            comboBoxModOrganizer.Text = Settings.Default.ModOrganizer;
            Program.ModOrganizer = Settings.Default.ModOrganizer;
            Program.GameFlagsByte = Settings.Default.GameFlagsByte;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save settings before closing
            Settings.Default.profilesFolderPath = txtProfilesFolderPath.Text;
            Settings.Default.modsFolderPath = txtModsFolderPath.Text;
            Settings.Default.autoProfileCheckBox = autoProfilescheckBox.Checked;
            Settings.Default.ChoosenGame = comboBoxGame.Text;
            Settings.Default.ModOrganizer = comboBoxModOrganizer.Text;
            Settings.Default.GameFlagsByte = Program.GameFlagsByte;
            Settings.Default.Save();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //Timer timer = new Timer();
            lblToastMessage.Visible = true;
            /*
            Utility.ReadFromPlugin();
            Utility.ClassifyPlugins(Utility.plugins, Program.foundDataDirectoryPath);
            Utility.SortPluginsAfterClassification(Utility.plugins);
            MyRegex.ReadAllTxtFiles();
            */
        }

        private void lblToastMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnModsSelectFolder_Click(object sender, EventArgs e)
        {
            if (modsFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = modsFolderBrowserDialog.SelectedPath;

                // Wyœwietl œcie¿kê w TextBox
                txtModsFolderPath.Text = selectedPath;
            }
        }

        private void btnProfileSelectFolder_Click(object sender, EventArgs e)
        {
            if (profilesFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = profilesFolderBrowserDialog.SelectedPath;

                // Wyœwietl œcie¿kê w TextBox
                txtProfilesFolderPath.Text = selectedPath;
            }
        }
        private void btnGameSelectFolder_Click(object sender, EventArgs e)
        {
            if (gameFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = gameFolderBrowserDialog.SelectedPath;

                // Wyœwietl œcie¿kê w TextBox
                txtGameFolderPath.Text = selectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void autoProfilecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Utility.FindLatestModifiedProfileDirectory();
            txtProfilesFolderPath.Text = Program.FoundPluginsTxtDirectoryPath;
        }

        private void txtProfileFolderPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProfileFolder_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxModOrganizer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxModOrganizer.Text)
            {
                case "Mod Organizer":
                    Program.ModOrganizer = "Mod Organizer";
                    break;
                case "Vortex":
                    Program.ModOrganizer = "Vortex";
                    break;
            }
            Utility.FindProfileDirectory();
            txtProfilesFolderPath.Text = Program.FoundPluginsTxtDirectoryPath;
        }

        private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxGame.Text)
            {
                case "Skyrim":
                    Program.ChoosenGame = "skyrim";
                    Program.GameFlagsByte = 0x02;
                    break;
                case "Skyrim SE":
                    Program.ChoosenGame = "skyrimse";
                    Program.GameFlagsByte = 0x02;
                    break;
                case "Fallout":
                    Program.ChoosenGame = "fallout";
                    Program.GameFlagsByte = 0x04;
                    break;
            }
        }


    }
}
