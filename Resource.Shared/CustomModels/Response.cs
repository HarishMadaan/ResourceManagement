using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Shared.CustomModels
{
    public class Response : IDisposable
    {
        public bool success { get; set; }
        public string message { get; set; }

        public object responseData { get; set; }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}