using System;
using System.Drawing;
using System.Windows.Forms;
using Maze.Implementation;

namespace Maze.UI
{
    public partial class ConfigurationForm : Form
    {
        private bool debugLogging;
        private MazeDrawingSettings drawingSettings;
        private IMazeDrawer drawer;
        private IMazeClusterer clusterer;

        public IMazeDrawer Drawer
        {
            get
            {
                return drawer;
            }

            set
            {
                drawer = value;

                drawingAlgoCombobox.SelectedValue = drawer;
                drawingAlgoCombobox.Enabled = true;
            }
        }

        public MazeDrawingSettings DrawingSettings
        {
            get
            {
                return drawingSettings;
            }

            set
            {
                drawingSettings = value;

                cellWidthNumericUpDown.Value = drawingSettings.CellWidth;
                cellWidthNumericUpDown.Enabled = true;

                cellHeightNumericUpDown.Value = drawingSettings.CellHeight;
                cellHeightNumericUpDown.Enabled = true;

                backgroundColorButton.BackColor = drawingSettings.BackgroundColor;
                backgroundColorButton.Enabled = true;

                borderColorButton.BackColor = drawingSettings.BorderColor;
                borderColorButton.Enabled = true;

                sideColorButton.BackColor = drawingSettings.SideColor;
                sideColorButton.Enabled = true;
            }
        }

        public bool DebugLogging
        {
            get
            {
                return debugLogging;
            }

            set
            {
                debugLogging = value;

                debugLoggingCheckbox.Checked = debugLogging;
                debugLoggingCheckbox.Enabled = true;
            }
        }

        public IMazeClusterer Clusterer
        {
            get
            {
                return clusterer;
            }

            set
            {
                clusterer = value;

                clustererCombobox.SelectedValue = value;
                clustererCombobox.Enabled = true;
            }
        }

        public ConfigurationForm()
        {
            InitializeComponent();

            drawingAlgoCombobox.DataSource =
                MazeDrawersObjects.Instance().GetNamedObjectsList();

            drawingAlgoCombobox.DisplayMember = "Name";
            drawingAlgoCombobox.ValueMember = "ObjectValue";

            clustererCombobox.DataSource =
                MazeClustererObjects.Instance().GetNamedObjectsList();

            clustererCombobox.DisplayMember = "Name";
            clustererCombobox.ValueMember = "ObjectValue";
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
            ColorDialog dialog = new ColorDialog
            {
                Color = previousColor
            };
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
                (IMazeDrawer)drawingAlgoCombobox.SelectedValue;

            if (drawerSelected != null)
            {
                drawer = drawerSelected;
            }

            IMazeClusterer clustererSelected =
                (IMazeClusterer)clustererCombobox.SelectedValue;

            if (clustererSelected != null)
            {
                clusterer = clustererSelected;
            }

            drawingSettings.CellHeight = (int)cellHeightNumericUpDown.Value;
            drawingSettings.CellWidth = (int)cellWidthNumericUpDown.Value;

            debugLogging = debugLoggingCheckbox.Checked;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
