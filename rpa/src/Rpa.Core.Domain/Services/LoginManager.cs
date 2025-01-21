namespace Rpa.Core.Domain.Services;

public class LoginManager {
    private readonly ILoginService _loginService;

    public LoginManager(ILoginService loginService) 
    {
        this._loginService = loginService;
    }

    public async Task runLoginAsync() 
    {
        await this._loginService.loginAsync();
    }
}