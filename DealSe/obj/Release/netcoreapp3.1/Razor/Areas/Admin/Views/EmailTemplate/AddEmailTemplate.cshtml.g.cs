#pragma checksum "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "495c5d2501860871b222d6b4ed016c391952a537"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_EmailTemplate_AddEmailTemplate), @"mvc.1.0.view", @"/Areas/Admin/Views/EmailTemplate/AddEmailTemplate.cshtml")]
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
#line 1 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\_ViewImports.cshtml"
using Pratigya;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"495c5d2501860871b222d6b4ed016c391952a537", @"/Areas/Admin/Views/EmailTemplate/AddEmailTemplate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4270d6d7021694fcdb731a7f4dcc3677d9d0cfc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_EmailTemplate_AddEmailTemplate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pratigya.Areas.Admin.FormModels.EmailTemplateFormModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/assets/js/tinymce/tinymce.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
  
	ViewData["Title"] = "AddEmailTemplate";
	Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n\t<li>\r\n\t\t<a");
            BeginWriteAttribute("href", " href=\"", 236, "\"", 293, 1);
#nullable restore
#line 9 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
WriteAttributeValue("", 243, Url.Action("Index", "Home" , new {Area="Admin" }), 243, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n\t</li>\r\n\t<li>\r\n\t\t<i class=\"entypo-cog\"></i>Others\r\n\t</li>\r\n\t<li><a");
            BeginWriteAttribute("href", " href=\"", 398, "\"", 465, 1);
#nullable restore
#line 14 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
WriteAttributeValue("", 405, Url.Action("Index", "EmailTemplate" , new { Area="Admin" }), 405, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-mail\"></i>Email Templates</a></li>\r\n\t<li class=\"active\">\r\n\t\t<strong>Add Email Template</strong>\r\n\t</li>\r\n</ol>\r\n<h2>Add Email Template</h2>\r\n<br />\r\n");
#nullable restore
#line 21 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
 if (ViewBag.Error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"row\">\r\n\t\t<div class=\"col-md-12\">\r\n\r\n\t\t\t<div class=\"alert alert-danger\"><strong>Oops!</strong> ");
#nullable restore
#line 26 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
                                                              Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\t\t</div>\r\n\t</div>\r\n");
#nullable restore
#line 29 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
 using (Html.BeginForm("AddEmailTemplate", "EmailTemplate", FormMethod.Post))
{
	

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
                                 ;


#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<div class=\"row\">\r\n\t\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t\t<div class=\"form-group\">\r\n\t\t\t\t\t\t<label class=\"control-label\" for=\"email_template_name\">Email Name</label>\r\n\t\t\t\t\t\t<label class=\"field-validation-error\">*</label>\r\n\t\t\t\t\t\t");
#nullable restore
#line 39 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
                   Write(Html.TextBoxFor(model => model.EmailTemplateName, new { @class = "form-control htmlvalid trimmed", @maxlength = "50" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
						<span id=""errormsgForEmailTemplateName""></span>
					</div>
				</div>
				<div class=""col-md-6"">
					<div class=""form-group"">
						<label class=""control-label"" for=""email_template_name"">Email Subject</label>
						<label class=""field-validation-error"">*</label>
						");
#nullable restore
#line 47 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
                   Write(Html.TextBoxFor(model => model.EmailTemplateSubject, new { @class = "form-control htmlvalid trimmed", @maxlength = "100" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
						<span id=""errormsgForEmailTemplateSubject""></span>
					</div>
				</div>
			</div>
			<div class=""row"">
				<div class=""col-md-12"">
					<div class=""form-group"">
						<label class=""control-label"" for=""plan_url"">Email Body</label>
						<label class=""field-validation-error"">*</label>
						");
#nullable restore
#line 57 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
                   Write(Html.TextAreaFor(model => model.EmailTemplateBody, new { id = "textarea1" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t<span id=\"errormsgForEmailbody\"></span>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t<div class=\"row center\">\r\n\t\t\t<button type=\"submit\" id=\"btnsubmit\" class=\"btn btn-success\">\r\n\t\t\t\t<i class=\"glyphicon glyphicon-save\"></i>\r\n\t\t\t\tSave\r\n\t\t\t</button>\r\n\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 2326, "\"", 2394, 1);
#nullable restore
#line 67 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
WriteAttributeValue("", 2333, Url.Action("Index", "EmailTemplate", new { Area = "Admin" }), 2333, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\">\r\n\t\t\t\t<i class=\"glyphicon glyphicon-remove\"></i>\r\n\t\t\t\tCancel\r\n\t\t\t</a>\r\n\t\t</div>\r\n");
#nullable restore
#line 72 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\EmailTemplate\AddEmailTemplate.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "495c5d2501860871b222d6b4ed016c391952a53710095", async() => {
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
	$(function () {
		tinymce.init({
			selector: '#textarea1',
			relative_urls: false,
			extended_valid_elements: ""a[class|name|href|target|title|onclick|rel|style],style[language|type|src],script[language|type|src],iframe[src|style|width|height|scrolling|marginwidth|marginheight|frameborder],img[class|src|border=0|alt|title|hspace|vspace|width|height|align|onmouseover|onmouseout|name|style],head,html,body"",
			width: 'auto',
			height: 'auto',
			plugins: [
				""advlist autolink link image lists charmap print preview hr anchor pagebreak"",
				""searchreplace wordcount visualblocks visualchars insertdatetime media nonbreaking"",
				""table contextmenu directionality emoticons paste textcolor code fullpage""
			],
			toolbar1: ""undo redo | bold italic underline | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | styleselect"",
			toolbar2: ""| link unlink anchor | image media | forecolor backcolor  | print preview code "",
			image_advta");
            WriteLiteral(@"b: true,
			file_browser_callback: function (field_name, url, type, win) {
				var w = window,
					d = document,
					e = d.documentElement,
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
	$(""#btnsubmit"").click(function () {
		var valid = true;
		var emailTemplateName = $(""#EmailTemplateName"").val();
		var emailTemplateSubject = $(""#EmailTemplateSubject"").val();
		var emailBody = tinymce.get('textarea1').getBody().textContent;
		if (emailTemplateName == """" || emailTemplateName =");
            WriteLiteral(@"= null) {
			$(""#errormsgForEmailTemplateName"")[0].innerHTML = ""Email Name is required"";
			$(""#errormsgForEmailTemplateName"")[0].style.color = ""red"";
			valid = false;
		}
		else {
			$(""#errormsgForEmailTemplateName"")[0].innerHTML = "" "";
		}
		if (emailTemplateSubject == """" || emailTemplateSubject == null) {
			$(""#errormsgForEmailTemplateSubject"")[0].innerHTML = ""Email Subject is required"";
			$(""#errormsgForEmailTemplateSubject"")[0].style.color = ""red"";
			valid = false;
		}
		else {
			$(""#errormsgForEmailTemplateSubject"")[0].innerHTML = "" "";
		}
		if (emailBody == """" || emailBody == null) {
			$(""#errormsgForEmailbody"")[0].innerHTML = ""Email Body is required"";
			$(""#errormsgForEmailbody"")[0].style.color = ""red"";
			valid = false;
		}
		else {
			$(""#errormsgForEmailbody"")[0].innerHTML = "" "";
		}
		if (valid == false) {
			return false;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pratigya.Areas.Admin.FormModels.EmailTemplateFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
