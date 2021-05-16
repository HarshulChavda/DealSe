#pragma checksum "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Offer\_OfferScripts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25e4a0c2def197b4d70d5ffd5c411cdb2c4fb1eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Offer__OfferScripts), @"mvc.1.0.view", @"/Areas/Admin/Views/Offer/_OfferScripts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25e4a0c2def197b4d70d5ffd5c411cdb2c4fb1eb", @"/Areas/Admin/Views/Offer/_OfferScripts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Offer__OfferScripts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script type=""text/javascript"">

    
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
        tableContainer = $(""#OfferDetails"");

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
                    ""url"": '/Admin/Offer/LoadData',
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },

                ""aoColumns"": [
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, """);
            WriteLiteral(@"width"": ""5%"",
                        ""mRender"": function (data, type, row) {
                            return ""<div class='checkbox checkbox-replace itemclass'><input type='checkbox' id="" + row.offerId + ""></div>"";
                        }
                    },
                    {
                        mData: null, ""bSortable"": false, ""bSearchable"": false, ""width"": ""10%"",
                        ""mRender"": function (data, type, row) {
                            return '';
                        }
                    },
                    { ""data"": ""storeName"", ""name"": ""StoreName"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""20%"" },
                    { ""data"": ""name"", ""name"": ""Name"", ""bSearchable"": true, ""bSortable"": true, ""autoWidth"": true, ""width"": ""15%"" },
                    { ""data"": ""validityDates"", ""name"": ""ValidityDates"", ""bSearchable"": true, ""bSortable"": true, ""autoWidth"": true, ""width"": ""15%"" },
                    { ""data"": ""addedDate"", ""name"": ""AddedDate"", ""bSearch");
            WriteLiteral(@"able"": true, ""bSortable"": true, ""autoWidth"": true, ""width"": ""15%"" },
                    { ""data"": ""userRedeemLimit"", ""name"": ""UserRedeemLimit"", ""bSearchable"": true,""bSortable"": true, ""autoWidth"": true, ""width"": ""10%"" },
                    {
                        ""mData"": ""Activated"", ""bSearchable"": false, ""bSortable"": false, ""autoWidth"": true, ""width"": ""15%"",
                        ""mRender"": function (data, type, row) {
                            return '<a class=""btn btn-blue btn-sm btn-icon icon-left"" href=""/Admin/Area//' +  + '""><i class=""entypo-pencil""></i>Edit</a>';
                        }, ""sClass"": ""view-more""
                    }
                ],
                ""fnRowCallback"": function (nRow, aData, iDisplayIndex) {
                    var info = $(this).DataTable().page.info();
                    $(""td:nth-child(2)"", nRow).append(info.start + iDisplayIndex + 1);
                    return nRow;
                },
                ""fnDrawCallback"": function () {
          ");
            WriteLiteral(@"          replaceCheckboxes();
                    responsivePaginationDesign();
                    checkAllCheckboxes();
                    addresponsiveTableDiv(""#OfferDetails"");
                },
            });
            $("".dataTables_wrapper select"").select2({
                minimumResultsForSearch: -1
            });
    }

    $(window).resize(function () {
        if (window.matchMedia('(max-width: 768px)').matches) {
            responsiveTableColumn('#OfferDetails');
        }
    })

    function checkall(current) {
        var status = $('#' + current.id).is(':checked');
        if (status == true) {
            $('#OfferDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked', true);
                $(this).attr('checked', true);
            });
            $("".itemclass"").addClass(""checked"");
        }
        else {
            $('#OfferDetails input[type=""checkbox""]').each(function () {
                $(this).prop('checked',");
            WriteLiteral(@" false);
            });
            $("".itemclass"").removeClass(""checked"");
        }
    }
    function checkchanged() {
        $('#OfferDetails td input[type=""checkbox""]').on(""change"", function () {
            checkAllCheckboxes()
        });
    }
    function checkAllCheckboxes() {
        var total = $('#OfferDetails td input[type=""checkbox""]').length;
        var selected = 0;
        $('#OfferDetails td input[type=""checkbox""]').each(function () {
            if ($(this).is("":checked"")) {
                selected += 1;
            }
        });
        if ((selected == total) && (total != 0)) {
            $('#OfferDetails th input[type=""checkbox""]').prop(""checked"", true);
            $('#OfferDetails th input[type=""checkbox""]').trigger(""change"")
        }
        else {
            $('#OfferDetails th input[type=""checkbox""]').prop(""checked"", false);
            $('#OfferDetails th input[type=""checkbox""]').trigger(""change"")
        }
    }

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591