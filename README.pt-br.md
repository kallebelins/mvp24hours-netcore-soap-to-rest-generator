# mvp24hours-netcore-soap-to-rest-generator
Projeto criado para transpor serviços SOAP (XML) em REST (JSON).

## Cenário

Alguns serviços necessitam realizar integração, todavia, a manipulação de XML para serviços web (WebServices ou WCF) diminui bastante a produtividade. Na maioria das vezes os serviços são de terceiros e não dão suporte a respostas no formato JSON.

## Solução

Gerar proxy para consumir o serviço SOAP, uma vez que criar métodos genéricos automáticos pode afetar a performance, e alterar o arquivo "Reference.cs" para permitir a serialização para o formato JSON.

### Desenvolvendo a Solução

Após gerar os proxies para conectar no serviço é necessário atualizar o arquivo que contém os proxies (Reference.cs).

```csharp

	//  sugiro criar uma variável com a pasta raiz
	const string FOLDER_MAIN = "D:/source/repos/github/mvp24hours-netcore-soap-to-rest-generator/src/Samples/";

	// Use o caminho absoluto para o arquivo "Reference.cs"
	ServiceGenerator.UpdateFileReference($"{FOLDER_MAIN}Samples.Infrastructure.WebService/Connected Services/Samples.WebAPI.WebService/Reference.cs");

```

Após atualizar o arquivo, você poderá gerar a controller baseada no serviço, assim:

```csharp

	//  sugiro criar uma variável com a pasta raiz
	const string FOLDER_MAIN = "D:/source/repos/github/mvp24hours-netcore-soap-to-rest-generator/src/Samples/";

	// controllers
	var controllerOptions = new ServiceGeneratorOptions
	{
		Namespace = "Samples.WebAPI.WebService",
		ServiceName = "WebService1",
		ServiceType = typeof(WebService1SoapClient)
	};
	
	// adicione o namespace de importação da classe "Client" do proxy
	controllerOptions.UsingNamespaces.Add("using Samples.WebAPI.WebService;");

	// passe os parâmetros para geração da controller
	var controller = ServiceGenerator.GenerateController(controllerOptions);

	// escreva o arquivo no diretório do projeto
	File.WriteAllText($"{FOLDER_MAIN}Samples.WebAPI/Controllers/WebService1Controller.cs", controller);

```

Para gerar uma controller sem async/wait use:
```csharp

	// controllers
	var controllerOptions = new ServiceGeneratorOptions {};

	// ...

	// Adicione um template de arquivo
	controllerOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_CONTROLLER;

```

Caso queira alterar, os arquivos de template (Snippets) estão na pasta gerada na mesma estrutura do projeto. 

Para adicionar um template de conteúdo personalizado (sem necessitar ler arquivo) use:

```csharp

	// controllers
	var controllerOptions = new ServiceGeneratorOptions {};

	// ...

	// Adicione um template de conteúdo
	modelOptions.Templates[ClassType.MethodController] = "Meu template aqui....";

```

#### Template de Controller

Os campos usados para o template da Controller são:
- [UsingNamespace] => Namespace a ser importado;
- [Namespace] => Namespace da classe;
- [ServiceName] => Nome do serviço;
- [ServiceTypeName] => Tipo de serviço;
- [ControllerDescription] => descrição para a classe Controller;
- [MethodList] => Template de métodos;

Exemplo:

```csharp

	[UsingNamespace]

	namespace [Namespace]
	{
		/// <summary>
		/// [ControllerDescription]
		/// </summary>
		[Produces("application/json")]
		[Route("api/[controller]")]
		[ApiController]
		public class [ServiceName]Controller : BaseMvpController
		{
			private readonly [ServiceTypeName] _serviceClient;

			public [ServiceName]Controller([ServiceTypeName] serviceClient)
			{
				_serviceClient = serviceClient;
			}

			[MethodList]
		}
	}

```

#### Template de Método

Os campos usados para o template de Métodos são:
- [ServiceName] => Nome do serviço;
- [ReturnType] => Tipo de retorno do método;
- [MethodName] => Nome do método;
- [MethodNameClean] => Nome do método sem "Async";
- [ParametersName] => Parâmetros da assinatura do método;
- [ParametersMethod] => Parâmetros usamos para invocar o método do serviço;
- [MethodDescription] => Descrição padrão para os métodos;

Exemplo:

```csharp

	/// <summary>
	/// [MethodDescription]
	/// </summary>
	[HttpPost]
	[Route("[MethodNameClean]", Name = "[ServiceName][MethodNameClean]")]
	public Task<[ReturnType]> [MethodNameClean]([ParametersName])
	{
		return _serviceClient.[MethodName]([ParametersMethod]);
	}

```

### Projeto de Exemplo

Criei um projeto de exemplo contendo:
- WebService que fornecerá o serviço;
- Console para alterar o arquivo "Reference.cs" e criar a Controller;
- Projeto compartilhado (infraestrutura) com proxy para consumir WebService;
- Projeto WebAPI configurado com:
  - Injeção de URL para diversos ambientes (desenvolvimento, teste e produção);
  - NLog para capturar falhas;
  - Documentação com Swagger;
  - API REST;

#### WebService Exemplo


#### Projeto REST (SOAP => REST)
