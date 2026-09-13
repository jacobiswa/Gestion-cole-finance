using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace imj_Tools
{
    public class Carousel : Panel_rond
    {
        private int currentIndex = 0;
        private PictureBox pictureBox;
        private System.Windows.Forms.Timer timer;
        private FlowLayoutPanel indicatorsPanel;
        private bool isUpdatingIndicators = false; // Empêche les déclenchements en boucle

        // --- Événements publics ---
        [Category("Action")]
        [Description("Se déclenche quand l'image affichée change.")]
        public event EventHandler ImageChanged;

        [Category("Action")]
        [Description("Se déclenche quand le carousel démarre.")]
        public event EventHandler CarouselStarted;

        [Category("Action")]
        [Description("Se déclenche quand le carousel s'arrête.")]
        public event EventHandler CarouselStopped;

        [Category("Action")]
        [Description("Se déclenche quand un indicateur est cliqué.")]
        public event EventHandler<int> IndicatorClicked;

        // --- Propriétés ---
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Intervalle en secondes pour changer d'image automatiquement.")]
        public int IntervalSeconds
        {
            get { return timer.Interval / 1000; }
            set
            {
                if (value <= 0) value = 1;
                timer.Interval = value * 1000; // secondes → ms
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Mode d'affichage des images (Zoom, Stretch, Center, etc.).")]
        public PictureBoxSizeMode ImageSizeMode
        {
            get { return pictureBox.SizeMode; }
            set { pictureBox.SizeMode = value; }
        }

        // 5 propriétés indépendantes pour les images
        [Browsable(true)][Category("Data")] public Image Image1 { get; set; }
        [Browsable(true)][Category("Data")] public Image Image2 { get; set; }
        [Browsable(true)][Category("Data")] public Image Image3 { get; set; }
        [Browsable(true)][Category("Data")] public Image Image4 { get; set; }
        [Browsable(true)][Category("Data")] public Image Image5 { get; set; }

        // --- Constructeur ---
        public Carousel()
        {
            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pictureBox);

            indicatorsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };
            this.Controls.Add(indicatorsPanel);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // par défaut 3 secondes
            timer.Tick += Timer_Tick;
        }

        // --- Cycle de vie ---
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            var imgs = GetImages();
            if (imgs.Length > 0)
            {
                currentIndex = 0;
                pictureBox.Image = imgs[currentIndex];
                CreateIndicators(imgs.Length);
                OnImageChanged(EventArgs.Empty);
            }
        }

        // --- Contrôle du carousel ---
        public void Start()
        {
            var imgs = GetImages();
            if (imgs.Length > 0)
            {
                currentIndex = 0;
                pictureBox.Image = imgs[currentIndex];
                CreateIndicators(imgs.Length);
                OnImageChanged(EventArgs.Empty);
            }
            if (imgs.Length > 1)
            {
                timer.Start();
                OnCarouselStarted(EventArgs.Empty);
            }
        }

        public void Stop()
        {
            timer.Stop();
            OnCarouselStopped(EventArgs.Empty);
        }

        public void Next()
        {
            var imgs = GetImages();
            if (imgs.Length == 0) return;
            currentIndex = (currentIndex + 1) % imgs.Length;
            pictureBox.Image = imgs[currentIndex];
            UpdateIndicators();
            OnImageChanged(EventArgs.Empty);
        }

        public void Previous()
        {
            var imgs = GetImages();
            if (imgs.Length == 0) return;
            currentIndex = (currentIndex - 1 + imgs.Length) % imgs.Length;
            pictureBox.Image = imgs[currentIndex];
            UpdateIndicators();
            OnImageChanged(EventArgs.Empty);
        }

        private void Timer_Tick(object sender, EventArgs e) => Next();

        // --- Gestion des images ---
        private Image[] GetImages()
        {
            var list = new System.Collections.Generic.List<Image>();
            if (Image1 != null) list.Add(Image1);
            if (Image2 != null) list.Add(Image2);
            if (Image3 != null) list.Add(Image3);
            if (Image4 != null) list.Add(Image4);
            if (Image5 != null) list.Add(Image5);
            return list.ToArray();
        }

        // --- Indicateurs ---
        private void CreateIndicators(int count)
        {
            indicatorsPanel.Controls.Clear();
            for (int i = 0; i < count; i++)
            {
                RadioButton rb = new RadioButton
                {
                    Appearance = Appearance.Button,
                    Width = 20,
                    Height = 20,
                    Text = "",
                    Tag = i
                };

                rb.Click += (s, e) =>
                {
                    // Si l'utilisateur clique manuellement sur le bouton radio
                    if (!isUpdatingIndicators)
                    {
                        int selectedIndex = (int)((RadioButton)s).Tag;
                        if (currentIndex != selectedIndex)
                        {
                            currentIndex = selectedIndex;
                            var imgs = GetImages();
                            if (imgs.Length > currentIndex)
                            {
                                pictureBox.Image = imgs[currentIndex];
                                OnImageChanged(EventArgs.Empty);
                                IndicatorClicked?.Invoke(this, currentIndex);
                            }
                        }

                        // Relance le timer pour redémarrer le cycle automatique à partir de cette image
                        if (timer.Enabled)
                        {
                            timer.Stop();
                            timer.Start();
                        }
                    }
                };

                indicatorsPanel.Controls.Add(rb);
            }
            UpdateIndicators();
        }

        private void UpdateIndicators()
        {
            isUpdatingIndicators = true; // Verrouille pour éviter les déclenchements parasites
            for (int i = 0; i < indicatorsPanel.Controls.Count; i++)
            {
                if (indicatorsPanel.Controls[i] is RadioButton rb)
                    rb.Checked = (i == currentIndex);
            }
            isUpdatingIndicators = false; // Déverrouille
        }

        // --- Déclencheurs d’événements ---
        protected virtual void OnImageChanged(EventArgs e) => ImageChanged?.Invoke(this, e);
        protected virtual void OnCarouselStarted(EventArgs e) => CarouselStarted?.Invoke(this, e);
        protected virtual void OnCarouselStopped(EventArgs e) => CarouselStopped?.Invoke(this, e);
    }
}