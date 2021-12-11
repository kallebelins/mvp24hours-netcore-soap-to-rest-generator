# mvp24hours-netcore-soap-to-rest-generator
Project created to transpose SOAP (XML) services into REST (JSON).

## Scenario

Some services need to perform integration, however, handling XML for web services (WebServices or WCF) greatly reduces productivity. Most of the time the services are third-party and do not support JSON format responses.

## Solution

Generate proxy to consume the SOAP service, since creating automatic generic methods can affect performance, and change the "Reference.cs" file to allow serialization to JSON format.

### Developing the Solution

After generating the proxies to connect to the service, it is necessary to update the file containing the proxies (Reference.cs).

```csharp

	//  I suggest creating a variable with the root folder
	const string FOLDER_MAIN = "D:/source/repos/github/mvp24hours-netcore-soap-to-rest-generator/src/Samples/";

	// Use the absolute path to the "Reference.cs" file
	ServiceGenerator.UpdateFileReference($"{FOLDER_MAIN}Samples.Infrastructure.WebService/Connected Services/Samples.WebAPI.WebService/Reference.cs");

```

After updating the file, you can generate the controller based on the service, like this:

```csharp

	//  I suggest creating a variable with the root folder
	const string FOLDER_MAIN = "D:/source/repos/github/mvp24hours-netcore-soap-to-rest-generator/src/Samples/";

	// controllers
	var controllerOptions = new ServiceGeneratorOptions
	{
		Namespace = "Samples.WebAPI.WebService",
		ServiceName = "WebService1",
		ServiceType = typeof(WebService1SoapClient)
	};
	
	// add the proxy's "Client" class import namespace
	controllerOptions.UsingNamespaces.Add("using Samples.WebAPI.WebService;");

	// pass the parameters for controller generation
	var controller = ServiceGenerator.GenerateController(controllerOptions);

	// write the file in the project directory
	File.WriteAllText($"{FOLDER_MAIN}Samples.WebAPI/Controllers/WebService1Controller.cs", controller);

```

To generate a controller without async/wait use:

```csharp

	// controllers
	var controllerOptions = new ServiceGeneratorOptions {};

	// ...

	// Add a file template
	controllerOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_CONTROLLER;

```

If you want to change it, the template files (Snippets) are in the folder generated in the same structure as the project.

To add a custom content template (no need to read a file) use:

```csharp

	// controllers
	var controllerOptions = new ServiceGeneratorOptions {};

	// ...

	// Add a content template
	modelOptions.Templates[ClassType.MethodController] = "My template here....";

```

#### Controller Template

The fields used for the Controller template are:
- [UsingNamespace] => Namespace to be imported;
- [Namespace] => Namespace of the class;
- [ServiceName] => Service name;
- [ServiceTypeName] => Service type;
- [ControllerDescription] => description for Controller class;
- [MethodList] => Template of methods;

Example:

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

#### Method Template

The fields used for the Methods template are:
- [ServiceName] => Service name;
- [ReturnType] => Method return type;
- [MethodName] => Method name;
- [MethodNameClean] => Method name without "Async";
- [ParametersName] => Method signature parameters;
- [ParametersMethod] => Parameters used to invoke the service method;
- [MethodDescription] => Default description for methods;

Example:

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

### Sample Project

I created an example project containing:
- WebService that will provide the service;
- Console to change the "Reference.cs" file and create the Controller;
- Shared project (infrastructure) with proxy to consume WebService;
- WebAPI project configured with:
   - URL injection for different environments (development, test and production);
   - NLog to capture failures through exception handling Middleware;
   - Documentation with Swagger;
   - REST API;
   - Uses Mvp24Hours library to speed up settings;

Access the sample project in the "Samples" folder.

![Project Structure](https://github.com/kallebelins/mvp24hours-netcore-soap-to-rest-generator/blob/main/docs/images/project-structure.png)

#### WebService Example

![WebService](https://github.com/kallebelins/mvp24hours-netcore-soap-to-rest-generator/blob/main/docs/images/webservice-wsdl.png)

#### Project REST (SOAP => REST)

![REST](https://github.com/kallebelins/mvp24hours-netcore-soap-to-rest-generator/blob/main/docs/images/rest-swagger.png)