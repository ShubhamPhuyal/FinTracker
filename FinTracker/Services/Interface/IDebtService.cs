using FinTracker.Models;

namespace FinTracker.Services.Interface
{
    public interface IDebtService
    {
        // Fetches all debts from the data source
        Task<List<Debt>> GetAllDebts();

        // Adds a new debt to the data source
        Task AddDebt(Debt debt);

        // Updates an existing debt in the data source
        Task UpdateDebt(Debt debt);

        // Deletes a debt from the data source using its ID
        Task DeleteDebt(int debtId);

        // Retrieves a specific debt by its ID
        Task<Debt> GetDebtById(int debtId);

        // Marks a debt as cleared (using its ID)
        Task ClearDebt(int debtId);
    }
}