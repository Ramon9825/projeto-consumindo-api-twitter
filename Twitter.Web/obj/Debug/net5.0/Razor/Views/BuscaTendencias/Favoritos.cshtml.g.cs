#pragma checksum "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0533fca4ecdda61ffe20df241b357a4f5ffe7a16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BuscaTendencias_Favoritos), @"mvc.1.0.view", @"/Views/BuscaTendencias/Favoritos.cshtml")]
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
#line 1 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\_ViewImports.cshtml"
using Twitter.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\_ViewImports.cshtml"
using Twitter.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0533fca4ecdda61ffe20df241b357a4f5ffe7a16", @"/Views/BuscaTendencias/Favoritos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c96ddf36debd9f05647f18fdb7598ca4e939f44e", @"/Views/_ViewImports.cshtml")]
    public class Views_BuscaTendencias_Favoritos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Twitter.Web.Models.ItemViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
  
    ViewData["Title"] = "Favoritos";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Tendências favoritas</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0533fca4ecdda61ffe20df241b357a4f5ffe7a163830", async() => {
                WriteLiteral("Voltar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
           Write(Html.DisplayNameFor(model => model.Tweets));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 25 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("id", " id=\"", 558, "\"", 571, 1);
#nullable restore
#line 27 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
WriteAttributeValue("", 563, item.Id, 563, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 620, "\"", 636, 1);
#nullable restore
#line 29 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
WriteAttributeValue("", 627, item.Url, 627, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 29 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 32 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
               Write(Html.DisplayFor(modelItem => item.Tweets));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 35 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
               Write(Html.ActionLink("Edit", "Editar", null, null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 36 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
               Write(Html.ActionLink("Delete", "Favoritos", null, null, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 39 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">
        $("".btn-primary"").click(function (event) {
            event.target.parentElement.parentElement.className = ""selecionado"";
            var id = event.target.parentElement.parentElement.id;

            $.post(""");
#nullable restore
#line 50 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
               Write(Url.Action($"Editar"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""", { id : id });
        });

    </script>

    <script type=""text/javascript"">
        $("".btn-danger"").click(function (event) {
            event.target.parentElement.parentElement.className = ""selecionado"";
            var id = event.target.parentElement.parentElement.id;
            enviarId(id);
        });

        function enviarId(id) {
            $.post(""");
#nullable restore
#line 63 "C:\Users\Ramon\Documents\projeto-consumindo-api-twitter\Twitter.Web\Views\BuscaTendencias\Favoritos.cshtml"
               Write(Url.Action("Deletar"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\", { id : id });\r\n        }\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Twitter.Web.Models.ItemViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
