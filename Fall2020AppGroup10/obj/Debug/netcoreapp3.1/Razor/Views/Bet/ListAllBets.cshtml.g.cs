#pragma checksum "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13a447416160b424881fc62bf809d2766fd991c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bet_ListAllBets), @"mvc.1.0.view", @"/Views/Bet/ListAllBets.cshtml")]
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
#line 1 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\_ViewImports.cshtml"
using Fall2020AppGroup10;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\_ViewImports.cshtml"
using Fall2020AppGroup10.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13a447416160b424881fc62bf809d2766fd991c6", @"/Views/Bet/ListAllBets.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"033eba7dba435ec38535c6f940e1cf9669bf6b1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Bet_ListAllBets : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bet>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <h4> List of All Player Bets </h4>

    <table class=""table table-bordered table-striped"">
        <thead>
            <tr>
                <th> User</th>
                <th> Wagered</th>
                <th> Start Date</th>
                <th> End Date</th>
                <th> User Win</th>
                <th> Odds</th>

            </tr>
        </thead>

        <tbody>
");
#nullable restore
#line 19 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml"
             foreach (Bet eachBet in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    \r\n                        <td>");
#nullable restore
#line 23 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml"
                       Write(eachBet.UserID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> ");
            WriteLiteral("\r\n                    \r\n\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml"
                   Write(eachBet.AmountPlaced);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml"
                   Write(eachBet.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml"
                   Write(eachBet.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml"
                   Write(eachBet.Result);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml"
                   Write(eachBet.Odds);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 34 "C:\Users\EthanLevin\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Bet\ListAllBets.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </tbody>\r\n\r\n    </table>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bet>> Html { get; private set; }
    }
}
#pragma warning restore 1591