﻿using System.Security.Claims;
using DbPortal;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using ResumeMaker.Common;

namespace ResumeMaker.Components
{
    public class ResumeMakerBaseViewComponent : ViewComponent
    {
        [FromServices]
        public IOptions<Appsettings> AppSettings { get; set; }

        public IConnectionFactory ConnectionFactory { get; set; }

        public Data.DbContext DbContext => new Data.DbContext();

        public new ClaimsPrincipal User
        {
            get
            {
                var claimsPrincipal = new ClaimsPrincipal(base.User);
                return claimsPrincipal;
            }
        }
    }
}
