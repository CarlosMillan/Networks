using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    [Serializable]
    public class MSeccion
    {
        private MDistrito _district;
        private int _id;
        private string _name;        
        private string _districtname;

        public int Id { get { return _id; } }        
        public MDistrito District { get { return _district; } }
        public string Distrito { get { return _districtname; } }       
        public string Nombre { get { return _name; } }               

        public MSeccion(MDistrito district, string name)
            :this(district, -1, name){ }

        public MSeccion(MDistrito district, int id, string name) 
        {
            this._id = id;
            this._district = district;
            this._name = name;
        }

        public MSeccion(string districtname, int id, string name)
        {            
            this._districtname = districtname;
            this._id = id;            
            this._name = name;
        }
    }
}