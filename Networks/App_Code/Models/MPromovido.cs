using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MPromovido: MIntegrante
    {
        private int _liderid;
        private string _relation;

        public int LiderId { get { return _liderid; } }
        public string Parentesco { get { return _relation; } }

        public MPromovido(int id, int liderid, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel, string elector, string parentesco)
            : base(id, lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel, elector)
        {
            this._liderid = liderid;
            this._relation = parentesco;
        }

        public MPromovido(int liderid, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel, string elector, string parentesco)
            : base(lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel, elector)
        {
            this._liderid = liderid;
            this._relation = parentesco;
        }
    }
}