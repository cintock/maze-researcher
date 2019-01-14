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
            this.label1 = new System.Windows.Forms.Label();
            this.drawingAlgoComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cellWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cellHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxMazePaint.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellHeightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMazePaint
            // 
            this.groupBoxMazePaint.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxMazePaint.Location = new System.Drawing.Point(91, 75);
            this.groupBoxMazePaint.Name = "groupBoxMazePaint";
            this.groupBoxMazePaint.Size = new System.Drawing.Size(406, 304);
            this.groupBoxMazePaint.TabIndex = 0;
            this.groupBoxMazePaint.TabStop = false;
            this.groupBoxMazePaint.Text = "Рисование лабиринта";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.drawingAlgoComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cellWidthNumericUpDown, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cellHeightNumericUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(329, 227);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм рисования";
            // 
            // drawingAlgoComboBox
            // 
            this.drawingAlgoComboBox.FormattingEnabled = true;
            this.drawingAlgoComboBox.Location = new System.Drawing.Point(167, 3);
            this.drawingAlgoComboBox.Name = "drawingAlgoComboBox";
            this.drawingAlgoComboBox.Size = new System.Drawing.Size(159, 21);
            this.drawingAlgoComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ширина ячейки лабиринта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Высота ячейки лабиринта";
            // 
            // cellWidthNumericUpDown
            // 
            this.cellWidthNumericUpDown.Location = new System.Drawing.Point(167, 86);
            this.cellWidthNumericUpDown.Name = "cellWidthNumericUpDown";
            this.cellWidthNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.cellWidthNumericUpDown.TabIndex = 4;
            // 
            // cellHeightNumericUpDown
            // 
            this.cellHeightNumericUpDown.Location = new System.Drawing.Point(167, 169);
            this.cellHeightNumericUpDown.Name = "cellHeightNumericUpDown";
            this.cellHeightNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.cellHeightNumericUpDown.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Цвет фона";
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxMazePaint);
            this.Name = "ConfigurationForm";
            this.Text = "ConfigurationForm";
            this.groupBoxMazePaint.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellHeightNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMazePaint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drawingAlgoComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cellWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown cellHeightNumericUpDown;
        private System.Windows.Forms.Label label4;
    }
}