using CORE.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Classes
{
    public class OperationClaims : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
