#pragma checksum "/Users/samt51/Projects/E-Shopping/EShopping.UI/Views/Shared/Component/CategoryList/Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "960a33f6a4007d17aad5b326fcd59b4368ab310b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Component_CategoryList_Default), @"mvc.1.0.view", @"/Views/Shared/Component/CategoryList/Default.cshtml")]
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
#line 1 "/Users/samt51/Projects/E-Shopping/EShopping.UI/Views/_ViewImports.cshtml"
using EShopping.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/samt51/Projects/E-Shopping/EShopping.UI/Views/_ViewImports.cshtml"
using EShopping.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/samt51/Projects/E-Shopping/EShopping.UI/Views/_ViewImports.cshtml"
using EShopping_Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/samt51/Projects/E-Shopping/EShopping.UI/Views/_ViewImports.cshtml"
using EShopping.UI.Extension;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"960a33f6a4007d17aad5b326fcd59b4368ab310b", @"/Views/Shared/Component/CategoryList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e446903a8e8c0879b8dc342bfd91aac841fa7ea7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Component_CategoryList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategoryListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n<ul class=\"list-group\">\n");
#nullable restore
#line 5 "/Users/samt51/Projects/E-Shopping/EShopping.UI/Views/Shared/Component/CategoryList/Default.cshtml"
     foreach (var ktg in Model.Categories)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item\">");
#nullable restore
#line 7 "/Users/samt51/Projects/E-Shopping/EShopping.UI/Views/Shared/Component/CategoryList/Default.cshtml"
                               Write(ktg.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n");
#nullable restore
#line 8 "/Users/samt51/Projects/E-Shopping/EShopping.UI/Views/Shared/Component/CategoryList/Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n</ul> ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategoryListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
