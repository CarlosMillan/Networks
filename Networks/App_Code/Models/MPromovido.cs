using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MPromovido: MIntegrante
    {
        private int _liderid;

        public int LiderId { get { return _liderid; } }

        public MPromovido(int id, int liderid, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel)
            : base(id, lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel)
        {
            this._liderid = liderid;
        }

        public MPromovido(int liderid, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel)
            : base(lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice,phonenextel)
        {
            this._liderid = liderid;
        }
    }
}