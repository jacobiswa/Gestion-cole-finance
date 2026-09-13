using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace imj_Tools
{
    public class ResizePanel : Panel
    {
        private bool isResizing = false;
        private int initialMouseX;
        private int initialMouseY;
        private int initialPanelWidth;
        private int initialPanelHeight;

        // Panel cible à redimensionner
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Panel cible à redimensionner")]
        public Panel TargetPanel { get; set; }

        // Direction du redimensionnement
        public enum ResizeDirection
        {
            Left,   // par défaut : panel à gauche
            Right,  // panel à droite
            Top     // panel en haut (vertical)
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Direction du redimensionnement")]
        public ResizeDirection Direction { get; set; } = ResizeDirection.Left;

        public ResizePanel()
        {
            this.Cursor = Cursors.SizeWE; // Curseur horizontal par défaut
            this.BackColor = System.Drawing.Color.LightGray;

            this.MouseDown += ResizePanel_MouseDown;
            this.MouseMove += ResizePanel_MouseMove;
            this.MouseUp += ResizePanel_MouseUp;
        }

        private void ResizePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && TargetPanel != null)
            {
                isResizing = true;
                initialMouseX = Cursor.Position.X;
                initialMouseY = Cursor.Position.Y;
                initialPanelWidth = TargetPanel.Width;
                initialPanelHeight = TargetPanel.Height;
            }
        }

        private void ResizePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing && TargetPanel != null)
            {
                switch (Direction)
                {
                    case ResizeDirection.Left:
                        {
                            int deltaX = Cursor.Position.X - initialMouseX;
                            int newWidth = initialPanelWidth + deltaX;
                            if (newWidth >= 150 && newWidth <= 900)
                                TargetPanel.Width = newWidth;
                            break;
                        }
                    case ResizeDirection.Right:
                        {
                            int deltaX = initialMouseX - Cursor.Position.X; // inversé
                            int newWidth = initialPanelWidth + deltaX;
                            if (newWidth >= 150 && newWidth <= 900)
                                TargetPanel.Width = newWidth;
                            break;
                        }
                    case ResizeDirection.Top:
                        {
                            int deltaY = Cursor.Position.Y - initialMouseY;
                            int newHeight = initialPanelHeight + deltaY;
                            if (newHeight >= 50 && newHeight <= 400)
                                TargetPanel.Height = newHeight;
                            break;
                        }
                }
            }
        }

        private void ResizePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = false;
            }
        }
    }
}
