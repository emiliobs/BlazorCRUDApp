﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Helpers
{
    public static class IJSExtension
    {
        public static Task GuardarComo(this IJSRuntime js , string nombreArchivo, byte[] archivo)
        {
            return js.InvokeAsync<object>("saveAsFile", nombreArchivo, Convert.ToBase64String(archivo));
        }
    }
}
