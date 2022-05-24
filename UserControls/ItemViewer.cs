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
        public ItemViewer()
        {
            InitializeComponent();
        }

        [Description("Title"), Category("Data")]
        public string TitleText
        {
            get => GrandChildTitleLabel.Text;
            set => GrandChildTitleLabel.Text = value;
        }

        [Description("Subtitle"), Category("Data")]
        public string SubtitleText
        {
            get => GrandChildSubtitleLabel.Text;
            set => GrandChildSubtitleLabel.Text = value;
        }

        [Description("Image"), Category("Data")]
        public Image Image
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }

        [Description("Button Image"), Category("Data")]
        public Image ButtonImage
        {
            get => GrandChildButton.BackgroundImage;
            set => GrandChildButton.BackgroundImage = value;
        }

        [Description("Button Background Color"), Category("Data")]
        public Color ButtonBackgroundColor
        {
            get => GrandChildButton.BackColor;
            set => GrandChildButton.BackColor = value;
        }

            [Description("Enviroment Text"), Category("Data")]
        public string EnviromentText
        {
            get => EnviromentsLabel.Text;
            set => EnviromentsLabel.Text = value;
        }

        [Description("Hidden Data"), Category("Data")]
        public string Hidden_Data
        {
            get => HiddenData.Text;
            set => HiddenData.Text = value;
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;

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
    }
}
