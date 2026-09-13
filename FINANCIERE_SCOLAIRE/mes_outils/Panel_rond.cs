using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace imj_Tools
{
    public class Panel_rond : Panel
    {
        private int borderRadius = 15;
        private Color borderColor = Color.White; // par défaut blanc
        private int borderThickness = 2;

        // Propriétés du dégradé
        private Color gradientTopColor = Color.White;
        private Color gradientBottomColor = Color.LightGray;
        private float gradientAngle = 90F; // Angle par défaut vertical (haut vers bas)

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Rayon des coins arrondis du panel.")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value < 0) value = 0; // Empêche les valeurs négatives
                borderRadius = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Couleur de la bordure du panel.")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Épaisseur de la bordure du panel.")]
        public int BorderThickness
        {
            get { return borderThickness; }
            set
            {
                borderThickness = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Couleur supérieure (ou de début) du dégradé de fond.")]
        public Color GradientTopColor
        {
            get { return gradientTopColor; }
            set
            {
                gradientTopColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Couleur inférieure (ou de fin) du dégradé de fond.")]
        public Color GradientBottomColor
        {
            get { return gradientBottomColor; }
            set
            {
                gradientBottomColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Angle d'orientation du dégradé en degrés.")]
        public float GradientAngle
        {
            get { return gradientAngle; }
            set
            {
                gradientAngle = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Empêche le dessin si le panel est invisible ou trop petit
            if (Width <= 0 || Height <= 0)
                return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (BorderRadius <= 0)
            {
                // Cas où le rayon est 0 : Rectangle standard sans coins arrondis
                this.Region = null; // Réinitialise la région par défaut

                using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, GradientTopColor, GradientBottomColor, GradientAngle))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }

                if (BorderThickness > 0)
                {
                    using (Pen pen = new Pen(BorderColor, BorderThickness))
                    {
                        // On ajuste légèrement le rectangle pour que la bordure reste visible à l'intérieur
                        Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                }
            }
            else
            {
                // Cas normal avec des coins arrondis
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
                    path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
                    path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
                    path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
                    path.CloseFigure();

                    // Définition de la région pour couper proprement les contrôles enfants à l'intérieur
                    this.Region = new Region(path);

                    // Remplissage du fond avec le dégradé
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, GradientTopColor, GradientBottomColor, GradientAngle))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    // Dessin de la bordure par-dessus
                    if (BorderThickness > 0)
                    {
                        using (Pen pen = new Pen(BorderColor, BorderThickness))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }

            base.OnPaint(e);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // redessine quand la taille change
        }
    }
}