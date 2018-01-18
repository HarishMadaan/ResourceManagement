using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Shared.CustomModels
{
    public class SkillCustomModel
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
