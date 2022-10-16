using System.Web;
using System.Web.Mvc;

namespace Logistics.UILayer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            // *Authorize  -  Giriş yapmadan hiç bir sayfa açılamasın
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());
            //


            filters.Add(new HandleErrorAttribute());
        }
    }
}
