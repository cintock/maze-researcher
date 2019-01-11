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
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.versionTextbox = new System.Windows.Forms.TextBox();
            this.clustersCountTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.somePicture = new System.Windows.Forms.PictureBox();
            this.labelMazeSize = new System.Windows.Forms.Label();
            this.createMazeButton = new System.Windows.Forms.Button();
            this.buttonCluster = new System.Windows.Forms.Button();
            this.drawButton = new System.Windows.Forms.Button();
            this.generatorCheckbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthTrackbar = new System.Windows.Forms.TrackBar();
            this.heightTrackbar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.logCheckbox = new System.Windows.Forms.CheckBox();
            this.debugConsole = new System.Windows.Forms.TextBox();
            this.cleanButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.somePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.versionTextbox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.clustersCountTextbox, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.somePicture, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelMazeSize, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.createMazeButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonCluster, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.drawButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.generatorCheckbox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.widthTrackbar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.heightTrackbar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.logCheckbox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.debugConsole, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cleanButton, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.13008F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.13008F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.13008F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.13008F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.13008F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.13008F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.21952F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 530);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // versionTextbox
            // 
            this.versionTextbox.Location = new System.Drawing.Point(375, 507);
            this.versionTextbox.Name = "versionTextbox";
            this.versionTextbox.ReadOnly = true;
            this.versionTextbox.Size = new System.Drawing.Size(130, 20);
            this.versionTextbox.TabIndex = 20;
            // 
            // clustersCountTextbox
            // 
            this.clustersCountTextbox.Location = new System.Drawing.Point(3, 507);
            this.clustersCountTextbox.Name = "clustersCountTextbox";
            this.clustersCountTextbox.ReadOnly = true;
            this.clustersCountTextbox.Size = new System.Drawing.Size(75, 20);
            this.clustersCountTextbox.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 484);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Количество областей";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(375, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Номер версии";
            // 
            // somePicture
            // 
            this.somePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.somePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.somePicture.Location = new System.Drawing.Point(3, 237);
            this.somePicture.Name = "somePicture";
            this.somePicture.Size = new System.Drawing.Size(366, 244);
            this.somePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.somePicture.TabIndex = 18;
            this.somePicture.TabStop = false;
            // 
            // labelMazeSize
            // 
            this.labelMazeSize.AutoSize = true;
            this.labelMazeSize.Location = new System.Drawing.Point(375, 195);
            this.labelMazeSize.Name = "labelMazeSize";
            this.labelMazeSize.Size = new System.Drawing.Size(10, 13);
            this.labelMazeSize.TabIndex = 15;
            this.labelMazeSize.Text = "-";
            // 
            // createMazeButton
            // 
            this.createMazeButton.Location = new System.Drawing.Point(3, 120);
            this.createMazeButton.Name = "createMazeButton";
            this.createMazeButton.Size = new System.Drawing.Size(139, 28);
            this.createMazeButton.TabIndex = 8;
            this.createMazeButton.Text = "Создать лабиринт";
            this.createMazeButton.UseVisualStyleBackColor = true;
            // 
            // buttonCluster
            // 
            this.buttonCluster.AutoSize = true;
            this.buttonCluster.Location = new System.Drawing.Point(3, 198);
            this.buttonCluster.Name = "buttonCluster";
            this.buttonCluster.Size = new System.Drawing.Size(138, 23);
            this.buttonCluster.TabIndex = 7;
            this.buttonCluster.Text = "Разделить по областям";
            this.buttonCluster.UseVisualStyleBackColor = true;
            this.buttonCluster.Click += new System.EventHandler(this.ClusterButtonClick);
            // 
            // drawButton
            // 
            this.drawButton.AutoSize = true;
            this.drawButton.Location = new System.Drawing.Point(3, 159);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(78, 23);
            this.drawButton.TabIndex = 5;
            this.drawButton.Text = "Нарисовать";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.DrawButtonClick);
            // 
            // generatorCheckbox
            // 
            this.generatorCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.generatorCheckbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generatorCheckbox.FormattingEnabled = true;
            this.generatorCheckbox.Location = new System.Drawing.Point(375, 81);
            this.generatorCheckbox.Name = "generatorCheckbox";
            this.generatorCheckbox.Size = new System.Drawing.Size(367, 21);
            this.generatorCheckbox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Алгоритм создания";
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
            this.widthTrackbar.Location = new System.Drawing.Point(375, 3);
            this.widthTrackbar.Maximum = 100;
            this.widthTrackbar.Minimum = 1;
            this.widthTrackbar.Name = "widthTrackbar";
            this.widthTrackbar.Size = new System.Drawing.Size(254, 33);
            this.widthTrackbar.TabIndex = 12;
            this.widthTrackbar.Value = 25;
            this.widthTrackbar.ValueChanged += new System.EventHandler(this.SizeTrackbarChanged);
            // 
            // heightTrackbar
            // 
            this.heightTrackbar.Location = new System.Drawing.Point(375, 42);
            this.heightTrackbar.Maximum = 100;
            this.heightTrackbar.Minimum = 1;
            this.heightTrackbar.Name = "heightTrackbar";
            this.heightTrackbar.Size = new System.Drawing.Size(254, 33);
            this.heightTrackbar.TabIndex = 14;
            this.heightTrackbar.Value = 25;
            this.heightTrackbar.ValueChanged += new System.EventHandler(this.SizeTrackbarChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Высота (строк)";
            // 
            // logCheckbox
            // 
            this.logCheckbox.Location = new System.Drawing.Point(375, 120);
            this.logCheckbox.Name = "logCheckbox";
            this.logCheckbox.Size = new System.Drawing.Size(167, 28);
            this.logCheckbox.TabIndex = 17;
            this.logCheckbox.Text = "Отладочное логирование";
            this.logCheckbox.UseVisualStyleBackColor = true;
            this.logCheckbox.CheckedChanged += new System.EventHandler(this.LogCheckboxCheckStateChanged);
            // 
            // debugConsole
            // 
            this.debugConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugConsole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.debugConsole.Location = new System.Drawing.Point(375, 237);
            this.debugConsole.Multiline = true;
            this.debugConsole.Name = "debugConsole";
            this.debugConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.debugConsole.Size = new System.Drawing.Size(367, 244);
            this.debugConsole.TabIndex = 16;
            this.debugConsole.WordWrap = false;
            // 
            // cleanButton
            // 
            this.cleanButton.AutoSize = true;
            this.cleanButton.Location = new System.Drawing.Point(375, 159);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(58, 23);
            this.cleanButton.TabIndex = 6;
            this.cleanButton.Text = "Стереть";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.CleanButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Лабиринты";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.somePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
