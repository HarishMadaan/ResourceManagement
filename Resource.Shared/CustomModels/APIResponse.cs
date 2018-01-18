using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Shared.CustomModels
{
    public class APIResponse
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public long TotalRecord { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public object ResponseData { get; set; }
        public List<string> errors { get; set; }
    }
}
