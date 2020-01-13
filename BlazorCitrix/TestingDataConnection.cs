using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCitrix
{
    public class TestingDataConnection : ComponentBase
    {

        [Parameter]
        public Action<int> Test { get; set; }
    }
}
