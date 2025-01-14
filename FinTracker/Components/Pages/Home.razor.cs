using System;
using System.Collections.Generic;
using System.Linq;
using FinTracker.Models;
using FinTracker.Services;
using Microsoft.AspNetCore.Components;

namespace FinTracker.Components.Pages
{
    public partial class Home : ComponentBase
    {
        // Variables for logout modal
        private bool IslogOut { get; set; } = false;

        private void Logout()
        {
            Nav.NavigateTo("/login");
        }

        private void ShowLogoutConfirmation()
        {
            IslogOut = true;
        }

        private void HideLogoutConfirmation()
        {
            IslogOut = false;
        }


    }
}
