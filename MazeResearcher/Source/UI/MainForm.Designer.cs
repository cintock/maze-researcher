/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
namespace Maze.UI
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox somePicture;
		private System.Windows.Forms.Button drawButton;
		private System.Windows.Forms.Button cleanButton;
		private System.Windows.Forms.Button buttonCluster;
		private System.Windows.Forms.Button createMazeButton;
		private System.Windows.Forms.ComboBox generatorCheckbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar widthTrackbar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar heightTrackbar;
		private System.Windows.Forms.Label labelMazeSize;
		private System.Windows.Forms.TextBox debugConsole;
		private System.Windows.Forms.CheckBox logCheckbox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox clustersCountTextbox;
		private System.Windows.Forms.TextBox versionTextbox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.somePicture = new System.Windows.Forms.PictureBox();
			this.drawButton = new System.Windows.Forms.Button();
			this.cleanButton = new System.Windows.Forms.Button();
			this.buttonCluster = new System.Windows.Forms.Button();
			this.createMazeButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.generatorCheckbox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.widthTrackbar = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.heightTrackbar = new System.Windows.Forms.TrackBar();
			this.labelMazeSize = new System.Windows.Forms.Label();
			this.debugConsole = new System.Windows.Forms.TextBox();
			this.logCheckbox = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.clustersCountTextbox = new System.Windows.Forms.TextBox();
			this.versionTextbox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.somePicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.widthTrackbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.heightTrackbar)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// somePicture
			// 
			this.somePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.somePicture.Location = new System.Drawing.Point(3, 219);
			this.somePicture.Name = "somePicture";
			this.somePicture.Size = new System.Drawing.Size(288, 269);
			this.somePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.somePicture.TabIndex = 4;
			this.somePicture.TabStop = false;
			// 
			// drawButton
			// 
			this.drawButton.Location = new System.Drawing.Point(3, 153);
			this.drawButton.Name = "drawButton";
			this.drawButton.Size = new System.Drawing.Size(95, 14);
			this.drawButton.TabIndex = 5;
			this.drawButton.Text = "Нарисовать";
			this.drawButton.UseVisualStyleBackColor = true;
			this.drawButton.Click += new System.EventHandler(this.DrawButtonClick);
			// 
			// cleanButton
			// 
			this.cleanButton.Location = new System.Drawing.Point(263, 153);
			this.cleanButton.Name = "cleanButton";
			this.cleanButton.Size = new System.Drawing.Size(75, 14);
			this.cleanButton.TabIndex = 6;
			this.cleanButton.Text = "Стереть";
			this.cleanButton.UseVisualStyleBackColor = true;
			this.cleanButton.Click += new System.EventHandler(this.CleanButtonClick);
			// 
			// buttonCluster
			// 
			this.buttonCluster.Location = new System.Drawing.Point(3, 173);
			this.buttonCluster.Name = "buttonCluster";
			this.buttonCluster.Size = new System.Drawing.Size(146, 14);
			this.buttonCluster.TabIndex = 7;
			this.buttonCluster.Text = "Разделить по областям";
			this.buttonCluster.UseVisualStyleBackColor = true;
			this.buttonCluster.Click += new System.EventHandler(this.ClusterButtonClick);
			// 
			// createMazeButton
			// 
			this.createMazeButton.Location = new System.Drawing.Point(3, 133);
			this.createMazeButton.Name = "createMazeButton";
			this.createMazeButton.Size = new System.Drawing.Size(139, 14);
			this.createMazeButton.TabIndex = 8;
			this.createMazeButton.Text = "Создать лабиринт";
			this.createMazeButton.UseVisualStyleBackColor = true;
			this.createMazeButton.Click += new System.EventHandler(this.CreateMazeButtonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 110);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "Алгоритм создания";
			// 
			// generatorCheckbox
			// 
			this.generatorCheckbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.generatorCheckbox.FormattingEnabled = true;
			this.generatorCheckbox.Location = new System.Drawing.Point(263, 113);
			this.generatorCheckbox.Name = "generatorCheckbox";
			this.generatorCheckbox.Size = new System.Drawing.Size(254, 21);
			this.generatorCheckbox.TabIndex = 10;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "Ширина (столбцов)";
			// 
			// widthTrackbar
			// 
			this.widthTrackbar.Location = new System.Drawing.Point(263, 3);
			this.widthTrackbar.Maximum = 100;
			this.widthTrackbar.Minimum = 1;
			this.widthTrackbar.Name = "widthTrackbar";
			this.widthTrackbar.Size = new System.Drawing.Size(254, 45);
			this.widthTrackbar.TabIndex = 12;
			this.widthTrackbar.Value = 25;
			this.widthTrackbar.ValueChanged += new System.EventHandler(this.SizeTrackbarChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(132, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "Высота (строк)";
			// 
			// heightTrackbar
			// 
			this.heightTrackbar.Location = new System.Drawing.Point(263, 58);
			this.heightTrackbar.Maximum = 100;
			this.heightTrackbar.Minimum = 1;
			this.heightTrackbar.Name = "heightTrackbar";
			this.heightTrackbar.Size = new System.Drawing.Size(254, 45);
			this.heightTrackbar.TabIndex = 14;
			this.heightTrackbar.Value = 25;
			this.heightTrackbar.ValueChanged += new System.EventHandler(this.SizeTrackbarChanged);
			// 
			// labelMazeSize
			// 
			this.labelMazeSize.Location = new System.Drawing.Point(263, 170);
			this.labelMazeSize.Name = "labelMazeSize";
			this.labelMazeSize.Size = new System.Drawing.Size(147, 20);
			this.labelMazeSize.TabIndex = 15;
			this.labelMazeSize.Text = "-";
			// 
			// debugConsole
			// 
			this.debugConsole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.debugConsole.Location = new System.Drawing.Point(3, 52);
			this.debugConsole.Multiline = true;
			this.debugConsole.Name = "debugConsole";
			this.debugConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.debugConsole.Size = new System.Drawing.Size(245, 83);
			this.debugConsole.TabIndex = 16;
			this.debugConsole.WordWrap = false;
			// 
			// logCheckbox
			// 
			this.logCheckbox.Location = new System.Drawing.Point(263, 133);
			this.logCheckbox.Name = "logCheckbox";
			this.logCheckbox.Size = new System.Drawing.Size(167, 14);
			this.logCheckbox.TabIndex = 17;
			this.logCheckbox.Text = "Отладочное логирование";
			this.logCheckbox.UseVisualStyleBackColor = true;
			this.logCheckbox.CheckStateChanged += new System.EventHandler(this.LogCheckboxCheckStateChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 190);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 14);
			this.label4.TabIndex = 18;
			this.label4.Text = "Количество областей";
			// 
			// clustersCountTextbox
			// 
			this.clustersCountTextbox.Location = new System.Drawing.Point(263, 193);
			this.clustersCountTextbox.Name = "clustersCountTextbox";
			this.clustersCountTextbox.ReadOnly = true;
			this.clustersCountTextbox.Size = new System.Drawing.Size(75, 20);
			this.clustersCountTextbox.TabIndex = 19;
			// 
			// versionTextbox
			// 
			this.versionTextbox.Location = new System.Drawing.Point(3, 26);
			this.versionTextbox.Name = "versionTextbox";
			this.versionTextbox.ReadOnly = true;
			this.versionTextbox.Size = new System.Drawing.Size(130, 20);
			this.versionTextbox.TabIndex = 20;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(86, 23);
			this.label5.TabIndex = 21;
			this.label5.Text = "Номер версии";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
			this.flowLayoutPanel1.Controls.Add(this.somePicture);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 495);
			this.flowLayoutPanel1.TabIndex = 22;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.labelMazeSize, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.createMazeButton, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.buttonCluster, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.clustersCountTextbox, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.cleanButton, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.drawButton, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.logCheckbox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.generatorCheckbox, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.widthTrackbar, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.heightTrackbar, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 210);
			this.tableLayoutPanel1.TabIndex = 24;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.label5);
			this.flowLayoutPanel2.Controls.Add(this.versionTextbox);
			this.flowLayoutPanel2.Controls.Add(this.debugConsole);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(25, 299);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(187, 145);
			this.flowLayoutPanel2.TabIndex = 23;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Location = new System.Drawing.Point(36, 23);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
			this.splitContainer1.Size = new System.Drawing.Size(1035, 571);
			this.splitContainer1.SplitterDistance = 800;
			this.splitContainer1.TabIndex = 24;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1083, 606);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MainForm";
			this.Text = "Лабиринты";
			((System.ComponentModel.ISupportInitialize)(this.somePicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.widthTrackbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.heightTrackbar)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
