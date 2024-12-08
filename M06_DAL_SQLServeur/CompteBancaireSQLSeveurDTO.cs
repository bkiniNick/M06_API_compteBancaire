using System.ComponentModel.DataAnnotations;
using M06_Entite;


namespace M06_DAL_SQLServeur
{
    public class CompteBancaireSQLSeveurDTO
    {


        [Key]
        public Guid CompteBancaireId { get; set; }

        [Required]
        public string TypeCompte { get; set; } // Par exemple, 'courant'


        // Constructeur par défaut
        public CompteBancaireSQLSeveurDTO()
        {
            CompteBancaireId = Guid.NewGuid();
        }

        // Constructeur paramétré
        public CompteBancaireSQLSeveurDTO(string typeCompte)
        {
            CompteBancaireId = Guid.NewGuid();
            TypeCompte = typeCompte;

        }

        public CompteBancaire VersEntite()
        {
            return (new CompteBancaire(TypeCompte));
        }

    }
}
