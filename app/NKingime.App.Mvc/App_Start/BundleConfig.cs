using System.Web;
using System.Web.Optimization;

namespace NKingime.App.Mvc
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/static/shared/js/jquery-{version}.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/static/shared/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/lib/bootstrap").Include(
                      "~/static/lib/bootstrap/js/bootstrap.js",
                      "~/static/lib/bootstrap/js/bootstrap-table.js",
                      "~/static/lib/bootstrap/js/bootstrap-table-zh-CN.js",
                      "~/static/shared/js/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css/bootstrap").Include(
                      "~/static/lib/bootstrap/css/bootstrap.css",
                      "~/static/lib/bootstrap/css/bootstrap-table.css",
                      "~/static/shared/css/site.css"));
        }
    }
}
