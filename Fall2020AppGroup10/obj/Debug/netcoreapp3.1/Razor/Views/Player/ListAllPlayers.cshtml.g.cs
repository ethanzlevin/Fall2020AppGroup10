#pragma checksum "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d9ea33b71d1791910ad71dd934e31d80c57572f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Player_ListAllPlayers), @"mvc.1.0.view", @"/Views/Player/ListAllPlayers.cshtml")]
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
#line 1 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\_ViewImports.cshtml"
using Fall2020AppGroup10;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\_ViewImports.cshtml"
using Fall2020AppGroup10.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d9ea33b71d1791910ad71dd934e31d80c57572f", @"/Views/Player/ListAllPlayers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"033eba7dba435ec38535c6f940e1cf9669bf6b1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Player_ListAllPlayers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Player>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h4>List of All Players</h4>

<table class=""table table-bordered table-striped"">
    <thead>
        <tr>
            <th> First Name </th>
            <th> Last Name </th>
            <th> DOB </th>
            <th> Position </th>
            <th> Rookie Year </th>
            <th> Salary </th>
            <th> Points Per Game </th>
            <th> Assists Per Game</th>
            <th> Feild Goal Percentage </th>
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 21 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
         foreach (Player eachPlayer in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.DOB);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.RookieYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.Salary);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.PointsPerGame);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.AssistsPerGame);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
               Write(eachPlayer.FieldGoalPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\natep\Source\Repos\Fall2020AppGroup10\Fall2020AppGroup10\Views\Player\ListAllPlayers.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </tbody>\r\n\r\n\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Player>> Html { get; private set; }
    }
}
#pragma warning restore 1591
