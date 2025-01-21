# RPA para Login no siste E-CAC

Status: ✅ Completo

# How to Run
> Tenha certeza que tem ao menos versão .NET 8 instalada na sua máquina para fazer o run do projeto
> Caso não tenha é possível fazer o download no seguinte link: https://dotnet.microsoft.com/pt-br/
## Login com CPF e senha
Substitua o `<CPF:string>` e `<password:string>` pela seu CPF e senha respectivamente.
```diff
dotnet run --project Rpa.Core.Automation/Rpa.Core.Automation.csproj cpf <CPF:string> <password:password>
```
## Login com Certificado Digital
Substitua o `<path:string>` pelo caminho do certificado digital (Para minimizar erros tenha certeza que o certificado já esteja instalado e sendo utilizado pelo Chrome)
```diff
dotnet run --project Rpa.Core.Automation/Rpa.Core.Automation.csproj cert <path:string>
```

