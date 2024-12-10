using System.ComponentModel.DataAnnotations;

namespace M06_MessageBancaire
{
    public class MessageCompteBancaire
    {
        [Key]
        public Guid CompteBancaireId { get; set; }

        [Required]
        public string TypeCompte { get; set; } 


        // Constructeur par défaut
        public MessageCompteBancaire()
        {
            CompteBancaireId = Guid.NewGuid();
        }

        // Constructeur paramétré
        public MessageCompteBancaire(Guid id ,string typeCompte)
        {
            CompteBancaireId = id;
            TypeCompte = typeCompte;

        }

    }
}
