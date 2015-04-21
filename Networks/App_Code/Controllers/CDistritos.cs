using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLiteDBManger;
using Networks.Models;
using System.Configuration;
using System.Data;

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
                DataTable DistrictsTable = DB.GetTable("V_Distrito_Seccion", new object[] {"Distrito", "ID", "Nombre"});

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

        public void SaveDistrict(MDistrito district)
        {
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DB.Insert("Distrito", new object[] { "null", String.Concat("'", district.Nombre, "'")});
            }catch(Exception E)
            {
                throw E;
            }
        }

        public void SaveSection(MSeccion section)
        {
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DB.Insert("Seccion", new object[] { "null", String.Concat("'", section.Nombre, "'"), section.District.Id });
            }
            catch (Exception E)
            {
                throw E;
            }
        }
    }
}