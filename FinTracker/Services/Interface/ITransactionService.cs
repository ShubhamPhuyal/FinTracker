using FinTracker.Models;

namespace FinTracker.Services.Interface
{
    public interface ITransactionService
    {
        // Retrieves all transactions
        Task<List<Transaction>> GetAllTransactions();

        // Adds a new transaction
        Task AddTransaction(Transaction transaction);

        // Updates an existing transaction
        Task UpdateTransaction(Transaction transaction);

        // Deletes a transaction by its ID
        Task DeleteTransaction(int transactionId);

        // Retrieves a specific transaction by ID
        Task<Transaction> GetTransactionById(int transactionId);
    }
}