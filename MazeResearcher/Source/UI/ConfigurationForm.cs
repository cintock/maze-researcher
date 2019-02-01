using System;
using System.Drawing;
using System.Windows.Forms;
using Maze.Logic;

namespace Maze.UI
{
    public partial class ConfigurationForm : Form
    {
        private bool debugLogging;
        private MazeDrawingSettings drawingSettings;
        private IMazeDrawer drawer;

        private MazeClusterersEnum clusterer;

        private Color backgroundColor;
        private Color borderColor;
        private Color sideColor;

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

                backgroundColor = drawingSettings.BackgroundColor;
                SetupColorButton(backgroundColorButton, backgroundColor);

                borderColor = drawingSettings.BorderColor;
                SetupColorButton(borderColorButton, borderColor);

                sideColor = drawingSettings.SideColor;
                SetupColorButton(sideColorButton, sideColor);
            }
        }

        private void SetupColorButton(Button button, Color color)
        {
            button.BackColor = color;
            button.Enabled = true;
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

        public MazeClusterersEnum Clusterer
        {
            get
            {
                return clusterer;
            }

            set
            {
                clusterer = value;

                clustererCombobox.Items.Clear();

                clustererCombobox.Items.AddRange(
                    MazeClustererObjects.Instance().GetNamesList().ToArray());

                clustererCombobox.SelectedIndex = 
                    MazeClustererObjects.Instance().GetNumIndexByEnumIndex(clusterer);

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

        }

        private void BackgroundColorSelect(Object sender, EventArgs e)
        {
            backgroundColor = SelectColorDialog(
                backgroundColorButton, backgroundColor);
        }

        private void BorderColorSelect(Object sender, EventArgs e)
        {
            borderColor = SelectColorDialog(
                borderColorButton, borderColor);
        }

        private void SideColorSelect(Object sender, EventArgs e)
        {
            sideColor = SelectColorDialog(
                sideColorButton, sideColor);
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

            int clustererIndex = clustererCombobox.SelectedIndex;
            if (clustererIndex >= 0)
            {
                clusterer = MazeClustererObjects.Instance().GetEnumIndexByNumIndex(clustererIndex);
            }

            drawingSettings.CellHeight = (int)cellHeightNumericUpDown.Value;
            drawingSettings.CellWidth = (int)cellWidthNumericUpDown.Value;

            drawingSettings.BackgroundColor = backgroundColor;
            drawingSettings.BorderColor = borderColor;
            drawingSettings.SideColor = sideColor;

            drawer.SetDrawingSettings(drawingSettings);

            debugLogging = debugLoggingCheckbox.Checked;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
