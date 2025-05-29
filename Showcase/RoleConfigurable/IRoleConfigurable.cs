using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVideoShop
{
    public interface IRoleConfigurable
    {
        GroupBox AdminPanel { get; }
        TabControl MainTabControl { get; }
        TabPage AdminTabPage { get; }
    }
}
