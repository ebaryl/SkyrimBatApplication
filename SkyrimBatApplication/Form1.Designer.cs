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
            timer1 = new System.Windows.Forms.Timer(components);
            txtPathGameDirectory = new TextBox();
            btnGameSelectFolder = new Button();
            gameFolderBrowserDialog = new FolderBrowserDialog();
            lblChoosenGame = new Label();
            lblModOrganizer = new Label();
            pictureBoxBat = new PictureBox();
            lblGameDirectory = new Label();
            lblModsDirectory = new Label();
            lblProfileDirectory = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBat).BeginInit();
            SuspendLayout();
            // 
            // btnExecute
            // 
            btnExecute.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExecute.BackColor = SystemColors.Menu;
            btnExecute.Font = new Font("Candara", 10.3F);
            btnExecute.ForeColor = SystemColors.ActiveCaptionText;
            btnExecute.Location = new Point(181, 345);
            btnExecute.Margin = new Padding(3, 4, 3, 4);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(151, 46);
            btnExecute.TabIndex = 0;
            btnExecute.Text = "Update Indexes";
            btnExecute.UseVisualStyleBackColor = true;
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
            lblToastMessage.Font = new Font("Segoe UI", 12F);
            lblToastMessage.ForeColor = Color.PaleGreen;
            lblToastMessage.Location = new Point(340, 355);
            lblToastMessage.Name = "lblToastMessage";
            lblToastMessage.Size = new Size(72, 28);
            lblToastMessage.TabIndex = 1;
            lblToastMessage.Text = "DONE!";
            lblToastMessage.Visible = false;
            lblToastMessage.Click += lblToastMessage_Click;
            // 
            // btnModsSelectFolder
            // 
            btnModsSelectFolder.BackColor = SystemColors.Info;
            btnModsSelectFolder.Location = new Point(422, 269);
            btnModsSelectFolder.Margin = new Padding(3, 4, 3, 4);
            btnModsSelectFolder.Name = "btnModsSelectFolder";
            btnModsSelectFolder.Size = new Size(62, 27);
            btnModsSelectFolder.TabIndex = 3;
            btnModsSelectFolder.Text = "Select";
            btnModsSelectFolder.UseVisualStyleBackColor = false;
            btnModsSelectFolder.Click += btnModsSelectFolder_Click;
            // 
            // txtPathModsDirectory
            // 
            txtPathModsDirectory.BackColor = SystemColors.MenuBar;
            txtPathModsDirectory.Font = new Font("Candara", 10.2F);
            txtPathModsDirectory.Location = new Point(92, 269);
            txtPathModsDirectory.Margin = new Padding(3, 4, 3, 4);
            txtPathModsDirectory.Name = "txtPathModsDirectory";
            txtPathModsDirectory.PlaceholderText = "Mods Folder";
            txtPathModsDirectory.Size = new Size(324, 28);
            txtPathModsDirectory.TabIndex = 4;
            txtPathModsDirectory.TextChanged += txtPathModsDirectory_TextChanged;
            // 
            // txtPathProfileDirectory
            // 
            txtPathProfileDirectory.BackColor = SystemColors.MenuBar;
            txtPathProfileDirectory.Font = new Font("Candara", 10.2F);
            txtPathProfileDirectory.Location = new Point(92, 305);
            txtPathProfileDirectory.Margin = new Padding(3, 4, 3, 4);
            txtPathProfileDirectory.Name = "txtPathProfileDirectory";
            txtPathProfileDirectory.PlaceholderText = "Organizer Profile With plugins.txt Inside";
            txtPathProfileDirectory.Size = new Size(324, 28);
            txtPathProfileDirectory.TabIndex = 7;
            txtPathProfileDirectory.TextChanged += txtPathProfileDirectory_TextChanged;
            // 
            // btnProfilesSelectFolder
            // 
            btnProfilesSelectFolder.BackColor = SystemColors.Info;
            btnProfilesSelectFolder.Location = new Point(422, 305);
            btnProfilesSelectFolder.Margin = new Padding(3, 4, 3, 4);
            btnProfilesSelectFolder.Name = "btnProfilesSelectFolder";
            btnProfilesSelectFolder.Size = new Size(62, 27);
            btnProfilesSelectFolder.TabIndex = 8;
            btnProfilesSelectFolder.Text = "Select";
            btnProfilesSelectFolder.UseVisualStyleBackColor = false;
            btnProfilesSelectFolder.Click += btnProfileSelectFolder_Click;
            // 
            // checkBoxAutoProfile
            // 
            checkBoxAutoProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBoxAutoProfile.AutoSize = true;
            checkBoxAutoProfile.BackColor = Color.Transparent;
            checkBoxAutoProfile.Checked = true;
            checkBoxAutoProfile.CheckState = CheckState.Checked;
            checkBoxAutoProfile.ForeColor = SystemColors.Control;
            checkBoxAutoProfile.Location = new Point(12, 201);
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
            lblGame.BackColor = Color.Transparent;
            lblGame.ForeColor = Color.White;
            lblGame.Location = new Point(1, 9);
            lblGame.Name = "lblGame";
            lblGame.Size = new Size(51, 20);
            lblGame.TabIndex = 10;
            lblGame.Text = "Game:";
            lblGame.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOrganizer
            // 
            lblOrganizer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblOrganizer.AutoSize = true;
            lblOrganizer.BackColor = Color.Transparent;
            lblOrganizer.ForeColor = SystemColors.Control;
            lblOrganizer.Location = new Point(1, 29);
            lblOrganizer.Name = "lblOrganizer";
            lblOrganizer.Size = new Size(77, 20);
            lblOrganizer.TabIndex = 11;
            lblOrganizer.Text = "Organizer:";
            lblOrganizer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPathGameDirectory
            // 
            txtPathGameDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPathGameDirectory.BackColor = SystemColors.MenuBar;
            txtPathGameDirectory.Font = new Font("Candara", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtPathGameDirectory.Location = new Point(92, 233);
            txtPathGameDirectory.Margin = new Padding(3, 4, 3, 4);
            txtPathGameDirectory.Name = "txtPathGameDirectory";
            txtPathGameDirectory.PlaceholderText = "Game Folder";
            txtPathGameDirectory.Size = new Size(324, 28);
            txtPathGameDirectory.TabIndex = 15;
            txtPathGameDirectory.TextChanged += txtPathGameFolder_TextChanged;
            // 
            // btnGameSelectFolder
            // 
            btnGameSelectFolder.BackColor = SystemColors.Info;
            btnGameSelectFolder.Location = new Point(422, 233);
            btnGameSelectFolder.Margin = new Padding(3, 4, 3, 4);
            btnGameSelectFolder.Name = "btnGameSelectFolder";
            btnGameSelectFolder.Size = new Size(62, 27);
            btnGameSelectFolder.TabIndex = 16;
            btnGameSelectFolder.Text = "Select";
            btnGameSelectFolder.UseVisualStyleBackColor = false;
            btnGameSelectFolder.Click += btnGameSelectFolder_Click;
            // 
            // lblChoosenGame
            // 
            lblChoosenGame.AutoSize = true;
            lblChoosenGame.BackColor = Color.Transparent;
            lblChoosenGame.ForeColor = SystemColors.Control;
            lblChoosenGame.Location = new Point(46, 9);
            lblChoosenGame.Name = "lblChoosenGame";
            lblChoosenGame.Size = new Size(87, 20);
            lblChoosenGame.TabIndex = 17;
            lblChoosenGame.Text = "gameName";
            lblChoosenGame.Visible = false;
            // 
            // lblModOrganizer
            // 
            lblModOrganizer.AutoSize = true;
            lblModOrganizer.BackColor = Color.Transparent;
            lblModOrganizer.ForeColor = SystemColors.Control;
            lblModOrganizer.Location = new Point(73, 29);
            lblModOrganizer.Name = "lblModOrganizer";
            lblModOrganizer.Size = new Size(112, 20);
            lblModOrganizer.TabIndex = 18;
            lblModOrganizer.Text = "organizerName";
            lblModOrganizer.Visible = false;
            // 
            // pictureBoxBat
            // 
            pictureBoxBat.BackColor = Color.Transparent;
            pictureBoxBat.Image = (Image)resources.GetObject("pictureBoxBat.Image");
            pictureBoxBat.Location = new Point(46, 29);
            pictureBoxBat.Name = "pictureBoxBat";
            pictureBoxBat.Size = new Size(419, 173);
            pictureBoxBat.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBat.TabIndex = 19;
            pictureBoxBat.TabStop = false;
            // 
            // lblGameDirectory
            // 
            lblGameDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGameDirectory.AutoSize = true;
            lblGameDirectory.BackColor = Color.Transparent;
            lblGameDirectory.ForeColor = SystemColors.Control;
            lblGameDirectory.Location = new Point(30, 235);
            lblGameDirectory.Name = "lblGameDirectory";
            lblGameDirectory.Size = new Size(48, 20);
            lblGameDirectory.TabIndex = 20;
            lblGameDirectory.Text = "Game";
            lblGameDirectory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblModsDirectory
            // 
            lblModsDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblModsDirectory.AutoSize = true;
            lblModsDirectory.BackColor = Color.Transparent;
            lblModsDirectory.ForeColor = SystemColors.Control;
            lblModsDirectory.Location = new Point(30, 271);
            lblModsDirectory.Name = "lblModsDirectory";
            lblModsDirectory.Size = new Size(46, 20);
            lblModsDirectory.TabIndex = 21;
            lblModsDirectory.Text = "Mods";
            lblModsDirectory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProfileDirectory
            // 
            lblProfileDirectory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblProfileDirectory.AutoSize = true;
            lblProfileDirectory.BackColor = Color.Transparent;
            lblProfileDirectory.ForeColor = SystemColors.Control;
            lblProfileDirectory.Location = new Point(30, 307);
            lblProfileDirectory.Name = "lblProfileDirectory";
            lblProfileDirectory.Size = new Size(52, 20);
            lblProfileDirectory.TabIndex = 22;
            lblProfileDirectory.Text = "Profile";
            lblProfileDirectory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(506, 409);
            Controls.Add(lblProfileDirectory);
            Controls.Add(lblModsDirectory);
            Controls.Add(lblGameDirectory);
            Controls.Add(pictureBoxBat);
            Controls.Add(lblModOrganizer);
            Controls.Add(lblChoosenGame);
            Controls.Add(btnGameSelectFolder);
            Controls.Add(txtPathGameDirectory);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bat Manager";
            Load += Form1_Load; // ADDED BY ME
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBat).EndInit();
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
        private System.Windows.Forms.Timer timer1;
        private TextBox txtPathGameDirectory;
        private Button btnGameSelectFolder;
        private FolderBrowserDialog gameFolderBrowserDialog;
        private Label lblChoosenGame;
        private Label lblModOrganizer;
        private PictureBox pictureBoxBat;
        private Label lblGameDirectory;
        private Label lblModsDirectory;
        private Label lblProfileDirectory;
    }
}
