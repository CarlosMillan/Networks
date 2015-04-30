using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Networks.Models
{
    public class MIntegrante
    {
        #region Fields
        private int _id;
        private string _lastname;
        private string _middlename;
        private string _names;
        private int _sectionid;
        private string _street;
        private string _colony;
        private string _email;
        private string _phonehome;
        private string _phoneoffice;
        private string _phonenextel;
        private string _elector;
        #endregion

        #region Properties
        public int ID { get { return _id; } }
        public string Paterno { get { return _lastname; } }
        public string Materno { get { return _middlename; } }
        public string Nombres { get { return _names; } }
        public int Seccion { get { return _sectionid; } }
        public string Calle { get { return _street; } }
        public string Colonia { get { return _colony; } }
        public string Email { get { return _email; } }
        public string Domicilio { get { return _phonehome; } }
        public string Oficina { get { return _phoneoffice; } }
        public string Nextel { get { return _phonenextel; } }
        public string Elector { get { return _elector; } }
        [Browsable(false)]
        public string NombreCompleto { get { return string.Concat(this._lastname, " ", _middlename, " ", _names); } }
        #endregion

        #region 50 y 12's
        public MIntegrante(int id, string lastname, string middlename, string names, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel)
            : this(id, lastname, middlename, names, -1, street, colony, email, phonehome, phoneoffice, phonenextel, null) { }

        public MIntegrante(string lastname, string middlename, string names, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel) 
            :this(lastname, middlename, names, -1, street, colony, email, phonehome, phoneoffice, phonenextel, null){}
        #endregion


        #region lider
        public MIntegrante(string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel)
            : this(-1, lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel, null) { }

        public MIntegrante(int id, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel)
            : this(id, lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel, null) { }
        #endregion

        public MIntegrante(string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel, string elector)
            : this(-1, lastname, middlename, names, sectionid, street, colony, email, phonehome, phoneoffice, phonenextel, elector) { }
        
        public MIntegrante(int id, string lastname, string middlename, string names, int sectionid, string street, string colony, string email, string phonehome, string phoneoffice, string phonenextel, string elector) 
        {
            this._id = id;
            this._lastname = lastname;
            this._middlename = middlename;
            this._names = names;
            this._sectionid = sectionid;
            this._street = street;
            this._colony = colony;
            this._email = email;
            this._phonehome = phonehome;
            this._phoneoffice = phonehome;
            this._phonenextel = phonenextel;
            this._elector = elector;
        }        
    }
}