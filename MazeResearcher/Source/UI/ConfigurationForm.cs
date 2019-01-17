﻿using System;
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
        private Boolean debugLogging;

        private MazeDrawingSettings drawingSettings;

        private IMazeDrawer drawer;

        public IMazeDrawer Drawer
        {
            get
            {
                return drawer;
            }
            set
            {
                drawer = value;
                drawingAlgoComboBox.SelectedValue = drawer;
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
                cellHeightNumericUpDown.Value = drawingSettings.CellHeight;

                backgroundColorButton.BackColor = drawingSettings.BackgroundColor;
                borderColorButton.BackColor = drawingSettings.BorderColor;
                sideColorButton.BackColor = drawingSettings.SideColor;
            }
        }

        public Boolean DebugLogging
        {
            get
            {
                return debugLogging;
            }
            set
            {
                debugLogging = value;
                debugLoggingCheckbox.Checked = debugLogging;
            }
        }

        public ConfigurationForm()
        {
            InitializeComponent();

            drawingAlgoComboBox.DataSource =
                MazeDrawersObjects.Instance().GetNamedObjectsList();

            drawingAlgoComboBox.DisplayMember = "Name";
            drawingAlgoComboBox.ValueMember = "ObjectValue";
        }

        public ConfigurationForm(IMazeDrawer drawer, MazeDrawingSettings drawingSettings) : 
            this()
        {
            Drawer = drawer;
            DrawingSettings = drawingSettings;
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
                (IMazeDrawer)drawingAlgoComboBox.SelectedValue;

            if (drawerSelected != null)
            {
                drawer = drawerSelected;
            }

            drawingSettings.CellHeight = (int)cellHeightNumericUpDown.Value;
            drawingSettings.CellWidth = (int)cellWidthNumericUpDown.Value;

            debugLogging = debugLoggingCheckbox.Checked;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
