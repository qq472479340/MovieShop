#pragma checksum "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08ac47aefc25cf0678d7d907fd3ffbc473f74640"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
#line 1 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08ac47aefc25cf0678d7d907fd3ffbc473f74640", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.MovieDetailsResponseModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cast", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n    <div class=\"container-fluid bg-dark\" style=\"color:white;\">\r\n        <div class=\"row\">\r\n            <div class=\"col-4\">\r\n                <div class=\"row justify-content-end\">\r\n                    <div class=\"col-6\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 307, "\"", 329, 1);
#nullable restore
#line 8 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 313, Model.PosterUrl, 313, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 348, "\"", 366, 1);
#nullable restore
#line 8 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 354, Model.Title, 354, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-6\">\r\n                <h2>");
#nullable restore
#line 13 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <span style=\"color:dimgrey\">");
#nullable restore
#line 14 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                       Write(Model.Tagline);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <div class=\"container-fluid\" style=\"color:gray;\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-6\">\r\n                            <h5>");
#nullable restore
#line 18 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                           Write(Model.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m | ");
#nullable restore
#line 18 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                              Write(Model.ReleaseDate.Value.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        </div>\r\n                        <div class=\"col-6\">\r\n");
#nullable restore
#line 21 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                             foreach (var genre in Model.Genres)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"#\" class=\"badge badge-secondary\">");
#nullable restore
#line 23 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                     Write(genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 24 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n                <span class=\"badge badge-warning\">");
#nullable restore
#line 28 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                             Write(Model.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <p>");
#nullable restore
#line 29 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
              Write(Model.Overview);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            </div>
            <div class=""col-2"">
                <button type=""button"" class=""btn btn-outline-light btn-block"">REVIEW</button><br />
                <button type=""button"" class=""btn btn-outline-light btn-block"">TRAILER</button><br />
                <button type=""button"" class=""btn btn-light btn-block"">BUY ");
#nullable restore
#line 34 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                     Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button><br />
                <button type=""button"" class=""btn btn-light btn-block"">WATCH MOVIE</button>
            </div>
        </div>
    </div>

<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-4"">
            <div class=""card"" style=""width: 25rem;"">
                <div class=""card-header"">
                    MOVIE FACTS
                </div>
                <ul class=""list-group list-group-flush"">
                    <li class=""list-group-item"">Release Date <span class=""badge badge-dark"">");
#nullable restore
#line 48 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                       Write(Model.ReleaseDate.Value.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                    <li class=\"list-group-item\">Run Time <span class=\"badge badge-dark\">");
#nullable restore
#line 49 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                   Write(Model.RunTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m</span></li>\r\n                    <li class=\"list-group-item\">Box Office <span class=\"badge badge-dark\">$ ");
#nullable restore
#line 50 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                       Write(Model.Revenue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                    <li class=\"list-group-item\">Budget <span class=\"badge badge-dark\">$ ");
#nullable restore
#line 51 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                   Write(Model.Budget);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-8\">\r\n            <div class=\"card\">\r\n                <div class=\"card-header\">\r\n                    CAST\r\n                </div>\r\n");
#nullable restore
#line 60 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                 foreach (var cast in Model.Casts)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <ul class=\"list-group list-group-horizontal\">\r\n                        <li class=\"list-group-item col-1\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "08ac47aefc25cf0678d7d907fd3ffbc473f7464011362", async() => {
                WriteLiteral("<img");
                BeginWriteAttribute("src", " src=\"", 3098, "\"", 3121, 1);
#nullable restore
#line 63 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 3104, cast.ProfilePath, 3104, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid\"");
                BeginWriteAttribute("alt", " alt=\"", 3140, "\"", 3156, 1);
#nullable restore
#line 63 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 3146, cast.Name, 3146, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                                          WriteLiteral(cast.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                        <li class=\"list-group-item col-4\">");
#nullable restore
#line 64 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                     Write(cast.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        <li class=\"list-group-item col-7\">");
#nullable restore
#line 65 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                     Write(cast.Character);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    </ul>\r\n");
#nullable restore
#line 67 "C:\Users\n1 f\Desktop\Antra\MovieShop\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.MovieDetailsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
