using System.Collections.Generic;
using ResumeMaker.Data;
using ResumeMaker.Data.Models.Core;

namespace ResumeMaker.ViewModels.Home
{
    public class ExperienceViewModel
    {
        public ExperienceViewModel()
        {

        }

        public ExperienceViewModel(Experience experience)
        {
            Experience = experience;
            JobDescriptions = new DbContext().JobDescription.GetAllByProperty(x => x.ExperienceId, Experience.Id);
            KeyAccomplishments = new DbContext().KeyAccomplishment.GetAllByProperty(x => x.ExperienceId, Experience.Id);

        }


        public Experience Experience { get; set; }

        public List<JobDescription> JobDescriptions { get; set; }

        public List<KeyAccomplishment> KeyAccomplishments { get; set; }

    }
}
