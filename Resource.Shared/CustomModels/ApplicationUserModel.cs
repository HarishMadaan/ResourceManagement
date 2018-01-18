using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Shared.CustomModels
{
    public class ApplicationUserModel
    {
        public int ApplicationUserId { get; set; }
        public Nullable<int> UserIdentityKey { get; set; }
        public Nullable<int> UserTypeId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MemberCode { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Designation { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
