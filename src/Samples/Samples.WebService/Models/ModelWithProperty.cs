using System.Runtime.Serialization;

namespace Samples.WebService.Models
{
    [DataContract(IsReference = false)]
    public class ModelWithProperty
    {
        [DataMember]
        public int Property1 { get; set; }
        [DataMember]
        public int Property2 { get; set; }
    }
}