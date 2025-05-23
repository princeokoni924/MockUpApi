using Core.IRepository;
using Core.Models;
using Core.Models.DtosModels;
using Core.Params;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ObjectRepository(AppData _db) : IObjectRepository
    {

        /// <summary>
        /// Create new object
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        public async Task<ObjectModel> AddObj(AddObjectDtoModel productDto)
        {
            var addObj = new ObjectModel
            {
                Id = productDto.Id,
                ObjectName = productDto.ObjectName,
                Data = productDto.Data  
            };
            await _db.Objects.AddAsync(addObj);
            await _db.SaveChangesAsync();
            return addObj;
        }
        /// <summary>
        /// Delete object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteObj(int id)
        {
            var delObj = await _db.Objects.FindAsync(id);
            if (delObj == null)
            {
                return false;
            }
            _db.Objects.Remove(delObj);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get the list of all objects
        /// </summary>
        /// <returns></returns>
        public async Task<List<ObjectModel>> GetFilterAndAllObj(ObjectSpecParams param )
        {
            var filter = _db.Objects.AsQueryable();

            // filter by name if search is not empty
            if (!string.IsNullOrWhiteSpace(param.Search))
            {
                filter = filter.Where(x => x.ObjectName.ToLower().Contains(param.Search));
            }


            // applied paging
            int skip =(param.PageIndex -1) * param.PageSize;
            var allObj = await _db.Objects.ToListAsync();
            filter = filter.Skip(skip).Take(param.PageSize);
            return  await filter.ToListAsync();
        }

        public async Task<ObjectModel> GetObjById(int id)
        {
            var objById = await _db.Objects.FindAsync(id);
            return objById!;
        }


        /// <summary>
        /// Update object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task<ObjectModel> UpDateObj(int id, ObjectModel update)
        {
            var updateObj = await _db.Objects.FindAsync(id);
            if(updateObj == null)
            {
                return null!;
            }
            updateObj.ObjectName = update.ObjectName;
            updateObj.Data = update.Data;
            _db.Objects.Update(updateObj);
            await _db.SaveChangesAsync();
            return updateObj;
        }
    }
}
