# Title: Validador de senhas

API criada para analisar se uma senha é válida ou não. São consideradas senhas válidas aquelas que contém: 

* Nove ou mais caracteres;
* Ao menos 1 dígito;
* Ao menos 1 letra minúscula;
* Ao menos 1 letra maiúscula;
* Ao menos 1 caractere especial;

## Iniciando

### Pré-requisitos

Para rodar esta aplicação, são necessários:

* .NET Core 3.1 (baixe aqui: );
* Visual Studio 2019 (baixe aqui: );

### Instalações

Siga as indicações dentro do site da Microsoft e do próprio instalador do visual studio para instalar todas as dependências.

## Rodando a aplicação

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

## Rodando os testes

Esta aplicação possui testes automatizados de unidade e integração. Você pode rodá-los tanto de dentro do Visual Studio quanto pela linha de comando. Abaixo, uma explicação sobre cada uma das duas formas:



### Sobre os testes

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

