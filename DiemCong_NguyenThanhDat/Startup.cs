using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiemCong_NguyenThanhDat.Startup))]
namespace DiemCong_NguyenThanhDat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
