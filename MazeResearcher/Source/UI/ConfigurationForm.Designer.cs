namespace Maze.UI
{
    partial class ConfigurationForm
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
            this.groupBoxMazePaint = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sideColorButton = new System.Windows.Forms.Button();
            this.borderColorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingAlgoCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cellWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cellHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.clustererCombobox = new System.Windows.Forms.ComboBox();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.rotationCombobox = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.debugLoggingCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBoxMazePaint.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellHeightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMazePaint
            // 
            this.groupBoxMazePaint.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxMazePaint.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMazePaint.Name = "groupBoxMazePaint";
            this.groupBoxMazePaint.Size = new System.Drawing.Size(408, 270);
            this.groupBoxMazePaint.TabIndex = 0;
            this.groupBoxMazePaint.TabStop = false;
            this.groupBoxMazePaint.Text = "Рисование лабиринта";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.sideColorButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.borderColorButton, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.drawingAlgoCombobox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cellWidthNumericUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cellHeightNumericUpDown, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.backgroundColorButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clustererCombobox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rotationLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.rotationCombobox, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 251);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // sideColorButton
            // 
            this.sideColorButton.Enabled = false;
            this.sideColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sideColorButton.Location = new System.Drawing.Point(154, 183);
            this.sideColorButton.Name = "sideColorButton";
            this.sideColorButton.Size = new System.Drawing.Size(55, 24);
            this.sideColorButton.TabIndex = 11;
            this.sideColorButton.UseVisualStyleBackColor = true;
            this.sideColorButton.Click += new System.EventHandler(this.SideColorSelect);
            // 
            // borderColorButton
            // 
            this.borderColorButton.Enabled = false;
            this.borderColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderColorButton.Location = new System.Drawing.Point(154, 153);
            this.borderColorButton.Name = "borderColorButton";
            this.borderColorButton.Size = new System.Drawing.Size(55, 24);
            this.borderColorButton.TabIndex = 10;
            this.borderColorButton.UseVisualStyleBackColor = true;
            this.borderColorButton.Click += new System.EventHandler(this.BorderColorSelect);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм рисования";
            // 
            // drawingAlgoCombobox
            // 
            this.drawingAlgoCombobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingAlgoCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drawingAlgoCombobox.Enabled = false;
            this.drawingAlgoCombobox.FormattingEnabled = true;
            this.drawingAlgoCombobox.Location = new System.Drawing.Point(154, 3);
            this.drawingAlgoCombobox.Name = "drawingAlgoCombobox";
            this.drawingAlgoCombobox.Size = new System.Drawing.Size(245, 21);
            this.drawingAlgoCombobox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ширина ячейки лабиринта";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Высота ячейки лабиринта";
            // 
            // cellWidthNumericUpDown
            // 
            this.cellWidthNumericUpDown.Enabled = false;
            this.cellWidthNumericUpDown.Location = new System.Drawing.Point(154, 63);
            this.cellWidthNumericUpDown.Name = "cellWidthNumericUpDown";
            this.cellWidthNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.cellWidthNumericUpDown.TabIndex = 4;
            // 
            // cellHeightNumericUpDown
            // 
            this.cellHeightNumericUpDown.Enabled = false;
            this.cellHeightNumericUpDown.Location = new System.Drawing.Point(154, 93);
            this.cellHeightNumericUpDown.Name = "cellHeightNumericUpDown";
            this.cellHeightNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.cellHeightNumericUpDown.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Цвет фона";
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Enabled = false;
            this.backgroundColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backgroundColorButton.Location = new System.Drawing.Point(154, 123);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(55, 24);
            this.backgroundColorButton.TabIndex = 7;
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            this.backgroundColorButton.Click += new System.EventHandler(this.BackgroundColorSelect);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Цвет рамки";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Цвет линий";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Алгоритм поиска областей";
            // 
            // clustererCombobox
            // 
            this.clustererCombobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clustererCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clustererCombobox.Enabled = false;
            this.clustererCombobox.FormattingEnabled = true;
            this.clustererCombobox.Location = new System.Drawing.Point(154, 33);
            this.clustererCombobox.Name = "clustererCombobox";
            this.clustererCombobox.Size = new System.Drawing.Size(245, 21);
            this.clustererCombobox.TabIndex = 13;
            // 
            // rotationLabel
            // 
            this.rotationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(3, 218);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(50, 13);
            this.rotationLabel.TabIndex = 14;
            this.rotationLabel.Text = "Поворот";
            // 
            // rotationCombobox
            // 
            this.rotationCombobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rotationCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotationCombobox.Enabled = false;
            this.rotationCombobox.FormattingEnabled = true;
            this.rotationCombobox.Location = new System.Drawing.Point(154, 213);
            this.rotationCombobox.Name = "rotationCombobox";
            this.rotationCombobox.Size = new System.Drawing.Size(245, 21);
            this.rotationCombobox.TabIndex = 15;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 349);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OKButtonClick);
            // 
            // debugLoggingCheckbox
            // 
            this.debugLoggingCheckbox.AutoSize = true;
            this.debugLoggingCheckbox.Enabled = false;
            this.debugLoggingCheckbox.Location = new System.Drawing.Point(15, 316);
            this.debugLoggingCheckbox.Name = "debugLoggingCheckbox";
            this.debugLoggingCheckbox.Size = new System.Drawing.Size(131, 17);
            this.debugLoggingCheckbox.TabIndex = 8;
            this.debugLoggingCheckbox.Text = "Отладочная консоль";
            this.debugLoggingCheckbox.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 384);
            this.Controls.Add(this.debugLoggingCheckbox);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxMazePaint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.groupBoxMazePaint.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellHeightNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMazePaint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drawingAlgoCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cellWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown cellHeightNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.Button sideColorButton;
        private System.Windows.Forms.Button borderColorButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox debugLoggingCheckbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox clustererCombobox;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.ComboBox rotationCombobox;
    }
}