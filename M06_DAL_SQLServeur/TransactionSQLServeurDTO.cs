using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M06_Entite;
namespace M06_DAL_SQLServeur
{
    public  class TransactionSQLServeurDTO
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
        public TransactionSQLServeurDTO()
        {
            TransactionId = Guid.NewGuid();
            DateTransactions = DateTime.Now;
        }

        public TransactionSQLServeurDTO(string typeTransactions, decimal montant)
        {
            TransactionId = Guid.NewGuid();
            TypeTransactions = typeTransactions;
            DateTransactions = DateTime.Now;
            Montant = montant;
        }
        public Transaction VersEntite()
        {
            return (new Transaction( TypeTransactions, Montant));
        }

    }
}
