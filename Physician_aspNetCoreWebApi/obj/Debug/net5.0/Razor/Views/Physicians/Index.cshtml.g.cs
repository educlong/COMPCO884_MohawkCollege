#pragma checksum "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "002b30dd3e0d3e73aa0b0df5a0072a6f7797098e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Physicians_Index), @"mvc.1.0.view", @"/Views/Physicians/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"002b30dd3e0d3e73aa0b0df5a0072a6f7797098e", @"/Views/Physicians/Index.cshtml")]
    public class Views_Physicians_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Physician_aspNetCoreWebApi.Models.Physician>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Specialty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OhipRegistration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Specialty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OhipRegistration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1406, "\"", 1438, 1);
#nullable restore
#line 52 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
WriteAttributeValue("", 1421, item.PhysicianId, 1421, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1491, "\"", 1523, 1);
#nullable restore
#line 53 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
WriteAttributeValue("", 1506, item.PhysicianId, 1506, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1578, "\"", 1610, 1);
#nullable restore
#line 54 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
WriteAttributeValue("", 1593, item.PhysicianId, 1593, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 57 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\Physician_aspNetCoreWebApi\Views\Physicians\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Physician_aspNetCoreWebApi.Models.Physician>> Html { get; private set; }
    }
}
#pragma warning restore 1591