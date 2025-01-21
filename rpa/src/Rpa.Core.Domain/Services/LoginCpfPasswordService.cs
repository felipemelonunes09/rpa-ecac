using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Rpa.Core.Domain.Services;

public class LoginCpfPasswordService : ILoginService {

    private string cpf;
    private string password;

    public LoginCpfPasswordService(string cpf, string passwod) {
        this.cpf = cpf;
        this.password = passwod;
    }
 
    public async Task loginAsync() {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        using (var driver = new ChromeDriver(options)) {
            try {
                driver.Navigate().GoToUrl("https://sso.acesso.gov.br/login?client_id=cav.receita.fazenda.gov.br&authorization_id=19489aa754b");
                
                var govBrButton = driver.FindElement(By.XPath("//input[@alt='Acesso Gov BR']"));
                govBrButton.Click();
                
                System.Threading.Thread.Sleep(100);

                var cpfField = driver.FindElement(By.Id("accountId"));
                cpfField.SendKeys(cpf);

                var nextButton = driver.FindElement(By.Id("enter-account-id"));
                nextButton.Click();

                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys(password);

                var loginButton = driver.FindElement(By.Id("submit-button"));
                loginButton.Click();

                System.Threading.Thread.Sleep(100);
                Console.WriteLine("Login successful!");
            }
            catch (Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}