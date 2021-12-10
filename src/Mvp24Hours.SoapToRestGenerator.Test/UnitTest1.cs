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
        public void Test1_Models()
        {
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "MyProject.WebAPI.Models",
                ServiceName = "MyService",
                ServiceType = typeof(ServiceClient)
            };

            var result = ServiceGenerator.GenerateModels(modelOptions);
            Assert.True(result.Count == 2);
        }

        [Fact]
        public void Test2_Models_Mapping()
        {
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "MyProject.WebAPI.Models",
                ServiceName = "MyService",
                ServiceType = typeof(ServiceClient),
                ModelSuffix = "Dto"
            };
            modelOptions.TemplatesPath[ClassType.Model] = ServiceGeneratorConstants.FILE_CLASS_MODEL_MAPPING;

            var result = ServiceGenerator.GenerateModels(modelOptions);
            Assert.True(result.Count == 2);
        }

        [Fact]
        public void Test3_Models_Async()
        {
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "MyProject.WebAPI.Models",
                ServiceName = "MyService",
                ServiceType = typeof(ServiceAsyncClient)
            };

            var result = ServiceGenerator.GenerateModels(modelOptions);
            Assert.True(result.Count == 2);
        }

        [Fact]
        public void Test4_Models_Mapping_Async()
        {
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "MyProject.WebAPI.Models",
                ServiceName = "MyService",
                ServiceType = typeof(ServiceAsyncClient),
                ModelSuffix = "Dto"
            };
            modelOptions.TemplatesPath[ClassType.Model] = ServiceGeneratorConstants.FILE_CLASS_MODEL_MAPPING;

            var result = ServiceGenerator.GenerateModels(modelOptions);
            Assert.True(result.Count == 2);
        }

        [Fact]
        public void Test5_Controller()
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
        public void Test6_Controller_Mapping()
        {
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
            Assert.True(result != null);
        }

        [Fact]
        public void Test7_Controller_Async()
        {
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "MyProject.WebAPI.Controller",
                ServiceName = "MyService",
                ServiceType = typeof(ServiceAsyncClient)
            };
            modelOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_MAPPING_ASYNC_CONTROLLER;

            var result = ServiceGenerator.GenerateController(modelOptions);
            Assert.True(result != null);
        }

        [Fact]
        public void Test8_Controller_Mapping_Async()
        {
            var modelOptions = new ServiceGeneratorOptions
            {
                Namespace = "MyProject.WebAPI.Controller",
                ServiceName = "MyService",
                ServiceType = typeof(ServiceAsyncClient),
                ModelSuffix = "Dto"
            };
            modelOptions.TemplatesPath[ClassType.Model] = ServiceGeneratorConstants.FILE_CLASS_MODEL_MAPPING;
            modelOptions.TemplatesPath[ClassType.MethodController] = ServiceGeneratorConstants.FILE_METHOD_MAPPING_ASYNC_CONTROLLER;

            var result = ServiceGenerator.GenerateController(modelOptions);
            Assert.True(result != null);
        }

    }
}
