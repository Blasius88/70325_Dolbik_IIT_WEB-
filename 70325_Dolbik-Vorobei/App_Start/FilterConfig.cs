using System.Web;
using System.Web.Mvc;

namespace _70325_Dolbik_Vorobei
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
