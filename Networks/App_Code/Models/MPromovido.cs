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

        public MPromovido(int id, string lastname, string middlename, string names, int sectionid, int coorid) 
            : base(id, lastname, middlename, names, sectionid) 
        {
            this._liderid = coorid;
        }

        public MPromovido(string lastname, string middlename, string names, int sectionid, int coorid)
            :base(lastname, middlename, names, sectionid)
        {
            this._liderid = coorid;
        }
    }
}