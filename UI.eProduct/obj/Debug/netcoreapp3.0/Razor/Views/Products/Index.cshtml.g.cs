#pragma checksum "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39dcdc630af7e20cde73bc531f4a4e5fa4bbd039"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
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
#line 1 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\_ViewImports.cshtml"
using UI.eProduct;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\_ViewImports.cshtml"
using UI.eProduct.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39dcdc630af7e20cde73bc531f4a4e5fa4bbd039", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40786d6cb4f68fed3fb50f22c25210be9621f97f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-white float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddItemToShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
   ViewData["Title"] = "List of Products"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<div class=\"row\">\n");
#nullable restore
#line 8 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""col-md-4 col-xs-6 border-primary mb-3"">
    <div class=""card mb-3"" style=""max-width: 540px;"">
        <div class=""row g-0"">
            <div class=""col-md-12"">
                <div class=""card-header text-white bg-info"">
                    <p class=""card-text"">
                        <h5 class=""card-title"">
                            ");
#nullable restore
#line 17 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                       Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            \n");
#nullable restore
#line 19 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                             if (TempData["UserRole"].ToString() == "Admin")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                               ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39dcdc630af7e20cde73bc531f4a4e5fa4bbd0396845", async() => {
                WriteLiteral("<i class=\"bi bi-pencil-square\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                                                                                     WriteLiteral(item.Id);

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
            WriteLiteral("\n");
#nullable restore
#line 22 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                             }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \n                        </h5>\n                    </p>\n                </div>\n            </div>\n            <div class=\"col-md-6\">\n                <img");
            BeginWriteAttribute("src", " src=\"", 1018, "\"", 1038, 1);
#nullable restore
#line 29 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
WriteAttributeValue("", 1024, item.ImageURL, 1024, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\"");
            BeginWriteAttribute("alt", " alt=\"", 1052, "\"", 1075, 1);
#nullable restore
#line 29 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
WriteAttributeValue("", 1058, item.ProductName, 1058, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            </div>\n            <div class=\"col-md-6\">\n                <div class=\"card-body\">\n                    <p class=\"card-text\">");
#nullable restore
#line 33 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                                    Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                    <p class=\"card-text\"><b>Name: </b>");
#nullable restore
#line 34 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                                                 Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                    <p class=\"card-text\"><b>Category: </b>");
#nullable restore
#line 35 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                                                     Write(item.ProductCategory.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n\n                    <p class=\"card-text \">\n                        <b>Status: </b>\n");
#nullable restore
#line 39 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                         if (item.Quantity > item.Re_OrderLevel)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge bg-success text-white\">AVAILABLE</span> ");
#nullable restore
#line 41 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                                                                   }
    else if (item.Quantity <= item.Re_OrderLevel)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"badge bg-danger text-white\">OUT OF STOCK</span>");
#nullable restore
#line 44 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </p>\n\n                </div>\n            </div>\n            <div class=\"col-md-12\">\n                <div class=\"card-footer \">\n                    <p class=\"card-text\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39dcdc630af7e20cde73bc531f4a4e5fa4bbd03912807", async() => {
                WriteLiteral("\n                            <i class=\"bi bi-eye-fill\"></i> Show Details\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                                                                                              WriteLiteral(item.Id);

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
            WriteLiteral("\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39dcdc630af7e20cde73bc531f4a4e5fa4bbd03915224", async() => {
                WriteLiteral("\n                            <i class=\"bi bi-cart-plus\"></i> Add to Cart (Price ");
#nullable restore
#line 60 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                                                                          Write(item.Price.ToString("c"));

#line default
#line hidden
#nullable disable
                WriteLiteral(")\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 5, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2211, "btn", 2211, 3, true);
            AddHtmlAttributeValue(" ", 2214, "btn-success", 2215, 12, true);
            AddHtmlAttributeValue(" ", 2226, "text-white", 2227, 11, true);
            AddHtmlAttributeValue(" ", 2237, "float-left", 2238, 11, true);
#nullable restore
#line 56 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
AddHtmlAttributeValue(" ", 2248, (item.Quantity <= item.Re_OrderLevel) ? "disabled" : "", 2249, 58, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
                             WriteLiteral(item.Id);

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
            WriteLiteral("\n                    </p>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>");
#nullable restore
#line 67 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
#nullable restore
#line 70 "C:\Users\CollenMawela-MpiloTe\source\repos\eProduct\UI.eProduct\Views\Products\Index.cshtml"
Write(await Html.PartialAsync("_CreateItem", "Products"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591