namespace ResumeMaker.ViewModels
{
    public class RatingsViewModel
    {
        public int AverageRating { get; set; }

        /// <summary>
        /// Always set this to Either "small-star" or "large-star" to change the star size
        /// </summary>
        public string Size { get; set; }
    }
}
