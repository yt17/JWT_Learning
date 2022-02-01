using CORE.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Classes
{
    public class UserOperationClaims : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
