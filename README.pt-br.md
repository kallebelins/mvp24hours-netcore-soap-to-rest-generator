# mvp24hours-netcore-soap-to-rest-generator
Projeto criado para gerar modelos e controllers para transpor serviços SOAP (XML) em REST (JSON).

## Cenário

Alguns serviços necessitam realizar integração, todavia, a manipulação de XML para serviços web (WebServices ou WCF) diminui bastante a produtividade. Na maioria das vezes os serviços são de terceiros e não dão suporte a respostas no formato JSON.

## Solução

Gerar as classes e modelos para consumir o serviço SOAP, uma vez que criar métodos genéricos automáticos pode afetar a performance.

### Solução 1 - Serviço Simples

Neste modelo o serviço gera classes/modelos com propriedades.

```csharp

	var modelOptions = new ServiceGeneratorOptions
	{
		Namespace = "MyProject.WebAPI.Controller",
		ServiceName = "MyService",
		ServiceType = typeof(ServiceClient)
	};

	var result = ServiceGenerator.GenerateController(modelOptions);
	// escrever o resultado da variável "result" em um arquivo "MyServiceController"

```

### Solução 2 - Serviço Assíncrono

Neste modelo queremos usar async/await.

```csharp

	var modelOptions = new ServiceGeneratorOptions
	{
		Namespace = "MyProject.WebAPI.Controller",
		ServiceName = "MyService",
		ServiceType = typeof(ServiceClient)
	};
	modelOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_MAPPING_ASYNC_CONTROLLER;

	var result = ServiceGenerator.GenerateController(modelOptions);
	// escrever o resultado da variável "result" em um arquivo "MyServiceController"

```


### Solução 3 - Serviço com Modelos

Alguns serviços geram classes com campos ao invés de propriedades. Neste ponto podemos criar modelos e usar o AutoMapper para transpor os dados de campos para propriedades.

Para gerar os modelos:

```csharp

	var modelOptions = new ServiceGeneratorOptions
	{
		Namespace = "MyProject.WebAPI.Models",
		ServiceName = "MyService",
		ServiceType = typeof(ServiceClient),
		ModelSuffix = "Dto"
	};
	modelOptions.TemplatesPath[ClassType.Model] = ServiceGeneratorConstants.FILE_CLASS_MODEL_MAPPING;
	var result = ServiceGenerator.GenerateModels(modelOptions);
	// escrever o resultado da variável "result" em arquivos que irão representar os modelos

```

Para gerar a controller com models:

```csharp

	var modelOptions = new ServiceGeneratorOptions
	{
		Namespace = "MyProject.WebAPI.Controller",
		ServiceName = "MyService",
		ServiceType = typeof(ServiceClient),
		ModelSuffix = "Dto"
	};
	modelOptions.TemplatesPath[ClassType.Model] = ServiceGeneratorConstants.FILE_CLASS_MODEL_MAPPING;
	modelOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_MAPPING_CONTROLLER;
	
	var result = ServiceGenerator.GenerateController(modelOptions);
	// escrever o resultado da variável "result" em um arquivo "MyServiceController"

```

Para gerar controllers com async/await:

```csharp

	var modelOptions = new ServiceGeneratorOptions
	{
		Namespace = "MyProject.WebAPI.Controller",
		ServiceName = "MyService",
		ServiceType = typeof(ServiceClient),
		ModelSuffix = "Dto"
	};
	modelOptions.TemplatesPath[ClassType.Model] = ServiceGeneratorConstants.FILE_CLASS_MODEL_MAPPING;
	modelOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_MAPPING_ASYNC_CONTROLLER;
	
	var result = ServiceGenerator.GenerateController(modelOptions);
	// escrever o resultado da variável "result" em um arquivo "MyServiceController"

```