#pragma checksum "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7524c850d24196c78dc1f5305a4254eecc6a98a8"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorMovieTracker_BlazorWebAssemblyApp.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using BlazorMovieTracker_BlazorWebAssemblyApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using BlazorMovieTracker_BlazorWebAssemblyApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\_Imports.razor"
using BlazorMovieTracker_BlazorWebAssemblyApp.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/genres")]
    public partial class Genres : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Genres</h1>");
#nullable restore
#line 5 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor"
 if(genres==null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>");
#nullable restore
#line 8 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table table-striped");
            __builder.AddMarkupContent(4, "<thead><tr><td>Genre</td>\r\n                <th>Count</th></tr></thead>\r\n        ");
            __builder.OpenElement(5, "tbody");
#nullable restore
#line 19 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor"
             foreach(var genre in genres)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "tr");
            __builder.OpenElement(7, "td");
            __builder.AddContent(8, 
#nullable restore
#line 22 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor"
                             genre.GenreDescription

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n                        ");
            __builder.OpenElement(10, "td");
            __builder.AddContent(11, 
#nullable restore
#line 23 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor"
                             genre.MovieCount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 25 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 28 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Genres.razor"
       
    private Genre[] genres;
    protected override async Task OnInitializedAsync()
    {
        genres = await Http.GetFromJsonAsync<Genre[]>("genres");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591