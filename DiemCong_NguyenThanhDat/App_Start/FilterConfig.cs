using System.Web;
using System.Web.Mvc;

namespace DiemCong_NguyenThanhDat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
