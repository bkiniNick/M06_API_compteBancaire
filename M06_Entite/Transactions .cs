using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M06_MessageBancaire;

namespace M06_Entite
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }

        [Required]
  
        public string TypeTransactions { get; set; } 

        [Required]
        public DateTime  DateTransactions { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Montant { get; set; }
        // Clé étrangère vers Transaction
        [ForeignKey("CompteBancaire")]
        public Guid? CompteBancaireId { get; set; }


        // Constructeur par défaut
        public Transaction()
        {
            TransactionId = Guid.NewGuid(); 
            DateTransactions = DateTime.Now; 
        }

        public Transaction(string typeTransactions, decimal montant)
        {
            TransactionId = Guid.NewGuid();
            TypeTransactions = typeTransactions;
            DateTransactions = DateTime.Now;
            Montant = montant;
        }
        public MessageTransaction versMessageTransaction()
        {
            return new(TransactionId, TypeTransactions, Montant);
        }
    }
}
