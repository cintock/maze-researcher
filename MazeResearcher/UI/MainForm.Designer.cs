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
		private System.Windows.Forms.Button buttonCheckMaze;
		private System.Windows.Forms.Button createMazeButton;
		private System.Windows.Forms.ComboBox generatorCheckbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar widthTrackbar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar heightTrackbar;
		private System.Windows.Forms.Label labelMazeSize;
		
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
			this.buttonCheckMaze = new System.Windows.Forms.Button();
			this.createMazeButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.generatorCheckbox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.widthTrackbar = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.heightTrackbar = new System.Windows.Forms.TrackBar();
			this.labelMazeSize = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.somePicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.widthTrackbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.heightTrackbar)).BeginInit();
			this.SuspendLayout();
			// 
			// somePicture
			// 
			this.somePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.somePicture.Location = new System.Drawing.Point(12, 222);
			this.somePicture.Name = "somePicture";
			this.somePicture.Size = new System.Drawing.Size(523, 372);
			this.somePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.somePicture.TabIndex = 4;
			this.somePicture.TabStop = false;
			// 
			// drawButton
			// 
			this.drawButton.Location = new System.Drawing.Point(12, 180);
			this.drawButton.Name = "drawButton";
			this.drawButton.Size = new System.Drawing.Size(95, 23);
			this.drawButton.TabIndex = 5;
			this.drawButton.Text = "Нарисовать";
			this.drawButton.UseVisualStyleBackColor = true;
			this.drawButton.Click += new System.EventHandler(this.DrawButtonClick);
			// 
			// cleanButton
			// 
			this.cleanButton.Location = new System.Drawing.Point(132, 180);
			this.cleanButton.Name = "cleanButton";
			this.cleanButton.Size = new System.Drawing.Size(75, 23);
			this.cleanButton.TabIndex = 6;
			this.cleanButton.Text = "Стереть";
			this.cleanButton.UseVisualStyleBackColor = true;
			this.cleanButton.Click += new System.EventHandler(this.CleanButtonClick);
			// 
			// buttonCheckMaze
			// 
			this.buttonCheckMaze.Location = new System.Drawing.Point(228, 180);
			this.buttonCheckMaze.Name = "buttonCheckMaze";
			this.buttonCheckMaze.Size = new System.Drawing.Size(140, 23);
			this.buttonCheckMaze.TabIndex = 7;
			this.buttonCheckMaze.Text = "Проверить лабиринт";
			this.buttonCheckMaze.UseVisualStyleBackColor = true;
			this.buttonCheckMaze.Click += new System.EventHandler(this.ButtonCheckMazeClick);
			// 
			// createMazeButton
			// 
			this.createMazeButton.Location = new System.Drawing.Point(12, 137);
			this.createMazeButton.Name = "createMazeButton";
			this.createMazeButton.Size = new System.Drawing.Size(139, 23);
			this.createMazeButton.TabIndex = 8;
			this.createMazeButton.Text = "Создать лабиринт";
			this.createMazeButton.UseVisualStyleBackColor = true;
			this.createMazeButton.Click += new System.EventHandler(this.CreateMazeButtonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "Алгоритм создания";
			// 
			// generatorCheckbox
			// 
			this.generatorCheckbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.generatorCheckbox.FormattingEnabled = true;
			this.generatorCheckbox.Location = new System.Drawing.Point(181, 14);
			this.generatorCheckbox.Name = "generatorCheckbox";
			this.generatorCheckbox.Size = new System.Drawing.Size(354, 21);
			this.generatorCheckbox.TabIndex = 10;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "Ширина (столбцов)";
			// 
			// widthTrackbar
			// 
			this.widthTrackbar.Location = new System.Drawing.Point(172, 41);
			this.widthTrackbar.Maximum = 100;
			this.widthTrackbar.Minimum = 1;
			this.widthTrackbar.Name = "widthTrackbar";
			this.widthTrackbar.Size = new System.Drawing.Size(363, 45);
			this.widthTrackbar.TabIndex = 12;
			this.widthTrackbar.Value = 25;
			this.widthTrackbar.ValueChanged += new System.EventHandler(this.SizeTrackbarChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(132, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "Высота (строк)";
			// 
			// heightTrackbar
			// 
			this.heightTrackbar.Location = new System.Drawing.Point(172, 85);
			this.heightTrackbar.Maximum = 100;
			this.heightTrackbar.Minimum = 1;
			this.heightTrackbar.Name = "heightTrackbar";
			this.heightTrackbar.Size = new System.Drawing.Size(363, 45);
			this.heightTrackbar.TabIndex = 14;
			this.heightTrackbar.Value = 25;
			this.heightTrackbar.ValueChanged += new System.EventHandler(this.SizeTrackbarChanged);
			// 
			// labelMazeSize
			// 
			this.labelMazeSize.Location = new System.Drawing.Point(172, 137);
			this.labelMazeSize.Name = "labelMazeSize";
			this.labelMazeSize.Size = new System.Drawing.Size(147, 23);
			this.labelMazeSize.TabIndex = 15;
			this.labelMazeSize.Text = "-";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 606);
			this.Controls.Add(this.labelMazeSize);
			this.Controls.Add(this.heightTrackbar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.widthTrackbar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.generatorCheckbox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.createMazeButton);
			this.Controls.Add(this.buttonCheckMaze);
			this.Controls.Add(this.cleanButton);
			this.Controls.Add(this.drawButton);
			this.Controls.Add(this.somePicture);
			this.Name = "MainForm";
			this.Text = "Лабиринты";
			((System.ComponentModel.ISupportInitialize)(this.somePicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.widthTrackbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.heightTrackbar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
