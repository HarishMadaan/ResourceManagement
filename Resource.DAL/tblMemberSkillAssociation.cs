//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resource.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMemberSkillAssociation
    {
        public int SkillAssociationId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> SkillId { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual tblMember tblMember { get; set; }
        public virtual tblSkill tblSkill { get; set; }
    }
}