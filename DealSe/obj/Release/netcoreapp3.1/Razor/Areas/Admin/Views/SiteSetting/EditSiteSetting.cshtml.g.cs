#pragma checksum "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20f587992200100e6eb70da9a7e7b056aef23edd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_SiteSetting_EditSiteSetting), @"mvc.1.0.view", @"/Areas/Admin/Views/SiteSetting/EditSiteSetting.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20f587992200100e6eb70da9a7e7b056aef23edd", @"/Areas/Admin/Views/SiteSetting/EditSiteSetting.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_SiteSetting_EditSiteSetting : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.FormModels.SiteSettingFormModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/js/icheck.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/js/ckeditor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/assets/js/tinymce/tinymce.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
  
    ViewData["Title"] = "EditSiteSetting";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 246, "\"", 304, 1);
#nullable restore
#line 9 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
WriteAttributeValue("", 253, Url.Action("Index", "Home", new {Area = "Admin" }), 253, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li>\r\n        <i class=\"entypo-cog\"></i>Others\r\n    </li>\r\n    <li><a");
            BeginWriteAttribute("href", " href=\"", 427, "\"", 493, 1);
#nullable restore
#line 14 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
WriteAttributeValue("", 434, Url.Action("Index", "SiteSetting", new { Area = "Admin" }), 434, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-tools\"></i>Site Settings</a></li>\r\n    <li class=\"active\">\r\n        <strong>Edit Site Setting</strong>\r\n    </li>\r\n</ol>\r\n<h2>Edit Site Setting</h2>\r\n<br />\r\n");
#nullable restore
#line 21 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
 if (ViewBag.Error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong> ");
#nullable restore
#line 25 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                                                              Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 28 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
 using (Html.BeginForm("EditSiteSetting", "SiteSetting", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
Write(Html.HiddenFor(model => model.SiteSettingId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
Write(Html.HiddenFor(model => Model.AddedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""row"">
                <div class=""col-md-6"">
                    <div class=""form-group"">
                        <label class=""control-label"" for=""SiteSetting_name"">Site Setting Name</label>
                        <label class=""field-validation-error"">*</label>
                        ");
#nullable restore
#line 41 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                   Write(Html.TextBoxFor(model => model.SiteSettingName, new { @class = "form-control htmlvalid trimmed", @maxlength = "50" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <span id=""span_SiteSettingName"" style=""color:red""></span>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""form-group"">
                        <label class=""control-label"" for=""SiteSetting_name"">Site Setting Type</label>
                        <label class=""field-validation-error"">*</label>
                        ");
#nullable restore
#line 49 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                   Write(Html.DropDownListFor(model => model.SiteSettingType, new SelectList(
                                              new List<Object>{
                                                new { value = 0 , text = "--Select Type--"  },
                                                new { value = 1 , text = "Text"},
                                                new { value = 2 , text = "Domain" },
                                                new { value = 3 , text = "Email"  },
                                                new{value=4,text="Number"},
                                                new{value=5,text="Boolean"},
                                                new{value=6,text="Html"}
                                              },
                                              "value",
                                              "text", 0), new { @class = "form-control", @id = "drpdata" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <span id=""span_SiteSettingType"" style=""color:red""></span>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-2"">
                    <div class=""form-group"">
                        <label class=""control-label"" for=""SiteSetting_value"">Enforce Validation</label>
                        <div class=""form-group"" id=""enforcevalidationswitch"">
                            <div class=""make-switch statusswitch"" data-on=""status"" data-off=""status"" data-on-label=""Yes"" data-off-label=""No"">
                                ");
#nullable restore
#line 71 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                           Write(Html.CheckBoxFor(model => model.EnforceValidation, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""tab-pane"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""form-group"">
                            <label class=""control-label"" for=""SiteSetting_value"">Site Setting Value</label>
                            <div class=""form-group textdiv"">
                                ");
#nullable restore
#line 83 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                           Write(Html.TextBoxFor(model => model.TextTypeSiteSettingValue, new { @class = "form-control htmlvalid trimmed" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                <span id=""span_TextTypeSiteSettingValue"" style=""color:red""></span>
                            </div>
                            <div class=""form-group domaindiv"" style=""display:none;"">
                                ");
#nullable restore
#line 87 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                           Write(Html.TextBoxFor(model => model.DomainTypeSiteSettingValue, new { @class = "form-control htmlvalid trimmed" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                <span id=""span_DomainTypeSiteSettingValue"" style=""color:red""></span>
                            </div>
                            <div class=""form-group emaildiv"" style=""display:none;"">
                                ");
#nullable restore
#line 91 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                           Write(Html.TextBoxFor(model => model.EmailTypeSiteSettingValue, new { @class = "form-control htmlvalid trimmed" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                <span id=""span_EmailTypeSiteSettingValue"" style=""color:red""></span>
                            </div>
                            <div class=""form-group numberdiv"" style=""display:none;"">
                                ");
#nullable restore
#line 95 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                           Write(Html.TextBoxFor(model => model.NumberTypeSiteSettingValue, new { @class = "form-control digit", @maxlength = "9" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                <span id=""span_NumberTypeSiteSettingValue"" style=""color:red""></span>
                            </div>
                            <div class=""form-group booleandiv"" style=""display:none;"">
                                <div class=""make-switch statusswitch"" data-on=""status"" data-off=""status"" data-on-label=""Yes"" data-off-label=""No"">
                                    ");
#nullable restore
#line 100 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                               Write(Html.CheckBoxFor(model => model.BooleanTypeSiteSettingValue, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"form-group htmldiv\" style=\"display:none;\">\r\n                                ");
#nullable restore
#line 104 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
                           Write(Html.TextAreaFor(model => model.HtmlTypeSiteSettingValue, new { @class = "form-control English htmlvalid trimmed", id = "textarea" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                <span id=""span_HtmlTypeSiteSettingValue"" style=""color:red""></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""row center"">
                <button type=""submit"" id=""btnsubmit"" class=""btn btn-success"">
                    <i class=""glyphicon glyphicon-save""></i>
                    Save
                </button>
                <a");
            BeginWriteAttribute("href", " href=\"", 6665, "\"", 6731, 1);
#nullable restore
#line 116 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
WriteAttributeValue("", 6672, Url.Action("Index", "SiteSetting", new { Area = "Admin" }), 6672, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\">\r\n                    <i class=\"glyphicon glyphicon-remove\"></i>\r\n                    Cancel\r\n                </a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 123 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20f587992200100e6eb70da9a7e7b056aef23edd16221", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20f587992200100e6eb70da9a7e7b056aef23edd17261", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20f587992200100e6eb70da9a7e7b056aef23edd18301", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 127 "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\EditSiteSetting.cshtml"
Write(await Html.PartialAsync("_SiteSettingScripts"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        var SiteSettingType = $(""#drpdata"").val();
        if (SiteSettingType == 2) {
            $("".emaildiv"").hide();
            $("".domaindiv"").show();
            $("".numberdiv"").hide();
            $("".booleandiv"").hide();
            $("".htmldiv"").hide();
            $("".textdiv"").hide();
            $(""#EmailTypeSiteSettingValue"").val("""");
            $(""#HtmlTypeSiteSettingValue"").val("""");
            $(""#NumberTypeSiteSettingValue"").val("""");
            $(""#TextTypeSiteSettingValue"").val("""");
        }
        else if (SiteSettingType == 3) {
            $("".emaildiv"").show();
            $("".domaindiv"").hide();
            $("".numberdiv"").hide();
            $("".booleandiv"").hide();
            $("".htmldiv"").hide();
            $("".textdiv"").hide();
            $(""#DomainTypeSiteSettingValue"").val("""");
            $(""#HtmlTypeSiteSettingValue"").val("""");
            $(""#NumberTypeSiteSettingValue"").val(""""");
            WriteLiteral(@");
            $(""#TextTypeSiteSettingValue"").val("""");
            $(""#EnforceValidation"")[0].checked = true;
            $(""#EnforceValidation"").parent().removeClass(""switch-off"");
            $(""#enforcevalidationswitch"").css(""pointer-events"", "" none"");
        }
        else if (SiteSettingType == 4) {
            $("".emaildiv"").hide();
            $("".domaindiv"").hide();
            $("".numberdiv"").show();
            $("".booleandiv"").hide();
            $("".htmldiv"").hide();
            $("".textdiv"").hide();
            $(""#DomainTypeSiteSettingValue"").val("""");
            $(""#EmailTypeSiteSettingValue"").val("""");
            $(""#HtmlTypeSiteSettingValue"").val("""");
            $(""#TextTypeSiteSettingValue"").val("""");
            $(""#EnforceValidation"")[0].checked = true;
            $(""#EnforceValidation"").parent().removeClass(""switch-off"");
            $(""#enforcevalidationswitch"").css(""pointer-events"", "" none"");
        }
        else if (SiteSettingType == 5) {
            $("".emai");
            WriteLiteral(@"ldiv"").hide();
            $("".domaindiv"").hide();
            $("".numberdiv"").hide();
            $("".booleandiv"").show();
            $("".htmldiv"").hide();
            $("".textdiv"").hide();
            $(""#DomainTypeSiteSettingValue"").val("""");
            $(""#EmailTypeSiteSettingValue"").val("""");
            $(""#HtmlTypeSiteSettingValue"").val("""");
            $(""#NumberTypeSiteSettingValue"").val("""");
            $(""#TextTypeSiteSettingValue"").val("""");
            $(""#EnforceValidation"")[0].checked = true;
            $(""#EnforceValidation"").parent().removeClass(""switch-off"");
            $(""#enforcevalidationswitch"").css(""pointer-events"", "" none"");
        }
        else if (SiteSettingType == 6) {
            $("".emaildiv"").hide();
            $("".domaindiv"").hide();
            $("".numberdiv"").hide();
            $("".booleandiv"").hide();
            $("".htmldiv"").show();
            $("".textdiv"").hide();
            $(""#DomainTypeSiteSettingValue"").val("""");
            $(""#EmailTypeS");
            WriteLiteral(@"iteSettingValue"").val("""");
            $(""#NumberTypeSiteSettingValue"").val("""");
            $(""#TextTypeSiteSettingValue"").val("""");
        }
        else {
            $("".emaildiv"").hide();
            $("".domaindiv"").hide();
            $("".numberdiv"").hide();
            $("".booleandiv"").hide();
            $("".htmldiv"").hide();
            $("".textdiv"").show();
            //English
            $(""#DomainTypeSiteSettingValue"").val("""");
            $(""#EmailTypeSiteSettingValue"").val("""");
            $(""#HtmlTypeSiteSettingValue"").val("""");
            $(""#NumberTypeSiteSettingValue"").val("""");
        }
    });
    $(function () {
        tinymce.init({
            selector: '#textarea',
            relative_urls: false,
            remove_script_host: false,
            extended_valid_elements: ""a[class|name|href|target|title|onclick|rel],script[language|type|src],iframe[src|style|width|height|scrolling|marginwidth|marginheight|frameborder],img[class|src|border=0|alt|title|hspace|v");
            WriteLiteral(@"space|width|height|align|onmouseover|onmouseout|name],link[href|rel],i[class|name|href|target|title|onclick|rel]"",
            width: 'auto',
            height: 'auto',
            plugins: [
                ""advlist autolink link image lists charmap print preview hr anchor pagebreak"",
                ""searchreplace wordcount visualblocks visualchars insertdatetime media nonbreaking"",
                ""table contextmenu directionality emoticons paste textcolor code fullpage""
            ],
            content_css: ['//fonts.googleapis.com/css?family=Montserrat'],
            toolbar1: ""undo redo | bold italic underline | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | styleselect"",
            toolbar2: ""| link unlink anchor | image media | forecolor backcolor  | print preview code "",
            image_advtab: true,
            file_browser_callback: function (field_name, url, type, win) {
                var w = window,
                    d = document,
       ");
            WriteLiteral(@"             e = d.documentElement,
                    g = d.getElementsByTagName('body')[0],
                    x = w.innerWidth || e.clientWidth || g.clientWidth,
                    y = w.innerHeight || e.clientHeight || g.clientHeight;
                var cmsURL = '/mcemanager/index.html?&field_name=' + field_name + '&langCode=' + tinymce.settings.language;
                if (type == 'image') {
                    cmsURL = cmsURL + ""&type=images"";
                }
                tinyMCE.activeEditor.windowManager.open({
                    file: cmsURL,
                    title: 'Filemanager',
                    width: x * 0.9,
                    height: y * 0.9,
                    resizable: ""yes"",
                    close_previous: ""no""
                });
            }
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.FormModels.SiteSettingFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
