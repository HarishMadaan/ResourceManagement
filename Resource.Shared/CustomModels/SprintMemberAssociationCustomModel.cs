using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Shared.CustomModels
{
    public class SprintMemberAssociationCustomModel
    {
        public int SprintMemberAssociationId { get; set; }
        public Nullable<int> SprintId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string SprintName { get; set; }
        public string MemberName { get; set; }
        public List<SprintMemberAsscId> SprintMemberList { get; set; }
    }
    public class SprintMemberAsscId
    {
        public int SprintMemberId { get; set; }
    }
}
