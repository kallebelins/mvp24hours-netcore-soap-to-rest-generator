using System.Collections.Generic;

namespace Mvp24Hours.SoapToRestGenerator.Classes
{
    public class ClassMethod
    {
        public ClassMethod()
        {
            Parameters = new List<ClassMethodParameter>();
        }

        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string ReturnType { get; set; }
        public List<ClassMethodParameter> Parameters { get; set; }

        public string MethodNameClean
        {
            get
            {
                string name = MethodName;
                if (!string.IsNullOrEmpty(name) && name.EndsWith("Async"))
                {
                    return name[0..^5];
                }

                return MethodName;
            }
        }
    }
}
