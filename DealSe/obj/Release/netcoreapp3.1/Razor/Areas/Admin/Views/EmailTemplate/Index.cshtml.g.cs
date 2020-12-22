#pragma checksum "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "812135252b24e54da400ba3a7245beaf7c192900"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_EmailTemplate_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/EmailTemplate/Index.cshtml")]
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
#line 1 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\_ViewImports.cshtml"
using DealSe;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"812135252b24e54da400ba3a7245beaf7c192900", @"/Areas/Admin/Views/EmailTemplate/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_EmailTemplate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.ViewModels.EmailTemplateViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/js/tinymce.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
  
	ViewData["Title"] = "Index";
	Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 241, "\"", 299, 1);
#nullable restore
#line 9 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
WriteAttributeValue("", 248, Url.Action("Index", "Home",new { Area = "Admin" }), 248, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""entypo-home""></i>Home</a>
    </li>
    <li>
        <i class=""entypo-cog""></i>Others
    </li>
    <li class=""active"">
        <strong><i class=""entypo-mail""></i>Email Template</strong>
    </li>
</ol>
<h2>Email Template</h2>
<br />
");
#nullable restore
#line 20 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
 if (TempData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"alert alert-danger\"><strong>Oops!</strong><br /><span> ");
#nullable restore
#line 24 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
                                                                      Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 27 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
}
else if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-14\">\r\n        <div class=\"alert alert-success\"><strong>Success!</strong> ");
#nullable restore
#line 32 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
                                                              Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 35 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br class=\"clear\" />\r\n");
#nullable restore
#line 37 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
Write(await Html.PartialAsync("_EmailTemplateDetails"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 38 "D:\Company Running Projects\DealSe\Project\DealSe\Areas\Admin\Views\EmailTemplate\Index.cshtml"
Write(await Html.PartialAsync("_DatatableCSSJSView"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "812135252b24e54da400ba3a7245beaf7c1929006621", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        tableContainer = $(""#EmailTemplatedetails"");
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
                    ""url"": '/Admin/EmailTemplate/LoadData',
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },

                ""aoColumns"": [
                    { ""data"": ""emailTemplateName"", ""name"": ""emailTemplateName"", ""bSearchable"": true, ""aut");
            WriteLiteral(@"oWidth"": true, ""width"": ""20%"" },
                    { ""data"": ""emailTemplateSubject"", ""name"": ""emailTemplateSubject"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""15%"" },
                    { ""data"": ""addedDate"", ""name"": ""addedDate"", ""bSearchable"": true, ""autoWidth"": true, ""width"": ""15%"" },

                    {
                        ""mData"": ""Activated"", ""bSearchable"": false, ""bSortable"": false, ""autoWidth"": true, ""width"": ""10%"",
                        ""mRender"": function (data, type, row) {
                            return '<a class=""btn btn-blue btn-sm btn-icon icon-left"" href=""/Admin/EmailTemplate/EditEmailTemplate/' + row.emailTemplateId + '""><i class=""entypo-pencil""></i>Edit</a>';
                        }, ""sClass"": ""view-more""
                    }
                ],
                bAutoWidth: false,
                fnPreDrawCallback: function () {
                    if (!responsiveHelper) {
                        responsiveHelper = new ResponsiveDatatablesHelper(tableCon");
            WriteLiteral(@"tainer, breakpointDefinition);
                    }
                },
                fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                    responsiveHelper.createExpandIcon(nRow);
                },
                fnDrawCallback: function (oSettings) {
                    responsiveHelper.respond();
                    responsivePaginationDesign();
                    if (window.matchMedia('(max-width: 768px)').matches) {
                        responsiveTableColumn(""#EmailTemplatedetails"");
                    }
                }
            });
        $("".dataTables_wrapper select"").select2({
            minimumResultsForSearch: -1
        });
    }
    $(window).resize(function () {
        if (window.matchMedia('(max-width: 768px)').matches) {
            responsiveTableColumn('#EmailTemplatedetails');
        }
    })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.ViewModels.EmailTemplateViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
