#pragma checksum "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0b2e92b9010facc93618ae9b2c2f1b2612599cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DashboardProf_ListePresence), @"mvc.1.0.view", @"/Views/DashboardProf/ListePresence.cshtml")]
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
#line 1 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\_ViewImports.cshtml"
using MiniProjet_alpha;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\_ViewImports.cshtml"
using MiniProjet_alpha.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0b2e92b9010facc93618ae9b2c2f1b2612599cb", @"/Views/DashboardProf/ListePresence.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61ea22acae464d5cfb922deee0bdba10c405e04f", @"/Views/_ViewImports.cshtml")]
    public class Views_DashboardProf_ListePresence : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MiniProjet_alpha.ViewModels.AdminDashboardViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TauxAbsEtu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TauxAbsMat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <div class=\" border rounded border-success bg-primary\">\r\n        <h1 class=\"display-4\">Liste de présence</h1>\r\n    </div>\r\n\r\n    <div class=\"container\" style=\"margin-top: 50px;\">\r\n           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0b2e92b9010facc93618ae9b2c2f1b2612599cb4685", async() => {
                WriteLiteral("Taux d\'absence par étudiant dans votre matière");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0b2e92b9010facc93618ae9b2c2f1b2612599cb5982", async() => {
                WriteLiteral("Taux d\'absence dans votre matière");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n   </div>\r\n\r\n    <table class=\"table table-bordered table-hover table-striped\" style=\"margin-top: 50px;\">\r\n        <thead class=\"thead-dark\">\r\n            <tr>\r\n                <th>");
#nullable restore
#line 19 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
               Write(Html.DisplayNameFor(model=>model.LibelleMatiere));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 20 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
               Write(Html.DisplayNameFor(model=>model.DateSeance));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 21 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
               Write(Html.DisplayNameFor(model=>model.NomComplet));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 22 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
               Write(Html.DisplayNameFor(model=>model.EstAbsent));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 26 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"table-info\">\r\n                <td>\r\n                   ");
#nullable restore
#line 30 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
              Write(Html.DisplayFor(modelItem => item.LibelleMatiere));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td> \r\n                   <td>\r\n                    ");
#nullable restore
#line 33 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateSeance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td> \r\n                   <td>\r\n                    ");
#nullable restore
#line 36 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
               Write(Html.DisplayFor(modelItem => item.NomComplet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td> \r\n\r\n");
#nullable restore
#line 39 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
          if(item.EstAbsent == 1)
         {

#line default
#line hidden
#nullable disable
            WriteLiteral("         <td>\r\n             Présent\r\n         </td>\r\n");
#nullable restore
#line 44 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
         }
         else
         {               

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>Absent</td>      \r\n");
#nullable restore
#line 48 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
         }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 50 "C:\Users\ELMOUKTAFI\Desktop\EMSI\Online Studies\MiniProjet_alpha\Views\DashboardProf\ListePresence.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MiniProjet_alpha.ViewModels.AdminDashboardViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
