using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piston_Installer.UserControls
{
    public partial class ItemViewer : UserControl
    {
        internal string HiddenData;
        public ItemViewer()
        {
            InitializeComponent();
        }

        [Description("Title"), Category("Text")]
        public string TitleText
        {
            get => GrandChildTitleLabel.Text;
            set => GrandChildTitleLabel.Text = value;
        }

        [Description("Subtitle"), Category("Text")]
        public string SubtitleText
        {
            get => GrandChildSubtitleLabel.Text;
            set => GrandChildSubtitleLabel.Text = value;
        }

        [Description("Image"), Category("Appearance")]
        public Image Image
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }

        [Description("Button Image"), Category("Button")]
        public Image ButtonImage
        {
            get => GrandChildButton.BackgroundImage;
            set => GrandChildButton.BackgroundImage = value;
        }

        [Description("Button Background Color"), Category("Button")]
        public Color ButtonBackgroundColor
        {
            get => GrandChildButton.BackColor;
            set => GrandChildButton.BackColor = value;
        }

        [Description("Enviroment Text"), Category("Text")]
        public string EnviromentText
        {
            get => EnviromentsLabel.Text;
            set => EnviromentsLabel.Text = value;
        }

        [Description("Hidden Data"), Category("Storage")]
        public string Hidden_Data
        {
            get => HiddenData;
            set => HiddenData = value;
        }

        [Description("Hidden Data"), Category("Visibility")]
        public bool ButtonVisible
        {
            get => GrandChildButton.Visible;
            set => GrandChildButton.Visible = value;
        }

        [Description("ImageName"), Category("Data")]
        public string ImageName
        {
            get => pictureBox1.Name;
            set => pictureBox1.Name = value;
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks image")]
        public event EventHandler ImageClick;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks interface")]
        public event EventHandler InterfaceClick;

        private void GrandChildButton_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }

        public void SetImageFromUrl(string Url)
        {
            this.pictureBox1.Load(Url);
        }

        private void EnviromentsLabel_TextChanged(object sender, EventArgs e)
        {
            if (EnviromentsLabel.Text == "")
            {
                InfoSymbolLabel.Visible = false;
            } else
            {
                InfoSymbolLabel.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.ImageClick != null)
                this.ImageClick(this, e);
        }

        private void GrandChildTitleLabel_Click(object sender, EventArgs e)
        {
            if (this.InterfaceClick != null)
                this.InterfaceClick(this, e);
        }

        private void GrandChildSubtitleLabel_Click(object sender, EventArgs e)
        {
            if (this.InterfaceClick != null)
                this.InterfaceClick(this, e);
        }

        private void EnviromentsLabel_Click(object sender, EventArgs e)
        {
            if (this.InterfaceClick != null)
                this.InterfaceClick(this, e);
        }

        private void InfoSymbolLabel_Click(object sender, EventArgs e)
        {
            if (this.InterfaceClick != null)
                this.InterfaceClick(this, e);
        }

        private void ItemViewer_Click(object sender, EventArgs e)
        {
            if (this.InterfaceClick != null)
                this.InterfaceClick(this, e);
        }
    }
}