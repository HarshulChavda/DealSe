#pragma checksum "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07b9a4ab1e7d0368d0916a55ec907d18ebb23144"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Country_AddCountry), @"mvc.1.0.view", @"/Areas/Admin/Views/Country/AddCountry.cshtml")]
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
#line 1 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\_ViewImports.cshtml"
using Pratigya;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b9a4ab1e7d0368d0916a55ec907d18ebb23144", @"/Areas/Admin/Views/Country/AddCountry.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4270d6d7021694fcdb731a7f4dcc3677d9d0cfc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Country_AddCountry : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pratigya.Areas.Admin.FormModels.CountryFormModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
  
    ViewData["Title"] = "AddCountry";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 242, "\"", 299, 1);
#nullable restore
#line 9 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
WriteAttributeValue("", 249, Url.Action("Index", "Home" , new {Area="Admin" }), 249, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li><a");
            BeginWriteAttribute("href", " href=\"", 359, "\"", 420, 1);
#nullable restore
#line 11 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
WriteAttributeValue("", 366, Url.Action("Index", "Country" , new { Area="Admin" }), 366, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-globe\"></i>Countries</a></li>\r\n    <li class=\"active\">\r\n        <strong>Add Country</strong>\r\n    </li>\r\n</ol>\r\n<h2>Add Country</h2>\r\n<br />\r\n");
#nullable restore
#line 18 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
 if (ViewBag.Error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong> ");
#nullable restore
#line 22 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
                                                              Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 25 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
 using (Html.BeginForm("AddCountry", "Country", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
Write(await Html.PartialAsync("_CountryInfo", Model));

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Country\AddCountry.cshtml"
                                                   
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pratigya.Areas.Admin.FormModels.CountryFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
