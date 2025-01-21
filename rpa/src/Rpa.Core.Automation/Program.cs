using Rpa.Core.Domain.Services;
class Program {
    
    public const string LOGIN_TYPE_CPF = "cpf";
    public const string LOGIN_TYPE_CERT = "cert";

    static async Task Main(string[] args) {

        if (args.Length  == 0) {
            Console.WriteLine("No arguments were provided");
            return ;
        }

        string type = args[0];

        Console.WriteLine("Starting Application-Login");
        var parameters = new Dictionary<string, string>();

        if (type == Program.LOGIN_TYPE_CPF) 
        {
            parameters["cpf"] = args[1];
            parameters["password"] = args[2];
        }
        else if (type == Program.LOGIN_TYPE_CERT) {
            parameters["path"] = args[1];
        }

        var loginService = LoginFactory.getLoginService(type, parameters);
        var loginManager = new LoginManager(loginService);

        await loginManager.runLoginAsync();
    }
}