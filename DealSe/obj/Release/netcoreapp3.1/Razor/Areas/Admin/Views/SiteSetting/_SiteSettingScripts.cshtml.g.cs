#pragma checksum "D:\Company Running Projects\DealSe\GitHub\DealSe\Areas\Admin\Views\SiteSetting\_SiteSettingScripts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b0097f9967f144c83b478430ea918dda8440b1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_SiteSetting__SiteSettingScripts), @"mvc.1.0.view", @"/Areas/Admin/Views/SiteSetting/_SiteSettingScripts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b0097f9967f144c83b478430ea918dda8440b1d", @"/Areas/Admin/Views/SiteSetting/_SiteSettingScripts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36ca803ce25a48926b0ae2447ab3721aafedf5", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_SiteSetting__SiteSettingScripts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script type=""text/javascript"">
    $(""#drpdata"").change(function () {
        var SiteSettingType = $(""#drpdata"").val();
        if (SiteSettingType == 2) {
            $("".emaildiv"").hide();
            $("".domaindiv"").show();
            $("".numberdiv"").hide();
            $("".booleandiv"").hide();
            $("".booleandiv"").hide();
            $("".htmldiv"").hide();
            $("".textdiv"").hide();
            $(""#enforcevalidationswitch"").css(""pointer-events"", ""all"");
        }
        else if (SiteSettingType == 3) {
            $("".emaildiv"").show();
            $("".domaindiv"").hide();
            $("".numberdiv"").hide();
            $("".booleandiv"").hide();
            $("".htmldiv"").hide();
            $("".textdiv"").hide();
            $(""#EnforceValidation"")[0].checked = true;
            $(""#EnforceValidation"").parent().removeClass(""switch-off"");
            $(""#enforcevalidationswitch"").css(""pointer-events"", ""none"");
        }
        else if (SiteSettingType == 4) {
      ");
            WriteLiteral(@"      $("".emaildiv"").hide();
            $("".domaindiv"").hide();
            $("".numberdiv"").show();
            $("".booleandiv"").hide();
            $("".htmldiv"").hide();
            $("".textdiv"").hide();
            $(""#EnforceValidation"")[0].checked = true;
            $(""#EnforceValidation"").parent().removeClass(""switch-off"");
            $(""#enforcevalidationswitch"").css(""pointer-events"", ""none"");
        }
        else if (SiteSettingType == 5) {
            $("".emaildiv"").hide();
            $("".domaindiv"").hide();
            $("".numberdiv"").hide();
            $("".booleandiv"").show();
            $("".htmldiv"").hide();
            $("".textdiv"").hide();
            $(""#EnforceValidation"")[0].checked = true;
            $(""#EnforceValidation"").parent().removeClass(""switch-off"");
            $(""#enforcevalidationswitch"").css(""pointer-events"", ""none"");
        }
        else if (SiteSettingType == 6) {
            $("".emaildiv"").hide();
            $("".domaindiv"").hide();
         ");
            WriteLiteral(@"   $("".numberdiv"").hide();
            $("".booleandiv"").hide();
            $("".htmldiv"").show();
            $("".textdiv"").hide();
            $(""#enforcevalidationswitch"").css(""pointer-events"", ""all"");
        }
        else {
            $("".emaildiv"").hide();
            $("".domaindiv"").hide();
            $("".numberdiv"").hide();
            $("".booleandiv"").hide();
            $("".htmldiv"").hide();
            $("".textdiv"").show();
            $(""#enforcevalidationswitch"").css(""pointer-events"", ""all"");
        }
    });

    $('#btnsubmit').on(""click"", function () {
        var pattern = new RegExp(/^((""[\w-\s]+"")|([\w-]+(?:\.[\w-]+)*)|(""[\w-\s]+"")([\w-]+(?:\.[\w-]+)*))(");
            WriteLiteral("@((?:[\\w-]+\\.)*\\w[\\w-]{0,66})\\.([a-z]{2,6}(?:\\.[a-z]{2})?)$)|(");
            WriteLiteral(@"@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
        var SiteSettingType = $(""#drpdata"").val();
        var enforceValidation = $(""#EnforceValidation"")[0].checked;
        var valid = 0;

        if ($(""#SiteSettingName"").val() == """" || SiteSettingType == ""0"") {
            if ($(""#SiteSettingName"").val() == """") {
                $(""#span_SiteSettingName"").html(""Site Setting Name Is Required."");
                valid = 1;
            }
            else {
                $(""#span_SiteSettingName"").html("""");
            }
            if (SiteSettingType == ""0"") {
                $(""#span_SiteSettingType"").html(""Site Setting Type Is Required."");
                valid = 1;
            }
            else {
                $(""#span_SiteSettingType"").html("""");
            }

        }
        else {
            $(""#span_SiteSettingName"").html("""");
            $(""#span_SiteSettingTyp");
            WriteLiteral(@"e"").html("""");
        }
        if (SiteSettingType == ""3"" || SiteSettingType == ""0"") {
            if ($(""#EmailTypeSiteSettingValue"").val() == """") {
                $(""#span_EmailTypeSiteSettingValue"").html(""Site Setting Value Is Required."");
                valid = 1;
            }
            else if (!pattern.test($(""#EmailTypeSiteSettingValue"").val())) {
                $(""#span_EmailTypeSiteSettingValue"").html(""Site Setting Value Is Not Valid."");
                valid = 1;
            }
            else {
                $(""#span_EmailTypeSiteSettingValue"").html("""");
            }
          
        }
        else if (SiteSettingType == ""4"" || SiteSettingType == ""0"") {
            if ($(""#NumberTypeSiteSettingValue"").val() == """") {
                $(""#span_NumberTypeSiteSettingValue"").html(""Site Setting Value Is Required."");
                valid = 1;
            }
            else {
                $(""#span_NumberTypeSiteSettingValue"").html("""");

            }
        
      ");
            WriteLiteral(@"  }
        else {
            if (enforceValidation == true) {
                if (SiteSettingType == ""1"" || SiteSettingType == ""0"") {
                    
                    if ($(""#TextTypeSiteSettingValue"").val() == """") {
                        $(""#span_TextTypeSiteSettingValue"").html(""Site Setting Value Is Required."");
                        valid = 1;
                    }
                    else {
                        $(""#span_TextTypeSiteSettingValue"").html("""");
                    }
                }
                else if (SiteSettingType == ""2"" || SiteSettingType == ""0"") {
                   
                    if ($(""#DomainTypeSiteSettingValue"").val() == """") {
                        $(""#span_DomainTypeSiteSettingValue"").html(""Site Setting Value Is Required."");
                        valid = 1;
                    }
                    else {
                        $(""#span_DomainTypeSiteSettingValue"").html("""");
                    }
               
             ");
            WriteLiteral(@"   }
                else if (SiteSettingType == ""6"" || SiteSettingType == ""0"") {
                   
                    if (tinymce.get('textarea').getBody().textContent == """") {
                        $(""#span_HtmlTypeSiteSettingValue"").html(""Site Setting Value Is Required."");
                        valid = 1;
                    }
                    else {
                        $(""#span_HtmlTypeSiteSettingValue"").html("""");
                    }
                   
                }
            }
        }

        if (valid == 0) {
            return true;
        }
        else {
            return false;
        }
    });


    $("".digit"").on(""keypress keyup blur"", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
