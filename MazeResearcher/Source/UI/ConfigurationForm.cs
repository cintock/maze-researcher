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

        private ComboboxValues<MazeDrawersEnum> drawersComboboxValues;
        private ComboboxValues<MazeRotateEnum> rotationComboboxValues;

        private MazeDrawersEnum drawer;
        private MazeClusterersEnum clusterer;
        private MazeRotateEnum rotation;

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

                drawingAlgoCombobox.SelectedIndex = drawersComboboxValues.IndexByValue(drawer);
                drawingAlgoCombobox.Enabled = true;
            }
        }

        public MazeRotateEnum Rotation
        {
            get
            {
                return rotation;
            }

            set
            {
                rotation = value;

                rotationCombobox.SelectedIndex = rotationComboboxValues.IndexByValue(rotation);
                rotationCombobox.Enabled = true;
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

        private void InitDrawersComboboxValues()
        {
            drawersComboboxValues = new ComboboxValues<MazeDrawersEnum>();

            drawersComboboxValues.AddElement(MazeDrawersEnum.SimpleMazeDrawer,
                "Простое рисование (без настроек)");

            drawersComboboxValues.AddElement(MazeDrawersEnum.StandardMazeDrawer,
                "Стандартное рисование");

            drawersComboboxValues.AddElement(MazeDrawersEnum.CellDebugMazeDrawer,
                "Отладочное рисование (двойные стенки)");

            drawersComboboxValues.AddElement(MazeDrawersEnum.SolidSidesDrawer,
                "Толстые стены лабиринта");

            drawersComboboxValues.AddElement(MazeDrawersEnum.EmptyMazeDrawer,
                "Без рисования");

            drawingAlgoCombobox.Items.Clear();
            drawingAlgoCombobox.Items.AddRange(drawersComboboxValues.Names());
        }

        private void InitRotationComboboxValues()
        {
            rotationComboboxValues = new ComboboxValues<MazeRotateEnum>();

            rotationComboboxValues.AddElement(MazeRotateEnum.Rotate0, "Без поворорта");
            rotationComboboxValues.AddElement(MazeRotateEnum.Rotate90, "90 по часовой");
            rotationComboboxValues.AddElement(MazeRotateEnum.Rotate180, "На 180");
            rotationComboboxValues.AddElement(MazeRotateEnum.Rotate270, "90 против часовой");

            rotationCombobox.Items.Clear();
            rotationCombobox.Items.AddRange(rotationComboboxValues.Names());
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

            InitDrawersComboboxValues();
            InitRotationComboboxValues();
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
                drawer = drawersComboboxValues.ValueByIndex(drawerIndex);
            }

            int clustererIndex = clustererCombobox.SelectedIndex;
            if (clustererIndex >= 0)
            {
                clusterer = MazeClustererObjects.Instance().GetEnumIndexByNumIndex(clustererIndex);
            }

            int rotationIndex = rotationCombobox.SelectedIndex;
            if (rotationIndex >= 0)
            {
                rotation = rotationComboboxValues.ValueByIndex(rotationIndex);
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
