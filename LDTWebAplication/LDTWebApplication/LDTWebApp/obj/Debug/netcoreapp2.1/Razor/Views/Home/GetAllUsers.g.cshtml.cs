#pragma checksum "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\Home\GetAllUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71f8b170026ccaf42bfb10e9d349141eb685eeea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetAllUsers), @"mvc.1.0.view", @"/Views/Home/GetAllUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/GetAllUsers.cshtml", typeof(AspNetCore.Views_Home_GetAllUsers))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\_ViewImports.cshtml"
using LDTWebApp;

#line default
#line hidden
#line 2 "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\_ViewImports.cshtml"
using LDTWebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71f8b170026ccaf42bfb10e9d349141eb685eeea", @"/Views/Home/GetAllUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e953eaf10afd45e7a1cb99fb97ca8484df9943c8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetAllUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebViewModels.UserViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\Home\GetAllUsers.cshtml"
  
    ViewData["Title"] = "GetAllUsers";

#line default
#line hidden
            BeginContext(96, 32, true);
            WriteLiteral("\r\n<h2>GetAllUsers</h2>\r\n\r\n<ol>\r\n");
            EndContext();
#line 9 "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\Home\GetAllUsers.cshtml"
     foreach (WebViewModels.UserViewModel item in Model)
    {

#line default
#line hidden
            BeginContext(193, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(206, 14, false);
#line 11 "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\Home\GetAllUsers.cshtml"
       Write(item.Firstname);

#line default
#line hidden
            EndContext();
            BeginContext(220, 19, true);
            WriteLiteral("</li>\r\n        <li>");
            EndContext();
            BeginContext(240, 13, false);
#line 12 "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\Home\GetAllUsers.cshtml"
       Write(item.Lastname);

#line default
#line hidden
            EndContext();
            BeginContext(253, 19, true);
            WriteLiteral("</li>\r\n        <li>");
            EndContext();
            BeginContext(273, 12, false);
#line 13 "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\Home\GetAllUsers.cshtml"
       Write(item.Address);

#line default
#line hidden
            EndContext();
            BeginContext(285, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 14 "C:\Users\User\Documents\ProjectLDT\LDTWebAplication\LDTWebApplication\LDTWebApp\Views\Home\GetAllUsers.cshtml"
    }

#line default
#line hidden
            BeginContext(299, 5, true);
            WriteLiteral("</ol>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebViewModels.UserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
