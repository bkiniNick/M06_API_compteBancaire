using M06_Entite;
using M06_MessageBancaire;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public List<CompteBancaire> GetCompteBancaires()
        {
            List<CompteBancaire> compteBancaires = m_contexte.CompteBancaires.Select(x=>x.VersEntite()).ToList();
           
            return compteBancaires;
        }
        public CompteBancaire GetCompteBancaire(Guid p_CompteBancaireId)
        {
            CompteBancaireSQLSeveurDTO resultat = m_contexte.CompteBancaires.Where(x => x.CompteBancaireId == p_CompteBancaireId).SingleOrDefault();
            return (resultat.VersEntite());
        }

        public void CreateCompteBancaire(CompteBancaire p_Compte)
        {
            if (p_Compte == null)
            {
                throw new ArgumentNullException(nameof(p_Compte));
            }


            // Initialisation de la connexion RabbitMQ
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection =  factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "CreateUpdate",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                EnveloppeBancaire message = new EnveloppeBancaire("create", p_Compte.versMessageCompteBancaire());
                string messageJson = JsonSerializer.Serialize(message);
                byte[] body = Encoding.UTF8.GetBytes(messageJson);

                channel.BasicPublish(exchange: "",
                                     routingKey: "CreateUpdate",
                                     basicProperties: null,
                                     body: body);

              
            }
           
        }

        public void UpdateCompteBancaire(CompteBancaire p_Compte)
        {
            if (p_Compte is null)
            {
                throw new ArgumentNullException(nameof(p_Compte));
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

                EnveloppeBancaire message = new EnveloppeBancaire("update", p_Compte.versMessageCompteBancaire());
                string messageJson = JsonSerializer.Serialize(message);
                byte[] body = Encoding.UTF8.GetBytes(messageJson);

                channel.BasicPublish(exchange: "",
                                     routingKey: "CreateUpdate",
                                     basicProperties: null,
                                     body: body);


            }
        }
        public void Dispose()
        {
            ; // le contexte sera ici disposé par le dispose de la transaction
        }
    }
}
