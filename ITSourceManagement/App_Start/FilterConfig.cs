using System.Web;
using System.Web.Mvc;
using ITSourceManagement.Filter;

namespace ITSourceManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
           // filters.Add(new MyActionFilterAttribute() { Message="全局"});//全局filter
            //filters.Add(new ErrorFilterAttribute());
        }
    }
}