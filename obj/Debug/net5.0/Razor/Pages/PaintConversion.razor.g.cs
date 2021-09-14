#pragma checksum "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d3f9b84df27bc8af1dcdc63776683e2dd45e173"
// <auto-generated/>
#pragma warning disable 1591
namespace wargamer_showcase.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\GitHub\wargamer_showcase\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GitHub\wargamer_showcase\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\GitHub\wargamer_showcase\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\GitHub\wargamer_showcase\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\GitHub\wargamer_showcase\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\GitHub\wargamer_showcase\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\GitHub\wargamer_showcase\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\GitHub\wargamer_showcase\_Imports.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\GitHub\wargamer_showcase\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\GitHub\wargamer_showcase\_Imports.razor"
using wargamer_showcase;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\GitHub\wargamer_showcase\_Imports.razor"
using wargamer_showcase.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\GitHub\wargamer_showcase\_Imports.razor"
using wargamer_showcase.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
using Microsoft.Identity.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/paintconversion")]
    public partial class PaintConversion : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2>PaintConversion</h2>\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 10 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
                  selectedPaint

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 10 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
                                                HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenElement(5, "input");
                __builder2.AddAttribute(6, "type", "text");
                __builder2.AddAttribute(7, "list", "paint-search");
                __builder2.AddAttribute(8, "placeholder", "Search for a paint");
                __builder2.AddAttribute(9, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 14 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
                        selectedPaint.PaintName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => selectedPaint.PaintName = __value, selectedPaint.PaintName));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(11, "\r\n    ");
                __builder2.OpenElement(12, "datalist");
                __builder2.AddAttribute(13, "id", "paint-search");
#nullable restore
#line 16 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
         foreach (var paint in allPaints)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(14, "option");
                __builder2.AddContent(15, 
#nullable restore
#line 18 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
                     paint.PaintName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
#nullable restore
#line 19 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
        }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(16, "\r\n    ");
                __builder2.AddMarkupContent(17, "<button type=\"submit\">Convert</button>");
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 23 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
 if (paintConverted)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(18, "<h3>\r\n        Converted Paints\r\n    </h3>\r\n    ");
            __builder.OpenElement(19, "ul");
#nullable restore
#line 29 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
         foreach (var convertedPaint in selectedPaint.ColorConversions)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(20, "li");
            __builder.AddContent(21, 
#nullable restore
#line 31 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
                 convertedPaint.ConvertedPaintName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(22, " by ");
            __builder.AddContent(23, 
#nullable restore
#line 31 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
                                                       convertedPaint.CompanyBy

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 32 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 34 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 35 "C:\GitHub\wargamer_showcase\Pages\PaintConversion.razor"
       
    List<Paint> allPaints = new();
    Paint selectedPaint = new();
    bool paintConverted = false;

    protected override async Task OnInitializedAsync()
    {
        var response = await cosmosDbService.GetAllPaintsAsync();
        allPaints = response.ToList();
    }

    private void HandleValidSubmit()
    {
        selectedPaint = allPaints.Find(p => p.PaintName == selectedPaint.PaintName);
        logger.LogInformation($"Found paint conversions\n{selectedPaint.ColorConversions}");
        paintConverted = true;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<PaintConversion> logger { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICosmosDbService cosmosDbService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IOptionsMonitor<MicrosoftIdentityOptions> microsoftIdentityOptions { get; set; }
    }
}
#pragma warning restore 1591
