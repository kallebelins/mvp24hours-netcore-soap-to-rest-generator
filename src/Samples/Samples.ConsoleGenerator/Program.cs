using Mvp24Hours.SoapToRestGenerator;
using Mvp24Hours.SoapToRestGenerator.Classes;
using Samples.Consolegenerator.WebService;
using System;
using System.IO;

namespace Samples.ConsoleGenerator
{
    public class Program
    {
        static void Main()
        {
            //WriteModelsMapping();
            WriteControllerMapping();
            // WriteController();
        }

        static void WriteController()
        {
            Console.WriteLine("Writing controller...");

            // controllers
            var controllerOptions = new ServiceGeneratorOptions
            {
                Namespace = "Samples.WebAPI.Controllers",
                ServiceName = "WebService1",
                ServiceType = typeof(WebService1SoapClient)
            };
            controllerOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_ASYNC_CONTROLLER;

            var controller = ServiceGenerator.GenerateController(controllerOptions);

            string fileName = GetFilePath("../../../../Samples.WebAPI/Controllers/WebService1Controller.cs");

            if (Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            File.WriteAllText(fileName, controller);
        }

        static void WriteModelsMapping()
        {
            Console.WriteLine("Writing models...");

            // models
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "Samples.WebAPI.Models",
                ServiceName = "WebService1",
                ServiceType = typeof(WebService1SoapClient),
                ModelSuffix = "Dto"
            };
            modelOptions.TemplatesPath[ClassType.Model] = ServiceGeneratorConstants.FILE_CLASS_MODEL_MAPPING;
            modelOptions.UsingNamespaces.Add("using Samples.WebAPI.WebService;");

            var models = ServiceGenerator.GenerateModels(modelOptions);

            foreach (var model in models)
            {
                string fileName = GetFilePath($"../../../../Samples.WebAPI/Models/{modelOptions.ModelPrefix}{model.Name}{modelOptions.ModelSuffix}.cs");

                if (Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }

                File.WriteAllText(fileName, model.Content);
            }
        }

        static void WriteControllerMapping()
        {
            Console.WriteLine("Writing controller...");

            // controllers
            var controllerOptions = new ServiceGeneratorOptions
            {
                Namespace = "Samples.WebAPI.Controllers",
                ServiceName = "WebService1",
                ServiceType = typeof(WebService1SoapClient),
                ModelSuffix = "Dto"
            };
            controllerOptions.TemplatesPath[ClassType.Model] = ServiceGeneratorConstants.FILE_CLASS_MODEL_MAPPING;
            controllerOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_MAPPING_ASYNC_CONTROLLER;

            controllerOptions.UsingNamespaces.Add("using Samples.WebAPI.WebService;");
            controllerOptions.UsingNamespaces.Add("using Samples.WebAPI.Models;");

            var controller = ServiceGenerator.GenerateController(controllerOptions);

            string fileName = GetFilePath("../../../../Samples.WebAPI/Controllers/WebService1Controller.cs");

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
