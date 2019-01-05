/*
 * Author: cintock
 * Date: 05.01.2019
 * Created by SharpDevelop.
 */
namespace tests
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox memorySizeTextbox;
		private System.Windows.Forms.Button allocMemButton;
		private System.Windows.Forms.Button resetMemButton;
		private System.Windows.Forms.PictureBox somePicture;
		private System.Windows.Forms.Button drawButton;
		private System.Windows.Forms.Button cleanButton;
		private System.Windows.Forms.Button buttonCheckMaze;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.memorySizeTextbox = new System.Windows.Forms.TextBox();
			this.allocMemButton = new System.Windows.Forms.Button();
			this.resetMemButton = new System.Windows.Forms.Button();
			this.somePicture = new System.Windows.Forms.PictureBox();
			this.drawButton = new System.Windows.Forms.Button();
			this.cleanButton = new System.Windows.Forms.Button();
			this.buttonCheckMaze = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.somePicture)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(45, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Выделить память (МБ)";
			// 
			// memorySizeTextbox
			// 
			this.memorySizeTextbox.Location = new System.Drawing.Point(185, 42);
			this.memorySizeTextbox.Name = "memorySizeTextbox";
			this.memorySizeTextbox.Size = new System.Drawing.Size(100, 20);
			this.memorySizeTextbox.TabIndex = 1;
			// 
			// allocMemButton
			// 
			this.allocMemButton.Location = new System.Drawing.Point(308, 40);
			this.allocMemButton.Name = "allocMemButton";
			this.allocMemButton.Size = new System.Drawing.Size(75, 23);
			this.allocMemButton.TabIndex = 2;
			this.allocMemButton.Text = "Выделить";
			this.allocMemButton.UseVisualStyleBackColor = true;
			this.allocMemButton.Click += new System.EventHandler(this.AllocMemButtonClick);
			// 
			// resetMemButton
			// 
			this.resetMemButton.Location = new System.Drawing.Point(45, 82);
			this.resetMemButton.Name = "resetMemButton";
			this.resetMemButton.Size = new System.Drawing.Size(75, 23);
			this.resetMemButton.TabIndex = 3;
			this.resetMemButton.Text = "Очистить";
			this.resetMemButton.UseVisualStyleBackColor = true;
			this.resetMemButton.Click += new System.EventHandler(this.ResetMemButtonClick);
			// 
			// somePicture
			// 
			this.somePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.somePicture.Location = new System.Drawing.Point(45, 206);
			this.somePicture.Name = "somePicture";
			this.somePicture.Size = new System.Drawing.Size(467, 295);
			this.somePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.somePicture.TabIndex = 4;
			this.somePicture.TabStop = false;
			// 
			// drawButton
			// 
			this.drawButton.Location = new System.Drawing.Point(45, 139);
			this.drawButton.Name = "drawButton";
			this.drawButton.Size = new System.Drawing.Size(95, 23);
			this.drawButton.TabIndex = 5;
			this.drawButton.Text = "Нарисовать";
			this.drawButton.UseVisualStyleBackColor = true;
			this.drawButton.Click += new System.EventHandler(this.DrawButtonClick);
			// 
			// cleanButton
			// 
			this.cleanButton.Location = new System.Drawing.Point(163, 139);
			this.cleanButton.Name = "cleanButton";
			this.cleanButton.Size = new System.Drawing.Size(75, 23);
			this.cleanButton.TabIndex = 6;
			this.cleanButton.Text = "Стереть";
			this.cleanButton.UseVisualStyleBackColor = true;
			this.cleanButton.Click += new System.EventHandler(this.CleanButtonClick);
			// 
			// buttonCheckMaze
			// 
			this.buttonCheckMaze.Location = new System.Drawing.Point(277, 139);
			this.buttonCheckMaze.Name = "buttonCheckMaze";
			this.buttonCheckMaze.Size = new System.Drawing.Size(140, 23);
			this.buttonCheckMaze.TabIndex = 7;
			this.buttonCheckMaze.Text = "Проверить лабиринт";
			this.buttonCheckMaze.UseVisualStyleBackColor = true;
			this.buttonCheckMaze.Click += new System.EventHandler(this.ButtonCheckMazeClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 527);
			this.Controls.Add(this.buttonCheckMaze);
			this.Controls.Add(this.cleanButton);
			this.Controls.Add(this.drawButton);
			this.Controls.Add(this.somePicture);
			this.Controls.Add(this.resetMemButton);
			this.Controls.Add(this.allocMemButton);
			this.Controls.Add(this.memorySizeTextbox);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "tests";
			((System.ComponentModel.ISupportInitialize)(this.somePicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
