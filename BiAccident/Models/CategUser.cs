﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiAccident.Models
{
    public class CategUser
    {
        private string nbAcc;
        private string catu;

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

        public string Catu
        {
            get
            {
                return catu;
            }

            set
            {
                catu = value;
            }
        }

        public CategUser(string nbAcc, string catu)
        {
            this.NbAcc = nbAcc;
            this.Catu = catu;
        }
    }
}