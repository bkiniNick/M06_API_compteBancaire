﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_MessageBancaire
{
    public  class EnveloppeBancaire
    {
        public string Action { get; set; }
        public MessageCompteBancaire contenu { get; set; }
        public EnveloppeBancaire()
        {

        }

        public EnveloppeBancaire(string p_Action,  MessageCompteBancaire p_contenu)
        {

            this.Action = p_Action;
            
            this.contenu = p_contenu;
        }

    }
}
