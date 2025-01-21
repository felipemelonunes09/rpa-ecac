namespace Rpa.Core.Domain.Services;
public class LoginFactory {
    public static ILoginService getLoginService(string type, Dictionary<string, string> parameters) {
        return type switch 
        {
            "cpf" => new LoginCpfPasswordService(parameters["cpf"], parameters["password"]),
            "cert" => new LoginCertService(parameters["path"]),
            _ => throw new ArgumentException("Requested login type invalid")
        };
    }
}
