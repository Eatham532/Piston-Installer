using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piston_Installer.net.eatham532.UtilForms
{
    public partial class PictureMessagebox : Form
    {
        public PictureMessagebox(string? URI, Image? image, string Title)
        {
            InitializeComponent();
            PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            if (URI == null)
            {
                PictureBox.Image = image;
            } 
            else
            {
                PictureBox.Load(URI);
            }
            this.Size = new Size(PictureBox.Width + 25, PictureBox.Height + 72);
            this.Show();
        }
    }
}
