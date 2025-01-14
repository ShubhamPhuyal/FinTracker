using System.Text.Json;
using FinTracker.Abstraction;
using FinTracker.Models;
using FinTracker.Services.Interface;

namespace FinTracker.Services
{
    public class DebtService : BaseService<Debt>, IDebtService
    {
        private static readonly string AppDebtFilePath = Const.Const.DebtsFilePath();
        private List<Debt> _debts;

        public DebtService()
        {
            // Initialize debts list
            _debts = LoadDebtsFromFile(AppDebtFilePath);
        }

        // Fetches all debts
        public async Task<List<Debt>> GetAllDebts()
        {
            return await Task.FromResult(_debts);
        }

        // Adds a new debt
        public async Task AddDebt(Debt debt)
        {
            debt.Id = _debts.Count > 0 ? _debts.Max(d => d.Id) + 1 : 1; // Assign a unique ID
            _debts.Add(debt);
            await SaveDebtsToFile();
        }

        // Updates an existing debt
        public async Task UpdateDebt(Debt debt)
        {
            var existingDebt = _debts.FirstOrDefault(d => d.Id == debt.Id);
            if (existingDebt != null)
            {
                existingDebt.Source = debt.Source;
                existingDebt.Title = debt.Title;
                existingDebt.Amount = debt.Amount;
                existingDebt.DueDate = debt.DueDate;
                existingDebt.Status = debt.Status;
                existingDebt.ClearedDate = debt.ClearedDate;

                await SaveDebtsToFile();
            }
        }

        // Deletes a debt by its ID
        public async Task DeleteDebt(int debtId)
        {
            var debtToRemove = _debts.FirstOrDefault(d => d.Id == debtId);
            if (debtToRemove != null)
            {
                _debts.Remove(debtToRemove);
                await SaveDebtsToFile();
            }
        }

        // Retrieves a debt by its ID
        public async Task<Debt> GetDebtById(int debtId)
        {
            var debt = _debts.FirstOrDefault(d => d.Id == debtId);
            return await Task.FromResult(debt);
        }

        // Marks a debt as cleared
        public async Task ClearDebt(int debtId)
        {
            var debt = _debts.FirstOrDefault(d => d.Id == debtId);
            if (debt != null)
            {
                debt.Status = "Cleared";
                debt.ClearedDate = DateOnly.FromDateTime(DateTime.Now);

                await SaveDebtsToFile();
            }
        }

        // Private method to load debts from the file
        private List<Debt> LoadDebtsFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Debt file not found: {filePath}");
                    return new List<Debt>();
                }

                var json = File.ReadAllText(filePath);
                var debts = JsonSerializer.Deserialize<List<Debt>>(json);

                return debts ?? new List<Debt>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON error: {jsonEx.Message}");
                return new List<Debt>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading debts: {ex.Message}");
                return new List<Debt>();
            }
        }

        // Private method to save debts to the file
        private async Task SaveDebtsToFile()
        {
            try
            {
                var json = JsonSerializer.Serialize(_debts, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(AppDebtFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving debts: {ex.Message}");
            }
        }
    }
}
