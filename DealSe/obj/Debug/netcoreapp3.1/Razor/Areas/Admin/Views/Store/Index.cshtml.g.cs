#pragma checksum "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a5fea780cbea4754de3243f156c9defd527b264"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Store_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Store/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a5fea780cbea4754de3243f156c9defd527b264", @"/Areas/Admin/Views/Store/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Store_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.ViewModels.StoreViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 230, "\"", 288, 1);
#nullable restore
#line 9 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 237, Url.Action("Index", "Home",new { Area = "Admin" }), 237, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li>\r\n        <i class=\"entypo-globe\"></i>Stores\r\n    </li>\r\n</ol>\r\n<h2>Stores</h2>\r\n<br />\r\n");
#nullable restore
#line 17 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
 if (TempData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong><br /><span> ");
#nullable restore
#line 21 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
                                                                          Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
}
else if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-success\"><strong>Success!</strong> ");
#nullable restore
#line 29 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
                                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 32 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
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
        <a href=""#"" class=""btn btn-blue btn-sm btn-icon icon-left statusbutton"" data-statuslabel=""Approve"">
            <i class=""entypo-check""></i>
            Approve
        </a>
        <a href=""#"" class=""btn btn-black btn-sm btn-icon icon-left statusbutton"" data-statuslabel=""DisApprove"">
            <i class=""entypo-cancel""></i>
            Dis Approve
        </a>
        <a href=""#"" class=""btn btn-danger btn-sm btn-icon icon-left statusbutton"" data-statuslabel=""Delete"">
            <i class=""entypo-trash""></i>
            Delete
        </a>
    </div");
            WriteLiteral(">\r\n    <div class=\"col-xs-12 col-sm-4\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 1973, "\"", 2036, 1);
#nullable restore
#line 58 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 1980, Url.Action("AddStore", "Store", new { Area = "Admin" }), 1980, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm btn-icon icon-left adminaddbutton\">\r\n            <i class=\"entypo-plus\"></i>\r\n            Add Store\r\n        </a>\r\n    </div>\r\n</div>\r\n<br class=\"clear\" />\r\n");
#nullable restore
#line 65 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
Write(await Html.PartialAsync("_StoreDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 66 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
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
        tableContainer = $(""#StoreDetails"");
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
                    ""url"": '/Admin/Store/LoadData',
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },

                ""aoColumns"": [
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""5%"",
   ");
            WriteLiteral(@"                     ""mRender"": function (data, type, row) {
                            return ""<div class='checkbox checkbox-replace itemclass'><input type='checkbox' id="" + row.storeId + ""></div>"";
                        }
                    },
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""5%"",
                        ""mRender"": function (data, type, row) {
                            return '';
                        }
                    },
                    { ""data"": ""storeTypeName"", ""name"": ""storeTypeName"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""8%"" },
                    { ""data"": ""areaName"", ""name"": ""areaName"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""8%"" },
                    { ""data"": ""name"", ""name"": ""name"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""14%"" },
                    { ""data"": ""email"", ""name"": ""email"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""8%"" },
                   ");
            WriteLiteral(@" { ""data"": ""ownerName"", ""name"": ""ownerName"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""8%"" },
                    { ""data"": ""ownerMobileNo"", ""name"": ""ownerMobileNo"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""8%"" },
                    { ""data"": ""displayAddedDate"", ""name"": ""displayAddedDate"", ""bSearchable"": true,""bSortable"": true, ""autoWidth"": true, ""width"": ""8%"" },
                    {
                        ""mData"": ""approved"", ""name"": ""approved"", ""autoWidth"": true, ""width"": ""5%"",
                        ""mRender"": function (data, type, row) {
                            if (row.approved == true) {
                                return '<div class=""label label-success"">Yes</div>';
                            }
                            else {
                                return '<div class=""label label-danger"">No</div>';
                            }
                        }
                    },
                    {
                        ""mData"": ""active"", ""name"":");
            WriteLiteral(@" ""active"", ""autoWidth"": true, ""width"": ""8%"",
                        ""mRender"": function (data, type, row) {
                            if (row.active == true) {
                                return '<div class=""label label-success"">Active</div>';
                            }
                            else {
                                return '<div class=""label label-inactive"">Inactive</div>';
                            }
                        }
                    },
                    {
                        ""mData"": ""Activated"", ""bSearchable"": false, ""bSortable"": false, ""autoWidth"": true, ""width"": ""8%"",
                        ""mRender"": function (data, type, row) {
                            return '<a class=""btn btn-blue btn-sm btn-icon icon-left"" href=""/Admin/Store/EditStore/' + row.storeId + '""><i class=""entypo-pencil""></i>Edit</a>';
                        }, ""sClass"": ""view-more""
                    }
                ],
                ""fnRowCallback"": function (nRow");
            WriteLiteral(@", aData, iDisplayIndex) {
                    var info = $(this).DataTable().page.info();
                    $(""td:nth-child(2)"", nRow).append(info.start + iDisplayIndex + 1);
                    return nRow;
                },
                ""fnDrawCallback"": function () {
                    replaceCheckboxes();
                    responsivePaginationDesign();
                    checkAllCheckboxes();
                    addresponsiveTableDiv(""#StoreDetails"");
                },
            });
            $("".dataTables_wrapper select"").select2({
                minimumResultsForSearch: -1
            });
    }
    $(window).resize(function () {
        if (window.matchMedia('(max-width: 768px)').matches) {
            responsiveTableColumn('#StoreDetails');
        }
    })

     $("".statusbutton"").click(function () {
            $(""#preloader"").show();
            var checkedrecord = new Array();
            var checkactivestatus = $('#StoreDetails tbody tr').find(':checkbox:c");
            WriteLiteral(@"hecked').length;
            if (checkactivestatus == 0) {

                $.alert({
                    title: 'Alert!',
                    content: 'Please select atleast one record.',
                });
            $(""#preloader"").hide();
            $("".checkbox-replace"").removeClass(""checked"");
            $(""#chk-1"").removeAttr(""checked"");
            $('#StoreDetails th input[type=""checkbox""]').prop(""checked"", false);
            $('#StoreDetails td input[type=""checkbox""]').prop(""checked"", false);
            return false;
            }
            $('#StoreDetails tbody tr').find(':checkbox:checked').each(function (i, row) {
                var $actualrow = $(row);
                $checkbox = $actualrow;
                if ($checkbox.attr('id') != 'chk-1') {
                    checkedrecord.push($checkbox.attr('id'));
                }
            });

        if (checkedrecord.length > 0) {
            var status = $(this).data(""statuslabel"");
            var alertMessage ");
            WriteLiteral(@"= '';

            if (status == ""Active"")
                alertMessage = 'Are you sure you want to active record(s)?';
            else if(status == ""Inactive"")
                alertMessage = 'Are you sure you want to inactive record(s)?';
            else (status == ""Delete"")
                alertMessage = 'Are you sure you want to delete record(s)?';

            $.confirm({
                title: 'Confirm!',
                content: alertMessage,
                buttons: {
                    confirm: function () {
                        $.post('");
#nullable restore
#line 208 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\Store\Index.cshtml"
                           Write(Url.Action("StoreOperation", "Store", new {area="Admin"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', { checkedrecord: checkedrecord, status: status }, function (data) {
                            if (data == ""Success"") {
                                $(""#preloader"").hide();
                                window.location.href = ""/admin/Store"";
                            } else {
                                $(""#preloader"").hide();
                            }
                        });
                    },
                    cancel: function () {
                        $("".checkbox-replace"").removeClass(""checked"");
                        $(""#chk-1"").removeAttr(""checked"");
                        $('#StoreDetails th input[type=""checkbox""]').prop(""checked"", false);
                        $('#StoreDetails td input[type=""checkbox""]').prop(""checked"", false);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.ViewModels.StoreViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
