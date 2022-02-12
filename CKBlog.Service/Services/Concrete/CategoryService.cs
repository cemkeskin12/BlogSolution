using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Data.UnitOfWork;
using CKBlog.Entity.DbObjects;
using CKBlog.Service.Services.Abstract;

namespace CKBlog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Category>> ListAllCategoriesAsync()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> CategoryAddAsync(Category entity, string createdByName)
        {
            entity.CreatedByName = createdByName;
            entity.ModifiedByName = createdByName;
            await _unitOfWork.Categories.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity;
        }

        public async Task<Category> GetByIdCategoryAsync(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);

        }

        public Category CategoryUpdate(Category entity, string modifiedByName)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedByName = modifiedByName;
            var result = _unitOfWork.Categories.Update(entity);
            _unitOfWork.Save();
            return result;
        }

        public Category CategoryDelete(Category entity)
        {
            var query = entity.IsActive;
            if (query)
            {
                entity.IsActive = false;
            }
            else
            {
                entity.IsActive = true;
            }

            var result = _unitOfWork.Categories.Update(entity);
            _unitOfWork.Save();
            return result;
        }
    }
}
