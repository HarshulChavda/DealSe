#pragma checksum "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e77ebcf479dddd5f25356fd8e16b3214068aabb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_StoreType_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/StoreType/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e77ebcf479dddd5f25356fd8e16b3214068aabb8", @"/Areas/Admin/Views/StoreType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_StoreType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.ViewModels.StoreTypeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 239, "\"", 297, 1);
#nullable restore
#line 9 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
WriteAttributeValue("", 246, Url.Action("Index", "Home",new { Area = "Admin" }), 246, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li>\r\n        <i class=\"entypo-globe\"></i>Store Types\r\n    </li>\r\n</ol>\r\n<h2>Store Types</h2>\r\n<br />\r\n");
#nullable restore
#line 17 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
 if (TempData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong><br /><span> ");
#nullable restore
#line 21 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
                                                                          Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
}
else if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-success\"><strong>Success!</strong> ");
#nullable restore
#line 29 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
                                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 32 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
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
        <a href=""#"" class=""btn btn-danger btn-sm btn-icon icon-left statusbutton"" data-statuslabel=""Delete"">
            <i class=""entypo-trash""></i>
            Delete
        </a>
    </div>
    <div class=""col-xs-12 col-sm-4"">
        <a");
            BeginWriteAttribute("href", " href=\"", 1611, "\"", 1682, 1);
#nullable restore
#line 50 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
WriteAttributeValue("", 1618, Url.Action("AddStoreType", "StoreType", new { Area = "Admin" }), 1618, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm btn-icon icon-left adminaddbutton\">\r\n            <i class=\"entypo-plus\"></i>\r\n            Add StoreType\r\n        </a>\r\n    </div>\r\n</div>\r\n<br class=\"clear\" />\r\n");
#nullable restore
#line 57 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
Write(await Html.PartialAsync("_StoreTypeDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 58 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
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
        tableContainer = $(""#StoreTypeDetails"");
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
                    ""url"": '/Admin/StoreType/LoadData',
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },

                ""aoColumns"": [
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""5");
            WriteLiteral(@"%"",
                        ""mRender"": function (data, type, row) {
                            return ""<div class='checkbox checkbox-replace itemclass'><input type='checkbox' id="" + row.storeTypeId + ""></div>"";
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
                            if");
            WriteLiteral(@" (row.active == true) {
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
                            return '<a class=""btn btn-blue btn-sm btn-icon icon-left"" href=""/Admin/StoreType/EditStoreType/' + row.storeTypeId + '""><i class=""entypo-pencil""></i>Edit</a>';
                        }, ""sClass"": ""view-more""
                    }
                ],
                ""fnRowCallback"": function (nRow, aData, iDisplayIndex) {
                    var info = $(this).DataTable().page.info();
                    $(""td:nth-child(");
            WriteLiteral(@"2)"", nRow).append(info.start + iDisplayIndex + 1);
                    return nRow;
                },
                ""fnDrawCallback"": function () {
                    replaceCheckboxes();
                    responsivePaginationDesign();
                    checkAllCheckboxes();
                    addresponsiveTableDiv(""#StoreTypeDetails"");
                },
            });
            $("".dataTables_wrapper select"").select2({
                minimumResultsForSearch: -1
            });
    }
    $(window).resize(function () {
        if (window.matchMedia('(max-width: 768px)').matches) {
            responsiveTableColumn('#StoreTypeDetails');
        }
    })

     $("".statusbutton"").click(function () {
            $(""#preloader"").show();
            var checkedrecord = new Array();
            var checkactivestatus = $('#StoreTypeDetails tbody tr').find(':checkbox:checked').length;
            if (checkactivestatus == 0) {

                $.alert({
                    title:");
            WriteLiteral(@" 'Alert!',
                    content: 'Please select atleast one record.',
                });
            $(""#preloader"").hide();
            $("".checkbox-replace"").removeClass(""checked"");
            $(""#chk-1"").removeAttr(""checked"");
            $('#StoreTypeDetails th input[type=""checkbox""]').prop(""checked"", false);
            $('#StoreTypeDetails td input[type=""checkbox""]').prop(""checked"", false);
            return false;
            }
            $('#StoreTypeDetails tbody tr').find(':checkbox:checked').each(function (i, row) {
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
                alertMessage = 'Are you sure you want to a");
            WriteLiteral(@"ctive record(s)?';
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
#line 184 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\StoreType\Index.cshtml"
                           Write(Url.Action("StoreTypeOperation", "StoreType", new {area="Admin"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', { checkedrecord: checkedrecord, status: status }, function (data) {
                            if (data == ""Success"") {
                                $(""#preloader"").hide();
                                window.location.href = ""/admin/StoreType"";
                            } else {
                                $(""#preloader"").hide();
                            }
                        });
                    },
                    cancel: function () {
                        $("".checkbox-replace"").removeClass(""checked"");
                        $(""#chk-1"").removeAttr(""checked"");
                        $('#StoreTypeDetails th input[type=""checkbox""]').prop(""checked"", false);
                        $('#StoreTypeDetails td input[type=""checkbox""]').prop(""checked"", false);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.ViewModels.StoreTypeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
