using DesafioDiaDoRock.ApplicationCore.Interfaces.Services;

namespace DesafioDiaDoRock.UI.Services;

public class LoginService : ILoginService
{
    private bool _isNecessaryAuthenticated;
    public bool IsNecessaryAuthenticated
    {
        get => _isNecessaryAuthenticated;
        set
        {
            if (_isNecessaryAuthenticated != value)
            {
                _isNecessaryAuthenticated = value;

            }
        }
    }

    public event Action<bool> OnAuthenticationChanged;

    public void ToggleAuthentication()
    {
        IsNecessaryAuthenticated = !IsNecessaryAuthenticated;

        OnAuthenticationChanged?.Invoke(IsNecessaryAuthenticated);

    }
}
