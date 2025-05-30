﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using M06_MessageBancaire;

namespace M06_Entite
{
    public class CompteBancaire
    {

        [Key]
        public Guid CompteBancaireId { get; set; }

        [Required]
        public string TypeCompte { get; set; } // Par exemple, 'courant'

      
        // Constructeur par défaut
        public CompteBancaire()
        {
            CompteBancaireId = Guid.NewGuid();
        }

        // Constructeur paramétré
        public CompteBancaire(string typeCompte)
        {
            CompteBancaireId = Guid.NewGuid();
            TypeCompte = typeCompte;
           
        }
        public MessageCompteBancaire versMessageCompteBancaire()
        {
            return new MessageCompteBancaire(CompteBancaireId,TypeCompte);
        }

    }
}
