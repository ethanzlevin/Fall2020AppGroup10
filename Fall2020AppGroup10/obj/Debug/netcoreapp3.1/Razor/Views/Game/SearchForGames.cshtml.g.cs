#pragma checksum "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64d46bca665be70d18b1a2c75e67725b96664011"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_SearchForGames), @"mvc.1.0.view", @"/Views/Game/SearchForGames.cshtml")]
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
#line 1 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\_ViewImports.cshtml"
using Fall2020AppGroup10;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\_ViewImports.cshtml"
using Fall2020AppGroup10.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d46bca665be70d18b1a2c75e67725b96664011", @"/Views/Game/SearchForGames.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"033eba7dba435ec38535c6f940e1cf9669bf6b1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_SearchForGames : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Game>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h4> Search Result</h4>

<table class=""table table-bordered table-striped"">
    <thead>
        <tr>
            <th> Date</th>
            <th> Favorite</th>
            <th> Score</th>
            <th> Home Team</th>
            <th> Away Team</th>
        </tr>

    </thead>

    <tbody>

");
#nullable restore
#line 19 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
         foreach (Game eachGame in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
               Write(eachGame.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 24 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
                 if (eachGame.Favorite.HasValue)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 26 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
                   Write(eachGame.Favorite);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 27 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 29 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
                 if (eachGame.Score.HasValue)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 31 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
                   Write(eachGame.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 32 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>");
#nullable restore
#line 34 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
               Write(eachGame.HomeID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                <td>");
#nullable restore
#line 36 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"
               Write(eachGame.AwayID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 41 "C:\Users\EthanLevin\source\repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Game\SearchForGames.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n\r\n\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Game>> Html { get; private set; }
    }
}
#pragma warning restore 1591
