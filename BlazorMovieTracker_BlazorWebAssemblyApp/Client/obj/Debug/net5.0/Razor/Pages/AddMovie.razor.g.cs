#pragma checksum "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\AddMovie.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e5500f05e6fd702bbd7066dcefd266fc7c081ad"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/addmovie")]
    public partial class AddMovie : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>AddMovie</h3>\r\n");
            __builder.OpenComponent<BlazorMovieTracker_BlazorWebAssemblyApp.Client.Pages.MovieForm>(1);
            __builder.AddAttribute(2, "ButtonText", "Add");
            __builder.AddAttribute(3, "movie", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorMovieTracker_BlazorWebAssemblyApp.Shared.Movie>(
#nullable restore
#line 5 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\AddMovie.razor"
                                   movie

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 5 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\AddMovie.razor"
                                                         AddMovieAsync
           

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 7 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\AddMovie.razor"
       
    Movie movie = new Movie();
    async Task AddMovieAsync()
    {
        if (movie.GenreId == null)
        {
            movie.GenreId = 1;
        }
        await Http.PostAsJsonAsync("movies", movie);
        NavManager.NavigateTo("/");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
