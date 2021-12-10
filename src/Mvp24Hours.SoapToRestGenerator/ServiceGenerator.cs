using Mvp24Hours.SoapToRestGenerator.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mvp24Hours.SoapToRestGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceGenerator
    {
        /// <summary>
        /// Adjusts the "Reference.cs" file to allow viewing the properties of the models.
        /// </summary>
        /// <param name="fileReferenceName">Physical path to access the "Reference.cs" file</param>
        public static void UpdateFileReference(string fileReferenceName)
        {
            if (!File.Exists(fileReferenceName))
                return;

            string fieldExpr = @"public\s[A-Za-z0-9\.<>]+\s[A-Za-z0-9]+;";

            var lines = File.ReadAllLines(fileReferenceName).ToList();

            if (lines.Any(x => x.Contains("Newtonsoft.Json")))
                return;

            int index = 0;

            while (lines.Count > index)
            {
                string line = lines[index].Trim();

                if (System.Text.RegularExpressions.Regex.IsMatch(line, fieldExpr))
                {
                    string fieldName = line.Split(' ').ElementAtOrDefault(2)?.Replace(";", "") ?? string.Empty;
                    string fieldNameProperty = char.ToLower(fieldName[0]) + fieldName[1..];
                    string typeContent = line.Split(' ').ElementAtOrDefault(1);
                    lines.Insert(index - 2, "[System.Text.Json.Serialization.JsonPropertyName(\"" + fieldNameProperty + "\"), Newtonsoft.Json.JsonProperty(PropertyName = \"" + fieldNameProperty + "\")] public " + typeContent + " " + fieldName + "Property { get { return " + fieldName + "; } set { " + fieldName + " = value; } }");
                    index++;
                }
                index++;
            }
            File.WriteAllLines(fileReferenceName, lines);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string GenerateController(ServiceGeneratorOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "Options is mandatory.");
            }

            var resultMethods = GenerateMethods(options);

            string templateController = GetTemplate(options, ClassType.Controller);
            string descriptionController = GetDescription(options, ClassType.Controller);

            return templateController
                .Replace("[UsingNamespace]", string.Join(Environment.NewLine, options.UsingNamespaces))
                .Replace("[Namespace]", options.Namespace ?? "Mvp24Hours.Generated")
                .Replace("[ServiceName]", options.ServiceName)
                .Replace("[ServiceTypeName]", options.ServiceType.Name)
                .Replace("[ControllerDescription]", descriptionController)
                .Replace("[MethodList]", string.Join(Environment.NewLine, resultMethods));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        internal static List<string> GenerateMethods(ServiceGeneratorOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "Options is mandatory.");
            }

            var result = new List<string>();

            string templateMethod = GetTemplate(options, ClassType.MethodController);
            string descriptionMethod = GetDescription(options, ClassType.MethodController);

            var methods = GetMethods(options);

            foreach (var method in methods)
            {
                var parametersName = string.Join
                    (", ", method.Parameters
                                 .Select(x => x.ParameterType + " " + x.Name)
                                 .ToArray());

                var parametersMethods = string.Join
                    (", ", method.Parameters
                                 .Select(x => x.Name)
                                 .ToArray());

                result.Add(
                    templateMethod
                        .Replace("[ServiceName]", method.ServiceName)
                        .Replace("[ReturnType]", method.ReturnType)
                        .Replace("[MethodName]", method.MethodName)
                        .Replace("[MethodNameClean]", method.MethodNameClean)
                        .Replace("[ParametersName]", parametersName)
                        .Replace("[ParametersMethod]", parametersMethods)
                        .Replace("[MethodDescription]", descriptionMethod)

                );
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="classType"></param>
        /// <returns></returns>
        internal static string GetTemplate(ServiceGeneratorOptions options, ClassType classType)
        {
            if (options.Templates.ContainsKey(classType))
            {
                return options.Templates[classType];
            }
            else if (options.TemplatesPath.ContainsKey(classType))
            {
                return GetTemplate(options.TemplatesPath[classType]);
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="classType"></param>
        /// <returns></returns>
        internal static string GetDescription(ServiceGeneratorOptions options, ClassType classType)
        {
            if (options.Descriptions.ContainsKey(classType))
            {
                return options.Descriptions[classType];
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal static string GetTemplate(string fileName)
        {
            string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string theDirectory = Path.GetDirectoryName(fullPath);
            return File.ReadAllText(Path.Combine(theDirectory, fileName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        internal static List<ClassMethod> GetMethods(ServiceGeneratorOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "Options is mandatory.");
            }

            var result = new List<ClassMethod>();

            foreach (var item in options.ServiceType.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                if (options.IgnoreMethods?.Contains(item.Name) ?? false)
                {
                    continue;
                }

                Type returnType = item.ReturnType;
                if (returnType.IsGenericType)
                {
                    returnType = item.ReturnType.GetGenericArguments().FirstOrDefault();
                }

                var method = new ClassMethod()
                {
                    ServiceName = options.ServiceName,
                    ReturnType = returnType.Name,
                    MethodName = item.Name
                };

                method.Parameters = item.GetParameters()
                    .Select(x => new ClassMethodParameter
                    {
                        Name = x.Name,
                        ParameterType = x.ParameterType.Name
                    })
                    .ToList();

                result.Add(method);
            }
            return result;
        }
    }
}
