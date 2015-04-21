using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MIntegrante
    {
        private int _id;
        private string _lastname;
        private string _middlename;
        private string _names;
        private int _sectionid;

        public int ID { get { return _id; } }
        public string Paterno { get { return _lastname; } }
        public string Materno { get { return _middlename; } }
        public string Nombres { get { return _names; } }
        public int Seccion { get { return _sectionid; } }

        public MIntegrante(string lastname, string middlename, string names, int sectionid)
            : this(-1, lastname, middlename, names, sectionid) { }
        
        public MIntegrante(int id, string lastname, string middlename, string names, int sectionid) 
        {
            this._id = id;
            this._lastname = lastname;
            this._middlename = middlename;
            this._names = names;
            this._sectionid = sectionid;
        }        
    }
}