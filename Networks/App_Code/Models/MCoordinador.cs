using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MCoordinador : MIntegrante
    {
        public MCoordinador(int id, string lastname, string middlename, string names, int sectionid) 
            : base(id, lastname, middlename, names, sectionid) { }

        public MCoordinador(string lastname, string middlename, string names, int sectionid)
            : base(lastname, middlename, names, sectionid) { }
    }
}