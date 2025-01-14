
namespace FinTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public string Title { get; set; }
        public string Type { get; set; } // Income Expense Debt
        public DateTime Date { get; set; }        // Date of the transaction
        public string Description { get; set; }
        public string Tags { get; set; }   // E.g. "Rent", "Salary", etc.

    }
}