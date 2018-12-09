using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Inova.Farm.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/AdminLTE/plugins/jQuery/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/AdminLTE/plugins/jQuery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/AdminLTE/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/AdminLTE/AdminLTE.css",
                      "~/Content/AdminLTE/AdminLTE.min.css"));
        }


    }
}