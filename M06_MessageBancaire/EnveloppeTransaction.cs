using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_MessageBancaire
{
    public class EnveloppeTransaction
    {
        public string Action { get; set; }
        public MessageTransaction transaction{ get; set; }
        public EnveloppeTransaction()
        {

        }

        public EnveloppeTransaction(string p_Action ,MessageTransaction p_contenu)
        {

            this.Action = p_Action;

            this.transaction = p_contenu;
        }

    }
}
