using ResumeMaker.Data.Models.Core;

namespace ResumeMaker.ViewModels.Home
{
    public class ContactViewModel : ContactDetail
    {
        public bool CanEdit { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
