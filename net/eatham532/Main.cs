using Piston_Installer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Install_Mods;

namespace Piston_Installer
{
    public partial class Main : Form
    {
        public Main()
        {
            try
            {
                if (!utils.InternetUtils.CheckForInternetConnection())
                {
                    MessageBox.Show("You need an active internet connection to use Piston Installer");
                    this.Close();
                    Environment.Exit(0);
                    return;
                }
            }
            catch { }

            utils.FabricUtils.SetFabricMcVersionList();
            InitializeComponent();
            ActiveControl = null;
        }

        private void Modpack_Click(object sender, EventArgs e)
        {
            Install_Modpack modpack = new Install_Modpack();
            this.Hide();
            DialogResult dialogResult = modpack.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.Dispose();
            } else
            {
                this.Show();
            }
        }

        private void Install_Fabric_Click(object sender, EventArgs e)
        {
            Install_Fabric fabric = new Install_Fabric();
            this.Hide();
            DialogResult dialogResult = fabric.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                this.Show();
            }
        }

        private void Install_Forge_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is still in development.");
        }

        private void AddModsBtn_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            this.Enabled = false;
            Install_Mods mods = new Install_Mods();
            
            this.Hide();
            DialogResult dialogResult = mods.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                this.Show();
            }
            UseWaitCursor = false;

            this.Enabled = true;
        }
    }
}
