namespace SkyrimBatApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnExecute = new Button();
            modsFolderBrowserDialog = new FolderBrowserDialog();
            lblToastMessage = new Label();
            btnModsSelectFolder = new Button();
            txtPathModsDirectory = new TextBox();
            txtPathProfileDirectory = new TextBox();
            btnProfilesSelectFolder = new Button();
            profilesFolderBrowserDialog = new FolderBrowserDialog();
            checkBoxAutoProfile = new CheckBox();
            lblGame = new Label();
            lblOrganizer = new Label();
            comboBoxChoosenGame = new ComboBox();
            comboBoxModOrganizer = new ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            txtPathGameDirectory = new TextBox();
            btnGameSelectFolder = new Button();
            gameFolderBrowserDialog = new FolderBrowserDialog();
            lblChoosenGame = new Label();
            lblModOrganizer = new Label();
            SuspendLayout();
            // 
            // btnExecute
            // 
            btnExecute.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExecute.BackColor = SystemColors.MenuBar;
            btnExecute.Location = new Point(184, 341);
            btnExecute.Margin = new Padding(3, 4, 3, 4);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(142, 40);
            btnExecute.TabIndex = 0;
            btnExecute.Text = "Update Indexes";
            btnExecute.UseVisualStyleBackColor = false;
            btnExecute.Click += btnExecute_Click;
            // 
            // modsFolderBrowserDialog
            // 
            modsFolderBrowserDialog.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // lblToastMessage
            // 
            lblToastMessage.AutoSize = true;
            lblToastMessage.BackColor = Color.Transparent;
            lblToastMessage.Font = new Font("Segoe UI", 13F);
            lblToastMessage.Location = new Point(333, 348);
            lblToastMessage.Name = "lblToastMessage";
            lblToastMessage.Size = new Size(49, 30);
            lblToastMessage.TabIndex = 1;
            lblToastMessage.Text = "OK!";
            lblToastMessage.Visible = false;
            lblToastMessage.Click += lblToastMessage_Click;
            // 
            // btnModsSelectFolder
            // 
            btnModsSelectFolder.Location = new Point(415, 255);
            btnModsSelectFolder.Margin = new Padding(3, 4, 3, 4);
            btnModsSelectFolder.Name = "btnModsSelectFolder";
            btnModsSelectFolder.Size = new Size(62, 27);
            btnModsSelectFolder.TabIndex = 3;
            btnModsSelectFolder.Text = "Select";
            btnModsSelectFolder.UseVisualStyleBackColor = true;
            btnModsSelectFolder.Click += btnModsSelectFolder_Click;
            // 
            // txtPathModsDirectory
            // 
            txtPathModsDirectory.BackColor = SystemColors.MenuBar;
            txtPathModsDirectory.Location = new Point(85, 255);
            txtPathModsDirectory.Margin = new Padding(3, 4, 3, 4);
            txtPathModsDirectory.Name = "txtPathModsDirectory";
            txtPathModsDirectory.PlaceholderText = "Mods Folder";
            txtPathModsDirectory.Size = new Size(324, 27);
            txtPathModsDirectory.TabIndex = 4;
            txtPathModsDirectory.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPathProfileDirectory
            // 
            txtPathProfileDirectory.BackColor = SystemColors.MenuBar;
            txtPathProfileDirectory.Location = new Point(85, 290);
            txtPathProfileDirectory.Margin = new Padding(3, 4, 3, 4);
            txtPathProfileDirectory.Name = "txtPathProfileDirectory";
            txtPathProfileDirectory.PlaceholderText = "Mod Organizer Folder With Profiles";
            txtPathProfileDirectory.Size = new Size(324, 27);
            txtPathProfileDirectory.TabIndex = 7;
            txtPathProfileDirectory.TextAlign = HorizontalAlignment.Center;
            txtPathProfileDirectory.TextChanged += txtPathProfileDirectory_TextChanged;
            // 
            // btnProfilesSelectFolder
            // 
            btnProfilesSelectFolder.Location = new Point(415, 290);
            btnProfilesSelectFolder.Margin = new Padding(3, 4, 3, 4);
            btnProfilesSelectFolder.Name = "btnProfilesSelectFolder";
            btnProfilesSelectFolder.Size = new Size(62, 27);
            btnProfilesSelectFolder.TabIndex = 8;
            btnProfilesSelectFolder.Text = "Select";
            btnProfilesSelectFolder.UseVisualStyleBackColor = true;
            btnProfilesSelectFolder.Click += btnProfileSelectFolder_Click;
            // 
            // checkBoxAutoProfile
            // 
            checkBoxAutoProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBoxAutoProfile.AutoSize = true;
            checkBoxAutoProfile.BackColor = SystemColors.Menu;
            checkBoxAutoProfile.Location = new Point(14, 77);
            checkBoxAutoProfile.Margin = new Padding(3, 4, 3, 4);
            checkBoxAutoProfile.Name = "checkBoxAutoProfile";
            checkBoxAutoProfile.Size = new Size(175, 24);
            checkBoxAutoProfile.TabIndex = 9;
            checkBoxAutoProfile.Text = "Detect profile change";
            checkBoxAutoProfile.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxAutoProfile.UseVisualStyleBackColor = false;
            checkBoxAutoProfile.CheckedChanged += checkBoxAutoProfile_CheckedChanged;
            // 
            // lblGame
            // 
            lblGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGame.AutoSize = true;
            lblGame.Location = new Point(14, 12);
            lblGame.Name = "lblGame";
            lblGame.Size = new Size(51, 20);
            lblGame.TabIndex = 10;
            lblGame.Text = "Game:";
            // 
            // lblOrganizer
            // 
            lblOrganizer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblOrganizer.AutoSize = true;
            lblOrganizer.Location = new Point(14, 44);
            lblOrganizer.Name = "lblOrganizer";
            lblOrganizer.Size = new Size(77, 20);
            lblOrganizer.TabIndex = 11;
            lblOrganizer.Text = "Organizer:";
            // 
            // comboBoxChoosenGame
            // 
            comboBoxChoosenGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxChoosenGame.FormattingEnabled = true;
            comboBoxChoosenGame.Items.AddRange(new object[] { "Skyrim", "Skyrim SE", "Fallout" });
            comboBoxChoosenGame.Location = new Point(333, 13);
            comboBoxChoosenGame.Margin = new Padding(3, 4, 3, 4);
            comboBoxChoosenGame.Name = "comboBoxChoosenGame";
            comboBoxChoosenGame.Size = new Size(119, 28);
            comboBoxChoosenGame.TabIndex = 13;
            comboBoxChoosenGame.SelectedIndexChanged += comboBoxChoosenGame_SelectedIndexChanged;
            // 
            // comboBoxModOrganizer
            // 
            comboBoxModOrganizer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxModOrganizer.FormattingEnabled = true;
            comboBoxModOrganizer.Items.AddRange(new object[] { "Mod Organizer", "Vortex" });
            comboBoxModOrganizer.Location = new Point(298, 56);
            comboBoxModOrganizer.Margin = new Padding(3, 4, 3, 4);
            comboBoxModOrganizer.Name = "comboBoxModOrganizer";
            comboBoxModOrganizer.Size = new Size(154, 28);
            comboBoxModOrganizer.TabIndex = 14;
            comboBoxModOrganizer.SelectedIndexChanged += comboBoxModOrganizer_SelectedIndexChanged;
            // 
            // txtPathGameDirectory
            // 
            txtPathGameDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPathGameDirectory.BackColor = SystemColors.MenuBar;
            txtPathGameDirectory.Location = new Point(85, 220);
            txtPathGameDirectory.Margin = new Padding(3, 4, 3, 4);
            txtPathGameDirectory.Name = "txtPathGameDirectory";
            txtPathGameDirectory.PlaceholderText = "Game Folder";
            txtPathGameDirectory.Size = new Size(324, 27);
            txtPathGameDirectory.TabIndex = 15;
            txtPathGameDirectory.TextAlign = HorizontalAlignment.Center;
            txtPathGameDirectory.TextChanged += txtGameFolderPath_TextChanged;
            // 
            // btnGameSelectFolder
            // 
            btnGameSelectFolder.Location = new Point(415, 220);
            btnGameSelectFolder.Margin = new Padding(3, 4, 3, 4);
            btnGameSelectFolder.Name = "btnGameSelectFolder";
            btnGameSelectFolder.Size = new Size(62, 27);
            btnGameSelectFolder.TabIndex = 16;
            btnGameSelectFolder.Text = "Select";
            btnGameSelectFolder.UseVisualStyleBackColor = true;
            btnGameSelectFolder.Click += btnGameSelectFolder_Click;
            // 
            // lblChoosenGame
            // 
            lblChoosenGame.AutoSize = true;
            lblChoosenGame.Location = new Point(70, 13);
            lblChoosenGame.Name = "lblChoosenGame";
            lblChoosenGame.Size = new Size(87, 20);
            lblChoosenGame.TabIndex = 17;
            lblChoosenGame.Text = "gameName";
            lblChoosenGame.Visible = false;
            // 
            // lblModOrganizer
            // 
            lblModOrganizer.AutoSize = true;
            lblModOrganizer.Location = new Point(97, 44);
            lblModOrganizer.Name = "lblModOrganizer";
            lblModOrganizer.Size = new Size(112, 20);
            lblModOrganizer.TabIndex = 18;
            lblModOrganizer.Text = "organizerName";
            lblModOrganizer.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(506, 409);
            Controls.Add(lblModOrganizer);
            Controls.Add(lblChoosenGame);
            Controls.Add(btnGameSelectFolder);
            Controls.Add(txtPathGameDirectory);
            Controls.Add(comboBoxModOrganizer);
            Controls.Add(comboBoxChoosenGame);
            Controls.Add(lblOrganizer);
            Controls.Add(lblGame);
            Controls.Add(checkBoxAutoProfile);
            Controls.Add(btnProfilesSelectFolder);
            Controls.Add(txtPathProfileDirectory);
            Controls.Add(txtPathModsDirectory);
            Controls.Add(btnModsSelectFolder);
            Controls.Add(lblToastMessage);
            Controls.Add(btnExecute);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bat Manager";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExecute;
        private FolderBrowserDialog modsFolderBrowserDialog;
        private Label lblToastMessage;
        private Button btnModsSelectFolder;
        private TextBox txtPathModsDirectory;
        private TextBox txtPathProfileDirectory;
        private Button btnProfilesSelectFolder;
        private FolderBrowserDialog profilesFolderBrowserDialog;
        private CheckBox checkBoxAutoProfile;
        private Label lblGame;
        private Label lblOrganizer;
        private ComboBox comboBoxChoosenGame;
        private ComboBox comboBoxModOrganizer;
        private System.Windows.Forms.Timer timer1;
        private TextBox txtPathGameDirectory;
        private Button btnGameSelectFolder;
        private FolderBrowserDialog gameFolderBrowserDialog;
        private Label lblChoosenGame;
        private Label lblModOrganizer;
    }
}
