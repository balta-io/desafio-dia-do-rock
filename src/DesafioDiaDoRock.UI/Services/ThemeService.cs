using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;

namespace DesafioDiaDoRock.UI.Services
{
    public class ThemeService : IThemeService
    {
        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    OnThemeChanged?.Invoke(_isDarkMode);
                }
            }
        }

        public event Action<bool> OnThemeChanged;

        public void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
            OnThemeChanged?.Invoke(IsDarkMode);

        }
    }
}