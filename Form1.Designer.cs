namespace BrickCreator
{
	partial class brickCreatorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
			this.components = new System.ComponentModel.Container();
			this.brickListBox = new System.Windows.Forms.ListBox();
			this.listRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ListLabel = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dimensionsLabel3 = new System.Windows.Forms.Label();
			this.dimensionsLabel2 = new System.Windows.Forms.Label();
			this.dimensionsLabel1 = new System.Windows.Forms.Label();
			this.heightCounter = new System.Windows.Forms.NumericUpDown();
			this.lengthCounter = new System.Windows.Forms.NumericUpDown();
			this.widthCounter = new System.Windows.Forms.NumericUpDown();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.descriptionBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.titleBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.nameBox = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.EmailLabel = new System.Windows.Forms.Label();
			this.aboutLabel5 = new System.Windows.Forms.Label();
			this.aboutLabel4 = new System.Windows.Forms.Label();
			this.aboutLabel3 = new System.Windows.Forms.Label();
			this.aboutLabel2 = new System.Windows.Forms.Label();
			this.aboutLabel1 = new System.Windows.Forms.Label();
			this.newBrickButton = new System.Windows.Forms.Button();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.UiBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.subCatBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.categoryBox = new System.Windows.Forms.TextBox();
			this.packBrickButton = new System.Windows.Forms.Button();
			this.saveBrickButton = new System.Windows.Forms.Button();
			this.listRightClickMenu.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.heightCounter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lengthCounter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.widthCounter)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// brickListBox
			// 
			this.brickListBox.ContextMenuStrip = this.listRightClickMenu;
			this.brickListBox.FormattingEnabled = true;
			this.brickListBox.Location = new System.Drawing.Point(9, 27);
			this.brickListBox.Name = "brickListBox";
			this.brickListBox.Size = new System.Drawing.Size(110, 212);
			this.brickListBox.TabIndex = 0;
			this.brickListBox.SelectedIndexChanged += new System.EventHandler(this.brickListBox_SelectedIndexChanged);
			this.brickListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brickListBox_mouseDown);
			// 
			// listRightClickMenu
			// 
			this.listRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
			this.listRightClickMenu.Name = "contextMenuStrip1";
			this.listRightClickMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.listRightClickMenu.ShowImageMargin = false;
			this.listRightClickMenu.Size = new System.Drawing.Size(100, 26);
			this.listRightClickMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
			// 
			// ListLabel
			// 
			this.ListLabel.AutoSize = true;
			this.ListLabel.Location = new System.Drawing.Point(6, 9);
			this.ListLabel.Name = "ListLabel";
			this.ListLabel.Size = new System.Drawing.Size(53, 13);
			this.ListLabel.TabIndex = 1;
			this.ListLabel.Text = "Brick List:";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(126, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(147, 137);
			this.tabControl1.TabIndex = 2;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabs_tabChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dimensionsLabel3);
			this.tabPage1.Controls.Add(this.dimensionsLabel2);
			this.tabPage1.Controls.Add(this.dimensionsLabel1);
			this.tabPage1.Controls.Add(this.heightCounter);
			this.tabPage1.Controls.Add(this.lengthCounter);
			this.tabPage1.Controls.Add(this.widthCounter);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(139, 111);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Brick";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dimensionsLabel3
			// 
			this.dimensionsLabel3.AutoSize = true;
			this.dimensionsLabel3.Location = new System.Drawing.Point(21, 73);
			this.dimensionsLabel3.Name = "dimensionsLabel3";
			this.dimensionsLabel3.Size = new System.Drawing.Size(41, 13);
			this.dimensionsLabel3.TabIndex = 5;
			this.dimensionsLabel3.Text = "Height:";
			// 
			// dimensionsLabel2
			// 
			this.dimensionsLabel2.AutoSize = true;
			this.dimensionsLabel2.Location = new System.Drawing.Point(19, 48);
			this.dimensionsLabel2.Name = "dimensionsLabel2";
			this.dimensionsLabel2.Size = new System.Drawing.Size(43, 13);
			this.dimensionsLabel2.TabIndex = 4;
			this.dimensionsLabel2.Text = "Length:";
			// 
			// dimensionsLabel1
			// 
			this.dimensionsLabel1.AutoSize = true;
			this.dimensionsLabel1.Location = new System.Drawing.Point(24, 22);
			this.dimensionsLabel1.Name = "dimensionsLabel1";
			this.dimensionsLabel1.Size = new System.Drawing.Size(38, 13);
			this.dimensionsLabel1.TabIndex = 3;
			this.dimensionsLabel1.Text = "Width:";
			// 
			// heightCounter
			// 
			this.heightCounter.Location = new System.Drawing.Point(62, 71);
			this.heightCounter.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.heightCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.heightCounter.Name = "heightCounter";
			this.heightCounter.Size = new System.Drawing.Size(58, 20);
			this.heightCounter.TabIndex = 2;
			this.ToolTip.SetToolTip(this.heightCounter, "The height of the Brick.\r\nPlease note that 1 height equals 1/3 stud.");
			this.heightCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.heightCounter.ValueChanged += new System.EventHandler(this.heightCounter_valueChanged);
			// 
			// lengthCounter
			// 
			this.lengthCounter.Location = new System.Drawing.Point(62, 45);
			this.lengthCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.lengthCounter.Name = "lengthCounter";
			this.lengthCounter.Size = new System.Drawing.Size(58, 20);
			this.lengthCounter.TabIndex = 1;
			this.ToolTip.SetToolTip(this.lengthCounter, "The length (in Studs) Of the brick.\r\nHas to be above or equal to the Width of the" +
        " Brick.");
			this.lengthCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.lengthCounter.ValueChanged += new System.EventHandler(this.lengthCounter_valueChanged);
			// 
			// widthCounter
			// 
			this.widthCounter.Location = new System.Drawing.Point(62, 19);
			this.widthCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.widthCounter.Name = "widthCounter";
			this.widthCounter.Size = new System.Drawing.Size(58, 20);
			this.widthCounter.TabIndex = 0;
			this.ToolTip.SetToolTip(this.widthCounter, "The width (in Studs) Of the brick.");
			this.widthCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.widthCounter.ValueChanged += new System.EventHandler(this.widthCounter_valueChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.descriptionBox);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.titleBox);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.nameBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(139, 111);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Options";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(37, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Description:";
			// 
			// descriptionBox
			// 
			this.descriptionBox.Location = new System.Drawing.Point(5, 72);
			this.descriptionBox.MaxLength = 200;
			this.descriptionBox.Multiline = true;
			this.descriptionBox.Name = "descriptionBox";
			this.descriptionBox.Size = new System.Drawing.Size(130, 35);
			this.descriptionBox.TabIndex = 7;
			this.descriptionBox.Text = "Please, don\'t leave this default.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 37);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Title:";
			// 
			// titleBox
			// 
			this.titleBox.Location = new System.Drawing.Point(63, 33);
			this.titleBox.MaxLength = 30;
			this.titleBox.Name = "titleBox";
			this.titleBox.Size = new System.Drawing.Size(69, 20);
			this.titleBox.TabIndex = 4;
			this.titleBox.Text = "brickPack";
			this.titleBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.titleBox_keyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 26);
			this.label5.TabIndex = 4;
			this.label5.Text = "Blockland\r\nName:";
			// 
			// nameBox
			// 
			this.nameBox.Location = new System.Drawing.Point(63, 9);
			this.nameBox.Name = "nameBox";
			this.nameBox.Size = new System.Drawing.Size(69, 20);
			this.nameBox.TabIndex = 3;
			this.nameBox.Text = "you shouldn\'t see this";
			this.nameBox.TextChanged += new System.EventHandler(this.nameBox_textChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.EmailLabel);
			this.tabPage3.Controls.Add(this.aboutLabel5);
			this.tabPage3.Controls.Add(this.aboutLabel4);
			this.tabPage3.Controls.Add(this.aboutLabel3);
			this.tabPage3.Controls.Add(this.aboutLabel2);
			this.tabPage3.Controls.Add(this.aboutLabel1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(139, 111);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "About";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// EmailLabel
			// 
			this.EmailLabel.AutoSize = true;
			this.EmailLabel.ForeColor = System.Drawing.Color.Blue;
			this.EmailLabel.Location = new System.Drawing.Point(35, 85);
			this.EmailLabel.Name = "EmailLabel";
			this.EmailLabel.Size = new System.Drawing.Size(102, 13);
			this.EmailLabel.TabIndex = 6;
			this.EmailLabel.Text = "Ipquarx@Gmail.com";
			// 
			// aboutLabel5
			// 
			this.aboutLabel5.AutoSize = true;
			this.aboutLabel5.Location = new System.Drawing.Point(4, 85);
			this.aboutLabel5.Name = "aboutLabel5";
			this.aboutLabel5.Size = new System.Drawing.Size(35, 13);
			this.aboutLabel5.TabIndex = 4;
			this.aboutLabel5.Text = "Email:";
			// 
			// aboutLabel4
			// 
			this.aboutLabel4.AutoSize = true;
			this.aboutLabel4.Location = new System.Drawing.Point(36, 68);
			this.aboutLabel4.Name = "aboutLabel4";
			this.aboutLabel4.Size = new System.Drawing.Size(68, 13);
			this.aboutLabel4.TabIndex = 3;
			this.aboutLabel4.Text = "Contact Info:";
			// 
			// aboutLabel3
			// 
			this.aboutLabel3.AutoSize = true;
			this.aboutLabel3.Location = new System.Drawing.Point(15, 44);
			this.aboutLabel3.Name = "aboutLabel3";
			this.aboutLabel3.Size = new System.Drawing.Size(111, 13);
			this.aboutLabel3.TabIndex = 2;
			this.aboutLabel3.Text = "Ipquarx (BL_ID: 9291)";
			// 
			// aboutLabel2
			// 
			this.aboutLabel2.AutoSize = true;
			this.aboutLabel2.Location = new System.Drawing.Point(39, 28);
			this.aboutLabel2.Name = "aboutLabel2";
			this.aboutLabel2.Size = new System.Drawing.Size(62, 13);
			this.aboutLabel2.TabIndex = 1;
			this.aboutLabel2.Text = "Created By:";
			// 
			// aboutLabel1
			// 
			this.aboutLabel1.AutoSize = true;
			this.aboutLabel1.Location = new System.Drawing.Point(24, 9);
			this.aboutLabel1.Name = "aboutLabel1";
			this.aboutLabel1.Size = new System.Drawing.Size(92, 13);
			this.aboutLabel1.TabIndex = 0;
			this.aboutLabel1.Text = "Brick Creator v2.8";
			// 
			// newBrickButton
			// 
			this.newBrickButton.Location = new System.Drawing.Point(9, 243);
			this.newBrickButton.Name = "newBrickButton";
			this.newBrickButton.Size = new System.Drawing.Size(75, 23);
			this.newBrickButton.TabIndex = 4;
			this.newBrickButton.Text = "New Brick";
			this.newBrickButton.UseVisualStyleBackColor = true;
			this.newBrickButton.Click += new System.EventHandler(this.newBrickButton_Click);
			// 
			// ToolTip
			// 
			this.ToolTip.AutoPopDelay = 5000;
			this.ToolTip.InitialDelay = 1000;
			this.ToolTip.ReshowDelay = 100;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(61, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 5;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.UiBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.subCatBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.categoryBox);
			this.groupBox1.Location = new System.Drawing.Point(127, 143);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(142, 96);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Brick Info";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "UiName:";
			// 
			// UiBox
			// 
			this.UiBox.Enabled = false;
			this.UiBox.Location = new System.Drawing.Point(55, 70);
			this.UiBox.Name = "UiBox";
			this.UiBox.Size = new System.Drawing.Size(81, 20);
			this.UiBox.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 26);
			this.label3.TabIndex = 3;
			this.label3.Text = "Sub-\r\nCategory:";
			// 
			// subCatBox
			// 
			this.subCatBox.Enabled = false;
			this.subCatBox.Location = new System.Drawing.Point(55, 45);
			this.subCatBox.Name = "subCatBox";
			this.subCatBox.Size = new System.Drawing.Size(81, 20);
			this.subCatBox.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Category:";
			// 
			// categoryBox
			// 
			this.categoryBox.Enabled = false;
			this.categoryBox.Location = new System.Drawing.Point(55, 19);
			this.categoryBox.Name = "categoryBox";
			this.categoryBox.Size = new System.Drawing.Size(81, 20);
			this.categoryBox.TabIndex = 3;
			// 
			// packBrickButton
			// 
			this.packBrickButton.Location = new System.Drawing.Point(93, 243);
			this.packBrickButton.Name = "packBrickButton";
			this.packBrickButton.Size = new System.Drawing.Size(92, 23);
			this.packBrickButton.TabIndex = 7;
			this.packBrickButton.Text = "Package Bricks";
			this.packBrickButton.UseVisualStyleBackColor = true;
			this.packBrickButton.Click += new System.EventHandler(this.packBrickButton_Click);
			// 
			// saveBrickButton
			// 
			this.saveBrickButton.Location = new System.Drawing.Point(194, 243);
			this.saveBrickButton.Name = "saveBrickButton";
			this.saveBrickButton.Size = new System.Drawing.Size(75, 23);
			this.saveBrickButton.TabIndex = 8;
			this.saveBrickButton.Text = "Save Brick";
			this.saveBrickButton.UseVisualStyleBackColor = true;
			this.saveBrickButton.Click += new System.EventHandler(this.saveBrickButton_Click);
			// 
			// brickCreatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 269);
			this.Controls.Add(this.saveBrickButton);
			this.Controls.Add(this.packBrickButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.newBrickButton);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.ListLabel);
			this.Controls.Add(this.brickListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "brickCreatorForm";
			this.ShowIcon = false;
			this.Text = "Brick Creator v2.8";
			this.Load += new System.EventHandler(this.brickCreatorForm_Load);
			this.listRightClickMenu.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.heightCounter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lengthCounter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.widthCounter)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.TextBox descriptionBox;
		private System.Windows.Forms.Label label7;

		#endregion

		private System.Windows.Forms.ListBox brickListBox;
		private System.Windows.Forms.Label ListLabel;
		private System.Windows.Forms.ContextMenuStrip listRightClickMenu;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label aboutLabel5;
		private System.Windows.Forms.Label aboutLabel4;
		private System.Windows.Forms.Label aboutLabel3;
		private System.Windows.Forms.Label aboutLabel2;
		private System.Windows.Forms.Label aboutLabel1;
		private System.Windows.Forms.NumericUpDown widthCounter;
		private System.Windows.Forms.NumericUpDown heightCounter;
		private System.Windows.Forms.NumericUpDown lengthCounter;
		private System.Windows.Forms.Label dimensionsLabel1;
		private System.Windows.Forms.Label dimensionsLabel2;
		private System.Windows.Forms.Label dimensionsLabel3;
		private System.Windows.Forms.Label EmailLabel;
		private System.Windows.Forms.Button newBrickButton;
		private System.Windows.Forms.ToolTip ToolTip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox UiBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox subCatBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox categoryBox;
		private System.Windows.Forms.Button packBrickButton;
		private System.Windows.Forms.Button saveBrickButton;
		private System.Windows.Forms.TextBox nameBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox titleBox;
		private System.Windows.Forms.Label label5;
	}
}
