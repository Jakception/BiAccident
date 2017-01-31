using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiAccident.Models
{
    public class CategUser
    {
        private string nbAcc { get; set; }
        private string catu { get; set; }

        public CategUser(string nbAcc, string catu)
        {
            this.nbAcc = nbAcc;
            this.catu = catu;
        }
    }
}