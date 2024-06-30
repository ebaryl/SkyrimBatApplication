using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Bat_Manager;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Diagnostics;

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
            Program.PathLoadOrderTxtFile = Settings.Default.PathLoadOrderTxtFile;

            Program.ChoosenGame = Settings.Default.ChoosenGame;
            lblChoosenGame.Text = Settings.Default.ChoosenGame;
            if (Program.ChoosenGame != null) { lblChoosenGame.Visible = true; }

            Program.ModOrganizer = Settings.Default.ModOrganizer;
            lblModOrganizer.Text = Settings.Default.ModOrganizer;
            if (Program.ModOrganizer != null) { lblModOrganizer.Visible = true; }


            Program.GameFlagsByte = Settings.Default.GameFlagsByte;


            //autoPath();
            /*
            if (Utility.IdentifyGameInstalledFromModOrganizer())
            {
                txtPathGameDirectory.Text = Program.PathGameDirectory;
                txtPathModsDirectory.Text = Program.PathModsDirectory;
                lblChoosenGame.Text = Program.ChoosenGame;
            }
            lblChoosenGame.Visible = true;
            */
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)

        {
            Settings.Default.PathGameDirectory = Program.PathGameDirectory;
            Settings.Default.PathProfileDirectory = Program.PathProfileDirectory;
            Settings.Default.CheckBoxAutoProfile = checkBoxAutoProfile.Checked;
            Settings.Default.PathModsDirectory = Program.PathModsDirectory;
            Settings.Default.PathPluginsTxtFile = Program.PathPluginsTxtFile;
            Settings.Default.PathLoadOrderTxtFile = Program.PathLoadOrderTxtFile;
            Settings.Default.ChoosenGame = Program.ChoosenGame;
            Settings.Default.ModOrganizer = Program.ModOrganizer;
            Settings.Default.GameFlagsByte = Program.GameFlagsByte;
            Settings.Default.Save();
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
            Program.PathPluginsTxtFile = Path.Combine(Program.PathProfileDirectory, "plugins.txt");
            Program.PathLoadOrderTxtFile = Path.Combine(Program.PathProfileDirectory, "loadorder.txt");
        }

        
        private void autoPath()
        {
            if (Program.PathModsDirectory == "" || txtPathModsDirectory.Text == "")
            {
                bool foundModOrganizer = Utility.IdentifyModOrganizerFromModsStagingFolder();
                if (foundModOrganizer)
                {
                    lblModOrganizer.Text = Program.ModOrganizer;
                    Utility.FindProfileDirectory();
                    txtPathProfileDirectory.Text = Program.PathProfileDirectory;
                }
                //else { txtPathProfileDirectory.Text = "!!! profile directory not found !!!"; }
            }

            if (Program.PathProfileDirectory == "" || txtPathModsDirectory.Text == "")
            {
                bool foundModsPath = Utility.FindModsDirectory();
                if (foundModsPath) { txtPathModsDirectory.Text = Program.PathModsDirectory; }
                //else { txtPathModsDirectory.Text = "!!! mods directory not found !!!"; }
            }
        }
        

        private void btnGameSelectFolder_Click(object sender, EventArgs e)
        {
            if (gameFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = gameFolderBrowserDialog.SelectedPath;

                bool gameIdentified = Utility.IdentifyGame(selectedPath);
                if (!gameIdentified)
                {
                    MessageBox.Show("Game launcher not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Program.PathGameDirectory = selectedPath;
                txtPathGameDirectory.Text = selectedPath;
                lblChoosenGame.Text = Program.ChoosenGame;
                lblChoosenGame.Visible = true;
            }
            UpdatelblToastMessage();
        }

        private void btnModsSelectFolder_Click(object sender, EventArgs e)
        {
            if (modsFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = modsFolderBrowserDialog.SelectedPath;
                if (!Utility.CheckForPluginsInside(selectedPath))
                {
                    MessageBox.Show("Mods not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Program.PathModsDirectory = selectedPath;
                txtPathModsDirectory.Text = selectedPath;
            }
            UpdatelblToastMessage();
        }

        private void btnProfileSelectFolder_Click(object sender, EventArgs e)
        {
            if (profilesFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = profilesFolderBrowserDialog.SelectedPath;

                if (!File.Exists(Path.Combine(selectedPath, "plugins.txt")))
                {
                    MessageBox.Show("plugins.txt not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Program.PathProfileDirectory = selectedPath;
                txtPathProfileDirectory.Text = selectedPath;
                Program.PathPluginsTxtFile = Path.Combine(selectedPath, "plugins.txt");
                Program.PathLoadOrderTxtFile = Path.Combine(selectedPath, "loadorder.txt");
                Utility.IdentifyModOrganizerFromBrowser();
                lblModOrganizer.Visible = true;
                lblModOrganizer.Text = Program.ModOrganizer;
            }
            UpdatelblToastMessage();
        }

        private void btnMyBatchFiles_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(Directory.GetCurrentDirectory().GetParentDirectory(1), "batchFiles"));
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //Timer timer = new Timer();
            if (txtPathGameDirectory.Text == "" || txtPathModsDirectory.Text == "" || txtPathProfileDirectory.Text == "")
            {
                MessageBox.Show("FILL DATA!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkBoxAutoProfile.Checked)
            {
                Utility.FindLatestModifiedProfileDirectory(1);
                txtPathProfileDirectory.Text = Program.PathProfileDirectory;
            }
            Utility.ReadLoadOrderFromFiles();
            Utility.ClassifyPlugins(Utility.plugins);
            Utility.SortPluginsAfterClassification(Utility.plugins);
            Utility.RemoveOldBats(Path.Combine(Program.PathGameDirectory, "data"));
            MyRegex.RegexUpdateIndexes();

            lblToastMessage.Text = "DONE!";
            lblToastMessage.Visible = true;
            lblToastMessage.ForeColor = Color.LightGreen;
            timerlblToastMessage.Start();
        }

        private void UpdatelblToastMessage()
        {
            if (lblToastMessage.Visible == true && Directory.Exists(txtPathGameDirectory.Text) &&
                Directory.Exists(txtPathModsDirectory.Text) && Directory.Exists(txtPathProfileDirectory.Text))
            {
                { lblToastMessage.Visible = false; }
            }

        }

        private void tooltipAutoProfile()
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();

            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 1000;
            tooltip.ReshowDelay = 500;
            tooltip.ShowAlways = true;
            tooltip.SetToolTip(checkBoxAutoProfile, "Detects organizer profile changes every Update Indexes");
        }

        private void timerlblToastMessage_Tick(object sender, EventArgs e)
        {
            lblToastMessage.Visible = false;
            timerlblToastMessage.Stop();
        }
    }
}
