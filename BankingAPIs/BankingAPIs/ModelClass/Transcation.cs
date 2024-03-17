using System.ComponentModel.DataAnnotations;

namespace BankingAPIs.ModelClass
{
    public class Transcation
    {
        [Key]
        public int Id { get; set; }
        public Guid TranscationId { get; set; }
        public double AmountTransfered { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }

        public TransactionStatus TransactionStat { get; set; }

        public DateTime TransDate { get; set; }

        public enum TransactionStatus
        {
            Successful,
            Failed,
            Pending
        }

        public Transcation()
        {


        }
    }
}
