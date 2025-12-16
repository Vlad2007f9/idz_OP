namespace idz_OP
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
            source = new TextBox();
            StaticsticsBox = new TextBox();
            openFileDialog = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            statisticsToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            newsFromTheSiteToolStripMenuItem = new ToolStripMenuItem();
            singletonToolStripMenuItem = new ToolStripMenuItem();
            lazySingletonToolStripMenuItem = new ToolStripMenuItem();
            limitSingletonToolStripMenuItem = new ToolStripMenuItem();
            buttonClear = new Button();
            filename = new TextBox();
            labelnews = new Label();
            textBoxtext = new TextBox();
            labelText = new Label();
            labelStat = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // source
            // 
            source.Location = new Point(0, 47);
            source.Multiline = true;
            source.Name = "source";
            source.ScrollBars = ScrollBars.Vertical;
            source.Size = new Size(363, 334);
            source.TabIndex = 0;
            source.TextChanged += source_TextChanged;
            source.KeyDown += source_KeyDown;
            // 
            // StaticsticsBox
            // 
            StaticsticsBox.Location = new Point(398, 47);
            StaticsticsBox.Multiline = true;
            StaticsticsBox.Name = "StaticsticsBox";
            StaticsticsBox.ScrollBars = ScrollBars.Vertical;
            StaticsticsBox.Size = new Size(361, 391);
            StaticsticsBox.TabIndex = 1;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolStripMenuItem1, statisticsToolStripMenuItem, aboutToolStripMenuItem, newsFromTheSiteToolStripMenuItem, singletonToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.Click += toolStripMenuItemFile_Click;
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(128, 26);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(128, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(128, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(128, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem, pasteToolStripMenuItem, cutToolStripMenuItem, undoToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(128, 26);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(128, 26);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(128, 26);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(128, 26);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 24);
            // 
            // statisticsToolStripMenuItem
            // 
            statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            statisticsToolStripMenuItem.Size = new Size(81, 24);
            statisticsToolStripMenuItem.Text = "Statistics";
            statisticsToolStripMenuItem.Click += statisticsToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(64, 24);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // newsFromTheSiteToolStripMenuItem
            // 
            newsFromTheSiteToolStripMenuItem.Name = "newsFromTheSiteToolStripMenuItem";
            newsFromTheSiteToolStripMenuItem.Size = new Size(147, 24);
            newsFromTheSiteToolStripMenuItem.Text = "News from the site";
            newsFromTheSiteToolStripMenuItem.Click += newsFromTheSiteToolStripMenuItem_Click;
            // 
            // singletonToolStripMenuItem
            // 
            singletonToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lazySingletonToolStripMenuItem, limitSingletonToolStripMenuItem });
            singletonToolStripMenuItem.Name = "singletonToolStripMenuItem";
            singletonToolStripMenuItem.Size = new Size(86, 24);
            singletonToolStripMenuItem.Text = "Singleton";
            singletonToolStripMenuItem.Click += singltonToolStripMenuItem_Click;
            // 
            // lazySingletonToolStripMenuItem
            // 
            lazySingletonToolStripMenuItem.Name = "lazySingletonToolStripMenuItem";
            lazySingletonToolStripMenuItem.Size = new Size(192, 26);
            lazySingletonToolStripMenuItem.Text = "Lazy Singleton";
            lazySingletonToolStripMenuItem.Click += lazySingletonToolStripMenuItem_Click;
            // 
            // limitSingletonToolStripMenuItem
            // 
            limitSingletonToolStripMenuItem.Name = "limitSingletonToolStripMenuItem";
            limitSingletonToolStripMenuItem.Size = new Size(192, 26);
            limitSingletonToolStripMenuItem.Text = "Limit Singleton";
            limitSingletonToolStripMenuItem.Click += limitSingletonToolStripMenuItem_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(0, 411);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 29);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "Clear Text";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // filename
            // 
            filename.Location = new Point(100, 413);
            filename.Name = "filename";
            filename.Size = new Size(73, 27);
            filename.TabIndex = 4;
            // 
            // labelnews
            // 
            labelnews.AutoSize = true;
            labelnews.Location = new Point(196, 415);
            labelnews.Name = "labelnews";
            labelnews.Size = new Size(121, 20);
            labelnews.TabIndex = 5;
            labelnews.Text = "Number of news:";
            // 
            // textBoxtext
            // 
            textBoxtext.Location = new Point(323, 412);
            textBoxtext.Name = "textBoxtext";
            textBoxtext.Size = new Size(67, 27);
            textBoxtext.TabIndex = 6;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Location = new Point(36, 25);
            labelText.Name = "labelText";
            labelText.Size = new Size(64, 20);
            labelText.TabIndex = 7;
            labelText.Text = "Text file:";
            // 
            // labelStat
            // 
            labelStat.AutoSize = true;
            labelStat.Location = new Point(517, 24);
            labelStat.Name = "labelStat";
            labelStat.Size = new Size(70, 20);
            labelStat.TabIndex = 8;
            labelStat.Text = "Statistics:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelStat);
            Controls.Add(labelText);
            Controls.Add(textBoxtext);
            Controls.Add(labelnews);
            Controls.Add(filename);
            Controls.Add(buttonClear);
            Controls.Add(StaticsticsBox);
            Controls.Add(source);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Idz_OP";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox source;
        private TextBox StaticsticsBox;
        private OpenFileDialog openFileDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private Button buttonClear;
        private TextBox filename;
        private Label labelnews;
        private TextBox textBoxtext;
        private ToolStripMenuItem statisticsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem newsFromTheSiteToolStripMenuItem;
        private ToolStripMenuItem singletonToolStripMenuItem;
        private ToolStripMenuItem lazySingletonToolStripMenuItem;
        private ToolStripMenuItem limitSingletonToolStripMenuItem;
        private Label labelText;
        private Label labelStat;
    }
}
