using M06_Entite;

namespace M06_BLCompteBancaire
{
    public class ManipulationTransaction
    {
        private IDepotTransaction m_depot;
        public ManipulationTransaction(IDepotTransaction depot)
        {
            m_depot = depot;
        }

        public List<Transaction> GetTransaction(Guid TrasactionId)
        {
            return m_depot.GetTransaction(TrasactionId);
        }

        public void CreateTransaction(Transaction p_transaction)
        {
            m_depot.CreateTransaction(p_transaction);

        }

        public void UpdateTransaction(Transaction p_transaction)
        {
            m_depot.UpdateTransaction(p_transaction);
        }

    }
}
