using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiAccident.Models
{
    public class NbCategUser
    {
        private string annee { get; set; }
        private List<CategUser> listCategUser { get; set; }

        public NbCategUser(string annee)
        {
            this.annee = annee;
            listCategUser = new List<CategUser>();
        }
        
        public string GetAnnee()
        {
            return this.annee;
        }
        public List<CategUser> GetListCategUser()
        {
            return this.listCategUser;
        }
    }
}