#pragma checksum "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\ProductCategory\_ProductCategoryDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9343477a673a2f41bfb72946de39723abc683215"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ProductCategory__ProductCategoryDetails), @"mvc.1.0.view", @"/Areas/Admin/Views/ProductCategory/_ProductCategoryDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9343477a673a2f41bfb72946de39723abc683215", @"/Areas/Admin/Views/ProductCategory/_ProductCategoryDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4270d6d7021694fcdb731a7f4dcc3677d9d0cfc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ProductCategory__ProductCategoryDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table class=""table table-bordered table-striped datatable scroll"" id=""ProductCategoryDetails"">
    <thead>
        <tr>
            <th class=""searchcheck"">
                <div class=""checkbox checkbox-replace"">
                    <input type=""checkbox"" id=""chk-1"" onclick=""checkall(this);"">
                </div>
            </th>
            <th>Sr No.</th>
            <th>Name</th>
            <th>Icon</th>
            <th>Added Date</th>
            <th>Active</th>
            <th class=""actionedit view-more"">
                Actions
            </th>
        </tr>
    </thead>
</table>
<script type=""text/javascript"">
    function checkall(current) {
        var status = $('#' + current.id).is(':checked');
        if (status == true) {
            $('#ProductCategoryDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked', true);
                $(this).attr('checked', true);
            });
            $("".itemclass"").addClass(""checked"");
  ");
            WriteLiteral(@"      }
        else {
            $('#ProductCategoryDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked', false);
            });
            $("".itemclass"").removeClass(""checked"");
        }
    }
    function checkchanged() {
        $('#ProductCategoryDetails td input[type=""checkbox""]').on(""change"", function () {
            checkAllCheckboxes()
        });
    }
    function checkAllCheckboxes() {
        var total = $('#ProductCategoryDetails td input[type=""checkbox""]').length;
        var selected = 0;
        $('#ProductCategoryDetails td input[type=""checkbox""]').each(function () {
            if ($(this).is("":checked"")) {
                selected += 1;
            }
        });
        if ((selected == total) && (total != 0)) {
            $('#ProductCategoryDetails th input[type=""checkbox""]').prop(""checked"", true);
            $('#ProductCategoryDetails th input[type=""checkbox""]').trigger(""change"")
        }
        else {
            ");
            WriteLiteral("$(\'#ProductCategoryDetails th input[type=\"checkbox\"]\').prop(\"checked\", false);\r\n            $(\'#ProductCategoryDetails th input[type=\"checkbox\"]\').trigger(\"change\")\r\n        }\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
