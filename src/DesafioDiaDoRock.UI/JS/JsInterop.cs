using Microsoft.JSInterop;

namespace DesafioDiaDoRock.UI.JS;

public class JsInterop(IJSRuntime _jsRuntime)
{
    public async Task InitFlatpickr()
    {
        await _jsRuntime.InvokeVoidAsync("initflatpickr");
    }
}