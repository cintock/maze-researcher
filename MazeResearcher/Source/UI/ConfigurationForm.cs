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
        private MazeDrawersEnum drawer;

        private MazeClusterersEnum clusterer;

        private Color backgroundColor;
        private Color borderColor;
        private Color sideColor;

        public MazeDrawersEnum Drawer
        {
            get
            {
                return drawer;
            }

            set
            {
                drawer = value;

                ConfigureCombobox(drawingAlgoCombobox, 
                    MazeDrawersObjects.Instance(), drawer);
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

                ConfigureCombobox(clustererCombobox, MazeClustererObjects.Instance(), clusterer);
            }
        }

        private void ConfigureCombobox<En, T>(ComboBox combo, 
            ObjectsDescription<En, T> objectDescription, En value) 
            where En: struct
        {
            combo.Items.Clear();

            combo.Items.AddRange(
                objectDescription.GetNamesList().ToArray());

            combo.SelectedIndex =
                objectDescription.GetNumIndexByEnumIndex(value);

            combo.Enabled = true;
        }

        public ConfigurationForm()
        {
            InitializeComponent();

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
            int drawerIndex = drawingAlgoCombobox.SelectedIndex;
            if (drawerIndex >= 0)
            {
                drawer = MazeDrawersObjects.Instance().GetEnumIndexByNumIndex(drawerIndex);
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

            debugLogging = debugLoggingCheckbox.Checked;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
