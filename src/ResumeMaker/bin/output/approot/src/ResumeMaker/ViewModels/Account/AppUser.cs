﻿namespace ResumeMaker.Common
{
    public class AppUser : IAppUser
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
