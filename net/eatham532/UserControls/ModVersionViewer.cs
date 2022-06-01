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
    public partial class ModVersionViewer : UserControl
    {
        internal string versionID;
        internal string versionURI;
        public ModVersionViewer()
        {
            InitializeComponent();
        }

        [Description("Main Text"), Category("Text")]
        public string TitleText
        {
            get => MainLabel.Text;
            set => MainLabel.Text = value;
        }

        
        [Description("Sub Text"), Category("Text")]
        public string SubtitleText
        {
            get => VersionLabel.Text;
            set => VersionLabel.Text = value;
        }


        [Description("Date Updated Text"), Category("Text")]
        public string DateText
        {
            get => DateUpdatedLabel.Text;
            set => DateUpdatedLabel.Text = value;
        }


        [Description("State Text"), Category("Text")]
        public string StateText
        {
            get => StateLabel.Text;
            set => StateLabel.Text = value;
        }


        [Description("Version ID"), Category("Storage")]
        public string VersionID
        {
            get => versionID;
            set => versionID = value;
        }


        [Description("Version URI"), Category("Storage")]
        public string VersionURI
        {
            get => this.versionURI;
            set => this.versionURI = value;
        }


        [Description("Version state color"), Category("Appearance")]
        public Color VersionStateColor
        {
            get => StateLabel.ForeColor;
            set => StateLabel.ForeColor = value;
        }


        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks the control")]
        public event EventHandler ControlClick;


        private void ModVersionViewer_Click(object sender, EventArgs e)
        {
            if (this.ControlClick != null)
                this.ControlClick(this, e);
        }

        private void MainLabel_Click(object sender, EventArgs e)
        {
            if (this.ControlClick != null)
                this.ControlClick(this, e);
        }

        private void SubLabel_Click(object sender, EventArgs e)
        {
            if (this.ControlClick != null)
                this.ControlClick(this, e);
        }

        private void DateUpdatedLabel_Click(object sender, EventArgs e)
        {
            if (this.ControlClick != null)
                this.ControlClick(this, e);
        }

        private void StateLabel_Click(object sender, EventArgs e)
        {
            if (this.ControlClick != null)
                this.ControlClick(this, e);
        }
    }
}
