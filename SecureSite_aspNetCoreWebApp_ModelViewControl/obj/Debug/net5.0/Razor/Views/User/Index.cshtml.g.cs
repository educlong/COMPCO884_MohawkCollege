#pragma checksum "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "063112047458bb83f503cc3ccbbb385c977ad43d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\_ViewImports.cshtml"
using SecureSite_aspNetCoreWebApp_ModelViewControl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\_ViewImports.cshtml"
using SecureSite_aspNetCoreWebApp_ModelViewControl.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"063112047458bb83f503cc3ccbbb385c977ad43d", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7da0433ed8da8460816598982446c73926af8d6a", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SecureSite_aspNetCoreWebApp_ModelViewControl.Models.ApplicationUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Users";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 12 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 26 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 29 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 35 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\SecureSite_aspNetCoreWebApp_ModelViewControl\Views\User\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SecureSite_aspNetCoreWebApp_ModelViewControl.Models.ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
