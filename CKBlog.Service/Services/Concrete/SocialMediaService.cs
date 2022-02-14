using CKBlog.Data.Repositories.Concrete;
using CKBlog.Data.UnitOfWork;
using CKBlog.Entity.DbObjects;
using CKBlog.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKBlog.Service.Services.Concrete
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SocialMediaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SocialMedia>> ListAllSocialMedias()
        {
            return await _unitOfWork.SocialMedias.GetAllAsync();
        }
    }
}
