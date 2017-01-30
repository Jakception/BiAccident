using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiAccident.Models
{
    public class NbAccidentLieux
    {
        private string annee { get; set; }
        private List<AccidentLieux> ListAccidentLieux { get; set; }

        public NbAccidentLieux(string annee)
        {
            this.annee = annee;
            this.ListAccidentLieux = new List<AccidentLieux>();
        }
        public List<AccidentLieux> GetListAccidentLieux()
        {
            return this.ListAccidentLieux;
        }
        public string GetAnnee()
        {
            return this.annee;
        }
    }
}