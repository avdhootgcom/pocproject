using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRVSS_PCS_BusinessService
{
    [Serializable]
    public class InspectionBO
   {
       private string fname;

       private string lname;

       public InspectionBO(string fname, string lname)
       {
           this.fname = fname;
           this.lname = lname;
       }

       public string Fname
       {
           get { return fname; }
           set { fname = value; }
       }

       public string Lname
       {
           get { return lname; }
           set { lname = value; }
       }
   }
}
