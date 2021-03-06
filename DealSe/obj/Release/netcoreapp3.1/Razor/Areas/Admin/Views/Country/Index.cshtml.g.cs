#pragma checksum "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d7139b94be10a4a71a2259b2efb8a681757d764"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Country_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Country/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d7139b94be10a4a71a2259b2efb8a681757d764", @"/Areas/Admin/Views/Country/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Country_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.ViewModels.CountryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 234, "\"", 292, 1);
#nullable restore
#line 9 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
WriteAttributeValue("", 241, Url.Action("Index", "Home",new { Area = "Admin" }), 241, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li>\r\n        <i class=\"entypo-globe\"></i>Countries\r\n    </li>\r\n</ol>\r\n<h2>Countries</h2>\r\n<br />\r\n");
#nullable restore
#line 17 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
 if (TempData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong><br /><span> ");
#nullable restore
#line 21 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
                                                                          Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
}
else if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-success\"><strong>Success!</strong> ");
#nullable restore
#line 29 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
                                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 32 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row user-dactive"">
    <div class=""col-xs-12 col-sm-8"">
        <a href=""#"" class=""btn btn-green btn-sm btn-icon icon-left statusbutton"" data-statuslabel=""Active"">
            <i class=""entypo-check""></i>
            Active
        </a>
        <a href=""#"" class=""btn btn-orange btn-sm btn-icon icon-left statusbutton"" data-statuslabel=""Inactive"">
            <i class=""entypo-cancel""></i>
            Inactive
        </a>
    </div>
    <div class=""col-xs-12 col-sm-4"">
        <a");
            BeginWriteAttribute("href", " href=\"", 1416, "\"", 1483, 1);
#nullable restore
#line 46 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
WriteAttributeValue("", 1423, Url.Action("AddCountry", "Country", new { Area = "Admin" }), 1423, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm btn-icon icon-left adminaddbutton\">\r\n            <i class=\"entypo-plus\"></i>\r\n            Add Country\r\n        </a>\r\n    </div>\r\n</div>\r\n<br class=\"clear\" />\r\n");
#nullable restore
#line 53 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
Write(await Html.PartialAsync("_CountryDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 54 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
Write(await Html.PartialAsync("_DatatableCSSJSView"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        loadData();
    });
    var responsiveHelper;
    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };
    function loadData() {
        var tableContainer;
        tableContainer = $(""#CountryDetails"");
        tableContainer.dataTable(
            {
                ""destroy"": true,
                ""aaSorting"": [],
                ""pageLength"": 10,
                ""bStateSave"": false,
                ""processing"": true,
                oLanguage: {
                    sProcessing: ""<div id=preloader></div>""
                },
                ""serverSide"": true,
                ""ajax"": {
                    ""url"": '/Admin/Country/LoadData',
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },

                ""aoColumns"": [
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""5%"",");
            WriteLiteral(@"
                        ""mRender"": function (data, type, row) {
                            return ""<div class='checkbox checkbox-replace itemclass'><input type='checkbox' id="" + row.countryId + ""></div>"";
                        }
                    },
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""10%"",
                        ""mRender"": function (data, type, row) {
                            return '';
                        }
                    },
                    { ""data"": ""name"", ""name"": ""name"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""30%"" },
                    { ""data"": ""displayAddedDate"", ""name"": ""displayAddedDate"", ""bSearchable"": true,""bSortable"": true, ""autoWidth"": true, ""width"": ""15%"" },
                    {
                        ""mData"": ""active"", ""name"": ""active"", ""autoWidth"": true, ""width"": ""12%"",
                        ""mRender"": function (data, type, row) {
                            if (row.");
            WriteLiteral(@"active == true) {
                                return '<div class=""label label-success"">Active</div>';
                            }
                            else {
                                return '<div class=""label label-inactive"">Inactive</div>';
                            }
                        }
                    },
                    {
                        ""mData"": ""Activated"", ""bSearchable"": false, ""bSortable"": false, ""autoWidth"": true, ""width"": ""13%"",
                        ""mRender"": function (data, type, row) {
                            return '<a class=""btn btn-blue btn-sm btn-icon icon-left"" href=""/Admin/Country/EditCountry/' + row.countryId + '""><i class=""entypo-pencil""></i>Edit</a>';
                        }, ""sClass"": ""view-more""
                    }
                ],
                ""fnRowCallback"": function (nRow, aData, iDisplayIndex) {
                    var info = $(this).DataTable().page.info();
                    $(""td:nth-child(2)"", nRow).a");
            WriteLiteral(@"ppend(info.start + iDisplayIndex + 1);
                    return nRow;
                },
                ""fnDrawCallback"": function () {
                    replaceCheckboxes();
                    responsivePaginationDesign();
                    checkAllCheckboxes();
                    addresponsiveTableDiv(""#CountryDetails"");
                },
            });
            $("".dataTables_wrapper select"").select2({
                minimumResultsForSearch: -1
            });
    }
    $(window).resize(function () {
        if (window.matchMedia('(max-width: 768px)').matches) {
            responsiveTableColumn('#CountryDetails');
        }
    })

     $("".statusbutton"").click(function () {
            $(""#preloader"").show();
            var checkedrecord = new Array();
            var checkactivestatus = $('#CountryDetails tbody tr').find(':checkbox:checked').length;
            if (checkactivestatus == 0) {

                $.alert({
                    title: 'Alert!',
      ");
            WriteLiteral(@"              content: 'Please select atleast one record.',
                });
            $(""#preloader"").hide();
            $("".checkbox-replace"").removeClass(""checked"");
            $(""#chk-1"").removeAttr(""checked"");
            $('#CountryDetails th input[type=""checkbox""]').prop(""checked"", false);
            $('#CountryDetails td input[type=""checkbox""]').prop(""checked"", false);
            return false;
            }
            $('#CountryDetails tbody tr').find(':checkbox:checked').each(function (i, row) {
                var $actualrow = $(row);
                $checkbox = $actualrow;
                if ($checkbox.attr('id') != 'chk-1') {
                    checkedrecord.push($checkbox.attr('id'));
                }
            });

        if (checkedrecord.length > 0) {
            var status = $(this).data(""statuslabel"");
            var alertMessage = '';

            if (status == ""Active"")
                alertMessage = 'Are you sure you want to active record(s)?';
    ");
            WriteLiteral(@"        else (status == ""Inactive"")
                alertMessage = 'Are you sure you want to inactive record(s)?';

            $.confirm({
                title: 'Confirm!',
                content: alertMessage,
                buttons: {
                    confirm: function () {
                        $.post('");
#nullable restore
#line 178 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Country\Index.cshtml"
                           Write(Url.Action("CountryOperation", "Country", new {area="Admin"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', { checkedrecord: checkedrecord, status: status }, function (data) {
                            if (data == ""Success"") {
                                $(""#preloader"").hide();
                                window.location.href = ""/admin/Country"";
                            } else {
                                $(""#preloader"").hide();
                            }
                        });
                    },
                    cancel: function () {
                        $("".checkbox-replace"").removeClass(""checked"");
                        $(""#chk-1"").removeAttr(""checked"");
                        $('#CountryDetails th input[type=""checkbox""]').prop(""checked"", false);
                        $('#CountryDetails td input[type=""checkbox""]').prop(""checked"", false);
                        $(""#preloader"").hide();
                    }
                }
            });
        }
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.ViewModels.CountryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
