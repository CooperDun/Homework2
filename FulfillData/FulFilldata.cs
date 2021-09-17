using System;
using System.Collections.Generic;
using System.Text;

namespace FulfillData
{
    public class FulFilldata
    {

        public string State     {get; set;}
         public   string Gender{get; set;}
         public   double Mean  {get; set;}
         public   int N { get; set; }

        public FulFilldata()
        {
            State = string.Empty;
            Gender = String.Empty;
            Mean = 0;
            N = 0;
        }

    }
}
