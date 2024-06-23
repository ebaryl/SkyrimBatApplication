using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SkyrimBatManager;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SkyrimBatApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tooltipAutoProfile();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.PathGameDirectory = Settings.Default.PathGameDirectory;
            txtPathGameDirectory.Text = Settings.Default.PathGameDirectory;

            Program.PathModsDirectory = Settings.Default.PathModsDirectory;
            txtPathModsDirectory.Text = Settings.Default.PathModsDirectory;

            txtPathProfileDirectory.Text = Settings.Default.PathProfileDirectory;
            Program.PathProfileDirectory = Settings.Default.PathProfileDirectory;
            checkBoxAutoProfile.Checked = Settings.Default.CheckBoxAutoProfile;

            Program.PathPluginsTxtFile = Settings.Default.PathPluginsTxtFile;

            Program.ChoosenGame = Settings.Default.ChoosenGame;
            comboBoxChoosenGame.Text = Settings.Default.ChoosenGame;

            Program.ModOrganizer = Settings.Default.ModOrganizer;
            comboBoxModOrganizer.Text = Settings.Default.ModOrganizer;

            Program.GameFlagsByte = Settings.Default.GameFlagsByte;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)

        {
            Settings.Default.PathGameDirectory = txtPathGameDirectory.Text;
            Settings.Default.PathProfileDirectory = txtPathProfileDirectory.Text;
            Settings.Default.CheckBoxAutoProfile = checkBoxAutoProfile.Checked;
            Settings.Default.PathModsDirectory = txtPathModsDirectory.Text;
            Settings.Default.ChoosenGame = comboBoxChoosenGame.Text;
            Settings.Default.ModOrganizer = comboBoxModOrganizer.Text;
            Settings.Default.GameFlagsByte = Program.GameFlagsByte;
            Settings.Default.Save();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //Timer timer = new Timer();
            if (txtPathGameDirectory.Text == "" || txtPathModsDirectory.Text == "" || txtPathProfileDirectory.Text == "")
            {
                lblToastMessage.Text = "Fill data!";
                lblToastMessage.Visible = true;
                return;
            }
            if (checkBoxAutoProfile.Checked)
            {
                Utility.FindLatestModifiedProfileDirectory();
                txtPathProfileDirectory.Text = Program.PathPluginsTxtFile;
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

        private void btnGameSelectFolder_Click(object sender, EventArgs e)
        {
            if (gameFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = gameFolderBrowserDialog.SelectedPath;

                // Wyœwietl œcie¿kê w TextBox
                txtPathGameDirectory.Text = selectedPath;
                Program.PathGameDirectory = selectedPath;
                bool isSuccess = Utility.IdentifyGame();
                if (!isSuccess) { txtPathGameDirectory.Text = "!!! game folder should contain .exe !!!"; }
                lblChoosenGame.Text = Program.ChoosenGame;
                lblChoosenGame.Visible = true;
            }
        }

        private void btnModsSelectFolder_Click(object sender, EventArgs e)
        {
            if (modsFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = modsFolderBrowserDialog.SelectedPath;

                // Wyœwietl œcie¿kê w TextBox
                txtPathModsDirectory.Text = selectedPath;
                Program.PathModsDirectory = selectedPath;
            }
        }

        private void btnProfileSelectFolder_Click(object sender, EventArgs e)
        {
            if (profilesFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = profilesFolderBrowserDialog.SelectedPath;

                // Wyœwietl œcie¿kê w TextBox
                txtPathProfileDirectory.Text = selectedPath;
                Program.PathProfileDirectory = selectedPath;
                Program.PathPluginsTxtFile = Path.Combine(selectedPath, "plugins.txt");
                if (!File.Exists(Program.PathPluginsTxtFile))
                {
                    txtPathProfileDirectory.Text = "!!! profile folder should contain plugins.txt !!!";
                    return; 
                }
                Utility.RecognizeModOrganizer();
                lblModOrganizer.Visible = true;
                lblModOrganizer.Text = Program.ModOrganizer;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void checkBoxAutoProfile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPathProfileDirectory_TextChanged(object sender, EventArgs e)
        {
            Program.PathProfileDirectory = txtPathProfileDirectory.Text;
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
            txtPathProfileDirectory.Text = Program.PathPluginsTxtFile;
        }

        private void comboBoxChoosenGame_SelectedIndexChanged(object sender, EventArgs e)
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

        private void tooltipAutoProfile()
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();

            // Set up the delays for the ToolTip
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 1000;
            tooltip.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active
            tooltip.ShowAlways = true;

            // Set the tooltip text for the checkbox
            tooltip.SetToolTip(checkBoxAutoProfile, "Detects mod organizer profile changes every time you click Update Indexes button");
        }
    }
}
