#pragma checksum "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69d1f53ac7924f2cf8969cc7126e9a889237fcd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_StoreType_EditStoreType), @"mvc.1.0.view", @"/Areas/Admin/Views/StoreType/EditStoreType.cshtml")]
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
#line 1 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\_ViewImports.cshtml"
using DealSe;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69d1f53ac7924f2cf8969cc7126e9a889237fcd0", @"/Areas/Admin/Views/StoreType/EditStoreType.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_StoreType_EditStoreType : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.FormModels.StoreTypeFormModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
  
    ViewData["Title"] = "EditStoreType";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 241, "\"", 298, 1);
#nullable restore
#line 10 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
WriteAttributeValue("", 248, Url.Action("Index", "Home" , new {Area="Admin" }), 248, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li><a");
            BeginWriteAttribute("href", " href=\"", 358, "\"", 421, 1);
#nullable restore
#line 12 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
WriteAttributeValue("", 365, Url.Action("Index", "StoreType" , new { Area="Admin" }), 365, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-globe\"></i>Store Types</a></li>\r\n    <li class=\"active\">\r\n        <strong>Edit Store Type</strong>\r\n    </li>\r\n</ol>\r\n<h2>Edit Store Type</h2>\r\n<br />\r\n");
#nullable restore
#line 19 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
 if (ViewBag.Error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong> ");
#nullable restore
#line 23 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
                                                              Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 26 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
 using (Html.BeginForm("EditStoreType", "StoreType", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
Write(await Html.PartialAsync("_StoreTypeInfo", Model));

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\EditStoreType.cshtml"
                                                     
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.FormModels.StoreTypeFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
