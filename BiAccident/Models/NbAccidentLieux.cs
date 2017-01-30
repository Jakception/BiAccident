using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiAccident.Models
{
    public class NbAccidentLieux
    {
        private string annee;
        private List<AccidentLieux> listAccidentLieux;

        public NbAccidentLieux(string annee)
        {
            this.Annee = annee;
            this.ListAccidentLieux = new List<AccidentLieux>();
        }

        public string Annee
        {
            get
            {
                return annee;
            }

            set
            {
                annee = value;
            }
        }

        public List<AccidentLieux> ListAccidentLieux
        {
            get
            {
                return listAccidentLieux;
            }

            set
            {
                listAccidentLieux = value;
            }
        }
    }
}