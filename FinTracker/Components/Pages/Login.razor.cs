using FinTracker.Models;
using Microsoft.AspNetCore.Components;

namespace FinTracker.Components.Pages
{
    public partial class Login
    {
        private string? ErrorMessage;
        private User Users { get; set; } = new User();

        private async Task HandleLogin()
        {
            // Clear any existing error messages
            ErrorMessage = null;

            // Validate input
            if (string.IsNullOrEmpty(Users.Username) || string.IsNullOrEmpty(Users.Password))
            {
                ErrorMessage = "Username and password are required.";
                return;
            }

            if (string.IsNullOrEmpty(Users.PreferredCurrency))
            {
                ErrorMessage = "Please select a preferred currency.";
                return;
            }

            // Call the UserService for authentication
            var currentUser = await UserService.Login(Users);

            if (currentUser != null)
            {
                // Store user globally and navigate to dashboard
                GlobalState.CurrentUser = currentUser;
                Nav.NavigateTo("/dashboard");
            }
            else
            {
                // Display error message on invalid credentials
                ErrorMessage = "Invalid username or password.";
            }
        }
    }
}
