using FinTracker.Models;
using Microsoft.AspNetCore.Components;

namespace FinTracker.Components.Pages
{
    public partial class Index
    {
        [CascadingParameter]
        private GlobalState _globalState { get; set; }

        protected override void OnInitialized()
        {

            Nav.NavigateTo("/login");

        }
    }
}