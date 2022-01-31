namespace Module4HW6.Helpers;

public static class TransactionDb
{
    public static async Task<T> Transaction<T>(Func<Task<T>> func, string[] args)
    {
        await using (var transaction =
                     await new SampleContextFactory().CreateDbContext(args).Database.BeginTransactionAsync())
        {
            try
            {
                var result = await func();
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                return default(T);
            }
        }
    }
}