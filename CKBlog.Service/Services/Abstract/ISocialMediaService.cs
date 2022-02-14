using CKBlog.Entity.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKBlog.Service.Services.Abstract
{
    public interface ISocialMediaService
    {
        Task<List<SocialMedia>> ListAllSocialMedias();
    }
}
