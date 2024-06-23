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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.PathGameDirectory = Settings.Default.PathGameDirectory;
            txtPathGameDirectory.Text = Settings.Default.PathGameDirectory;
            Program.PathPluginsTxtDirectory = Settings.Default.PathProfilesDirectory;
            txtPathProfilesDirectory.Text = Settings.Default.PathProfilesDirectory;
            Program.PathModsDirectory = Settings.Default.PathModsDirectory;
            txtPathModsDirectory.Text = Settings.Default.PathModsDirectory;
            checkBoxAutoProfile.Checked = Settings.Default.CheckBoxAutoProfile;
            Program.ChoosenGame = Settings.Default.ChoosenGame;
            comboBoxChoosenGame.Text = Settings.Default.ChoosenGame;
            Program.ModOrganizer = Settings.Default.ModOrganizer;
            comboBoxModOrganizer.Text = Settings.Default.ModOrganizer;
            Program.GameFlagsByte = Settings.Default.GameFlagsByte;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)

        {
            Settings.Default.PathGameDirectory = txtPathGameDirectory.Text;
            Settings.Default.PathProfilesDirectory = txtPathProfilesDirectory.Text;
            Settings.Default.PathModsDirectory = txtPathModsDirectory.Text;
            Settings.Default.ChoosenGame = comboBoxChoosenGame.Text;
            Settings.Default.GameFlagsByte = Program.GameFlagsByte;
            Settings.Default.ModOrganizer = comboBoxModOrganizer.Text;
            Settings.Default.CheckBoxAutoProfile = checkBoxAutoProfile.Checked;
            Settings.Default.Save();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //Timer timer = new Timer();
            if (txtPathGameDirectory.Text == "" || txtPathModsDirectory.Text == "" || txtPathProfilesDirectory.Text == "")
            {
                lblToastMessage.Text = "Fill data!";
                lblToastMessage.Visible = true;
                return;
            }
            if (checkBoxAutoProfile.Checked)
            {
                Utility.FindLatestModifiedProfileDirectory();
                txtPathProfilesDirectory.Text = Program.PathPluginsTxtDirectory;
            }
            lblToastMessage.Text = "OK!";
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
                txtPathModsDirectory.Text = selectedPath;
            }
        }

        private void btnProfileSelectFolder_Click(object sender, EventArgs e)
        {
            if (profilesFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = profilesFolderBrowserDialog.SelectedPath;

                // Wyœwietl œcie¿kê w TextBox
                txtPathProfilesDirectory.Text = selectedPath;
            }
        }
        private void btnGameSelectFolder_Click(object sender, EventArgs e)
        {
            if (gameFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = gameFolderBrowserDialog.SelectedPath;

                // Wyœwietl œcie¿kê w TextBox
                txtPathGameDirectory.Text = selectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void autoProfilecheckBox_CheckedChanged(object sender, EventArgs e)
        {

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
            txtPathProfilesDirectory.Text = Program.PathPluginsTxtDirectory;
        }

        private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxChoosenGame.Text)
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

        private void txtGameFolderPath_TextChanged(object sender, EventArgs e)
        {
            Program.PathGameDirectory = txtPathGameDirectory.Text;
        }
    }
}
