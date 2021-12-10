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
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<ClassModelResult> GenerateModels(ServiceGeneratorOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "Options is mandatory.");
            }

            var result = new List<ClassModelResult>();

            string templateModel = GetTemplate(options, ClassType.Model);
            string descriptionModel = GetDescription(options, ClassType.Model);
            string templateProperty = GetTemplate(options, ClassType.PropertyModel);
            string descriptionProperty = GetDescription(options, ClassType.PropertyModel);
            string templateField = GetTemplate(options, ClassType.FieldModel);
            string descriptionField = GetDescription(options, ClassType.FieldModel);

            var models = GetModels(options);

            foreach (var model in models)
            {
                string resultModel = templateModel
                    .Replace("[UsingNamespace]", string.Join(Environment.NewLine, options.UsingNamespaces))
                    .Replace("[Namespace]", options.Namespace ?? "Mvp24Hours.Generated")
                    .Replace("[ClassDescription]", descriptionModel)
                    .Replace("[ClassName]", model.Name)
                    .Replace("[ClassNameMapped]", $"{options.ModelPrefix ?? string.Empty}{model.Name}{options.ModelSuffix ?? string.Empty}");

                var propContents = new List<string>();

                foreach (var prop in model.Properties)
                {
                    propContents.Add(templateProperty
                        .Replace("[PropertyDescription]", descriptionProperty.Replace("[PropertyName]", prop.Name))
                        .Replace("[PropertyName]", prop.Name)
                        .Replace("[PropertyType]", prop.TypeName)
                    );
                }

                var fieldContents = new List<string>();

                foreach (var prop in model.Fields)
                {
                    fieldContents.Add(templateField
                        .Replace("[FieldDescription]", descriptionField.Replace("[FieldName]", prop.Name))
                        .Replace("[FieldName]", prop.Name)
                        .Replace("[FieldType]", prop.TypeName)
                    );
                }

                result.Add(new ClassModelResult
                {
                    Name = model.Name,
                    Content = resultModel
                        .Replace("[PropertyList]", string.Join(Environment.NewLine, propContents))
                        .Replace("[FieldList]", string.Join(Environment.NewLine, fieldContents))
                });
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<string> GenerateMethods(ServiceGeneratorOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "Options is mandatory.");
            }

            var result = new List<string>();

            string templateMethod = GetTemplate(options, ClassType.MethodController);
            string descriptionMethod = GetDescription(options, ClassType.MethodController);

            var methods = GetMethods(options);
            var models = GetModels(options);

            foreach (var method in methods)
            {
                var parametersName = string.Join
                    (", ", method.Parameters
                                 .Select(x => x.ParameterType + " " + x.Name)
                                 .ToArray());

                var parametersNameFormatted = string.Join
                    (", ", method.Parameters
                                 .Select(x => GetNameMapped(x.ParameterType, options.ModelPrefix, options.ModelSuffix, x.IsClass, models) + " " + x.Name)
                                 .ToArray());

                var parametersMethods = string.Join
                    (", ", method.Parameters
                                 .Select(x => x.Name)
                                 .ToArray());

                var parametersMethodsFormatted = string.Join
                    (", ", method.Parameters
                                 .Select(x => $"{x.Name}.MapTo<{x.ParameterType}>()")
                                 .ToArray());

                result.Add(
                    templateMethod
                        .Replace("[ServiceName]", method.ServiceName)
                        .Replace("[ReturnType]", method.ReturnType.TypeName)
                        .Replace("[ReturnTypeMapped]", GetNameMapped(method.ReturnType.TypeName, options.ModelPrefix, options.ModelSuffix, method.ReturnType.IsClass, models))
                        .Replace("[MethodName]", method.MethodName)
                        .Replace("[MethodNameClean]", method.MethodNameClean)
                        .Replace("[ParametersName]", parametersName)
                        .Replace("[ParametersNameMapped]", parametersNameFormatted)
                        .Replace("[ParametersMethod]", parametersMethods)
                        .Replace("[ParametersMethodMapped]", parametersMethodsFormatted)
                        .Replace("[MethodDescription]", descriptionMethod)

                );
            }

            return result;
        }

        static string GetNameMapped(string name, string prefix, string suffix, bool isComposite, List<ClassModel> models)
        {
            string dtoName = models.Where(x => x.Parents.Any(y => y.Contains(name))).Select(y => y.Name).FirstOrDefault();
            return isComposite ?
                $"{prefix ?? string.Empty}{dtoName ?? name}{suffix ?? string.Empty}"
                    : name;
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
                .Replace("[ServiceTypeName]", options.ServiceType.FullName)
                .Replace("[ControllerDescription]", descriptionController)
                .Replace("[MethodList]", string.Join(Environment.NewLine, resultMethods));
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
                    ReturnType = new ClassProperty
                    {
                        Name = returnType.Name,
                        TypeName = returnType.Name,
                        IsClass = returnType.IsClass && returnType.Name.ToLower() != "string"
                    },
                    MethodName = item.Name
                };

                if (string.IsNullOrEmpty(options.ModelPrefix) && string.IsNullOrEmpty(options.ModelSuffix))
                {
                    method.Parameters = item.GetParameters()
                        .Select(x => new ClassMethodParameter
                        {
                            Name = x.Name,
                            ParameterType = x.ParameterType.Name,
                            IsClass = x.ParameterType.IsClass
                        })
                        .ToList();
                }
                else
                {
                    //var models = GetModels(options);
                    //foreach (var model in models)
                    //{
                    //}
                    var dic = new Dictionary<string, ClassModel>();

                    string methodName = item.Name;

                    if (methodName.EndsWith("Asy
                        methodName = methodName[0..^5];

                    foreach (var param in item.GetParameters())
                    {
                        LoadModel(param.ParameterType, dic, methodName);
                    }
                }

                result.Add(method);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        internal static List<ClassModel> GetModels(ServiceGeneratorOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), "Options is mandatory.");
            }

            var dic = new Dictionary<string, ClassModel>();

            foreach (var item in options.ServiceType.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                if (options.IgnoreMethods?.Contains(item.Name) ?? false)
                {
                    continue;
                }

                string methodName = item.Name;

                if (methodName.EndsWith("Async"))
                    methodName = methodName[0..^5];

                LoadModel(item.ReturnType, dic, methodName);

                foreach (var pr in item.GetParameters())
                {
                    LoadModel(pr.ParameterType, dic, methodName);
                }
            }
            return dic.Values.ToList();
        }

        private static void LoadModel(Type type, Dictionary<string, ClassModel> dic, string methodName, string parent = null)
        {
            if (type == null)
            {
                return;
            }

            if (type.IsGenericType)
            {
                LoadModel(type.GetGenericArguments().FirstOrDefault(), dic, methodName, parent);
                return;
            }

            if (type.IsArray)
            {
                LoadModel(type.GetElementType(), dic, methodName, parent);
                return;
            }

            var model = new ClassModel
            {
                Name = type.Name
            };

            foreach (var prop in type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                if (!type.Name.StartsWith(methodName)
                    && !prop.Name.StartsWith(methodName)
                    && !prop.PropertyType.Name.StartsWith(methodName))
                {
                    model.Properties.Add(new ClassProperty
                    {
                        Name = prop.Name,
                        TypeName = prop.PropertyType.Name,
                        IsClass = prop.PropertyType.IsClass && prop.PropertyType.Name.ToLower() != "string"
                    });
                }
                else if (type.Name.StartsWith(methodName))
                {
                    parent = $"{parent}${type.Name}";
                }
                else if (prop.PropertyType.Name.StartsWith(methodName))
                {
                    parent = $"{parent}${prop.PropertyType.Name}";
                }

                if (prop.PropertyType.IsClass && prop.PropertyType.Name.ToLower() != "string")
                {
                    LoadModel(prop.PropertyType, dic, methodName, parent);
                }
            }

            foreach (var field in type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                if (!type.Name.StartsWith(methodName)
                    && !field.Name.StartsWith(methodName)
                    && !field.FieldType.Name.StartsWith(methodName))
                {
                    model.Fields.Add(new ClassField
                    {
                        Name = field.Name,
                        TypeName = field.FieldType.Name,
                        IsClass = field.FieldType.IsClass && field.FieldType.Name.ToLower() != "string"
                    });
                }
                else if (type.Name.StartsWith(methodName))
                {
                    parent = $"{parent}${type.Name}";
                }
                else if (field.FieldType.Name.StartsWith(methodName))
                {
                    parent = $"{parent}${field.FieldType.Name}";
                }

                if (field.FieldType.IsClass && field.FieldType.Name.ToLower() != "string")
                {
                    LoadModel(field.FieldType, dic, methodName, parent);
                }
            }

            if (model.Properties.Count > 0 || model.Fields.Count > 0)
            {
                if (!dic.ContainsKey(type.Name))
                {
                    dic.Add(model.Name, model);
                }
                dic[type.Name].Parents.Add(parent);
            }
        }

    }
}
