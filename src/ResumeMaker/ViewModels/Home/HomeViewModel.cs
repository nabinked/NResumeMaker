﻿using ResumeMaker.Data.Models.Core;

namespace ResumeMaker.ViewModels.Home
{
    public class HomeViewModel
    {
        public bool IsUserLoggedIn { get; set; }

        public ContactDetails ContactDetails { get; set; }
        public Summary Summary { get; set; }
        public Objective Objective { get; set; }
    }
}
