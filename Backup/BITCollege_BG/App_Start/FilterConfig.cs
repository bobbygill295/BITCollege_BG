﻿using System.Web;
using System.Web.Mvc;

namespace BITCollege_BG
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}