using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MCoordinador : MIntegrante
    {
        public MCoordinador(int id, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel)
            : base(id, lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel) { }

        public MCoordinador(string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel)
            : base(lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice,phonenextel) { }

        public MCoordinador(int id, string lastname, string middlename, string names)
            : base(id, lastname, middlename, names, -1, null, null, null, null, null, null) { }
    }
}