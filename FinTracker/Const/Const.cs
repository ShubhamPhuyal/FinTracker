namespace FinTracker.Const
{
    public class Const
    {
        public static string UsersFilePath()
        {
            return Path.Combine(FileSystem.AppDataDirectory, "users.json");
        }

        public static string TransactionsFilePath()
        {
            return Path.Combine(FileSystem.AppDataDirectory, "transactions.json");
        }

        public static string TagsFilePath()
        {
            return Path.Combine(FileSystem.AppDataDirectory, "tags.json");
        }

        public static string DebtsFilePath()
        {
            return Path.Combine(FileSystem.AppDataDirectory, "debts.json");
        }

    }
}