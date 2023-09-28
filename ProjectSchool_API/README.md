# Passos para execução do ASP.NET Core API no Visual Studio Code

- Instale o .NET Core na versão 2.2.110 (OBS: Caso tenha instalado mais versões incluindo essa siga os passos abaixo:)

1 - No diretório "Project-School\ProjectSchool_API\ProjectSchool_API" digite no terminal o seguinte comando:
```
dotnet new globaljson
```
2 - Após inserir esse comando será criado um arquivo json contendo a versão do dotnet usada no projeto, dentro do arquivo altere a versão do SDK pela indicada

![Versão SDK dotnet](https://github.com/raphael-hfRocha/Project-School/assets/76854919/46f5c891-307c-48bf-b4c1-624e829b882b)

- Após isso, digite no terminal comando de execução:

```
dotnet watch run
```
