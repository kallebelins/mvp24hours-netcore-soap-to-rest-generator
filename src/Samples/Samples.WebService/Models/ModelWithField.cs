using System.Runtime.Serialization;

namespace Samples.WebService.Models
{
    [DataContract(IsReference = false)]
    public class ModelWithField
    {
        [DataMember]
        public int Field1;
        [DataMember]
        public int Field2;
    }
}