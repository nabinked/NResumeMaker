namespace ResumeMaker.ViewModels
{
    public class DeleteActionViewModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public long RecordId { get; set; }
        public bool IsVisible { get; set; }
        public string ReturnUrl { get; set; }
    }
}
