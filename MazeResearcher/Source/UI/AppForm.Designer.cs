namespace Maze.UI
{
    partial class AppForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.mazeConfigurationTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mazeGenerationAlgoCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mazeColumnsTrackbar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.mazeRowsTrackbar = new System.Windows.Forms.TrackBar();
            this.createMazeButton = new System.Windows.Forms.Button();
            this.debugLoggingCheckbox = new System.Windows.Forms.CheckBox();
            this.mazeSizeLabel = new System.Windows.Forms.Label();
            this.mazeViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mazePicturebox = new System.Windows.Forms.PictureBox();
            this.debugConsole = new System.Windows.Forms.TextBox();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.showMazeClusters = new System.Windows.Forms.CheckBox();
            this.mazeConfigurationTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeColumnsTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeRowsTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeViewSplitContainer)).BeginInit();
            this.mazeViewSplitContainer.Panel1.SuspendLayout();
            this.mazeViewSplitContainer.Panel2.SuspendLayout();
            this.mazeViewSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePicturebox)).BeginInit();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм создания";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mazeConfigurationTableLayoutPanel
            // 
            this.mazeConfigurationTableLayoutPanel.ColumnCount = 3;
            this.mazeConfigurationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mazeConfigurationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mazeConfigurationTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.mazeGenerationAlgoCombobox, 1, 0);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.mazeColumnsTrackbar, 1, 1);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.mazeRowsTrackbar, 1, 2);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.createMazeButton, 0, 3);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.debugLoggingCheckbox, 2, 0);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.mazeSizeLabel, 1, 3);
            this.mazeConfigurationTableLayoutPanel.Controls.Add(this.showMazeClusters, 2, 1);
            this.mazeConfigurationTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeConfigurationTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.mazeConfigurationTableLayoutPanel.Name = "mazeConfigurationTableLayoutPanel";
            this.mazeConfigurationTableLayoutPanel.RowCount = 5;
            this.mazeConfigurationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mazeConfigurationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mazeConfigurationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mazeConfigurationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mazeConfigurationTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mazeConfigurationTableLayoutPanel.Size = new System.Drawing.Size(997, 172);
            this.mazeConfigurationTableLayoutPanel.TabIndex = 1;
            // 
            // mazeGenerationAlgoCombobox
            // 
            this.mazeGenerationAlgoCombobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeGenerationAlgoCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mazeGenerationAlgoCombobox.FormattingEnabled = true;
            this.mazeGenerationAlgoCombobox.Location = new System.Drawing.Point(135, 3);
            this.mazeGenerationAlgoCombobox.Name = "mazeGenerationAlgoCombobox";
            this.mazeGenerationAlgoCombobox.Size = new System.Drawing.Size(614, 21);
            this.mazeGenerationAlgoCombobox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 51);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ширина (столбцов)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mazeColumnsTrackbar
            // 
            this.mazeColumnsTrackbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeColumnsTrackbar.Location = new System.Drawing.Point(135, 30);
            this.mazeColumnsTrackbar.Maximum = 100;
            this.mazeColumnsTrackbar.Minimum = 1;
            this.mazeColumnsTrackbar.Name = "mazeColumnsTrackbar";
            this.mazeColumnsTrackbar.Size = new System.Drawing.Size(614, 45);
            this.mazeColumnsTrackbar.TabIndex = 3;
            this.mazeColumnsTrackbar.Value = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 51);
            this.label3.TabIndex = 4;
            this.label3.Text = "Высота (строк)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mazeRowsTrackbar
            // 
            this.mazeRowsTrackbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeRowsTrackbar.Location = new System.Drawing.Point(135, 81);
            this.mazeRowsTrackbar.Maximum = 100;
            this.mazeRowsTrackbar.Minimum = 1;
            this.mazeRowsTrackbar.Name = "mazeRowsTrackbar";
            this.mazeRowsTrackbar.Size = new System.Drawing.Size(614, 45);
            this.mazeRowsTrackbar.TabIndex = 5;
            this.mazeRowsTrackbar.Value = 35;
            // 
            // createMazeButton
            // 
            this.createMazeButton.Location = new System.Drawing.Point(3, 132);
            this.createMazeButton.Name = "createMazeButton";
            this.createMazeButton.Size = new System.Drawing.Size(126, 23);
            this.createMazeButton.TabIndex = 6;
            this.createMazeButton.Text = "Создать лабиринт";
            this.createMazeButton.UseVisualStyleBackColor = true;
            this.createMazeButton.Click += new System.EventHandler(this.CreateMazeButtonClick);
            // 
            // debugLoggingCheckbox
            // 
            this.debugLoggingCheckbox.AutoSize = true;
            this.debugLoggingCheckbox.Location = new System.Drawing.Point(755, 3);
            this.debugLoggingCheckbox.Name = "debugLoggingCheckbox";
            this.debugLoggingCheckbox.Size = new System.Drawing.Size(154, 17);
            this.debugLoggingCheckbox.TabIndex = 7;
            this.debugLoggingCheckbox.Text = "Отладочное логирование";
            this.debugLoggingCheckbox.UseVisualStyleBackColor = true;
            this.debugLoggingCheckbox.CheckedChanged += new System.EventHandler(this.LogCheckboxCheckStateChanged);
            // 
            // mazeSizeLabel
            // 
            this.mazeSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mazeSizeLabel.AutoSize = true;
            this.mazeSizeLabel.Location = new System.Drawing.Point(135, 137);
            this.mazeSizeLabel.Name = "mazeSizeLabel";
            this.mazeSizeLabel.Size = new System.Drawing.Size(10, 13);
            this.mazeSizeLabel.TabIndex = 8;
            this.mazeSizeLabel.Text = "-";
            // 
            // mazeViewSplitContainer
            // 
            this.mazeViewSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mazeViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazeViewSplitContainer.Location = new System.Drawing.Point(3, 181);
            this.mazeViewSplitContainer.Name = "mazeViewSplitContainer";
            // 
            // mazeViewSplitContainer.Panel1
            // 
            this.mazeViewSplitContainer.Panel1.Controls.Add(this.mazePicturebox);
            // 
            // mazeViewSplitContainer.Panel2
            // 
            this.mazeViewSplitContainer.Panel2.Controls.Add(this.debugConsole);
            this.mazeViewSplitContainer.Size = new System.Drawing.Size(997, 398);
            this.mazeViewSplitContainer.SplitterDistance = 602;
            this.mazeViewSplitContainer.TabIndex = 2;
            // 
            // mazePicturebox
            // 
            this.mazePicturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mazePicturebox.Location = new System.Drawing.Point(0, 0);
            this.mazePicturebox.Name = "mazePicturebox";
            this.mazePicturebox.Size = new System.Drawing.Size(598, 394);
            this.mazePicturebox.TabIndex = 3;
            this.mazePicturebox.TabStop = false;
            // 
            // debugConsole
            // 
            this.debugConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugConsole.Location = new System.Drawing.Point(0, 0);
            this.debugConsole.Multiline = true;
            this.debugConsole.Name = "debugConsole";
            this.debugConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.debugConsole.Size = new System.Drawing.Size(387, 394);
            this.debugConsole.TabIndex = 0;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.mazeViewSplitContainer, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.mazeConfigurationTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1003, 582);
            this.mainTableLayoutPanel.TabIndex = 3;
            // 
            // showMazeClusters
            // 
            this.showMazeClusters.AutoSize = true;
            this.showMazeClusters.Location = new System.Drawing.Point(755, 30);
            this.showMazeClusters.Name = "showMazeClusters";
            this.showMazeClusters.Size = new System.Drawing.Size(204, 17);
            this.showMazeClusters.TabIndex = 9;
            this.showMazeClusters.Text = "Отобразить связанность областей";
            this.showMazeClusters.UseVisualStyleBackColor = true;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 582);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "AppForm";
            this.Text = "AppForm";
            this.mazeConfigurationTableLayoutPanel.ResumeLayout(false);
            this.mazeConfigurationTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeColumnsTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeRowsTrackbar)).EndInit();
            this.mazeViewSplitContainer.Panel1.ResumeLayout(false);
            this.mazeViewSplitContainer.Panel2.ResumeLayout(false);
            this.mazeViewSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeViewSplitContainer)).EndInit();
            this.mazeViewSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mazePicturebox)).EndInit();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel mazeConfigurationTableLayoutPanel;
        private System.Windows.Forms.ComboBox mazeGenerationAlgoCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar mazeColumnsTrackbar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar mazeRowsTrackbar;
        private System.Windows.Forms.Button createMazeButton;
        private System.Windows.Forms.SplitContainer mazeViewSplitContainer;
        private System.Windows.Forms.PictureBox mazePicturebox;
        private System.Windows.Forms.TextBox debugConsole;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.CheckBox debugLoggingCheckbox;
        private System.Windows.Forms.Label mazeSizeLabel;
        private System.Windows.Forms.CheckBox showMazeClusters;
    }
}