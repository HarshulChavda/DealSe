#pragma checksum "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "939ec20c8dfda1d82ef51057b1df1d4ca7b791d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Area_AddArea), @"mvc.1.0.view", @"/Areas/Admin/Views/Area/AddArea.cshtml")]
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
#line 1 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\_ViewImports.cshtml"
using DealSe;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"939ec20c8dfda1d82ef51057b1df1d4ca7b791d9", @"/Areas/Admin/Views/Area/AddArea.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Area_AddArea : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.FormModels.AreaFormModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
  
    ViewData["Title"] = "AddArea";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 221, "\"", 278, 1);
#nullable restore
#line 9 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
WriteAttributeValue("", 228, Url.Action("Index", "Home" , new {Area="Admin" }), 228, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li><a");
            BeginWriteAttribute("href", " href=\"", 338, "\"", 396, 1);
#nullable restore
#line 11 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
WriteAttributeValue("", 345, Url.Action("Index", "Area" , new { Area="Admin" }), 345, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-globe\"></i>Areas</a></li>\r\n    <li class=\"active\">\r\n        <strong>Add Area</strong>\r\n    </li>\r\n</ol>\r\n<h2>Add Area</h2>\r\n<br />\r\n");
#nullable restore
#line 18 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
 if (ViewBag.Error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong> ");
#nullable restore
#line 22 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
                                                              Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 25 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
 using (Html.BeginForm("AddArea", "Area", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
Write(await Html.PartialAsync("_AreaInfo", Model));

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\AddArea.cshtml"
                                                
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.FormModels.AreaFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
