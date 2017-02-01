using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiAccident.Models
{
    public class CategVoiture
    {
        private string nbAcc;
        private string catv;

        public string NbAcc
        {
            get
            {
                return nbAcc;
            }

            set
            {
                nbAcc = value;
            }
        }

        public string Catv
        {
            get
            {
                return catv;
            }

            set
            {
                catv = value;
            }
        }

        public CategVoiture(string nbAcc, string catv)
        {
            this.NbAcc = nbAcc;
            this.Catv = catv;
        }
    }
}