using M06_Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_DAL_SQLServeur
{
    public class DepotCompteBancaire :IDepotCompteBancaire
    {
        private ApplicationDBContext m_contexte;

        public DepotCompteBancaire(ApplicationDBContext p_contexte)
        {
            if (p_contexte is null)
            {
                throw new ArgumentNullException(nameof(p_contexte));
            }

            this.m_contexte = p_contexte;
        }
        public CompteBancaire GetCompteBancaire(Guid p_CompteBancaireId)
        {
            CompteBancaireSQLSeveurDTO resultat = m_contexte.CompteBancaires.Where(x => x.CompteBancaireId == p_CompteBancaireId).SingleOrDefault();
            return (resultat.VersEntite());
        }

        public void CreateCompteBancaire(CompteBancaire p_Compte)
        {

            if (p_Compte is null)
            {
                throw new ArgumentNullException(nameof(p_Compte));
            }
            var existingClient = m_contexte.CompteBancaires.FirstOrDefault(c => c.CompteBancaireId == p_Compte.CompteBancaireId);
            if (existingClient == null)
            {
                m_contexte.Add(new CompteBancaireSQLSeveurDTO(p_Compte.TypeCompte));
                m_contexte.SaveChanges();
            }
            else
            {
                Console.WriteLine("le client existe deja");
            }

        }
        public void UpdateCompteBancaire(CompteBancaire p_Compte)
        {
            if (p_Compte is null)
            {
                throw new ArgumentNullException(nameof(p_Compte));
            }
            CompteBancaireSQLSeveurDTO l = new CompteBancaireSQLSeveurDTO(p_Compte.TypeCompte);

                this.m_contexte.Update(l);
            this.m_contexte.SaveChanges();
            this.m_contexte.ChangeTracker.Clear();
        }
        public void Dispose()
        {
            ; // le contexte sera ici disposé par le dispose de la transaction
        }
    }
}
