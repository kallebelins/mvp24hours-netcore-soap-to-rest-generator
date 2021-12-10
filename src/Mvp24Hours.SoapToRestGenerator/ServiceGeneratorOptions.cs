using Mvp24Hours.SoapToRestGenerator.Classes;
using System;
using System.Collections.Generic;

namespace Mvp24Hours.SoapToRestGenerator
{
    public class ServiceGeneratorOptions
    {
        public ServiceGeneratorOptions()
        {
            IgnoreMethods = new List<string>()
            {
                "Equals", "Abort", "Close", "Open", "CloseAsync", "GetHashCode", "GetType", "ToString"
                , "OpenAsync", "get_ChannelFactory", "get_ClientCredentials", "get_State", "get_InnerChannel", "get_Endpoint"
            };
            Templates = new Dictionary<ClassType, string>();
            TemplatesPath = new Dictionary<ClassType, string>()
            {
                { ClassType.Model, ServiceGeneratorConstants.FILE_CLASS_MODEL },
                { ClassType.FieldModel, ServiceGeneratorConstants.FILE_FIELD_MODEL },
                { ClassType.PropertyModel, ServiceGeneratorConstants.FILE_PROPERTY_MODEL },
                { ClassType.Controller, ServiceGeneratorConstants.FILE_CLASS_CONTROLLER },
                { ClassType.MethodController, ServiceGeneratorConstants.FILE_METHOD_CONTROLLER }
            };
            Descriptions = new Dictionary<ClassType, string>();
            UsingNamespaces = new List<string>();
        }

        public Type ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string Namespace { get; set; }
        public List<string> UsingNamespaces { get; set; }
        public List<string> IgnoreMethods { get; private set; }
        public Dictionary<ClassType, string> Descriptions { get; private set; }
        public Dictionary<ClassType, string> Templates { get; private set; }
        public Dictionary<ClassType, string> TemplatesPath { get; private set; }
        public string ModelPrefix { get; set; }
        public string ModelSuffix { get; set; }
    }
}
