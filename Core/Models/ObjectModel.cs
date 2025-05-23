using Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ObjectModel:BaseEntity
    {
        public required string ObjectName { get; set; }
        public required string Data { get; set; }

    }
}
