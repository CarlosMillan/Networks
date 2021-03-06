﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    [Serializable]
    public class MDistrito
    {
        private string _name;
        private int _id;

        public int Id { get { return _id; } }
        public string Nombre { get { return _name; } }       

        public MDistrito(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public MDistrito(string name) 
            :this(-1, name){}
    }
}