using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCAngular.App_Start
{
  public class BundleConfig
  {
    public static void registerBundle(BundleCollection bundles)
    {
      ScriptBundle scriptBundle = new ScriptBundle("~/bundles/angular");

      //scriptBundle.Include(
      //  "~/dist/MVCAngular/vendor-es2015.js",
      //  "~/dist/MVCAngular/vendor-es5.js",
      //  "~/dist/MVCAngular/styles-es2015.js",
      //  "~/dist/MVCAngular/styles-es5.js",
      //  "~/dist/MVCAngular/runtime-es2015.js",
      //  "~/dist/MVCAngular/runtime-es5.js",
      //  "~/dist/MVCAngular/main-es5.js",
      //  "~/dist/MVCAngular/main-es2015.js",
      //  "~/dist/MVCAngular/polyfills-es5.js",
      //  "~/dist/MVCAngular/polyfills-es2015.js"
      //  );

      scriptBundle.IncludeDirectory("~/dist/MVCAngular/", "*.js", true);

      bundles.Add(scriptBundle);
    }
  }
}
