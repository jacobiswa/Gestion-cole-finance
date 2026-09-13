using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace imj_Tools
{
    public class Bouton_rond : Button
    {
        // Champs privés - Dégradé et bordure par défaut
        private int borderRadius = 20;
        private Color borderColor = Color.White;
        private int borderThickness = 0; // Défaut : 0

        // Champs privés - Bordure au survol (Hover)
        private Color hoverBorderColor = Color.White;
        private int hoverBorderThickness = 0; // Défaut au survol : 0

        // Champs privés - Dégradé par défaut
        private Color gradientTopColor = Color.DodgerBlue;
        private Color gradientBottomColor = Color.RoyalBlue;
        private float gradientAngle = 90F;

        // Champs privés - Survol (Hover)
        private Color hoverGradientTopColor = Color.SkyBlue;
        private Color hoverGradientBottomColor = Color.DeepSkyBlue;

        // Champs privés - Clic (Pressed)
        private Color pressedGradientTopColor = Color.MediumBlue;
        private Color pressedGradientBottomColor = Color.DarkBlue;

        // États d'interaction
        private bool isHovered = false;
        private bool isPressed = false;

        public Bouton_rond()
        {
            // Optimisation du rendu graphique pour éviter le scintillement (flickering)
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.SupportsTransparentBackColor, true);

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
        }

        #region Propriétés Générales

        [Browsable(true)]
        [Category("Appearance Custom")]
        [Description("Rayon des coins arrondis du bouton.")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = Math.Max(0, value); this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom")]
        [Description("Couleur de la bordure.")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom")]
        [Description("Épaisseur de la bordure par défaut (0 = aucune bordure).")]
        public int BorderThickness
        {
            get => borderThickness;
            set { borderThickness = Math.Max(0, value); this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom")]
        [Description("Couleur supérieure du dégradé à l'état normal.")]
        public Color GradientTopColor
        {
            get => gradientTopColor;
            set { gradientTopColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom")]
        [Description("Couleur inférieure du dégradé à l'état normal.")]
        public Color GradientBottomColor
        {
            get => gradientBottomColor;
            set { gradientBottomColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom")]
        [Description("Angle du dégradé en degrés.")]
        public float GradientAngle
        {
            get => gradientAngle;
            set { gradientAngle = value; this.Invalidate(); }
        }

        #endregion

        #region Propriétés Survol et Clic (Hover & Pressed)

        [Browsable(true)]
        [Category("Appearance Custom - Hover")]
        [Description("Couleur de la bordure au survol.")]
        public Color HoverBorderColor
        {
            get => hoverBorderColor;
            set { hoverBorderColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom - Hover")]
        [Description("Épaisseur de la bordure au survol (0 = aucune bordure).")]
        public int HoverBorderThickness
        {
            get => hoverBorderThickness;
            set { hoverBorderThickness = Math.Max(0, value); this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom - Hover")]
        [Description("Couleur supérieure du dégradé au survol de la souris.")]
        public Color HoverGradientTopColor
        {
            get => hoverGradientTopColor;
            set { hoverGradientTopColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom - Hover")]
        [Description("Couleur inférieure du dégradé au survol de la souris.")]
        public Color HoverGradientBottomColor
        {
            get => hoverGradientBottomColor;
            set { hoverGradientBottomColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom - Pressed")]
        [Description("Couleur supérieure du dégradé au clic de la souris.")]
        public Color PressedGradientTopColor
        {
            get => pressedGradientTopColor;
            set { pressedGradientTopColor = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance Custom - Pressed")]
        [Description("Couleur inférieure du dégradé au clic de la souris.")]
        public Color PressedGradientBottomColor
        {
            get => pressedGradientBottomColor;
            set { pressedGradientBottomColor = value; this.Invalidate(); }
        }

        #endregion

        #region Gestion des événements de la souris

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            isPressed = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Button == MouseButtons.Left)
            {
                isPressed = true;
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            this.Invalidate();
        }

        #endregion

        #region Rendu Graphique (OnPaint)

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Détermination dynamique de l'épaisseur et de la couleur de la bordure selon l'état
            int currentBorderThickness = isHovered ? hoverBorderThickness : borderThickness;
            Color currentBorderColor = isHovered ? hoverBorderColor : borderColor;

            // Délimitation de la zone de dessin
            float shrink = currentBorderThickness > 0 ? currentBorderThickness / 2f : 0.5f;
            RectangleF rect = new RectangleF(shrink, shrink, this.Width - (shrink * 2), this.Height - (shrink * 2));

            // Sélection dynamique des couleurs selon l'état actuel
            Color topColor = gradientTopColor;
            Color bottomColor = gradientBottomColor;

            if (isPressed)
            {
                topColor = pressedGradientTopColor;
                bottomColor = pressedGradientBottomColor;
            }
            else if (isHovered)
            {
                topColor = hoverGradientTopColor;
                bottomColor = hoverGradientBottomColor;
            }

            using (GraphicsPath path = GetRoundedPath(rect, borderRadius))
            {
                // Remplissage avec le dégradé correspondant à l'état
                using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, topColor, bottomColor, gradientAngle))
                {
                    g.FillPath(brush, path);
                }

                // Dessin de la bordure (uniquement si l'épaisseur courante est supérieure à 0)
                if (currentBorderThickness > 0)
                {
                    using (Pen pen = new Pen(currentBorderColor, currentBorderThickness))
                    {
                        pen.Alignment = PenAlignment.Center;
                        g.DrawPath(pen, path);
                    }
                }

                // Application de la région découpée pour le contrôle
                using (GraphicsPath regionPath = GetRoundedPath(new RectangleF(0, 0, this.Width, this.Height), borderRadius))
                {
                    this.Region = new Region(regionPath);
                }
            }

            // Dessin du texte du bouton
            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            float diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Haut-Gauche
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Haut-Droit
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Bas-Droit
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Bas-Gauche
            path.CloseFigure();

            return path;
        }

        #endregion
    }
}