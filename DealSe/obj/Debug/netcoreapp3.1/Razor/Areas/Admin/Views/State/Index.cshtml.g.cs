#pragma checksum "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9dd0561ceceab1a5ebf86aff8039af8df7f14405"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_State_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/State/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dd0561ceceab1a5ebf86aff8039af8df7f14405", @"/Areas/Admin/Views/State/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_State_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.ViewModels.StateViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 230, "\"", 288, 1);
#nullable restore
#line 9 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
WriteAttributeValue("", 237, Url.Action("Index", "Home",new { Area = "Admin" }), 237, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li>\r\n        <i class=\"entypo-globe\"></i>States\r\n    </li>\r\n</ol>\r\n<h2>States</h2>\r\n<br />\r\n");
#nullable restore
#line 17 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
 if (TempData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong><br /><span> ");
#nullable restore
#line 21 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
                                                                          Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
}
else if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-success\"><strong>Success!</strong> ");
#nullable restore
#line 29 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
                                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 32 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
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
#line 51 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
                       Write(Html.DropDownListFor(Model => Model.CountryId, new SelectList(ViewBag.CountryList, "Value", "Text"), "Select Country", new { @class = "select2" }));

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
            BeginWriteAttribute("href", " href=\"", 2828, "\"", 2891, 1);
#nullable restore
#line 78 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
WriteAttributeValue("", 2835, Url.Action("AddState", "State", new { Area = "Admin" }), 2835, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm btn-icon icon-left adminaddbutton\">\r\n            <i class=\"entypo-plus\"></i>\r\n            Add State\r\n        </a>\r\n    </div>\r\n</div>\r\n<br class=\"clear\" />\r\n");
#nullable restore
#line 85 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
Write(await Html.PartialAsync("_StateDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 86 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
Write(await Html.PartialAsync("_DatatableCSSJSView"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        var countryId = $(""#CountryId"").val();
        if (countryId != """") {
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
        var countryId = $(""#CountryId"").val();
        var tableContainer;
        tableContainer = $(""#StateDetails"");

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
                    ""url"": '/Admin/State/LoadData',
                    ""type"": ""POST"",");
            WriteLiteral(@"
                    ""data"": { countryId: countryId},
                    ""datatype"": ""json""
                },

                ""aoColumns"": [
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""5%"",
                        ""mRender"": function (data, type, row) {
                            return ""<div class='checkbox checkbox-replace itemclass'><input type='checkbox' id="" + row.stateId + ""></div>"";
                        }
                    },
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""10%"",
                        ""mRender"": function (data, type, row) {
                            return '';
                        }
                    },
                    { ""data"": ""name"", ""name"": ""name"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""30%"" },
                    { ""data"": ""displayAddedDate"", ""name"": ""displayAddedDate"", ""bSearchable"": true,""bSortable"": t");
            WriteLiteral(@"rue, ""autoWidth"": true, ""width"": ""15%"" },
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
                            return '<a class=""btn btn-blue btn-sm btn-icon icon-left"" href=""/Admin/State/EditState/' + row.stateId + '""><i class=""entypo-pencil""></i>Edit</a>';
                      ");
            WriteLiteral(@"  }, ""sClass"": ""view-more""
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
                    addresponsiveTableDiv(""#StateDetails"");
                },
            });
            $("".dataTables_wrapper select"").select2({
                minimumResultsForSearch: -1
            });
    }
    $(window).resize(function () {
        if (window.matchMedia('(max-width: 768px)').matches) {
            responsiveTableColumn('#StateDetails');
        }
    })

     $("".statusbutton"").click(function () {
            $(""#preloader"").show();
         ");
            WriteLiteral(@"   var checkedrecord = new Array();
            var checkactivestatus = $('#StateDetails tbody tr').find(':checkbox:checked').length;
            if (checkactivestatus == 0) {

                $.alert({
                    title: 'Alert!',
                    content: 'Please select atleast one record.',
                });
            $(""#preloader"").hide();
            $("".checkbox-replace"").removeClass(""checked"");
            $(""#chk-1"").removeAttr(""checked"");
            $('#StateDetails th input[type=""checkbox""]').prop(""checked"", false);
            $('#StateDetails td input[type=""checkbox""]').prop(""checked"", false);
            return false;
            }
            $('#StateDetails tbody tr').find(':checkbox:checked').each(function (i, row) {
                var $actualrow = $(row);
                $checkbox = $actualrow;
                if ($checkbox.attr('id') != 'chk-1') {
                    checkedrecord.push($checkbox.attr('id'));
                }
            });

       ");
            WriteLiteral(@" if (checkedrecord.length > 0) {
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
#line 219 "D:\Company Running Projects\DealSe\Local Server\DealSe\Areas\Admin\Views\State\Index.cshtml"
                           Write(Url.Action("StateOperation", "State", new {area="Admin"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', { checkedrecord: checkedrecord, status: status, countryId : $(""#CountryId"").val() }, function (data) {
                            if (data == ""Success"") {
                                $(""#preloader"").hide();
                                window.location.href = ""/admin/State"";
                            } else {
                                $(""#preloader"").hide();
                            }
                        });
                    },
                    cancel: function () {
                        $("".checkbox-replace"").removeClass(""checked"");
                        $(""#chk-1"").removeAttr(""checked"");
                        $('#StateDetails th input[type=""checkbox""]').prop(""checked"", false);
                        $('#StateDetails td input[type=""checkbox""]').prop(""checked"", false);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.ViewModels.StateViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
