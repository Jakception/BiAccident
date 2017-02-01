using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiAccident.Models;

namespace BiAccident.ViewModels
{
    public class NbCategVoitureViewModels
    {
        List<Models.NbCategVoiture> listNbCategVoiture;

        public NbCategVoitureViewModels()
        {
            this.listNbCategVoiture = new List<NbCategVoiture>();
        }

        public List<NbCategVoiture> ListNbCategVoiture
        {
            get
            {
                return listNbCategVoiture;
            }

            set
            {
                listNbCategVoiture = value;
            }
        }
    }
}