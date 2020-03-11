# Projeto: Validador de senhas

API criada para analisar se uma senha é válida ou não. São consideradas senhas válidas aquelas que contém: 

* Nove ou mais caracteres;
* Ao menos 1 dígito;
* Ao menos 1 letra minúscula;
* Ao menos 1 letra maiúscula;
* Ao menos 1 caractere especial;

**IMPORTANTE: os comentários do arquivo ConfigureSwaggerOptions.cs foram mantidos para referências a estudos posteriores.**

## Iniciando

### Pré-requisitos

Para rodar esta aplicação, são necessários:

#### Windows

* [.NET Core SDK 3.1.100](https://dotnet.microsoft.com/download/dotnet-core/3.1);
* [ASP.NET Core Runtime 3.1.0](https://dotnet.microsoft.com/download/dotnet-core/3.1);
* [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/);

#### Linux

* [.NET Core SDK 3.1.100](https://docs.microsoft.com/pt-br/dotnet/core/install/linux-package-manager-ubuntu-1904#install-the-net-core-sdk);
* [ASP.NET Core Runtime 3.1.0](https://docs.microsoft.com/pt-br/dotnet/core/install/linux-package-manager-ubuntu-1904#install-the-net-core-runtime);


### Instalações

Siga as indicações dentro do site da Microsoft e do próprio instalador do visual studio para instalar todas as dependências.

## Rodando a aplicação pelo Swagger

### Rodando pelo Visual Studio 2019

* Abra o projeto no Visual Studio 2019;
* Aperte **Ctrl+shift+B** para buildar o projeto;
* Selecione o projeto **ValidadorSenha.Api** como Startup project;
* No menu superior, garanta que o projeto supracitado esteja selecionado e clique em **IIS Express**;
* Aguarde a aplicação ser carregada no navegador;

### Rodando pela CommandLine

* Abra sua cmdline no diretório do projeto;
* Vá até a pasta **\src\ValidadorSenha.Api**;
* Rode o comando **dotnet run**;
* Aguarde enquanto o projeto é compilado;
* Copie o endereço que é exposto no console (geralmente http://localhost:5000) e cole-o no navegador;
* Acrescente **/swagger** ao final da URL copiada;
* Dê ENTER e acesse a aplicação;

## Testando fora do swagger

Caso queira enviar uma requisição de fora do Swagger, siga os seguintes passos:

* Rode a aplicação;
* Abra um programa de envio de mensagens e coloque o endpoint do localhost + **/api/v1/Senha**;
* Configure para enviar um arquivo json;
* Crie o arquivo json informando a senha desejada paa teste, como abaixo:

```
{
    "senha": "senha a ser testada"
}

```

* Você receberá um objeto de resposta como segue o exemplo abaixo:

```
{
  "senhaValida": false
}
```

**OBS: Caso esteja executando do Insomnia, desabilite os certificados SSL para testes**;

## Rodando os testes

Esta aplicação possui testes automatizados de unidade e API. Você pode rodá-los tanto de dentro do Visual Studio quanto pela linha de comando. Abaixo, uma explicação sobre cada uma das duas formas:

### Sobre os testes de unidade

Criados para testar principalmente a lógica de negócio do validador da senha, são testes mais rápidos criados para dar feedbacks mais rápido.

### Como rodar todos os testes de uma vez pela Commandline

* Acesse a raiz do projeto;
* Rode o comando **dotnet test**;
* Aguarde a resposta no console, mostrando o *Total de testes* e os testes *Aprovados*;

### Como rodar apenas os testes de unidade

Existem duas opções, uma utilizando o Visual Studio 2019 e outra pela linha de comando.

#### Pelo Visual Studio 2019

* Abra o projeto no Visual Studio;
* Vá em **Test > Test Explorer**;
* Deixe a aba do Test Explorer aberta e aperte **Ctrl+Shif+B** para buildar o projeto;
* Aguarde os testes serem carregados no Test Explorer;
* Clique com botão direito no item **ValidadorSenha.Api.Testes.Unidade**;
* Selecione a opção **Run** e aguarde a aplicação rodar todos os testes;

#### Pela Commandline

* Acesse a pasta raíz do projeto;
* Entre na pasta **\tests\ValidadorSenha.Api.Testes.Unidade**;
* Rode o comando **dotnet test**;
* Aguarde a resposta no console, mostrando o *Total de testes* e os testes *Aprovados*;

### Como rodar apenas os testes de API

Existem duas opções, uma utilizando o Visual Studio 2019 e outra pela linha de comando.

#### Pelo Visual Studio 2019

* Abra o projeto no Visual Studio;
* Vá em **Test > Test Explorer**;
* Deixe a aba do Test Explorer aberta e aperte **Ctrl+Shif+B** para buildar o projeto;
* Aguarde os testes serem carregados no Test Explorer;
* Clique com botão direito no item **ValidadorSenha.Api.Testes.Api**;
* Selecione a opção **Run** e aguarde a aplicação rodar todos os testes;

#### Pela Commandline

* Acesse a pasta raíz do projeto;
* Entre na pasta **\tests\ValidadorSenha.Api.Testes.Api**;
* Rode o comando **dotnet test**;
* Aguarde a resposta no console, mostrando o *Total de testes* e os testes *Aprovados*;

## Sobre decisões arquiteturais

Foi decidido utilizar um objeto específico para receber e devolver a senha para garantir uma assinatura mínima à API e forçar que as informações recebidas e devolvidas estejam em um
formato minimamente aceitável.

Poderíamos receber apenas um texto puro e devolver um booleano puro, mas não vimos vantagem na técnica, já que a string recebida poderia ser qualquer tipo de comando e o booleano seria transformado em uma string dentro do JSON de resposta, criando a necessidade de um casting pelas aplicações que consumirão a API. 
