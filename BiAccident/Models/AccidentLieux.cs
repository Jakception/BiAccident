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

        public string Num_Acc
        {
            get
            {
                return num_Acc;
            }

            set
            {
                num_Acc = value;
            }
        }

        public string Catr
        {
            get
            {
                return catr;
            }

            set
            {
                catr = value;
            }
        }

        public AccidentLieux(string num_Acc, string catr)
        {
            this.Num_Acc = num_Acc;
            this.Catr = catr;
        }

    }
}