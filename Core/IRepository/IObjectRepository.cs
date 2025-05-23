using Core.Models;
using Core.Models.DtosModels;
using Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IObjectRepository
    {
        Task<List<ObjectModel>> GetFilterAndAllObj(ObjectSpecParams param);
        Task<ObjectModel> GetObjById(int id);
        Task<ObjectModel> UpDateObj (int id, ObjectModel update);
        Task<bool> DeleteObj(int id);
        Task<ObjectModel> AddObj(AddObjectDtoModel productDto);
    }
}
