using Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DtosModels
{
    public class AddObjectDtoModel:BaseEntity
    {
        public string ObjectName { get; set;} = string.Empty;
        public String Data { get; set; } = string.Empty;
    }
}
