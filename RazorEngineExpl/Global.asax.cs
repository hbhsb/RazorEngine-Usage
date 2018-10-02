using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using RazorEngine;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngineExpl.AppCode;
using RazorEngineExpl.Models;

namespace RazorEngineExpl
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Preload();
            //对RazorEngine进行配置
            var config = new TemplateServiceConfiguration();
            config.DisableTempFileLocking = true;
            config.CachingProvider = new DefaultCachingProvider(t => { });
            //config.ReferenceResolver = new MyIReferenceResolver();
            string[] viewFoldersToWatch = { Server.MapPath("~/Views/") };
            config.TemplateManager = new ResolvePathTemplateManager(viewFoldersToWatch);
            //扩展RazorEngine模板语法
            config.BaseTemplateType = typeof(HtmlTranslateBase<>);
            var service = RazorEngineService.Create(config);
            Engine.Razor = service;

            //对模板进行Compile
            string mainPanel = Server.MapPath("~/Views/MainPanel.cshtml");
            string detailCard = Server.MapPath("~/Views/DetailCard.cshtml");
            Engine.Razor.Compile(mainPanel, typeof(CommonModel));
            Engine.Razor.Compile(detailCard, typeof(CommonModel));
        }

        private static void Preload()
        {
            var refAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (AssemblyName refAssembly in refAssemblies)
            {
                Assembly.Load(refAssembly);
            }
        }
    }
}