#pragma checksum "C:\Users\jason\Documents\AllCodingSave\Oct2020\MovieShop\backend\MovieShop.web\Views\Shared\Components\Genres\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "091078f11b8b9b7cbfc7407aa2ad6bc8b7077e57"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Genres_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Genres/Default.cshtml")]
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
#line 1 "C:\Users\jason\Documents\AllCodingSave\Oct2020\MovieShop\backend\MovieShop.web\Views\_ViewImports.cshtml"
using MovieShop.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jason\Documents\AllCodingSave\Oct2020\MovieShop\backend\MovieShop.web\Views\_ViewImports.cshtml"
using MovieShop.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"091078f11b8b9b7cbfc7407aa2ad6bc8b7077e57", @"/Views/Shared/Components/Genres/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08ec4958f30060de1821c42cb92b137d676df4e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Genres_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MovieShop.Core.Entities.Genre>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\jason\Documents\AllCodingSave\Oct2020\MovieShop\backend\MovieShop.web\Views\Shared\Components\Genres\Default.cshtml"
 foreach(var genre in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"dropdown-item\">\r\n        ");
#nullable restore
#line 6 "C:\Users\jason\Documents\AllCodingSave\Oct2020\MovieShop\backend\MovieShop.web\Views\Shared\Components\Genres\Default.cshtml"
   Write(genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </a>\r\n");
#nullable restore
#line 8 "C:\Users\jason\Documents\AllCodingSave\Oct2020\MovieShop\backend\MovieShop.web\Views\Shared\Components\Genres\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MovieShop.Core.Entities.Genre>> Html { get; private set; }
    }
}
#pragma warning restore 1591
