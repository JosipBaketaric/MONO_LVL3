﻿using System.Web;
using System.Web.Mvc;

namespace LVL3.MVCApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
