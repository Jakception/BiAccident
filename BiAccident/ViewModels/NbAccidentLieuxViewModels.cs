using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiAccident.Models;

namespace BiAccident.ViewModels
{
    public class NbAccidentLieuxViewModels
    {
        List<Models.NbAccidentLieux> listNbAccidentLieux;

        public NbAccidentLieuxViewModels()
        {
            this.listNbAccidentLieux = new List<NbAccidentLieux>();
        }

        public List<NbAccidentLieux> ListNbAccidentLieux
        {
            get
            {
                return listNbAccidentLieux;
            }

            set
            {
                listNbAccidentLieux = value;
            }
        }
    }
}