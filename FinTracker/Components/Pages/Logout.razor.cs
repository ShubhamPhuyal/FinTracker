using Microsoft.AspNetCore.Components;
namespace FinTracker.Components.Pages
{
    public partial class Logout : ComponentBase
    {
        private bool IslogOut { get; set; } = false; private void PerformLogout()
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
