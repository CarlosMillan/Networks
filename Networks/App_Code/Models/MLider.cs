﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MLider : MIntegrante
    {
        private int _terrid;

        public int Territorial { get { return _terrid; } }

        public MLider(int id, int terrid, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel, string elector)
            : base(id, lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel, elector)
        {
            this._terrid = terrid;
        }

        public MLider(int terrid, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel, string elector)
            : base(lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel, elector)
        {
            this._terrid = terrid;
        }

        public MLider(int id, string lastname, string middlename, string names)
            : base(id, lastname, middlename, names, -1, null, null, null, null, null, null, null) { }
    }
}