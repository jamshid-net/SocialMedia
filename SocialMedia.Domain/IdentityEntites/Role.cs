using SocialMedia.Domain.Common;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.IdentityEntites
{
    public class Role : BaseAuditableEntity 
    {
        public string RoleName { get; set; }
        public virtual List<Permission>? Permissions { get; set; }
        public List<User>? UserRoles { get; set; }
    }
}
