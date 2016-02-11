using System;

namespace ResumeMaker.ViewModels
{
    public class CreateUpdateActionViewModel
    {
        public string FormParams { get; set; }
        public string TargetElementId { get; set; }
        public Uri GetFormUrl { get; set; }
        public string InnerText { get; set; }
        public bool IsVisible { get; set; }
    }
}
