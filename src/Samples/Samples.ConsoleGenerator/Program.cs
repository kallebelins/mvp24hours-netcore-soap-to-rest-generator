using Mvp24Hours.SoapToRestGenerator;
using Mvp24Hours.SoapToRestGenerator.Classes;
using Samples.WebAPI.WebService;
using System;
using System.IO;

namespace Samples.ConsoleGenerator
{
    public class Program
    {
        const string FOLDER_MAIN = @"C:/Fabrica/GitHub/mvp24hours-netcore-soap-to-rest-generator/src/Samples/Samples.WebAPI/";

        static void Main()
        {

            // use the full path of the file
            ServiceGenerator.UpdateFileReference($"{FOLDER_MAIN}Connected Services/Samples.WebAPI.WebService/Reference.cs");

            // creates the controller file from the service
            WriteController();
        }

        static void WriteController()
        {
            Console.WriteLine("Writing controller...");

            // controllers
            var controllerOptions = new ServiceGeneratorOptions
            {
                Namespace = "Samples.WebAPI.WebService",
                ServiceName = "WebService1",
                ServiceType = typeof(WebService1SoapClient)
            };
            controllerOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_ASYNC_CONTROLLER;

            controllerOptions.UsingNamespaces.Add("using Samples.WebAPI.WebService;");

            var controller = ServiceGenerator.GenerateController(controllerOptions);

            string fileName = GetFilePath($"{FOLDER_MAIN}Controllers/WebService1Controller.cs");

            if (Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            File.WriteAllText(fileName, controller);
        }

        internal static string GetFilePath(string fileName)
        {
            string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string theDirectory = Path.GetDirectoryName(fullPath);
            return Path.Combine(theDirectory, fileName);
        }
    }
}
