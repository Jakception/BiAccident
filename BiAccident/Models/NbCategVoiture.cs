using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiAccident.Models
{
    public class NbCategVoiture
    {
        private string annee { get; set; }
        private List<CategVoiture> listCategVoiture { get; set; }

        public NbCategVoiture(string annee)
        {
            this.annee = annee;
            listCategVoiture = new List<CategVoiture>();
        }

        public string GetAnnee()
        {
            return this.annee;
        }
        public List<CategVoiture> GetlistCategVoiture()
        {
            return this.listCategVoiture;
        }
    }
}