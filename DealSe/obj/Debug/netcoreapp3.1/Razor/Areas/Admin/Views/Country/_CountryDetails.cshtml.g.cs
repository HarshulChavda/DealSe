#pragma checksum "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Country\_CountryDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a91e831b601d1840d265d1fe2d6dc5d296603394"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Country__CountryDetails), @"mvc.1.0.view", @"/Areas/Admin/Views/Country/_CountryDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a91e831b601d1840d265d1fe2d6dc5d296603394", @"/Areas/Admin/Views/Country/_CountryDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Country__CountryDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table class=""table table-bordered table-striped datatable scroll"" id=""CountryDetails"">
    <thead>
        <tr>
            <th class=""searchcheck"">
                <div class=""checkbox checkbox-replace"">
                    <input type=""checkbox"" id=""chk-1"" onclick=""checkall(this);"">
                </div>
            </th>
            <th>Sr No.</th>
            <th>Country Name</th>
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
            $('#CountryDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked', true);
                $(this).attr('checked', true);
            });
            $("".itemclass"").addClass(""checked"");
        }
        else {
          ");
            WriteLiteral(@"  $('#CountryDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked', false);
            });
            $("".itemclass"").removeClass(""checked"");
        }
    }
    function checkchanged() {
        $('#CountryDetails td input[type=""checkbox""]').on(""change"", function () {
            checkAllCheckboxes()
        });
    }
    function checkAllCheckboxes() {
        var total = $('#CountryDetails td input[type=""checkbox""]').length;
        var selected = 0;
        $('#CountryDetails td input[type=""checkbox""]').each(function () {
            if ($(this).is("":checked"")) {
                selected += 1;
            }
        });
        if ((selected == total) && (total != 0)) {
            $('#CountryDetails th input[type=""checkbox""]').prop(""checked"", true);
            $('#CountryDetails th input[type=""checkbox""]').trigger(""change"")
        }
        else {
            $('#CountryDetails th input[type=""checkbox""]').prop(""checked"", false);
           ");
            WriteLiteral(" $(\'#CountryDetails th input[type=\"checkbox\"]\').trigger(\"change\")\r\n        }\r\n    }\r\n</script>");
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
