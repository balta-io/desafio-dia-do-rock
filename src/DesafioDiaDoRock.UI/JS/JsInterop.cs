using DesafioDiaDoRock.ApplicationCore.Entities;
using DesafioDiaDoRock.ApplicationCore.Models.Integrations;
using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace DesafioDiaDoRock.UI.JS;

public class JsInterop(IJSRuntime _jsRuntime)
{
    public async Task InitFlatpickr()
    {
        await _jsRuntime.InvokeVoidAsync("initflatpickr");
    }
    public async Task CreatMarker(Position position,Event @event)
    {
        await _jsRuntime.InvokeVoidAsync("creatMarker", position, 
            @event.UrlImage, 
            @event.NameLocation, 
            @event.Address, 
            @event.FormatDateResponse(),
            @event.Band);
    }

    public async Task RemoveMarkers()
    {
        await _jsRuntime.InvokeVoidAsync("removeMarkers");
    }
}