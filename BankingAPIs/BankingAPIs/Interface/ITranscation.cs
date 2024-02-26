using System.Transactions;

namespace BankingAPIs.Interface
{
    public interface ITranscation
    {
        Transaction CreateNewTransaction(Transaction transaction);
        Transaction FindTransactionByDate(DateTime TranscDate);
    }
}
