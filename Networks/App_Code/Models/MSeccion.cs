using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MSeccion
    {
        private MDistrito _district;
        private int _id;
        private string _name;

        public MDistrito District { get { return _district; } }
        public int Id { get { return _id; } }
        public string Name { get { return _name; } }

        public MSeccion(MDistrito district, int id, string name) 
        {
            this._id = id;
            this._district = district;
            this._name = name;
        }
    }
}