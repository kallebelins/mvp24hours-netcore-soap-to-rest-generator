using Samples.WebService.Models;
using System.Collections.Generic;
using System.Web.Services;

namespace Samples.WebService.Services
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public ModelWithProperty Service1(ModelWithProperty request)
        {
            return request;
        }

        [WebMethod]
        public ModelWithProperty Service2(ModelWithProperty request1, ModelWithProperty request2)
        {
            return new ModelWithProperty
            {
                Property1 = request1?.Property1 ?? 0 + request2?.Property1 ?? 0,
                Property2 = request1?.Property2 ?? 0 + request2?.Property2 ?? 0
            };
        }

        [WebMethod]
        public List<ModelWithProperty> Service3(ModelWithProperty request1, ModelWithProperty request2)
        {
            return new List<ModelWithProperty> { request1, request2 };
        }

        [WebMethod]
        public ModelWithField Service4(ModelWithField request)
        {
            return request;
        }

        [WebMethod]
        public ModelWithField Service5(ModelWithField request1, ModelWithField request2)
        {
            return new ModelWithField
            {
                Field1 = request1?.Field1 ?? 0 + request2?.Field1 ?? 0,
                Field2 = request1?.Field2 ?? 0 + request2?.Field2 ?? 0
            };
        }

        [WebMethod]
        public List<ModelWithField> Service6(ModelWithField request1, ModelWithField request2)
        {
            return new List<ModelWithField> { request1, request2 };
        }

        [WebMethod]
        public List<ModelWithProperty> Service7(List<ModelWithProperty> request)
        {
            return request;
        }

        [WebMethod]
        public List<ModelWithField> Service8(List<ModelWithField> request)
        {
            return request;
        }
    }
}
