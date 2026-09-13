using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace imj_Tools
{
    [ToolboxItem(true)]
    [DefaultEvent("SelectedIndexChanged")]
    public class DropDown_imj : Control
    {
        // ---------- Champs ----------
        private int borderRadius = 5;
        private Color borderColor = Color.White;
        private int borderThickness = 2;
        private Color gradientTopColor = Color.White;
        private Color gradientBottomColor = Color.LightGray;
        private float gradientAngle = 90F;

        private Color arrowColor = Color.DimGray;
        private Color textColor = Color.Black;
        private string placeholderText = "Sélectionner...";

        private int itemHeight = 28;
        private int maxDropDownItems = 8;
        private Color popupBackColor = Color.White;
        private Color itemHoverColor = Color.FromArgb(230, 230, 230);
        private Color itemSelectedColor = Color.FromArgb(200, 220, 255);
        private Color itemTextColor = Color.Black;

        private int selectedIndex = -1;
        private bool hover;
        private bool isOpen;

        private readonly BindingList<object> items = new BindingList<object>();
        private string displayMember = "";
        private string valueMember = "";

        private ToolStripDropDown popup;
        private ListePopup liste;

        // ---------- Événement ----------
        [Category("Behavior")]
        [Description("Déclenché quand l'élément sélectionné change.")]
        public event EventHandler SelectedIndexChanged;

        // ---------- Constructeur ----------
        public DropDown_imj()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable, true);

            Size = new Size(200, 36);
            Cursor = Cursors.Hand;
            TabStop = true;
            Font = new Font("Segoe UI", 9F);

            items.ListChanged += (s, e) =>
            {
                if (selectedIndex >= items.Count) SelectedIndex = -1;
                Invalidate();
            };
        }

        #region Propriétés Data (Binding, DisplayMember, ValueMember)

        [Browsable(true), Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BindingList<object> Items => items;

        [Browsable(true), Category("Data")]
        public string DisplayMember
        {
            get => displayMember;
            set { displayMember = value; Invalidate(); }
        }

        [Browsable(true), Category("Data")]
        public string ValueMember
        {
            get => valueMember;
            set => valueMember = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                int v = (value < -1 || value >= items.Count) ? -1 : value;
                if (v == selectedIndex) return;
                selectedIndex = v;
                Invalidate();
                SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Browsable(true)]
        public override string Text
        {
            get => (selectedIndex >= 0 && selectedIndex < items.Count)
                ? GetItemText(items[selectedIndex])
                : placeholderText;
            set => base.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get => (selectedIndex >= 0 && selectedIndex < items.Count) ? items[selectedIndex] : null;
            set => SelectedIndex = (value == null) ? -1 : items.IndexOf(value);
        }

        [Browsable(false)]
        public object SelectedValue
        {
            get
            {
                if (selectedIndex < 0 || selectedIndex >= items.Count) return null;
                object item = items[selectedIndex];

                if (string.IsNullOrEmpty(valueMember)) return item;

                var prop = item.GetType().GetProperty(valueMember);
                if (prop != null) return prop.GetValue(item, null);

                if (item is DataRowView drv) return drv[valueMember];

                return item;
            }
        }

        // Méthode helper interne pour extraire le texte à afficher
        internal string GetItemText(object item)
        {
            if (item == null) return string.Empty;
            if (string.IsNullOrEmpty(displayMember)) return item.ToString();

            var prop = item.GetType().GetProperty(displayMember);
            if (prop != null)
            {
                return prop.GetValue(item, null)?.ToString() ?? string.Empty;
            }

            if (item is DataRowView drv)
            {
                return drv[displayMember]?.ToString() ?? string.Empty;
            }

            return item.ToString();
        }

        #endregion

        #region Propriétés Apparence

        [Browsable(true), Category("Appearance")]
        [Description("Rayon (diamètre d'arc) des coins arrondis.")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = Math.Max(0, value); MajRegion(); Invalidate(); }
        }

        [Browsable(true), Category("Appearance")]
        [Description("Couleur de la bordure.")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        [Browsable(true), Category("Appearance")]
        [Description("Épaisseur de la bordure.")]
        public int BorderThickness
        {
            get => borderThickness;
            set { borderThickness = Math.Max(0, value); Invalidate(); }
        }

        [Browsable(true), Category("Appearance")]
        [Description("Couleur de début du dégradé.")]
        public Color GradientTopColor
        {
            get => gradientTopColor;
            set { gradientTopColor = value; Invalidate(); }
        }

        [Browsable(true), Category("Appearance")]
        [Description("Couleur de fin du dégradé.")]
        public Color GradientBottomColor
        {
            get => gradientBottomColor;
            set { gradientBottomColor = value; Invalidate(); }
        }

        [Browsable(true), Category("Appearance")]
        [Description("Angle du dégradé en degrés.")]
        public float GradientAngle
        {
            get => gradientAngle;
            set { gradientAngle = value; Invalidate(); }
        }

        [Browsable(true), Category("Appearance")]
        [Description("Couleur de la flèche.")]
        public Color ArrowColor
        {
            get => arrowColor;
            set { arrowColor = value; Invalidate(); }
        }

        [Browsable(true), Category("Appearance")]
        [Description("Couleur du texte affiché dans la zone fermée.")]
        public Color TextColor
        {
            get => textColor;
            set { textColor = value; Invalidate(); }
        }

        [Browsable(true), Category("Appearance")]
        [Description("Texte affiché quand rien n'est sélectionné.")]
        public string PlaceholderText
        {
            get => placeholderText;
            set { placeholderText = value; Invalidate(); }
        }

        #endregion

        #region Propriétés Popup & Items

        [Browsable(true), Category("Appearance")]
        [Description("Hauteur d'un élément de la liste.")]
        public int ItemHeight
        {
            get => itemHeight;
            set => itemHeight = Math.Max(12, value);
        }

        [Browsable(true), Category("Behavior")]
        [Description("Nombre maximum d'éléments visibles avant scroll.")]
        public int MaxDropDownItems
        {
            get => maxDropDownItems;
            set => maxDropDownItems = Math.Max(1, value);
        }

        [Browsable(true), Category("Appearance")]
        public Color PopupBackColor
        {
            get => popupBackColor;
            set => popupBackColor = value;
        }

        [Browsable(true), Category("Appearance")]
        public Color ItemHoverColor
        {
            get => itemHoverColor;
            set => itemHoverColor = value;
        }

        [Browsable(true), Category("Appearance")]
        public Color ItemSelectedColor
        {
            get => itemSelectedColor;
            set => itemSelectedColor = value;
        }

        [Browsable(true), Category("Appearance")]
        public Color ItemTextColor
        {
            get => itemTextColor;
            set => itemTextColor = value;
        }

        [Browsable(false)]
        public bool IsDropDownOpen => isOpen;

        #endregion

        #region Chemin arrondi (helper)

        internal static GraphicsPath CheminArrondi(Rectangle rect, int rayon)
        {
            GraphicsPath path = new GraphicsPath();

            if (rect.Width <= 0 || rect.Height <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int d = Math.Min(rayon, Math.Min(rect.Width, rect.Height));
            if (d <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void MajRegion()
        {
            if (Width <= 0 || Height <= 0) return;

            if (borderRadius <= 0)
            {
                Region = null;
                return;
            }

            using (GraphicsPath p = CheminArrondi(new Rectangle(0, 0, Width, Height), borderRadius))
                Region = new Region(p);
        }

        #endregion

        #region Dessin du contrôle principal

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (Width <= 0 || Height <= 0) return;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = CheminArrondi(rect, borderRadius))
            {
                // Fond en dégradé
                using (LinearGradientBrush brush =
                       new LinearGradientBrush(ClientRectangle, gradientTopColor, gradientBottomColor, gradientAngle))
                {
                    g.FillPath(brush, path);
                }

                // Bordure
                if (borderThickness > 0)
                {
                    Color c = (hover || isOpen) ? ControlPaint.Light(borderColor, 0.2f) : borderColor;
                    using (Pen pen = new Pen(c, borderThickness))
                        g.DrawPath(pen, path);
                }
            }

            // Texte d'affichage
            int padGauche = Math.Max(8, borderRadius / 2);
            Rectangle rTexte = new Rectangle(padGauche, 0, Width - padGauche - 28, Height);

            string txt = (selectedIndex >= 0 && selectedIndex < items.Count)
                ? GetItemText(items[selectedIndex])
                : placeholderText;

            Color cTxt = (selectedIndex < 0) ? Color.FromArgb(150, textColor) : textColor;

            TextRenderer.DrawText(g, txt, Font, rTexte, cTxt,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);

            // Flèche
            DessinerFleche(g);

            base.OnPaint(e);
        }

        private void DessinerFleche(Graphics g)
        {
            float cx = Width - 16;
            float cy = Height / 2f;

            using (Pen pen = new Pen(arrowColor, 2f))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                if (isOpen) // Chevron haut
                {
                    g.DrawLines(pen, new[]
                    {
                        new PointF(cx - 5, cy + 2),
                        new PointF(cx,     cy - 3),
                        new PointF(cx + 5, cy + 2)
                    });
                }
                else // Chevron bas
                {
                    g.DrawLines(pen, new[]
                    {
                        new PointF(cx - 5, cy - 2),
                        new PointF(cx,     cy + 3),
                        new PointF(cx + 5, cy - 2)
                    });
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            MajRegion();
            Invalidate();
        }

        #endregion

        #region Interactions Utilisateur

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            if (e.Button == MouseButtons.Left)
            {
                if (isOpen) FermerListe();
                else OuvrirListe();
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Enter:
                case Keys.Escape:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (isOpen) return;
                    if (e.Alt) OuvrirListe();
                    else if (selectedIndex < items.Count - 1) SelectedIndex = selectedIndex + 1;
                    e.Handled = true;
                    break;

                case Keys.Up:
                    if (selectedIndex > 0) SelectedIndex = selectedIndex - 1;
                    e.Handled = true;
                    break;

                case Keys.Enter:
                case Keys.Space:
                case Keys.F4:
                    if (isOpen) FermerListe(); else OuvrirListe();
                    e.Handled = true;
                    break;

                case Keys.Escape:
                    FermerListe();
                    e.Handled = true;
                    break;
            }
        }

        protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); Invalidate(); }
        protected override void OnLostFocus(EventArgs e) { base.OnLostFocus(e); Invalidate(); }

        #endregion

        #region Gestion Popup

        public void OuvrirListe()
        {
            if (DesignMode || items.Count == 0) return;

            if (popup == null)
            {
                liste = new ListePopup(this);

                ToolStripControlHost host = new ToolStripControlHost(liste)
                {
                    Margin = Padding.Empty,
                    Padding = Padding.Empty,
                    AutoSize = false
                };

                popup = new ToolStripDropDown
                {
                    Margin = Padding.Empty,
                    Padding = Padding.Empty,
                    AutoSize = false,
                    AutoClose = true,
                    DropShadowEnabled = true,
                    BackColor = popupBackColor
                };
                popup.Items.Add(host);
                popup.Closed += (s, e) =>
                {
                    isOpen = false;
                    Invalidate();
                };
            }

            int nb = Math.Min(items.Count, maxDropDownItems);
            int h = nb * itemHeight + 2 * ListePopup.PaddingVertical;
            Size taille = new Size(Width, h);

            liste.Size = taille;
            ((ToolStripControlHost)popup.Items[0]).Size = taille;
            popup.Size = taille;

            using (GraphicsPath p = CheminArrondi(new Rectangle(0, 0, taille.Width, taille.Height), borderRadius))
                popup.Region = new Region(p);

            liste.PreparerAffichage();

            isOpen = true;
            Invalidate();

            popup.Show(this, new Point(0, Height + 2));
            liste.Focus();
        }

        public void FermerListe()
        {
            popup?.Close();
            isOpen = false;
            Invalidate();
        }

        internal void ChoisirIndex(int index)
        {
            SelectedIndex = index;
            FermerListe();
            Focus();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                popup?.Dispose();
                liste?.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        // =====================================================
        //  Contrôle interne : la liste affichée dans le popup
        // =====================================================
        internal class ListePopup : Control
        {
            public const int PaddingVertical = 4;

            private readonly DropDown_imj owner;
            private int hoverIndex = -1;
            private int premierVisible = 0;

            public ListePopup(DropDown_imj proprietaire)
            {
                owner = proprietaire;
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.Selectable, true);
                Cursor = Cursors.Hand;
            }

            private int NbVisible => Math.Max(1, (Height - 2 * PaddingVertical) / owner.ItemHeight);
            private bool AvecScroll => owner.Items.Count > NbVisible;

            public void PreparerAffichage()
            {
                hoverIndex = owner.SelectedIndex;

                premierVisible = 0;
                if (owner.SelectedIndex >= NbVisible)
                    premierVisible = Math.Min(owner.SelectedIndex, owner.Items.Count - NbVisible);

                Invalidate();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

                using (GraphicsPath path = CheminArrondi(rect, owner.BorderRadius))
                {
                    using (SolidBrush b = new SolidBrush(owner.PopupBackColor))
                        g.FillPath(b, path);

                    if (owner.BorderThickness > 0)
                        using (Pen p = new Pen(owner.BorderColor, owner.BorderThickness))
                            g.DrawPath(p, path);
                }

                int marge = Math.Max(4, owner.BorderRadius / 3);
                int largeurItem = Width - 2 * marge - (AvecScroll ? 6 : 0);

                g.SetClip(new Rectangle(2, 2, Width - 4, Height - 4));

                int nb = NbVisible;
                for (int i = 0; i < nb; i++)
                {
                    int idx = premierVisible + i;
                    if (idx >= owner.Items.Count) break;

                    Rectangle r = new Rectangle(marge,
                                                PaddingVertical + i * owner.ItemHeight,
                                                largeurItem,
                                                owner.ItemHeight);

                    Color fond = Color.Empty;
                    if (idx == owner.SelectedIndex) fond = owner.ItemSelectedColor;
                    else if (idx == hoverIndex) fond = owner.ItemHoverColor;

                    if (fond != Color.Empty)
                    {
                        using (GraphicsPath pi = CheminArrondi(r, Math.Min(8, owner.BorderRadius)))
                        using (SolidBrush b = new SolidBrush(fond))
                            g.FillPath(b, pi);
                    }

                    Rectangle rTxt = new Rectangle(r.X + 6, r.Y, r.Width - 10, r.Height);

                    // Utilisation de GetItemText pour le dessin de l'élément dans la liste
                    TextRenderer.DrawText(g, owner.GetItemText(owner.Items[idx]), owner.Font, rTxt, owner.ItemTextColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
                }

                g.ResetClip();

                if (AvecScroll) DessinerScroll(g);
            }

            private void DessinerScroll(Graphics g)
            {
                int total = owner.Items.Count;
                int nb = NbVisible;

                int zoneH = Height - 2 * PaddingVertical;
                int barreH = Math.Max(20, zoneH * nb / total);
                int max = total - nb;
                int y = PaddingVertical + (max <= 0 ? 0 : (zoneH - barreH) * premierVisible / max);

                Rectangle rb = new Rectangle(Width - 8, y, 4, barreH);
                using (GraphicsPath p = CheminArrondi(rb, 4))
                using (SolidBrush b = new SolidBrush(Color.FromArgb(120, owner.ArrowColor)))
                    g.FillPath(b, p);
            }

            private int IndexDepuisPoint(Point pt)
            {
                if (pt.Y < PaddingVertical) return -1;
                int i = (pt.Y - PaddingVertical) / owner.ItemHeight;
                if (i < 0 || i >= NbVisible) return -1;
                int idx = premierVisible + i;
                return (idx < owner.Items.Count) ? idx : -1;
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                int i = IndexDepuisPoint(e.Location);
                if (i != hoverIndex) { hoverIndex = i; Invalidate(); }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                hoverIndex = -1;
                Invalidate();
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (e.Button != MouseButtons.Left) return;
                int i = IndexDepuisPoint(e.Location);
                if (i >= 0) owner.ChoisirIndex(i);
            }

            protected override void OnMouseWheel(MouseEventArgs e)
            {
                base.OnMouseWheel(e);
                if (!AvecScroll) return;

                int pas = e.Delta > 0 ? -1 : 1;
                Defiler(pas * SystemInformation.MouseWheelScrollLines);
            }

            private void Defiler(int delta)
            {
                int max = Math.Max(0, owner.Items.Count - NbVisible);
                premierVisible = Math.Max(0, Math.Min(max, premierVisible + delta));
                Invalidate();
            }

            protected override bool IsInputKey(Keys keyData) => true;

            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);

                switch (e.KeyCode)
                {
                    case Keys.Down:
                        DeplacerHover(1);
                        break;
                    case Keys.Up:
                        DeplacerHover(-1);
                        break;
                    case Keys.Enter:
                        if (hoverIndex >= 0) owner.ChoisirIndex(hoverIndex);
                        break;
                    case Keys.Escape:
                        owner.FermerListe();
                        break;
                }
                e.Handled = true;
            }

            private void DeplacerHover(int delta)
            {
                int n = owner.Items.Count;
                if (n == 0) return;

                hoverIndex = Math.Max(0, Math.Min(n - 1, hoverIndex + delta));

                if (hoverIndex < premierVisible) premierVisible = hoverIndex;
                else if (hoverIndex >= premierVisible + NbVisible)
                    premierVisible = hoverIndex - NbVisible + 1;

                Invalidate();
            }
        }
    }
}