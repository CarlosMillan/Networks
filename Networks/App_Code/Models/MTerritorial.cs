using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MTerritorial: MIntegrante
    {
        private int _coorid;

        public int CoordinadorId { get { return _coorid; } }

        public MTerritorial(int id, int coorid, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel, string elector)
            : base(id, lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel, elector)
        {
            this._coorid = coorid;
        }

        public MTerritorial(int coorid, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel, string elector)
            : base(lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice,phonenextel, elector)
        {
            this._coorid = coorid;
        }

        public MTerritorial(int id, string lastname, string middlename, string names)
            : base(id, lastname, middlename, names, -1, null, null, null, null, null, null, null) { }
    }
}