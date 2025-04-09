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
            panel1 = new Panel();
            removeTexture = new Button();
            addTexture = new Button();
            texturesList = new ListBox();
            label3 = new Label();
            inputTextBox = new TextBox();
            removeAnimationFrame = new Button();
            addAnimationFrame = new Button();
            animationFramesList = new ListBox();
            label2 = new Label();
            removeAnimation = new Button();
            addAnimation = new Button();
            animationsList = new ListBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exportToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            indexToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            propertyGrid1 = new PropertyGrid();
            panel2 = new Panel();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // sampleControl
            // 
            sampleControl.Dock = DockStyle.Fill;
            sampleControl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            sampleControl.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
            sampleControl.Location = new Point(0, 28);
            sampleControl.MouseHoverUpdatesOnly = false;
            sampleControl.Name = "sampleControl";
            sampleControl.Size = new Size(1262, 725);
            sampleControl.TabIndex = 0;
            sampleControl.Text = "Sample Control";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
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
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 453);
            panel1.TabIndex = 1;
            // 
            // removeTexture
            // 
            removeTexture.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeTexture.Location = new Point(248, 408);
            removeTexture.Margin = new Padding(0);
            removeTexture.Name = "removeTexture";
            removeTexture.Size = new Size(32, 29);
            removeTexture.TabIndex = 13;
            removeTexture.Text = "-";
            removeTexture.UseVisualStyleBackColor = true;
            removeTexture.Click += removeTexture_Click;
            // 
            // addTexture
            // 
            addTexture.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addTexture.Location = new Point(283, 408);
            addTexture.Margin = new Padding(0);
            addTexture.Name = "addTexture";
            addTexture.Size = new Size(32, 29);
            addTexture.TabIndex = 12;
            addTexture.Text = "+";
            addTexture.UseVisualStyleBackColor = true;
            addTexture.Click += addTexture_Click;
            // 
            // texturesList
            // 
            texturesList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            texturesList.FormattingEnabled = true;
            texturesList.ItemHeight = 20;
            texturesList.Items.AddRange(new object[] { "Hay", "awwa" });
            texturesList.Location = new Point(0, 321);
            texturesList.Name = "texturesList";
            texturesList.Size = new Size(315, 84);
            texturesList.TabIndex = 11;
            texturesList.SelectedIndexChanged += texturesList_SelectedIndexChange;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 295);
            label3.Name = "label3";
            label3.Size = new Size(312, 21);
            label3.TabIndex = 10;
            label3.Text = "Textures";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(0, 698);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(10, 27);
            inputTextBox.TabIndex = 9;
            inputTextBox.VisibleChanged += inputTextBox_VisibleChanged;
            inputTextBox.KeyPress += inputTextBox_KeyPress;
            inputTextBox.Leave += inputTextBox_FocusLeave;
            // 
            // removeAnimationFrame
            // 
            removeAnimationFrame.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeAnimationFrame.Location = new Point(248, 261);
            removeAnimationFrame.Margin = new Padding(0);
            removeAnimationFrame.Name = "removeAnimationFrame";
            removeAnimationFrame.Size = new Size(32, 29);
            removeAnimationFrame.TabIndex = 8;
            removeAnimationFrame.Text = "-";
            removeAnimationFrame.UseVisualStyleBackColor = true;
            removeAnimationFrame.Click += removeAnimationFrame_Click;
            // 
            // addAnimationFrame
            // 
            addAnimationFrame.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addAnimationFrame.Location = new Point(283, 261);
            addAnimationFrame.Margin = new Padding(0);
            addAnimationFrame.Name = "addAnimationFrame";
            addAnimationFrame.Size = new Size(32, 29);
            addAnimationFrame.TabIndex = 7;
            addAnimationFrame.Text = "+";
            addAnimationFrame.UseVisualStyleBackColor = true;
            addAnimationFrame.Click += addAnimationFrame_Click;
            // 
            // animationFramesList
            // 
            animationFramesList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            animationFramesList.FormattingEnabled = true;
            animationFramesList.ItemHeight = 20;
            animationFramesList.Items.AddRange(new object[] { "Hay", "awwa" });
            animationFramesList.Location = new Point(0, 176);
            animationFramesList.Name = "animationFramesList";
            animationFramesList.Size = new Size(315, 84);
            animationFramesList.TabIndex = 6;
            animationFramesList.SelectedIndexChanged += animationFramesList_SelectedIndexChanged;
            animationFramesList.MouseDoubleClick += animationFramesList_MouseDoubleClick;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 152);
            label2.Name = "label2";
            label2.Size = new Size(312, 21);
            label2.TabIndex = 5;
            label2.Text = "Animation Frames";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // removeAnimation
            // 
            removeAnimation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeAnimation.Location = new Point(248, 123);
            removeAnimation.Margin = new Padding(0);
            removeAnimation.Name = "removeAnimation";
            removeAnimation.Size = new Size(32, 29);
            removeAnimation.TabIndex = 4;
            removeAnimation.Text = "-";
            removeAnimation.UseVisualStyleBackColor = true;
            removeAnimation.Click += removeAnimation_Click;
            // 
            // addAnimation
            // 
            addAnimation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addAnimation.Location = new Point(283, 123);
            addAnimation.Margin = new Padding(0);
            addAnimation.Name = "addAnimation";
            addAnimation.Size = new Size(32, 29);
            addAnimation.TabIndex = 3;
            addAnimation.Text = "+";
            addAnimation.UseVisualStyleBackColor = true;
            addAnimation.Click += addAnimation_Click;
            // 
            // animationsList
            // 
            animationsList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            animationsList.FormattingEnabled = true;
            animationsList.ItemHeight = 20;
            animationsList.Items.AddRange(new object[] { "Hay", "awwa" });
            animationsList.Location = new Point(0, 36);
            animationsList.Name = "animationsList";
            animationsList.Size = new Size(315, 84);
            animationsList.TabIndex = 2;
            animationsList.SelectedIndexChanged += animationsList_SelectedIndexChanged;
            animationsList.MouseDoubleClick += animationsList_MouseDoubleClick;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(232, 21);
            label1.TabIndex = 1;
            label1.Text = "Animations";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1262, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, exportToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(233, 26);
            newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(233, 26);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(230, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(233, 26);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(233, 26);
            saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(230, 6);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            exportToolStripMenuItem.Size = new Size(233, 26);
            exportToolStripMenuItem.Text = "&Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(230, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(233, 26);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator4, selectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(179, 26);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(179, 26);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(176, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(179, 26);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(179, 26);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(179, 26);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(176, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(179, 26);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(161, 26);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(161, 26);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator5, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new Size(150, 26);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new Size(150, 26);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(150, 26);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(147, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(150, 26);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // propertyGrid1
            // 
            propertyGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propertyGrid1.BackColor = SystemColors.ActiveCaption;
            propertyGrid1.CommandsActiveLinkColor = Color.Red;
            propertyGrid1.Location = new Point(0, 470);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(344, 252);
            propertyGrid1.TabIndex = 3;
            propertyGrid1.ViewBorderColor = Color.Chocolate;
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(propertyGrid1);
            panel2.Location = new Point(0, 28);
            panel2.MinimumSize = new Size(261, 725);
            panel2.Name = "panel2";
            panel2.Size = new Size(346, 725);
            panel2.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 753);
            Controls.Add(panel2);
            Controls.Add(sampleControl);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.PropertyGrid propertyGrid1;

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