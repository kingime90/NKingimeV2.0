﻿using System.Web.Mvc;

namespace NKingime.App.Mvc.Areas.Sample
{
    public class SampleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Sample";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Sample_default",
                "Sample/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}