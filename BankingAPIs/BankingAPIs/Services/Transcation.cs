using BankingAPIs.Interface;
using System.Transactions;

namespace BankingAPIs.Repos
{
    public class Transcation : ITranscation
    {
        public Transaction CreateNewTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction FindTransactionByDate(DateTime TranscDate)
        {
            throw new NotImplementedException();
        }
    }
}
