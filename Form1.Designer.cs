namespace WinFormsApp1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            sampleControl = new Editor.Controls.SampleControl();
            panel1 = new System.Windows.Forms.Panel();
            removeTexture = new System.Windows.Forms.Button();
            addTexture = new System.Windows.Forms.Button();
            texturesList = new System.Windows.Forms.ListBox();
            label3 = new System.Windows.Forms.Label();
            inputTextBox = new System.Windows.Forms.TextBox();
            removeAnimationFrame = new System.Windows.Forms.Button();
            addAnimationFrame = new System.Windows.Forms.Button();
            animationFramesList = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            removeAnimation = new System.Windows.Forms.Button();
            addAnimation = new System.Windows.Forms.Button();
            animationsList = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // sampleControl
            // 
            sampleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            sampleControl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            sampleControl.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
            sampleControl.Location = new System.Drawing.Point(0, 28);
            sampleControl.MouseHoverUpdatesOnly = false;
            sampleControl.Name = "sampleControl";
            sampleControl.Size = new System.Drawing.Size(1262, 725);
            sampleControl.TabIndex = 0;
            sampleControl.Text = "Sample Control";
            // 
            // panel1
            // 
            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            panel1.AutoSize = true;
            panel1.Controls.Add(removeTexture);
            panel1.Controls.Add(addTexture);
            panel1.Controls.Add(texturesList);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(inputTextBox);
            panel1.Controls.Add(removeAnimationFrame);
            panel1.Controls.Add(addAnimationFrame);
            panel1.Controls.Add(animationFramesList);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(removeAnimation);
            panel1.Controls.Add(addAnimation);
            panel1.Controls.Add(animationsList);
            panel1.Controls.Add(label1);
            panel1.Cursor = System.Windows.Forms.Cursors.Default;
            panel1.Location = new System.Drawing.Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(331, 731);
            panel1.TabIndex = 1;
            // 
            // removeTexture
            // 
            removeTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            removeTexture.Location = new System.Drawing.Point(262, 530);
            removeTexture.Margin = new System.Windows.Forms.Padding(0);
            removeTexture.Name = "removeTexture";
            removeTexture.Size = new System.Drawing.Size(32, 29);
            removeTexture.TabIndex = 13;
            removeTexture.Text = "-";
            removeTexture.UseVisualStyleBackColor = true;
            removeTexture.Click += removeTexture_Click;
            // 
            // addTexture
            // 
            addTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            addTexture.Location = new System.Drawing.Point(297, 530);
            addTexture.Margin = new System.Windows.Forms.Padding(0);
            addTexture.Name = "addTexture";
            addTexture.Size = new System.Drawing.Size(32, 29);
            addTexture.TabIndex = 12;
            addTexture.Text = "+";
            addTexture.UseVisualStyleBackColor = true;
            addTexture.Click += addTexture_Click;
            // 
            // texturesList
            // 
            texturesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            texturesList.FormattingEnabled = true;
            texturesList.ItemHeight = 20;
            texturesList.Items.AddRange(new object[] { "Hay", "awwa" });
            texturesList.Location = new System.Drawing.Point(0, 403);
            texturesList.Name = "texturesList";
            texturesList.Size = new System.Drawing.Size(331, 124);
            texturesList.TabIndex = 11;
            texturesList.SelectedIndexChanged += texturesList_SelectedIndexChange;
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(3, 377);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(293, 21);
            label3.TabIndex = 10;
            label3.Text = "Textures";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new System.Drawing.Point(0, 698);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new System.Drawing.Size(10, 27);
            inputTextBox.TabIndex = 9;
            inputTextBox.VisibleChanged += inputTextBox_VisibleChanged;
            inputTextBox.KeyPress += inputTextBox_KeyPress;
            inputTextBox.Leave += inputTextBox_FocusLeave;
            // 
            // removeAnimationFrame
            // 
            removeAnimationFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            removeAnimationFrame.Location = new System.Drawing.Point(262, 345);
            removeAnimationFrame.Margin = new System.Windows.Forms.Padding(0);
            removeAnimationFrame.Name = "removeAnimationFrame";
            removeAnimationFrame.Size = new System.Drawing.Size(32, 29);
            removeAnimationFrame.TabIndex = 8;
            removeAnimationFrame.Text = "-";
            removeAnimationFrame.UseVisualStyleBackColor = true;
            removeAnimationFrame.Click += removeAnimationFrame_Click;
            // 
            // addAnimationFrame
            // 
            addAnimationFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            addAnimationFrame.Location = new System.Drawing.Point(297, 345);
            addAnimationFrame.Margin = new System.Windows.Forms.Padding(0);
            addAnimationFrame.Name = "addAnimationFrame";
            addAnimationFrame.Size = new System.Drawing.Size(32, 29);
            addAnimationFrame.TabIndex = 7;
            addAnimationFrame.Text = "+";
            addAnimationFrame.UseVisualStyleBackColor = true;
            addAnimationFrame.Click += addAnimationFrame_Click;
            // 
            // animationFramesList
            // 
            animationFramesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            animationFramesList.FormattingEnabled = true;
            animationFramesList.ItemHeight = 20;
            animationFramesList.Items.AddRange(new object[] { "Hay", "awwa" });
            animationFramesList.Location = new System.Drawing.Point(0, 218);
            animationFramesList.Name = "animationFramesList";
            animationFramesList.Size = new System.Drawing.Size(331, 124);
            animationFramesList.TabIndex = 6;
            animationFramesList.SelectedIndexChanged += animationFramesList_SelectedIndexChanged;
            animationFramesList.MouseDoubleClick += animationFramesList_MouseDoubleClick;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(3, 192);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(293, 21);
            label2.TabIndex = 5;
            label2.Text = "Animation Frames";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // removeAnimation
            // 
            removeAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            removeAnimation.Location = new System.Drawing.Point(264, 163);
            removeAnimation.Margin = new System.Windows.Forms.Padding(0);
            removeAnimation.Name = "removeAnimation";
            removeAnimation.Size = new System.Drawing.Size(32, 29);
            removeAnimation.TabIndex = 4;
            removeAnimation.Text = "-";
            removeAnimation.UseVisualStyleBackColor = true;
            removeAnimation.Click += removeAnimation_Click;
            // 
            // addAnimation
            // 
            addAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            addAnimation.Location = new System.Drawing.Point(299, 163);
            addAnimation.Margin = new System.Windows.Forms.Padding(0);
            addAnimation.Name = "addAnimation";
            addAnimation.Size = new System.Drawing.Size(32, 29);
            addAnimation.TabIndex = 3;
            addAnimation.Text = "+";
            addAnimation.UseVisualStyleBackColor = true;
            addAnimation.Click += addAnimation_Click;
            // 
            // animationsList
            // 
            animationsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            animationsList.FormattingEnabled = true;
            animationsList.ItemHeight = 20;
            animationsList.Items.AddRange(new object[] { "Hay", "awwa" });
            animationsList.Location = new System.Drawing.Point(0, 36);
            animationsList.Name = "animationsList";
            animationsList.Size = new System.Drawing.Size(331, 124);
            animationsList.TabIndex = 2;
            animationsList.SelectedIndexChanged += animationsList_SelectedIndexChanged;
            animationsList.MouseDoubleClick += animationsList_MouseDoubleClick;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(3, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 21);
            label1.TabIndex = 1;
            label1.Text = "Animations";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1262, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, exportToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("newToolStripMenuItem.Image"));
            newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            newToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("openToolStripMenuItem.Image"));
            openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O));
            openToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(230, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("saveToolStripMenuItem.Image"));
            saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            saveToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.S));
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            exportToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            exportToolStripMenuItem.Text = "&Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator4, selectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            undoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y));
            redoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("cutToolStripMenuItem.Image"));
            cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X));
            cutToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image"));
            copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C));
            copyToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("pasteToolStripMenuItem.Image"));
            pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V));
            pasteToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(176, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator5, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(147, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1262, 753);
            Controls.Add(panel1);
            Controls.Add(sampleControl);
            Controls.Add(menuStrip1);
            Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            MainMenuStrip = menuStrip1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button removeTexture;
        private System.Windows.Forms.Button addTexture;
        private System.Windows.Forms.ListBox texturesList;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox inputTextBox;

        private System.Windows.Forms.Button addAnimation;
        private System.Windows.Forms.Button removeAnimation;
        private System.Windows.Forms.Button removeAnimationFrame;
        private System.Windows.Forms.Button addAnimationFrame;
        private System.Windows.Forms.ListBox animationFramesList;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.ListBox animationsList;

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion

        private Editor.Controls.SampleControl sampleControl;
    }
}