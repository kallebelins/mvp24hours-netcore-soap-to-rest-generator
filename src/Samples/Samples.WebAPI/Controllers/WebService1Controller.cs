using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Infrastructure.Extensions;
using Mvp24Hours.WebAPI.Controller;
using Samples.WebAPI.Models;
using Samples.WebAPI.WebService;
using System.Threading.Tasks;

namespace Samples.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WebService1Controller : BaseMvpController
    {
        private readonly WebService1SoapClient _serviceClient;

        public WebService1Controller(WebService1SoapClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service1", Name = "WebService1Service1")]
        public async Task<ModelWithPropertyDto> Service1(ModelWithPropertyDto request)
        {
            Service1Response result = await _serviceClient.Service1Async(request.MapTo<Service1Request>());
            return result.MapTo<ModelWithPropertyDto>();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service2", Name = "WebService1Service2")]
        public async Task<ModelWithPropertyDto> Service2(ModelWithPropertyDto request)
        {
            Service2Response result = await _serviceClient.Service2Async(request.MapTo<Service2Request>());
            return result.MapTo<ModelWithPropertyDto>();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service3", Name = "WebService1Service3")]
        public async Task<ModelWithPropertyDto> Service3(ModelWithPropertyDto request)
        {
            Service3Response result = await _serviceClient.Service3Async(request.MapTo<Service3Request>());
            return result.MapTo<ModelWithPropertyDto>();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service4", Name = "WebService1Service4")]
        public async Task<ModelWithFieldDto> Service4(ModelWithFieldDto request)
        {
            Service4Response result = await _serviceClient.Service4Async(request.MapTo<Service4Request>());
            return result.MapTo<ModelWithFieldDto>();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service5", Name = "WebService1Service5")]
        public async Task<ModelWithFieldDto> Service5(ModelWithFieldDto request)
        {
            Service5Response result = await _serviceClient.Service5Async(request.MapTo<Service5Request>());
            return result.MapTo<ModelWithFieldDto>();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service6", Name = "WebService1Service6")]
        public async Task<ModelWithFieldDto> Service6(ModelWithFieldDto request)
        {
            Service6Response result = await _serviceClient.Service6Async(request.MapTo<Service6Request>());
            return result.MapTo<ModelWithFieldDto>();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service7", Name = "WebService1Service7")]
        public async Task<ModelWithPropertyDto> Service7(ModelWithPropertyDto request)
        {
            Service7Response result = await _serviceClient.Service7Async(request.MapTo<Service7Request>());
            return result.MapTo<ModelWithPropertyDto>();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service8", Name = "WebService1Service8")]
        public async Task<ModelWithFieldDto> Service8(ModelWithFieldDto request)
        {
            Service8Response result = await _serviceClient.Service8Async(request.MapTo<Service8Request>());
            return result.MapTo<ModelWithFieldDto>();
        }

    }
}
