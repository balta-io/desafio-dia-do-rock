namespace DesafioDiaDoRock.ApplicationCore.Interfaces.Services;

public interface ILoginService
{
    bool IsNecessaryAuthenticated { get; set; }
    event Action<bool> OnAuthenticationChanged;
    void ToggleAuthentication();
}
