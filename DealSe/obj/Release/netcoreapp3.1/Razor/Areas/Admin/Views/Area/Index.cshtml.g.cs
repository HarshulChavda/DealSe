#pragma checksum "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "632a8fe679651a6171489d32d1bc6de3c964b497"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Area_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Area/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"632a8fe679651a6171489d32d1bc6de3c964b497", @"/Areas/Admin/Views/Area/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Area_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.ViewModels.AreaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 228, "\"", 286, 1);
#nullable restore
#line 9 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
WriteAttributeValue("", 235, Url.Action("Index", "Home",new { Area = "Admin" }), 235, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li>\r\n        <i class=\"entypo-globe\"></i>Areas\r\n    </li>\r\n</ol>\r\n<h2>Areas</h2>\r\n<br />\r\n");
#nullable restore
#line 17 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
 if (TempData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong><br /><span> ");
#nullable restore
#line 21 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
                                                                          Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
}
else if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-success\"><strong>Success!</strong> ");
#nullable restore
#line 29 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
                                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 32 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-12"">
        <div class=""panel panel-default panel-shadow"" data-collapsed=""0"">
            <!-- to apply shadow add class ""panel-shadow"" -->
            <!-- panel head -->
            <div class=""panel-heading"">
                <div class=""panel-title""><i class=""entypo-search""></i> Search</div>
                <div class=""panel-options"">
                    <a href=""#"" data-rel=""collapse""><i class=""entypo-down-open""></i></a>
                </div>
            </div>

            <!-- panel body -->
            <div class=""panel-body search-panel"">
                <div class=""row"">
                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <label class=""control-label"" for=""status"">Country Name</label>
                            ");
#nullable restore
#line 51 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
                       Write(Html.DropDownListFor(Model => Model.CountryId, new SelectList(ViewBag.CountryList, "Value", "Text"), "Select Country", new { @class = "select2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <label class=""control-label"" for=""status"">State Name</label>
                            ");
#nullable restore
#line 57 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
                       Write(Html.DropDownListFor(Model => Model.StateId, new SelectList(ViewBag.StateList, "Value", "Text"), "Select State", new { @class = "select2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <label class=""control-label"" for=""status"">City Name</label>
                            ");
#nullable restore
#line 63 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
                       Write(Html.DropDownListFor(Model => Model.CityId, new SelectList(ViewBag.CityList, "Value", "Text"), "Select City", new { @class = "select2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""row center"">
                    <button type=""button"" id=""btnsearch"" class=""btn btn-success"">
                        <i class=""entypo entypo-search""></i>
                        Search
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>
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
            BeginWriteAttribute("href", " href=\"", 3648, "\"", 3709, 1);
#nullable restore
#line 89 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
WriteAttributeValue("", 3655, Url.Action("AddArea", "Area", new { Area = "Admin" }), 3655, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm btn-icon icon-left adminaddbutton\">\r\n            <i class=\"entypo-plus\"></i>\r\n            Add Area\r\n        </a>\r\n    </div>\r\n</div>\r\n<br class=\"clear\" />\r\n");
#nullable restore
#line 96 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
Write(await Html.PartialAsync("_AreaDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 97 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
Write(await Html.PartialAsync("_FillCommonDropdownListScript"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 98 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
Write(await Html.PartialAsync("_DatatableCSSJSView"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        var cityId = $(""#CityId"").val();
        if (cityId != """") {
            loadData();
        }
    });
    var responsiveHelper;
    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };
    $(""#btnsearch"").click(function () {
        loadData();
    });
    function loadData() {
        var cityId = $(""#CityId"").val();
        var tableContainer;
        tableContainer = $(""#AreaDetails"");

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
                    ""url"": '/Admin/Area/LoadData',
                    ""type"": ""POST"",
                ");
            WriteLiteral(@"    ""data"": { cityId: cityId},
                    ""datatype"": ""json""
                },

                ""aoColumns"": [
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""5%"",
                        ""mRender"": function (data, type, row) {
                            return ""<div class='checkbox checkbox-replace itemclass'><input type='checkbox' id="" + row.areaId + ""></div>"";
                        }
                    },
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""10%"",
                        ""mRender"": function (data, type, row) {
                            return '';
                        }
                    },
                    { ""data"": ""name"", ""name"": ""AreaName"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""30%"" },
                    { ""data"": ""displayAddedDate"", ""name"": ""DisplayAddedDate"", ""bSearchable"": true,""bSortable"": true, ""autoWidth"": tr");
            WriteLiteral(@"ue, ""width"": ""15%"" },
                    {
                        ""mData"": ""active"", ""name"": ""active"", ""autoWidth"": true, ""width"": ""12%"",
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
                        ""mData"": ""Activated"", ""bSearchable"": false, ""bSortable"": false, ""autoWidth"": true, ""width"": ""13%"",
                        ""mRender"": function (data, type, row) {
                            return '<a class=""btn btn-blue btn-sm btn-icon icon-left"" href=""/Admin/Area/EditArea/' + row.areaId + '""><i class=""entypo-pencil""></i>Edit</a>';
                        }, ""sClass"": ""view-mo");
            WriteLiteral(@"re""
                    }
                ],
                ""fnRowCallback"": function (nRow, aData, iDisplayIndex) {
                    var info = $(this).DataTable().page.info();
                    $(""td:nth-child(2)"", nRow).append(info.start + iDisplayIndex + 1);
                    return nRow;
                },
                ""fnDrawCallback"": function () {
                    replaceCheckboxes();
                    responsivePaginationDesign();
                    checkAllCheckboxes();
                    addresponsiveTableDiv(""#AreaDetails"");
                },
            });
            $("".dataTables_wrapper select"").select2({
                minimumResultsForSearch: -1
            });
    }

    $(window).resize(function () {
        if (window.matchMedia('(max-width: 768px)').matches) {
            responsiveTableColumn('#AreaDetails');
        }
    })

     $("".statusbutton"").click(function () {
            $(""#preloader"").show();
            var checkedrecord = ");
            WriteLiteral(@"new Array();
            var checkactivestatus = $('#AreaDetails tbody tr').find(':checkbox:checked').length;
            if (checkactivestatus == 0) {

                $.alert({
                    title: 'Alert!',
                    content: 'Please select atleast one record.',
                });
            $(""#preloader"").hide();
            $("".checkbox-replace"").removeClass(""checked"");
            $(""#chk-1"").removeAttr(""checked"");
            $('#AreaDetails th input[type=""checkbox""]').prop(""checked"", false);
            $('#AreaDetails td input[type=""checkbox""]').prop(""checked"", false);
            return false;
            }
            $('#AreaDetails tbody tr').find(':checkbox:checked').each(function (i, row) {
                var $actualrow = $(row);
                $checkbox = $actualrow;
                if ($checkbox.attr('id') != 'chk-1') {
                    checkedrecord.push($checkbox.attr('id'));
                }
            });

        if (checkedrecord.length >");
            WriteLiteral(@" 0) {
            var status = $(this).data(""statuslabel"");
            var alertMessage = '';

            if (status == ""Active"")
                alertMessage = 'Are you sure you want to active record(s)?';
            else (status == ""Inactive"")
                alertMessage = 'Are you sure you want to inactive record(s)?';

            $.confirm({
                title: 'Confirm!',
                content: alertMessage,
                buttons: {
                    confirm: function () {
                        $.post('");
#nullable restore
#line 232 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\Area\Index.cshtml"
                           Write(Url.Action("AreaOperation", "Area", new {area="Admin"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', { checkedrecord: checkedrecord, status: status, countryId: $(""#CountryId"").val(), stateId: $(""#StateId"").val(), cityId: $(""#CityId"").val() }, function (data) {
                            if (data == ""Success"") {
                                $(""#preloader"").hide();
                                window.location.href = ""/admin/Area"";
                            } else {
                                $(""#preloader"").hide();
                            }
                        });
                    },
                    cancel: function () {
                        $("".checkbox-replace"").removeClass(""checked"");
                        $(""#chk-1"").removeAttr(""checked"");
                        $('#AreaDetails th input[type=""checkbox""]').prop(""checked"", false);
                        $('#AreaDetails td input[type=""checkbox""]').prop(""checked"", false);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.ViewModels.AreaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
