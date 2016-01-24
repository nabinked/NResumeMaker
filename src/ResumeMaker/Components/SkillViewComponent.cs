using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ResumeMaker.Services.ToastNotification;

namespace ResumeMaker.Components
{
    public class SkillViewComponent : ResumeMakerBaseViewComponent
    {
        public IViewComponentResult Invoke(long userId)
        {
            var skills = DbContext.Skill.GetAllByProperty(x => x.UserId, userId).OrderByDescending(x=>x.Proficiency);
            return View("SkillView",skills);
        }

    }
}
