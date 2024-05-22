using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stone.Willock.Infrastructure.Library
{
    public interface IOutput
    {
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object? Result { get; set; }

        object GetResult();
        void AddResult(object result);
        void AddErrorMessage(string error);
        void AddMessage(string error);
    }
}
