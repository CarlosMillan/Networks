using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MLider : MIntegrante
    {
        private int _terrid;

        public int Territorial { get { return _terrid; } }

        public MLider(int id, string lastname, string middlename, string names, int sectionid, int coorid) 
            : base(id, lastname, middlename, names, sectionid) 
        {
            this._terrid = coorid;
        }

        public MLider(string lastname, string middlename, string names, int sectionid, int coorid)
            :base(lastname, middlename, names, sectionid)
        {
            this._terrid = coorid;
        }
    }
}