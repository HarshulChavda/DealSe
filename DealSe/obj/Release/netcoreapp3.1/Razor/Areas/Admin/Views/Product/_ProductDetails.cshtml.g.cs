#pragma checksum "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Product\_ProductDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2825d8b39a0b67d4d1529f542e207291a7ce7c76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product__ProductDetails), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/_ProductDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2825d8b39a0b67d4d1529f542e207291a7ce7c76", @"/Areas/Admin/Views/Product/_ProductDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4270d6d7021694fcdb731a7f4dcc3677d9d0cfc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product__ProductDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table class=""table table-bordered table-striped datatable scroll"" id=""ProductDetails"">
    <thead>
        <tr>
            <th class=""searchcheck"">
                <div class=""checkbox checkbox-replace"">
                    <input type=""checkbox"" id=""chk-1"" onclick=""checkall(this);"">
                </div>
            </th>
            <th>Sr No.</th>
            <th>Color Code</th>
            <th>Product Sub Category</th>
            <th>Company</th>
            <th>Product</th>
            <th>Image</th>
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
            $('#ProductDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked', true);
                $(this)");
            WriteLiteral(@".attr('checked', true);
            });
            $("".itemclass"").addClass(""checked"");
        }
        else {
            $('#ProductDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked', false);
            });
            $("".itemclass"").removeClass(""checked"");
        }
    }
    function checkchanged() {
        $('#ProductDetails td input[type=""checkbox""]').on(""change"", function () {
            checkAllCheckboxes()
        });
    }
    function checkAllCheckboxes() {
        var total = $('#ProductDetails td input[type=""checkbox""]').length;
        var selected = 0;
        $('#ProductDetails td input[type=""checkbox""]').each(function () {
            if ($(this).is("":checked"")) {
                selected += 1;
            }
        });
        if ((selected == total) && (total != 0)) {
            $('#ProductDetails th input[type=""checkbox""]').prop(""checked"", true);
            $('#ProductDetails th input[type=""checkbox""]').trigger(""cha");
            WriteLiteral("nge\")\r\n        }\r\n        else {\r\n            $(\'#ProductDetails th input[type=\"checkbox\"]\').prop(\"checked\", false);\r\n            $(\'#ProductDetails th input[type=\"checkbox\"]\').trigger(\"change\")\r\n        }\r\n    }\r\n</script>");
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
