using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Piston_Installer.utils;
using CurseForge.APIClient;

namespace Install_Mods
{
    public partial class Mod_Viewer : Form
    {
        public Mod_Viewer(string ModID, bool IsModrinth)
        {
            MessageBox.Show("start");
            InitializeComponent();
            InitializeModviewer(ModID, IsModrinth);
            this.ShowDialog();
            MessageBox.Show("Shown");
        }

        private async void InitializeModviewer(string ModID, bool IsModrinth)
        {
            if (IsModrinth)
            {
                MessageBox.Show("Modrinth");
                await ModrinthUtils.GetProject(ModID.ToString());

                MainWebBrowser.DocumentText = ModrinthUtils.ModrinthProjectDeserialized.body;
                
            } 
            else
            {
                MessageBox.Show("Curseforge + " + ModID);
                ApiClient client = CurseforgeUtils.GetApi();
                var Mod = await client.GetModAsync(Int32.Parse(ModID));

                MainWebBrowser.DocumentText = client.GetModDescriptionAsync(Int32.Parse(ModID)).Result.Data;
            }

            MessageBox.Show("Done");
        }
    }
}
