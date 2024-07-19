using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Services
{
    public interface IThemeService
    {
        bool IsDarkMode { get; set; }
        event Action<bool> OnThemeChanged;
        void ToggleTheme();
    }
}
