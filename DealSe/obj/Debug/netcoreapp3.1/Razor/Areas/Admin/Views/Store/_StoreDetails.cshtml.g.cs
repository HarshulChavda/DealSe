#pragma checksum "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\_StoreDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c034d24f012aa4780bedbfe8d45a2e1d71282a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Store__StoreDetails), @"mvc.1.0.view", @"/Areas/Admin/Views/Store/_StoreDetails.cshtml")]
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
#line 1 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\_ViewImports.cshtml"
using DealSe;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c034d24f012aa4780bedbfe8d45a2e1d71282a2", @"/Areas/Admin/Views/Store/_StoreDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Store__StoreDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table class=""table table-bordered table-striped datatable scroll"" id=""StoreDetails"">
    <thead>
        <tr>
            <th class=""searchcheck"">
                <div class=""checkbox checkbox-replace"">
                    <input type=""checkbox"" id=""chk-1"" onclick=""checkall(this);"">
                </div>
            </th>
            <th>Sr No.</th>
            <th>Store Type</th>
            <th>Area</th>
            <th>Store</th>
            <th>Email</th>
            <th>Owner</th>
            <th>Owner Mobile No</th>
            <th>Added Date</th>
            <th>Approved</th>
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
            $('#StoreDetails input[type=""checkbox""]').each(function () {
                $(this).pr");
            WriteLiteral(@"op('checked', true);
                $(this).attr('checked', true);
            });
            $("".itemclass"").addClass(""checked"");
        }
        else {
            $('#StoreDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked', false);
            });
            $("".itemclass"").removeClass(""checked"");
        }
    }
    function checkchanged() {
        $('#StoreDetails td input[type=""checkbox""]').on(""change"", function () {
            checkAllCheckboxes()
        });
    }
    function checkAllCheckboxes() {
        var total = $('#StoreDetails td input[type=""checkbox""]').length;
        var selected = 0;
        $('#StoreDetails td input[type=""checkbox""]').each(function () {
            if ($(this).is("":checked"")) {
                selected += 1;
            }
        });
        if ((selected == total) && (total != 0)) {
            $('#StoreDetails th input[type=""checkbox""]').prop(""checked"", true);
            $('#StoreDetails th inpu");
            WriteLiteral("t[type=\"checkbox\"]\').trigger(\"change\")\r\n        }\r\n        else {\r\n            $(\'#StoreDetails th input[type=\"checkbox\"]\').prop(\"checked\", false);\r\n            $(\'#StoreDetails th input[type=\"checkbox\"]\').trigger(\"change\")\r\n        }\r\n    }\r\n</script>");
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