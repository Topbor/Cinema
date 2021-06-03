using System.Web;
using System.Web.Mvc;

namespace CinemaTR3
{
    public class FilterConfig : MvcApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
