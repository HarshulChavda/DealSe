#pragma checksum "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33896db34ae152f0853cc7976c447d20358674a5"
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
#line 1 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\_ViewImports.cshtml"
using Pratigya;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33896db34ae152f0853cc7976c447d20358674a5", @"/Areas/Admin/Views/Home/EditProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4270d6d7021694fcdb731a7f4dcc3677d9d0cfc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_EditProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pratigya.Areas.Admin.FormModels.AdminFormModel>
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
#line 3 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
  
    ViewBag.Title = "Profile Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("<ol class=\"breadcrumb\">\r\n    <li>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 187, "\"", 246, 1);
#nullable restore
#line 8 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
WriteAttributeValue("", 194, Url.Action("Index", "Home", new { Area = "Admin" }), 194, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"entypo-home\"></i>Home</a>\r\n    </li>\r\n    <li class=\"active\">\r\n        <strong>Edit Profile</strong>\r\n    </li>\r\n</ol>\r\n<h2>Edit Profile</h2>\r\n");
#nullable restore
#line 15 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
 if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-success\"><strong>Success!</strong> ");
#nullable restore
#line 19 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
                                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 22 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
 if (ViewBag.Error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"alert alert-danger\"><strong>Oops!</strong> ");
#nullable restore
#line 27 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
                                                              Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 30 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33896db34ae152f0853cc7976c447d20358674a59217", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 33 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 34 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 35 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.AdminID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 36 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.AddedDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 37 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.UpdatedDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 38 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 39 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.PasswordResetToken));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 40 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
Write(Html.HiddenFor(model => model.Logo));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\" for=\"first_name\">First Name</label>\r\n                ");
#nullable restore
#line 45 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.TextBoxFor(model => model.FirstName, new { @class = "form-control trimmed" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 46 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.ValidationMessageFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-3\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\" for=\"last_name\">Last Name</label>\r\n                ");
#nullable restore
#line 52 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.TextBoxFor(model => model.LastName, new { @class = "form-control trimmed" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 53 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
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
                <div class=""input-group"">
                    <div class=""input-group-addon"">
                        <i class=""entypo-mail""></i>
                    </div>
                    ");
#nullable restore
#line 63 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
               Write(Html.TextBoxFor(model => model.Email, new { @class = "form-control trimmed" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                ");
#nullable restore
#line 65 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
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
#line 77 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
               Write(Html.PasswordFor(model => model.NewPassword, new { @class = "form-control passwordField", autocomplete = "new-password" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                ");
#nullable restore
#line 79 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.ValidationMessageFor(model => model.NewPassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label\">Mobile No</label>\r\n                ");
#nullable restore
#line 85 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
           Write(Html.TextBoxFor(model => model.MobileNo, new { @class = "form-control trimmed" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
#nullable restore
#line 86 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
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
#line 98 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
                             if (Model.Logo != null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <img");
                BeginWriteAttribute("src", " src=\"", 4194, "\"", 4225, 2);
                WriteAttributeValue("", 4200, "/Upload/Admin/", 4200, 14, true);
#nullable restore
#line 100 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
WriteAttributeValue("", 4214, Model.Logo, 4214, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"NewImage\" />\r\n");
#nullable restore
#line 101 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "33896db34ae152f0853cc7976c447d20358674a518423", async() => {
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
#line 105 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
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
    <hr />
    <div class=""row center"">
        <button type=""submit"" class=""btn btn-success"">
            <i class=""glyphicon glyphicon-save""></i>
            Update
        </button>
        <a");
                BeginWriteAttribute("href", " href=\"", 5836, "\"", 5870, 1);
#nullable restore
#line 133 "D:\Company Running Projects\Pratigya\Source Code\Website\Pratigya\Pratigya\Areas\Admin\Views\Home\EditProfile.cshtml"
WriteAttributeValue("", 5843, Url.Action("Index","Home"), 5843, 27, false);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33896db34ae152f0853cc7976c447d20358674a523823", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pratigya.Areas.Admin.FormModels.AdminFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
