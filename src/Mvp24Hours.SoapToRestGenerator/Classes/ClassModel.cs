using System.Collections.Generic;

namespace Mvp24Hours.SoapToRestGenerator.Classes
{
    public class ClassModel
    {
        public ClassModel()
        {
            Properties = new List<ClassProperty>();
            Fields = new List<ClassField>();
            Parents = new List<string>();
        }
        public string Name { get; set; }
        public IList<ClassProperty> Properties { get; set; }
        public IList<ClassField> Fields { get; set; }
        public IList<string> Parents { get; set; }
    }
}
