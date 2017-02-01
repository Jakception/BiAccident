using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiAccident.Models;

namespace BiAccident.ViewModels
{
    public class NbCategUserViewModels
    {
        List<Models.NbCategUser> listNbCategUser;

        public NbCategUserViewModels()
        {
            this.listNbCategUser = new List<NbCategUser>();
        }

        public List<NbCategUser> ListNbCategUser
        {
            get
            {
                return listNbCategUser;
            }

            set
            {
                listNbCategUser = value;
            }
        }
    }
}