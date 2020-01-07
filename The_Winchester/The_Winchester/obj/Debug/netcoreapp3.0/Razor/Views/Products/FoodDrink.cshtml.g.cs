#pragma checksum "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\Products\FoodDrink.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0eb356bd2b70e747cfc1784c91d93819b861133"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_FoodDrink), @"mvc.1.0.view", @"/Views/Products/FoodDrink.cshtml")]
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
#line 1 "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\_ViewImports.cshtml"
using The_Winchester;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\_ViewImports.cshtml"
using The_Winchester.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0eb356bd2b70e747cfc1784c91d93819b861133", @"/Views/Products/FoodDrink.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee5bb7627be9749bc9821213bb53397e7542827f", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_FoodDrink : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<The_Winchester.Product>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\Products\FoodDrink.cshtml"
  
    ViewData["Title"] = "FoodDrink";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0eb356bd2b70e747cfc1784c91d93819b8611333360", async() => {
                WriteLiteral(@"

    <main class=""page catalog-page"">
        <section class=""clean-block clean-catalog dark"">
            <div class=""container"">
                <div class=""block-heading"">
                    <h2 class=""text-info"">Food and Drink</h2>
                    <p>Choose from a range of wonderful products and have them delivered to your table!</p>
                </div>
                <div class=""content"">
                    <div class=""row"">
                        <div class=""col-md-3"">
                            <div class=""d-none d-md-block"">
                                <div class=""filters"">
                                    <div class=""filter-item""></div>
                                </div>
                            </div>
                            <div class=""dropdown"">
                                <button class=""btn btn-primary dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false"" type=""button"" style=""margin-left: 32px;"">Filter</button>
                        ");
                WriteLiteral(@"        <div class=""dropdown-menu"" role=""menu""><a class=""dropdown-item"" role=""presentation"" href=""#"">First Item</a><a class=""dropdown-item"" role=""presentation"" href=""#"">Second Item</a><a class=""dropdown-item"" role=""presentation"" href=""#"">Third Item</a></div>
                            </div>
                            <div class=""d-md-none"">
                                <a class=""btn btn-link d-md-none filter-collapse"" data-toggle=""collapse"" aria-expanded=""false"" aria-controls=""filters"" href=""#filters"" role=""button"">Filters<i class=""icon-arrow-down filter-caret""></i></a>
                                <div class=""collapse""
                                     id=""filters"">
                                    <div class=""filters"">
                                        <div class=""filter-item""></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-9"">");
                WriteLiteral(@"
                            <div class=""products"">
                                <div class=""table-responsive"">
                                    <table class=""table"">
                                        <thead>
                                            <tr>
                                                <th>Product</th>
                                                <th>Price</th>
                                                <th>Description</th>
                                                <th>Quantity</th>
                                                <th>Add to basket</th>
                                            </tr>
                                        </thead>
                                        <tbody>
");
#nullable restore
#line 52 "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\Products\FoodDrink.cshtml"
                                              
                                                foreach (var product in Model)
                                                {
                                                    if (product.InUse == 1)
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <tr>\r\n                                                            <td>");
#nullable restore
#line 58 "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\Products\FoodDrink.cshtml"
                                                           Write(product.ProdName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                            <td>");
#nullable restore
#line 59 "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\Products\FoodDrink.cshtml"
                                                           Write(product.ProdPrice.ToString("c"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                            <td>");
#nullable restore
#line 60 "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\Products\FoodDrink.cshtml"
                                                           Write(product.ProdDesc);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                                            <td><input type=""number""></td>
                                                            <td><button class=""btn btn-primary"" type=""button"">Add</button> <button class=""btn btn-primary"" type=""button"">Remove</button></td>
                                                        </tr>
");
#nullable restore
#line 64 "D:\git\ISAD251CW\The_Winchester\The_Winchester\Views\Products\FoodDrink.cshtml"
                                                    }
                                                }
                                            

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<The_Winchester.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
