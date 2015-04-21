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

        public MTerritorial(int id, string lastname, string middlename, string names, int sectionid, int coorid) 
            : base(id, lastname, middlename, names, sectionid) 
        {
            this._coorid = coorid;
        }

        public MTerritorial(string lastname, string middlename, string names, int sectionid, int coorid)
            :base(lastname, middlename, names, sectionid)
        {
            this._coorid = coorid;
        }
    }
}