using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLiteDBManger;
using Networks.Models;
using System.Configuration;
using System.Data;
using System.Text;

namespace Networks.Controllers
{
    public class CDistritos
    {
        public CDistritos(){ }

        public List<MDistrito> GetDistricts()
        {
            List<MDistrito> Result = new List<MDistrito>();            

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DataTable DistrictsTable = DB.GetTable("Distrito", new object[] { "ID", "Nombre" });

                foreach (DataRow Row in DistrictsTable.Rows)
                    Result.Add(new MDistrito(Int32.Parse(Row["ID"].ToString()), Row["Nombre"].ToString()));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MSeccion> GetSections()
        {
            List<MSeccion> Result = new List<MSeccion>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DataTable DistrictsTable = DB.GetTable("V_Seccion_Distrito", new object[] { "Distrito", "ID", "Nombre" });

                foreach (DataRow Row in DistrictsTable.Rows)
                {
                    MSeccion S = new MSeccion(Row["Distrito"].ToString(), Int32.Parse(Row["ID"].ToString()), Row["Nombre"].ToString());
                    Result.Add(S);
                }

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }        

        public bool SaveDistrict(MDistrito district)
        {
            bool Saved = false;
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder WhereStatement = new StringBuilder();
                WhereStatement.AppendFormat("Nombre like {0}", Extensions.SParam(district.Nombre));
                object ID =  DB.GetValue("Distrito", "ID", WhereStatement.ToString());

                if (ID == null)
                {
                    DB.Insert("Distrito", new object[] { "ID", "null"
                                                        ,"Nombre", Extensions.SParam(district.Nombre)});

                    Saved = true;
                }
            }catch(Exception E)
            {
                throw E;                
            }

            return Saved;
        }

        public bool SaveSection(MSeccion section)
        {
            bool Saved = false;
            try
            {                
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder WhereStatement = new StringBuilder();
                WhereStatement.AppendFormat("DistritoId = {0} and Nombre like {1}", section.District.Id, Extensions.SParam(section.Nombre));
                object ID =  DB.GetValue("Seccion", "ID", WhereStatement.ToString());

                if (ID == null)
                {
                    DB.Insert("Seccion", new object[] { "ID", "null"
                                                      , "Nombre", Extensions.SParam(section.Nombre)
                                                      , "DistritoId" , section.District.Id });
                    Saved = true;
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Saved;
        }
    }
}