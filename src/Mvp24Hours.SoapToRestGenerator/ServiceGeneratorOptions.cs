//=====================================================================================
// Developed by Kallebe Lins (kallebe.santos@outlook.com)
// Teacher, Architect, Consultant and Project Leader
// Virtual Card: https://www.linkedin.com/in/kallebelins
//=====================================================================================
// Reproduction or sharing is free! Contribute to a better world!
//=====================================================================================
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
                { ClassType.Controller, ServiceGeneratorConstants.FILE_CLASS_CONTROLLER },
                { ClassType.MethodController, ServiceGeneratorConstants.FILE_METHOD_ASYNC_CONTROLLER }
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
    }
}
