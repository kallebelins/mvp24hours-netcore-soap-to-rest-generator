//=====================================================================================
// Developed by Kallebe Lins (kallebe.santos@outlook.com)
// Teacher, Architect, Consultant and Project Leader
// Virtual Card: https://www.linkedin.com/in/kallebelins
//=====================================================================================
// Reproduction or sharing is free! Contribute to a better world!
//=====================================================================================
using Mvp24Hours.SoapToRestGenerator.Classes;
using System.Threading.Tasks;
using Xunit;

namespace Mvp24Hours.SoapToRestGenerator.Test
{
    public class UnitTest1
    {
        public class ModelWithProperty
        {
            public int Property1 { get; set; }
            public int Property2 { get; set; }
        }

        public class ModelWithField
        {
            public int Field1;
            public int Field2;
        }

        public class ServiceClient
        {
            public ModelWithProperty Service1(ModelWithProperty request)
            {
                return request;
            }

            public ModelWithField Service2(ModelWithField request)
            {
                return request;
            }
        }

        public class ServiceAsyncClient
        {
            public Task<ModelWithProperty> Service1Async(ModelWithProperty request)
            {
                return Task.FromResult(request);
            }

            public Task<ModelWithField> Service2Async(ModelWithField request)
            {
                return Task.FromResult(request);
            }
        }

        [Fact]
        public void Test1_Controller()
        {
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "MyProject.WebAPI.Controller",
                ServiceName = "MyService",
                ServiceType = typeof(ServiceClient)
            };

            var result = ServiceGenerator.GenerateController(modelOptions);
            Assert.True(result != null);
        }

        [Fact]
        public void Test2_Controller_Async()
        {
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "MyProject.WebAPI.Controller",
                ServiceName = "MyService",
                ServiceType = typeof(ServiceAsyncClient)
            };
            modelOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_ASYNC_CONTROLLER;

            var result = ServiceGenerator.GenerateController(modelOptions);
            Assert.True(result != null);
        }
    }
}
