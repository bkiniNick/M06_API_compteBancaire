using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_Entite
{
    public  interface IDepotTransaction: IDisposable
    {
        public List<Transaction> GetTransaction(Guid TrasactionId);

        public void CreateTransaction(Transaction p_transaction);

        public void UpdateTransaction(Transaction p_transaction);



    }
}
