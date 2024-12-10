using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_MessageBancaire
{
    public class MessageTransaction
    {
        [Key]
        public Guid TransactionId { get; set; }

        [Required]

        public string TypeTransactions { get; set; }

        [Required]
        public DateTime DateTransactions { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Montant { get; set; }
        // Clé étrangère vers Transaction
        [ForeignKey("CompteBancaire")]
        public Guid? CompteBancaireId { get; set; }


        // Constructeur par défaut
        public MessageTransaction()
        {
            TransactionId = Guid.NewGuid();
            DateTransactions = DateTime.Now;
        }

        public MessageTransaction(Guid transac , string typeTransactions, decimal montant)
        {
            TransactionId = transac;
            TypeTransactions = typeTransactions;
            DateTransactions = DateTime.Now;
            Montant = montant;
        }
    }
}
