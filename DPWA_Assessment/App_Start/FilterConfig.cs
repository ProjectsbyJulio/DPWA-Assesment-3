﻿using System.Web;
using System.Web.Mvc;

namespace DPWA_Assessment
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
