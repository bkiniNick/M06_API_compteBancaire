using M06_Entite;
using M06_MessageBancaire;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace M06_DAL_SQLServeur
{
    public  class DepotTransaction : IDepotTransaction
    { private ApplicationDBContext m_contexte;

        public DepotTransaction(ApplicationDBContext p_contexte)
        {
            if (p_contexte is null)
            {
                throw new ArgumentNullException(nameof(p_contexte));
            }

            this.m_contexte = p_contexte;
        }
        public List<Transaction> GetTransaction(Guid CompteBancaireId)
        {
            List<TransactionSQLServeurDTO> listTransaction = m_contexte.Transactions.Where(x => x.CompteBancaireId == CompteBancaireId).ToList();

           List<Transaction> resultat=listTransaction.Select(x => x.VersEntite()).ToList();
            return resultat;
        }


        public void CreateTransaction(Transaction p_transaction)
        {
            if (p_transaction is null)
            {
                throw new ArgumentNullException(nameof(p_transaction));
            }
            // Initialisation de la connexion RabbitMQ
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "CreateUpdate",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                EnveloppeTransaction message = new EnveloppeTransaction("create", p_transaction.versMessageTransaction());
                string messageJson = JsonSerializer.Serialize(message);
                byte[] body = Encoding.UTF8.GetBytes(messageJson);

                channel.BasicPublish(exchange: "",
                                     routingKey: "CreateUpdate",
                                     basicProperties: null,
                                     body: body);


            }
            /*
            var existingClient = m_contexte.Transactions.FirstOrDefault(c => c.TransactionId == p_transaction.TransactionId);
            if (existingClient == null)
            {
                m_contexte.Add(new TransactionSQLServeurDTO(p_transaction.TypeTransactions,p_transaction.Montant));
                m_contexte.SaveChanges();
            }
            else
            {
                Console.WriteLine("le client existe deja");
            }*/
        }


        public void UpdateTransaction(Transaction p_transaction)
        {
            if (p_transaction is null)
            {
                throw new ArgumentNullException(nameof(p_transaction));
            }
            // Initialisation de la connexion RabbitMQ
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "CreateUpdate",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                EnveloppeTransaction message = new EnveloppeTransaction("update", p_transaction.versMessageTransaction());
                string messageJson = JsonSerializer.Serialize(message);
                byte[] body = Encoding.UTF8.GetBytes(messageJson);

                channel.BasicPublish(exchange: "",
                                     routingKey: "CreateUpdate",
                                     basicProperties: null,
                                     body: body);


            }
            /* TransactionSQLServeurDTO l = new TransactionSQLServeurDTO(p_transaction.TypeTransactions, p_transaction.Montant);

             this.m_contexte.Update(l);
             this.m_contexte.SaveChanges();
             this.m_contexte.ChangeTracker.Clear();*/
        }
        public void Dispose()
        {
            ; // le contexte sera ici disposé par le dispose de la transaction
        }

    }
}
