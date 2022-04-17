// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "C:\Users\PAUL LONG\Box\dotNet\COMPCO884\BlazorMovieTracker_BlazorWebAssemblyApp\Client\Pages\Index.razor"
      
    private Movie[] movies;
    protected override async Task OnInitializedAsync()
    {
        movies = await Http.GetFromJsonAsync<Movie[]>("movies");
    }
    async Task DeleteAsync(int id)
    {
        Movie movie = movies.First(mov => mov.Id == id);
        if(await JS.InvokeAsync<bool>("confirm",$"Are you sure you wanna delete {movie.Title}?"))
        {
            await Http.DeleteAsync($"movies/{id}");
            await OnInitializedAsync();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
