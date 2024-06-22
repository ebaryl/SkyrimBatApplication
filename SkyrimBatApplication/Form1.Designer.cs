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
            txtModsFolderPath = new TextBox();
            txtProfilesFolderPath = new TextBox();
            btnProfilesSelectFolder = new Button();
            profilesFolderBrowserDialog = new FolderBrowserDialog();
            autoProfilescheckBox = new CheckBox();
            lblGame = new Label();
            lblModOrganizer = new Label();
            comboBoxGame = new ComboBox();
            comboBoxModOrganizer = new ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            txtGameFolderPath = new TextBox();
            btnGameSelectFolder = new Button();
            gameFolderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // btnExecute
            // 
            btnExecute.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExecute.BackColor = SystemColors.MenuBar;
            btnExecute.Location = new Point(161, 256);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(124, 30);
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
            lblToastMessage.Location = new Point(291, 261);
            lblToastMessage.Name = "lblToastMessage";
            lblToastMessage.Size = new Size(41, 25);
            lblToastMessage.TabIndex = 1;
            lblToastMessage.Text = "OK!";
            lblToastMessage.Visible = false;
            lblToastMessage.Click += lblToastMessage_Click;
            // 
            // btnModsSelectFolder
            // 
            btnModsSelectFolder.Location = new Point(363, 227);
            btnModsSelectFolder.Name = "btnModsSelectFolder";
            btnModsSelectFolder.Size = new Size(54, 23);
            btnModsSelectFolder.TabIndex = 3;
            btnModsSelectFolder.Text = "Select";
            btnModsSelectFolder.UseVisualStyleBackColor = true;
            btnModsSelectFolder.Click += btnModsSelectFolder_Click;
            // 
            // txtModsFolderPath
            // 
            txtModsFolderPath.BackColor = SystemColors.MenuBar;
            txtModsFolderPath.Location = new Point(73, 227);
            txtModsFolderPath.Name = "txtModsFolderPath";
            txtModsFolderPath.PlaceholderText = "Mods Folder";
            txtModsFolderPath.Size = new Size(284, 23);
            txtModsFolderPath.TabIndex = 4;
            txtModsFolderPath.TextAlign = HorizontalAlignment.Center;
            // 
            // txtProfilesFolderPath
            // 
            txtProfilesFolderPath.BackColor = SystemColors.MenuBar;
            txtProfilesFolderPath.Location = new Point(73, 198);
            txtProfilesFolderPath.Name = "txtProfilesFolderPath";
            txtProfilesFolderPath.PlaceholderText = "Mod Organizer Profile Folder";
            txtProfilesFolderPath.Size = new Size(284, 23);
            txtProfilesFolderPath.TabIndex = 7;
            txtProfilesFolderPath.TextAlign = HorizontalAlignment.Center;
            txtProfilesFolderPath.TextChanged += txtProfileFolderPath_TextChanged;
            // 
            // btnProfilesSelectFolder
            // 
            btnProfilesSelectFolder.Location = new Point(363, 198);
            btnProfilesSelectFolder.Name = "btnProfilesSelectFolder";
            btnProfilesSelectFolder.Size = new Size(54, 23);
            btnProfilesSelectFolder.TabIndex = 8;
            btnProfilesSelectFolder.Text = "Select";
            btnProfilesSelectFolder.UseVisualStyleBackColor = true;
            btnProfilesSelectFolder.Click += btnProfileSelectFolder_Click;
            // 
            // autoProfilescheckBox
            // 
            autoProfilescheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            autoProfilescheckBox.AutoSize = true;
            autoProfilescheckBox.BackColor = SystemColors.Menu;
            autoProfilescheckBox.Location = new Point(12, 84);
            autoProfilescheckBox.Name = "autoProfilescheckBox";
            autoProfilescheckBox.Size = new Size(383, 19);
            autoProfilescheckBox.TabIndex = 9;
            autoProfilescheckBox.Text = "Detect mod organizer profile change (after check and index update)";
            autoProfilescheckBox.UseVisualStyleBackColor = false;
            autoProfilescheckBox.CheckedChanged += autoProfilecheckBox_CheckedChanged;
            // 
            // lblGame
            // 
            lblGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGame.AutoSize = true;
            lblGame.Location = new Point(12, 9);
            lblGame.Name = "lblGame";
            lblGame.Size = new Size(38, 15);
            lblGame.TabIndex = 10;
            lblGame.Text = "Game";
            // 
            // lblModOrganizer
            // 
            lblModOrganizer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblModOrganizer.AutoSize = true;
            lblModOrganizer.Location = new Point(10, 48);
            lblModOrganizer.Name = "lblModOrganizer";
            lblModOrganizer.Size = new Size(86, 15);
            lblModOrganizer.TabIndex = 11;
            lblModOrganizer.Text = "Mod Organizer";
            // 
            // comboBoxGame
            // 
            comboBoxGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxGame.FormattingEnabled = true;
            comboBoxGame.Items.AddRange(new object[] { "Skyrim", "Skyrim SE", "Fallout" });
            comboBoxGame.Location = new Point(56, 6);
            comboBoxGame.Name = "comboBoxGame";
            comboBoxGame.Size = new Size(105, 23);
            comboBoxGame.TabIndex = 13;
            comboBoxGame.SelectedIndexChanged += comboBoxGame_SelectedIndexChanged;
            // 
            // comboBoxModOrganizer
            // 
            comboBoxModOrganizer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxModOrganizer.FormattingEnabled = true;
            comboBoxModOrganizer.Items.AddRange(new object[] { "Mod Organizer", "Vortex" });
            comboBoxModOrganizer.Location = new Point(102, 45);
            comboBoxModOrganizer.Name = "comboBoxModOrganizer";
            comboBoxModOrganizer.Size = new Size(135, 23);
            comboBoxModOrganizer.TabIndex = 14;
            comboBoxModOrganizer.SelectedIndexChanged += comboBoxModOrganizer_SelectedIndexChanged;
            // 
            // txtGameFolderPath
            // 
            txtGameFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtGameFolderPath.BackColor = SystemColors.MenuBar;
            txtGameFolderPath.Location = new Point(73, 169);
            txtGameFolderPath.Name = "txtGameFolderPath";
            txtGameFolderPath.PlaceholderText = "Game Folder";
            txtGameFolderPath.Size = new Size(284, 23);
            txtGameFolderPath.TabIndex = 15;
            txtGameFolderPath.TextAlign = HorizontalAlignment.Center;
            // 
            // btnGameSelectFolder
            // 
            btnGameSelectFolder.Location = new Point(363, 169);
            btnGameSelectFolder.Name = "btnGameSelectFolder";
            btnGameSelectFolder.Size = new Size(54, 23);
            btnGameSelectFolder.TabIndex = 16;
            btnGameSelectFolder.Text = "Select";
            btnGameSelectFolder.UseVisualStyleBackColor = true;
            btnGameSelectFolder.Click += btnGameSelectFolder_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(443, 307);
            Controls.Add(btnGameSelectFolder);
            Controls.Add(txtGameFolderPath);
            Controls.Add(comboBoxModOrganizer);
            Controls.Add(comboBoxGame);
            Controls.Add(lblModOrganizer);
            Controls.Add(lblGame);
            Controls.Add(autoProfilescheckBox);
            Controls.Add(btnProfilesSelectFolder);
            Controls.Add(txtProfilesFolderPath);
            Controls.Add(txtModsFolderPath);
            Controls.Add(btnModsSelectFolder);
            Controls.Add(lblToastMessage);
            Controls.Add(btnExecute);
            DoubleBuffered = true;
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
        private TextBox txtModsFolderPath;
        private TextBox txtProfilesFolderPath;
        private Button btnProfilesSelectFolder;
        private FolderBrowserDialog profilesFolderBrowserDialog;
        private CheckBox autoProfilescheckBox;
        private Label lblGame;
        private Label lblModOrganizer;
        private ComboBox comboBoxGame;
        private ComboBox comboBoxModOrganizer;
        private System.Windows.Forms.Timer timer1;
        private TextBox txtGameFolderPath;
        private Button btnGameSelectFolder;
        private FolderBrowserDialog gameFolderBrowserDialog;
    }
}
