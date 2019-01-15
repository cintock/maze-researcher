using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maze.Implementation;

namespace Maze.UI
{
    public partial class ConfigurationForm : Form
    {
        private IMazeDrawer drawer;

        private MazeDrawingSettings drawingSettings;

        public IMazeDrawer Drawer
        {
            get {
                return drawer;
            }
        }

        public MazeDrawingSettings DrawingSettings {
            get {
                return drawingSettings;
            }
        }

        public ConfigurationForm(IMazeDrawer drawer, MazeDrawingSettings drawingSettings)
        {
            InitializeComponent();

            this.drawer = drawer;
            this.drawingSettings = drawingSettings;

            drawingAlgoComboBox.DataSource = MazeDrawersObjects.Instance().GetNamedObjectsList();
            drawingAlgoComboBox.DisplayMember = "Name";
            drawingAlgoComboBox.ValueMember = "ObjectValue";
            drawingAlgoComboBox.SelectedValue = drawer;

            cellWidthNumericUpDown.Value = drawingSettings.CellWidth;
            cellHeightNumericUpDown.Value = drawingSettings.CellHeight;

            backgroundColorButton.BackColor = drawingSettings.BackgroundColor;
            borderColorButton.BackColor = drawingSettings.BorderColor;
            sideColorButton.BackColor = drawingSettings.SideColor;
        }

        private void BackgroundColorSelect(Object sender, EventArgs e)
        {
            drawingSettings.BackgroundColor = SelectColorDialog(
                backgroundColorButton, drawingSettings.BackgroundColor);
        }

        private void BorderColorSelect(Object sender, EventArgs e)
        {
            drawingSettings.BorderColor = SelectColorDialog(
                borderColorButton, drawingSettings.BorderColor);
        }

        private void SideColorSelect(Object sender, EventArgs e)
        {
            drawingSettings.SideColor = SelectColorDialog(
                sideColorButton, drawingSettings.SideColor);
        }

        private Color SelectColorDialog(Control colorView, Color previousColor)
        {
            Color selectedColor = previousColor;
            ColorDialog dialog = new ColorDialog();
            dialog.Color = previousColor;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                selectedColor = dialog.Color;
                colorView.BackColor = selectedColor;
            }
            return selectedColor;
        }

        private void OKButtonClick(Object sender, EventArgs e)
        {
            IMazeDrawer drawerSelected = 
                (IMazeDrawer)drawingAlgoComboBox.SelectedValue;

            if (drawerSelected != null)
            {
                drawer = drawerSelected;
            }

            drawingSettings.CellHeight = (Int32)cellHeightNumericUpDown.Value;
            drawingSettings.CellWidth = (Int32)cellWidthNumericUpDown.Value;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
