using CKBlog.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CKBlog.Web.ViewComponents
{
    public class SocialMediaListViewComponent : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaListViewComponent(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var social = await _socialMediaService.ListAllSocialMedias();
            return View(social);
        }
    }
}
