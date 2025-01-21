using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Rpa.Core.Domain.Services;

public class LoginCertService : ILoginService {

    private string certPath;

    public LoginCertService(string certPath) {
        this.certPath = certPath;
    }

    public async Task loginAsync() {
        if (!File.Exists(this.certPath))
        {
            throw new FileNotFoundException("File not found.");
        }

        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--ignore-certificate-errors");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--disable-popup-blocking");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument($"--user-data-dir={this.certPath}");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        using (IWebDriver driver = new ChromeDriver(options))
        {
            try
            {
                driver.Navigate().GoToUrl("https://cav.receita.fazenda.gov.br/autenticacao/login");
                
                var govBrButton = driver.FindElement(By.XPath("//input[@alt='Acesso Gov BR']"));
                govBrButton.Click();
                System.Threading.Thread.Sleep(500);

                var certificateButton = driver.FindElement(By.Id("login-certificate"));
                Console.WriteLine("Login successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o login: {ex.Message}");
            }
        }
    }
}