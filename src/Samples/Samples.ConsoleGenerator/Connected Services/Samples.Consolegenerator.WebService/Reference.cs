﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Samples.Consolegenerator.WebService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModelWithProperty", Namespace="http://tempuri.org/")]
    public partial class ModelWithProperty : object
    {
        
        private int Property1Field;
        
        private int Property2Field;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Property1
        {
            get
            {
                return this.Property1Field;
            }
            set
            {
                this.Property1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Property2
        {
            get
            {
                return this.Property2Field;
            }
            set
            {
                this.Property2Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModelWithField", Namespace="http://tempuri.org/")]
    public partial class ModelWithField : object
    {
        
        private int Field1Field;
        
        private int Field2Field;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Field1
        {
            get
            {
                return this.Field1Field;
            }
            set
            {
                this.Field1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Field2
        {
            get
            {
                return this.Field2Field;
            }
            set
            {
                this.Field2Field = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Samples.Consolegenerator.WebService.WebService1Soap")]
    public interface WebService1Soap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service1", ReplyAction="*")]
        System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service1Response> Service1Async(Samples.Consolegenerator.WebService.Service1Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service2", ReplyAction="*")]
        System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service2Response> Service2Async(Samples.Consolegenerator.WebService.Service2Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service3", ReplyAction="*")]
        System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service3Response> Service3Async(Samples.Consolegenerator.WebService.Service3Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service4", ReplyAction="*")]
        System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service4Response> Service4Async(Samples.Consolegenerator.WebService.Service4Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service5", ReplyAction="*")]
        System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service5Response> Service5Async(Samples.Consolegenerator.WebService.Service5Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service6", ReplyAction="*")]
        System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service6Response> Service6Async(Samples.Consolegenerator.WebService.Service6Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service7", ReplyAction="*")]
        System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service7Response> Service7Async(Samples.Consolegenerator.WebService.Service7Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service8", ReplyAction="*")]
        System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service8Response> Service8Async(Samples.Consolegenerator.WebService.Service8Request request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service1Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service1", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service1RequestBody Body;
        
        public Service1Request()
        {
        }
        
        public Service1Request(Samples.Consolegenerator.WebService.Service1RequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service1RequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithProperty request;
        
        public Service1RequestBody()
        {
        }
        
        public Service1RequestBody(Samples.Consolegenerator.WebService.ModelWithProperty request)
        {
            this.request = request;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service1Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service1Response", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service1ResponseBody Body;
        
        public Service1Response()
        {
        }
        
        public Service1Response(Samples.Consolegenerator.WebService.Service1ResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service1ResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithProperty Service1Result;
        
        public Service1ResponseBody()
        {
        }
        
        public Service1ResponseBody(Samples.Consolegenerator.WebService.ModelWithProperty Service1Result)
        {
            this.Service1Result = Service1Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service2Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service2", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service2RequestBody Body;
        
        public Service2Request()
        {
        }
        
        public Service2Request(Samples.Consolegenerator.WebService.Service2RequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service2RequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithProperty request1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public Samples.Consolegenerator.WebService.ModelWithProperty request2;
        
        public Service2RequestBody()
        {
        }
        
        public Service2RequestBody(Samples.Consolegenerator.WebService.ModelWithProperty request1, Samples.Consolegenerator.WebService.ModelWithProperty request2)
        {
            this.request1 = request1;
            this.request2 = request2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service2Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service2Response", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service2ResponseBody Body;
        
        public Service2Response()
        {
        }
        
        public Service2Response(Samples.Consolegenerator.WebService.Service2ResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service2ResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithProperty Service2Result;
        
        public Service2ResponseBody()
        {
        }
        
        public Service2ResponseBody(Samples.Consolegenerator.WebService.ModelWithProperty Service2Result)
        {
            this.Service2Result = Service2Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service3Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service3", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service3RequestBody Body;
        
        public Service3Request()
        {
        }
        
        public Service3Request(Samples.Consolegenerator.WebService.Service3RequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service3RequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithProperty request1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public Samples.Consolegenerator.WebService.ModelWithProperty request2;
        
        public Service3RequestBody()
        {
        }
        
        public Service3RequestBody(Samples.Consolegenerator.WebService.ModelWithProperty request1, Samples.Consolegenerator.WebService.ModelWithProperty request2)
        {
            this.request1 = request1;
            this.request2 = request2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service3Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service3Response", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service3ResponseBody Body;
        
        public Service3Response()
        {
        }
        
        public Service3Response(Samples.Consolegenerator.WebService.Service3ResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service3ResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithProperty> Service3Result;
        
        public Service3ResponseBody()
        {
        }
        
        public Service3ResponseBody(System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithProperty> Service3Result)
        {
            this.Service3Result = Service3Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service4Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service4", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service4RequestBody Body;
        
        public Service4Request()
        {
        }
        
        public Service4Request(Samples.Consolegenerator.WebService.Service4RequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service4RequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithField request;
        
        public Service4RequestBody()
        {
        }
        
        public Service4RequestBody(Samples.Consolegenerator.WebService.ModelWithField request)
        {
            this.request = request;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service4Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service4Response", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service4ResponseBody Body;
        
        public Service4Response()
        {
        }
        
        public Service4Response(Samples.Consolegenerator.WebService.Service4ResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service4ResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithField Service4Result;
        
        public Service4ResponseBody()
        {
        }
        
        public Service4ResponseBody(Samples.Consolegenerator.WebService.ModelWithField Service4Result)
        {
            this.Service4Result = Service4Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service5Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service5", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service5RequestBody Body;
        
        public Service5Request()
        {
        }
        
        public Service5Request(Samples.Consolegenerator.WebService.Service5RequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service5RequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithField request1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public Samples.Consolegenerator.WebService.ModelWithField request2;
        
        public Service5RequestBody()
        {
        }
        
        public Service5RequestBody(Samples.Consolegenerator.WebService.ModelWithField request1, Samples.Consolegenerator.WebService.ModelWithField request2)
        {
            this.request1 = request1;
            this.request2 = request2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service5Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service5Response", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service5ResponseBody Body;
        
        public Service5Response()
        {
        }
        
        public Service5Response(Samples.Consolegenerator.WebService.Service5ResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service5ResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithField Service5Result;
        
        public Service5ResponseBody()
        {
        }
        
        public Service5ResponseBody(Samples.Consolegenerator.WebService.ModelWithField Service5Result)
        {
            this.Service5Result = Service5Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service6Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service6", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service6RequestBody Body;
        
        public Service6Request()
        {
        }
        
        public Service6Request(Samples.Consolegenerator.WebService.Service6RequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service6RequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Samples.Consolegenerator.WebService.ModelWithField request1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public Samples.Consolegenerator.WebService.ModelWithField request2;
        
        public Service6RequestBody()
        {
        }
        
        public Service6RequestBody(Samples.Consolegenerator.WebService.ModelWithField request1, Samples.Consolegenerator.WebService.ModelWithField request2)
        {
            this.request1 = request1;
            this.request2 = request2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service6Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service6Response", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service6ResponseBody Body;
        
        public Service6Response()
        {
        }
        
        public Service6Response(Samples.Consolegenerator.WebService.Service6ResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service6ResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithField> Service6Result;
        
        public Service6ResponseBody()
        {
        }
        
        public Service6ResponseBody(System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithField> Service6Result)
        {
            this.Service6Result = Service6Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service7Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service7", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service7RequestBody Body;
        
        public Service7Request()
        {
        }
        
        public Service7Request(Samples.Consolegenerator.WebService.Service7RequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service7RequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithProperty> request;
        
        public Service7RequestBody()
        {
        }
        
        public Service7RequestBody(System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithProperty> request)
        {
            this.request = request;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service7Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service7Response", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service7ResponseBody Body;
        
        public Service7Response()
        {
        }
        
        public Service7Response(Samples.Consolegenerator.WebService.Service7ResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service7ResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithProperty> Service7Result;
        
        public Service7ResponseBody()
        {
        }
        
        public Service7ResponseBody(System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithProperty> Service7Result)
        {
            this.Service7Result = Service7Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service8Request
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service8", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service8RequestBody Body;
        
        public Service8Request()
        {
        }
        
        public Service8Request(Samples.Consolegenerator.WebService.Service8RequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service8RequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithField> request;
        
        public Service8RequestBody()
        {
        }
        
        public Service8RequestBody(System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithField> request)
        {
            this.request = request;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Service8Response
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Service8Response", Namespace="http://tempuri.org/", Order=0)]
        public Samples.Consolegenerator.WebService.Service8ResponseBody Body;
        
        public Service8Response()
        {
        }
        
        public Service8Response(Samples.Consolegenerator.WebService.Service8ResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class Service8ResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithField> Service8Result;
        
        public Service8ResponseBody()
        {
        }
        
        public Service8ResponseBody(System.Collections.Generic.List<Samples.Consolegenerator.WebService.ModelWithField> Service8Result)
        {
            this.Service8Result = Service8Result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface WebService1SoapChannel : Samples.Consolegenerator.WebService.WebService1Soap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<Samples.Consolegenerator.WebService.WebService1Soap>, Samples.Consolegenerator.WebService.WebService1Soap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WebService1SoapClient(EndpointConfiguration endpointConfiguration) : 
                base(WebService1SoapClient.GetBindingForEndpoint(endpointConfiguration), WebService1SoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebService1SoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WebService1SoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebService1SoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WebService1SoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service1Response> Service1Async(Samples.Consolegenerator.WebService.Service1Request request)
        {
            return base.Channel.Service1Async(request);
        }
        
        public System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service2Response> Service2Async(Samples.Consolegenerator.WebService.Service2Request request)
        {
            return base.Channel.Service2Async(request);
        }
        
        public System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service3Response> Service3Async(Samples.Consolegenerator.WebService.Service3Request request)
        {
            return base.Channel.Service3Async(request);
        }
        
        public System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service4Response> Service4Async(Samples.Consolegenerator.WebService.Service4Request request)
        {
            return base.Channel.Service4Async(request);
        }
        
        public System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service5Response> Service5Async(Samples.Consolegenerator.WebService.Service5Request request)
        {
            return base.Channel.Service5Async(request);
        }
        
        public System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service6Response> Service6Async(Samples.Consolegenerator.WebService.Service6Request request)
        {
            return base.Channel.Service6Async(request);
        }
        
        public System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service7Response> Service7Async(Samples.Consolegenerator.WebService.Service7Request request)
        {
            return base.Channel.Service7Async(request);
        }
        
        public System.Threading.Tasks.Task<Samples.Consolegenerator.WebService.Service8Response> Service8Async(Samples.Consolegenerator.WebService.Service8Request request)
        {
            return base.Channel.Service8Async(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WebService1Soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.WebService1Soap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WebService1Soap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:54020/services/webservice1.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.WebService1Soap12))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:54020/services/webservice1.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            WebService1Soap,
            
            WebService1Soap12,
        }
    }
}
