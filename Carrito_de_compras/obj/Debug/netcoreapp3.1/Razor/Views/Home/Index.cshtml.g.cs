#pragma checksum "/home/perez/Escritorio/DejandoHuella/Carrito_de_compras/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fb62d91f9ceee98893ea7cdbd7938d331cb7280"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "/home/perez/Escritorio/DejandoHuella/Carrito_de_compras/Views/_ViewImports.cshtml"
using Carrito_de_compras;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/perez/Escritorio/DejandoHuella/Carrito_de_compras/Views/_ViewImports.cshtml"
using Carrito_de_compras.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fb62d91f9ceee98893ea7cdbd7938d331cb7280", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"234b67ef623ef7fd53dafa83872b46c4d0aac6a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/home/perez/Escritorio/DejandoHuella/Carrito_de_compras/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Bienvendo al Carrito de Compras</h1>
<div id=""carouselExampleSlidesOnly"" class=""carousel slide"" data-ride=""carousel"">
  <div class=""carousel-inner"">
    <div class=""carousel-item active"">
        <img src=""carrusel/ima1200843873.jpg"" class=""d-block w-100"" width=""1000"" height=""250"">
    </div>
    <div class=""carousel-item"">
      <img src=""carrusel/Por-que-abandonan-el-carrito-de-compras-en-internet.jpg"" class=""d-block w-100"" width=""1000"" height=""250"">
    </div>
  </div>
</div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
