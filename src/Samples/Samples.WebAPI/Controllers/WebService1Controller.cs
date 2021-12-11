using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.WebAPI.Controller;

namespace Samples.WebAPI.WebService
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
        public Service1Response Service1(Service1Request request)
        {
            return _serviceClient.Service1Async(request).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service2", Name = "WebService1Service2")]
        public Service2Response Service2(Service2Request request)
        {
            return _serviceClient.Service2Async(request).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service3", Name = "WebService1Service3")]
        public Service3Response Service3(Service3Request request)
        {
            return _serviceClient.Service3Async(request).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service4", Name = "WebService1Service4")]
        public Service4Response Service4(Service4Request request)
        {
            return _serviceClient.Service4Async(request).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service5", Name = "WebService1Service5")]
        public Service5Response Service5(Service5Request request)
        {
            return _serviceClient.Service5Async(request).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service6", Name = "WebService1Service6")]
        public Service6Response Service6(Service6Request request)
        {
            return _serviceClient.Service6Async(request).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service7", Name = "WebService1Service7")]
        public Service7Response Service7(Service7Request request)
        {
            return _serviceClient.Service7Async(request).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("Service8", Name = "WebService1Service8")]
        public Service8Response Service8(Service8Request request)
        {
            return _serviceClient.Service8Async(request).Result;
        }
    }
}
