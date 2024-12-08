using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_Entite
{
    public interface IDepotCompteBancaire :IDisposable
    {
        public CompteBancaire GetCompteBancaire(Guid p_CompteBancaireId );
        public void CreateCompteBancaire(CompteBancaire p_Compte);
        public void UpdateCompteBancaire(CompteBancaire p_Compte);

    }
}
