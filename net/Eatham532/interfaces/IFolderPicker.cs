using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistonInstaller.net.Eatham532.interfaces
{
    public interface IFolderPicker
    {
        Task<string> PickFolder();
    }
}
