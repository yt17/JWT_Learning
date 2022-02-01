using CORE.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Product:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
