#pragma checksum "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "621e3a526412762560cbe459b8b6a97addebe612"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_EditProfile), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/EditProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"621e3a526412762560cbe459b8b6a97addebe612", @"/Areas/Admin/Views/Home/EditProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_EditProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealSe.Areas.Admin.FormModels.AdminFormModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/images/noimage.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("noimage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/assets/js/fileinput.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
  
    ViewBag.Title = "Profile Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 185, "\"", 244, 1);
#nullable restore
#line 8 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
WriteAttributeValue("", 192, Url.Action("Index", "Home", new { Area = "Admin" }), 192, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li class=\"active\">\r\n        <strong>Edit Profile</strong>\r\n    </li>\r\n</ol>\r\n<h2>Edit Profile</h2>\r\n");
#nullable restore
#line 15 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
 if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-success\"><strong>Success!</strong> ");
#nullable restore
#line 19 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
                                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 22 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
 if (ViewBag.Error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong> ");
#nullable restore
#line 27 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
                                                              Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 30 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "621e3a526412762560cbe459b8b6a97addebe6128783", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 33 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 34 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 35 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.AdminID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 36 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.AddedDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 37 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.UpdatedDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 38 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 39 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.PasswordResetToken));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 40 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.Logo));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <div class=""row"">
        <div class=""col-md-3"">
            <div class=""form-group"">
                <label class=""control-label"" for=""first_name"">First Name</label>
                <label class=""field-validation-error"">*</label>
                ");
#nullable restore
#line 46 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.TextBoxFor(model => model.FirstName, new { @class = "form-control trimmed" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 47 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.ValidationMessageFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
        <div class=""col-md-3"">
            <div class=""form-group"">
                <label class=""control-label"" for=""last_name"">Last Name</label>
                <label class=""field-validation-error"">*</label>
                ");
#nullable restore
#line 54 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.TextBoxFor(model => model.LastName, new { @class = "form-control trimmed" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 55 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.ValidationMessageFor(model => model.LastName));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""form-group"">
                <label class=""control-label"">Email</label>
                <label class=""field-validation-error"">*</label>
                <div class=""input-group"">
                    <div class=""input-group-addon"">
                        <i class=""entypo-mail""></i>
                    </div>
                    ");
#nullable restore
#line 66 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
               Write(Html.TextBoxFor(model => model.Email, new { @class = "form-control trimmed" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                ");
#nullable restore
#line 68 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.ValidationMessageFor(model => model.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""form-group"">
                <label class=""control-label"">Choose Password</label>
                <div class=""input-group"">
                    <div class=""input-group-addon"">
                        <i class=""entypo-key""></i>
                    </div>
                    ");
#nullable restore
#line 80 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
               Write(Html.PasswordFor(model => model.NewPassword, new { @class = "form-control passwordField", autocomplete = "new-password" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                ");
#nullable restore
#line 82 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.ValidationMessageFor(model => model.NewPassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\">Mobile No</label>\r\n                ");
#nullable restore
#line 88 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.TextBoxFor(model => model.MobileNo, new { @class = "form-control trimmed" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 89 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.ValidationMessageFor(model => model.MobileNo));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"" style=""margin-bottom:25px;"">
            <div class=""form-group"">
                <label class=""control-label"">Logo</label>
                <label class=""field-validation-error"">*</label>
                <div class=""input-group"">
                    <div class=""fileinput fileinput-new"" data-provides=""fileinput"">
                        <div class=""fileinput-new thumbnail file"" style=""width: 150px; height: 150px;"" data-trigger=""fileinput"">
");
#nullable restore
#line 101 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
                             if (Model.Logo != null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <img");
                BeginWriteAttribute("src", " src=\"", 4387, "\"", 4418, 2);
                WriteAttributeValue("", 4393, "/Upload/Admin/", 4393, 14, true);
#nullable restore
#line 103 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
WriteAttributeValue("", 4407, Model.Logo, 4407, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"NewImage\" />\r\n");
#nullable restore
#line 104 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "621e3a526412762560cbe459b8b6a97addebe61217268", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 108 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </div>
                        <div class=""fileinput-preview fileinput-exists thumbnail"" style=""max-width: 250px; max-height: 140px""></div>
                        <div>
                            <span class=""btn btn-white btn-file"">
                                <span class=""fileinput-new"">Select Image</span>
                                <span class=""fileinput-exists"">Change</span>
                                <input type=""file"" name=""file"" id=""imageUpload"">
                            </span>
                            <a href=""#"" class=""btn btn-orange fileinput-exists"" data-dismiss=""fileinput"" id=""btnRemove"">Remove</a>
                        </div>
                        <span id=""errormsgForimage""></span>
                    </div>
                    <div>
                        <span class=""label label-important"">NOTE!</span>
                        <span>Please upload image of 150 x 150 or higher pixels. For best results, the image pixels should be mu");
                WriteLiteral(@"ltiples of the minimum width and height.</span>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class=""row center"">
        <button type=""submit"" class=""btn btn-success"">
            <i class=""glyphicon glyphicon-save""></i>
            Update
        </button>
        <a");
                BeginWriteAttribute("href", " href=\"", 6017, "\"", 6051, 1);
#nullable restore
#line 135 "D:\Project\DealSe\GitHub\DealSe\Areas\Admin\Views\Home\EditProfile.cshtml"
WriteAttributeValue("", 6024, Url.Action("Index","Home"), 6024, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-default\">\r\n            <i class=\"glyphicon glyphicon-remove\"></i>\r\n            Cancel\r\n        </a>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "621e3a526412762560cbe459b8b6a97addebe61222570", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"">
    $('.passwordField').keypress(function (e) {
        if (e.which === 32)
            return false;
    });

    $(""#imageUpload"").change(function () {
        //Get reference of FileUpload.
        var fileUpload = $(""#imageUpload"")[0];
        if (fileUpload.value != """") {
            //Check whether the file is valid Image.
            var regex = new RegExp("".jpg|.png|.jpeg"");
            if (regex.test(fileUpload.value.toLowerCase())) {
                //Check whether HTML5 is supported.
                if (typeof (fileUpload.files) != ""undefined"") {
                    //Initiate the FileReader object.
                    var reader = new FileReader();
                    //Read the contents of Image File.
                    reader.readAsDataURL(fileUpload.files[0]);
                    reader.onload = function (e) {
                        //Initiate the JavaScript Image object.
                        var image = new Image();
                 ");
            WriteLiteral(@"       //Set the Base64 string return from FileReader as source.
                        image.src = e.target.result;
                        image.onload = function () {
                            //Determine the Height and Width.
                            var height = this.height;
                            var width = this.width;
                            if (!(height >= 150 || width >= 150)) {
                                $.alert({
                                    title: 'Alert!',
                                    content: 'Oops! Please upload banner image of 150 x 150 or higher pixels. For best results, the image pixels should be multiples of the minimum width and height.',
                                });
                                $(""#btnRemove"").trigger(""click"");
                            }
                        };
                    }
                } else {
                    $.alert({
                        title: 'Alert!',
                        con");
            WriteLiteral(@"tent: 'Oops! This browser does not support HTML5.',
                    });
                    $(""#btnRemove"").trigger(""click"");
                }
            }
            else {
                $.alert({
                    title: 'Alert!',
                    content: 'Oops! Please select a valid Image file.',
                });
                $(""#btnRemove"").trigger(""click"");
            }
        }
    })
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealSe.Areas.Admin.FormModels.AdminFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
