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
            pictureBoxBat.SendToBack();
            //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            tooltipAutoProfile();
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
            lblChoosenGame.Text = Settings.Default.ChoosenGame;

            Program.ModOrganizer = Settings.Default.ModOrganizer;
            lblModOrganizer.Text = Settings.Default.ModOrganizer;

            Program.GameFlagsByte = Settings.Default.GameFlagsByte;
            Settings.Default.Save();

            if (Program.PathModsDirectory == "" || Program.PathProfileDirectory == "")
            {
                autoPath();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)

        {
            Settings.Default.PathGameDirectory = txtPathGameDirectory.Text;
            Settings.Default.PathProfileDirectory = txtPathProfileDirectory.Text;
            Settings.Default.CheckBoxAutoProfile = checkBoxAutoProfile.Checked;
            Settings.Default.PathModsDirectory = txtPathModsDirectory.Text;
            Settings.Default.PathPluginsTxtFile = Program.PathPluginsTxtFile;
            Settings.Default.ChoosenGame = Program.ChoosenGame;
            Settings.Default.ModOrganizer = Program.ModOrganizer;
            Settings.Default.GameFlagsByte = Program.GameFlagsByte;
            Settings.Default.Save();
        }

        private void autoPath()
        {
            bool foundModOrganizer = Utility.IdentifyModOrganizerFromModsStagingFolder();
            if (foundModOrganizer)
            {
                lblModOrganizer.Text = Program.ModOrganizer;
                Utility.FindProfileDirectory();
                txtPathProfileDirectory.Text = Program.PathProfileDirectory;
            }
            //else { txtPathProfileDirectory.Text = "!!! profile directory not found !!!"; }

            bool foundModsPath = Utility.FindModsDirectory();
            if (foundModsPath) { txtPathModsDirectory.Text = Program.PathModsDirectory; }
            //else { txtPathModsDirectory.Text = "!!! mods directory not found !!!"; }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //Timer timer = new Timer();
            if (txtPathGameDirectory.Text == "" || txtPathModsDirectory.Text == "" || txtPathProfileDirectory.Text == "")
            {
                lblToastMessage.Text = "FILL DATA!";
                lblToastMessage.ForeColor = Color.Red;
                lblToastMessage.Visible = true;
                return;
            }
            if (checkBoxAutoProfile.Checked)
            {
                Utility.FindLatestModifiedProfileDirectory();
                txtPathProfileDirectory.Text = Program.PathProfileDirectory;
            }

            Utility.ReadFromPlugin();
            Utility.ClassifyPlugins(Utility.plugins, Program.PathModsDirectory);
            Utility.SortPluginsAfterClassification(Utility.plugins);
            MyRegex.ReadAllTxtFiles();

            lblToastMessage.Text = "DONE!";
            lblToastMessage.Visible = true;
            lblToastMessage.ForeColor = Color.LightGreen;
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
            UpdatelblToastMessage();
        }

        private void btnModsSelectFolder_Click(object sender, EventArgs e)
        {
            if (modsFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz wybran¹ œcie¿kê
                string selectedPath = modsFolderBrowserDialog.SelectedPath;
                 if (!Utility.CheckForPluginsInside(selectedPath)) {
                    MessageBox.Show("Mods not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }

                // Wyœwietl œcie¿kê w TextBox
                txtPathModsDirectory.Text = selectedPath;
                Program.PathModsDirectory = selectedPath;
            }
            UpdatelblToastMessage();
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
                Utility.IdentifyModOrganizerFromBrowser();
                lblModOrganizer.Visible = true;
                lblModOrganizer.Text = Program.ModOrganizer;
            }
            UpdatelblToastMessage();
        }

        private void UpdatelblToastMessage()
        {
            if (lblToastMessage.Visible == true && Directory.Exists(txtPathGameDirectory.Text) &&
                Directory.Exists(txtPathModsDirectory.Text) && Directory.Exists(txtPathProfileDirectory.Text))
            {
                { lblToastMessage.Visible = false; }
            }

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void checkBoxAutoProfile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPathGameFolder_TextChanged(object sender, EventArgs e)
        {
            Program.PathGameDirectory = txtPathGameDirectory.Text;
        }

        private void txtPathModsDirectory_TextChanged(object sender, EventArgs e)
        {
            Program.PathModsDirectory = txtPathModsDirectory.Text;
        }

        private void txtPathProfileDirectory_TextChanged(object sender, EventArgs e)
        {
            Program.PathProfileDirectory = txtPathProfileDirectory.Text;
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
