using System.Collections.Generic;
using ResumeMaker.Data.Models.Core;

namespace ResumeMaker.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<ResumeDisplayTile> ResumeDisplayTiles { get; set; }

    }

    public class ResumeDisplayTile
    {
        public long UserId { get; set; }
        public string Summary { get; set; }

    }
}
