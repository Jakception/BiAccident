using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiAccident.Models
{
    public class AccidentLieux
    {
        private string num_Acc;
        private string catr;

        public AccidentLieux(string num_Acc, string catr)
        {
            this.num_Acc = num_Acc;
            this.catr = catr;
        }

    }
}