#pragma checksum "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a1b9d11dfb7a90cc7af865d537d0b208b65cf44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_StoreType__StoreTypeInfo), @"mvc.1.0.view", @"/Areas/Admin/Views/StoreType/_StoreTypeInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a1b9d11dfb7a90cc7af865d537d0b208b65cf44", @"/Areas/Admin/Views/StoreType/_StoreTypeInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_StoreType__StoreTypeInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.FormModels.StoreTypeFormModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml"
Write(Html.HiddenFor(Model => Model.AddedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml"
Write(Html.HiddenFor(Model => Model.StoreTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <div class=""row"">
            <div class=""col-md-6"">
                <div class=""form-group"">
                    <label class=""control-label"">Name</label>
                    <label class=""field-validation-error"">*</label>
                    ");
#nullable restore
#line 12 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml"
               Write(Html.TextBoxFor(model => model.Name, new { @class = "form-control htmlvalid trimmed txtOnly", @maxlength = "50" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 13 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml"
               Write(Html.ValidationMessageFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
            <div class=""col-md-6"">
                <div class=""form-group"">
                    <label class=""control-label"">Status</label>
                    <div class=""form-group"">
                        <div class=""make-switch statusswitch"" data-on=""status"" data-off=""status"" data-on-label=""Active"" data-off-label=""Inactive"">
                            ");
#nullable restore
#line 21 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml"
                       Write(Html.CheckBoxFor(Model => Model.Active, new { @checked = "checked" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div class=""row center"">
        <button type=""submit"" id=""btnSubmit"" class=""btn btn-success"">
            <i class=""glyphicon glyphicon-save""></i>
            Save
        </button>
        <a");
            BeginWriteAttribute("href", " href=\"", 1450, "\"", 1514, 1);
#nullable restore
#line 32 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\StoreType\_StoreTypeInfo.cshtml"
WriteAttributeValue("", 1457, Url.Action("Index", "StoreType", new { Area = "Admin" }), 1457, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\">\r\n            <i class=\"glyphicon glyphicon-remove\"></i>\r\n            Cancel\r\n        </a>\r\n    </div>\r\n");
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
