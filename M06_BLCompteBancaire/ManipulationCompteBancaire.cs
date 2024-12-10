using M06_DAL_SQLServeur;
using M06_Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_BLCompteBancaire
{
    public  class ManipulationCompteBancaire
    {
        private IDepotCompteBancaire m_depot;

        public ManipulationCompteBancaire (IDepotCompteBancaire depot)
        {
            m_depot = depot;
        }

        
        public List<CompteBancaire> GetCompteBancaires()
        {
            return m_depot.GetCompteBancaires();    
        }
        public CompteBancaire GetCompteBancaire(Guid p_CompteBancaireId)
        {
            return m_depot.GetCompteBancaire(p_CompteBancaireId);
        }

        public void CreateCompteBancaire(CompteBancaire p_Compte)
        {
            m_depot.CreateCompteBancaire(p_Compte);
        }

        public void UpdateCompteBancaire(CompteBancaire p_Compte)
        {
            m_depot.UpdateCompteBancaire(p_Compte);
        }


    }
}
