using Networks.Models;
using SQLiteDBManger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Networks.Controllers
{
    public class CIntegrantes
    {
        public enum TypeIntegrante {Coordinador, Territorial, Lider, Promovido}
        private TypeIntegrante _type;

        public CIntegrantes(TypeIntegrante t) 
        {
            _type = t;
        }

        #region Get
        public List<MCoordinador> GetCoordindores()
        {
            List<MCoordinador> Result = new List<MCoordinador>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DataTable DistrictsTable = DB.GetTable("Coordinador", new object[] { "ID", 
                                                                                     "ApellidoPaterno", 
                                                                                     "ApellidoMaterno", 
                                                                                     "Nombres",
                                                                                     "SeccionId"
                                                                                    });

                foreach (DataRow Row in DistrictsTable.Rows)
                    Result.Add(new MCoordinador(Int32.Parse(Row["ID"].ToString())
                                                , Row["ApellidoPaterno"].ToString()
                                                , Row["ApellidoMaterno"].ToString()
                                                , Row["Nombres"].ToString()
                                                , Int32.Parse(Row["SeccionId"].ToString())
                                                ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MTerritorial> GetTerrotoriales()
        {
            List<MTerritorial> Result = new List<MTerritorial>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DataTable DistrictsTable = DB.GetTable("Territorial", new object[] { "ID", 
                                                                                     "ApellidoPaterno", 
                                                                                     "ApellidoMaterno", 
                                                                                     "Nombres",
                                                                                     "SeccionId",
                                                                                     "CoordinadorId"
                                                                                    });

                foreach (DataRow Row in DistrictsTable.Rows)
                    Result.Add(new MTerritorial(Int32.Parse(Row["ID"].ToString())
                                                , Row["ApellidoPaterno"].ToString()
                                                , Row["ApellidoMaterno"].ToString()
                                                , Row["Nombres"].ToString()
                                                , Int32.Parse(Row["SeccionId"].ToString())
                                                , Int32.Parse(Row["CoordinadorId"].ToString())
                                                ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MLider> GetLideres()
        {
            List<MLider> Result = new List<MLider>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DataTable DistrictsTable = DB.GetTable("Lider", new object[] { "ID", 
                                                                                     "ApellidoPaterno", 
                                                                                     "ApellidoMaterno", 
                                                                                     "Nombres",
                                                                                     "SeccionId",
                                                                                     "TerritorialId"
                                                                                    });

                foreach (DataRow Row in DistrictsTable.Rows)
                    Result.Add(new MLider(Int32.Parse(Row["ID"].ToString())
                                                , Row["ApellidoPaterno"].ToString()
                                                , Row["ApellidoMaterno"].ToString()
                                                , Row["Nombres"].ToString()
                                                , Int32.Parse(Row["SeccionId"].ToString())
                                                , Int32.Parse(Row["TerritorialId"].ToString())
                                                ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MPromovido> GetPromovidos()
        {
            List<MPromovido> Result = new List<MPromovido>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DataTable DistrictsTable = DB.GetTable("Promovido", new object[] { "ID", 
                                                                                "ApellidoPaterno", 
                                                                                "ApellidoMaterno", 
                                                                                "Nombres",
                                                                                "SeccionId",
                                                                                "LiderId"
                                                                            });

                foreach (DataRow Row in DistrictsTable.Rows)
                    Result.Add(new MPromovido(Int32.Parse(Row["ID"].ToString())
                                                , Row["ApellidoPaterno"].ToString()
                                                , Row["ApellidoMaterno"].ToString()
                                                , Row["Nombres"].ToString()
                                                , Int32.Parse(Row["SeccionId"].ToString())
                                                , Int32.Parse(Row["LiderId"].ToString())
                                                ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }
        #endregion

        #region Save
        public void SaveCoordinador(MCoordinador coor)
        {
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DB.Insert(_type.ToString(), new object[] { "null"
                                                          , String.Concat("'", coor.Paterno, "'") 
                                                          , String.Concat("'", coor.Materno, "'") 
                                                          , String.Concat("'", coor.Nombres, "'")
                                                          , coor.Seccion
                                                          , 
                                                          });
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public void SaveTerritorial(MTerritorial terr)
        {
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DB.Insert("Territorial", new object[] { "null"
                                                          , terr.CoordinadorId
                                                          , String.Concat("'", terr.Paterno, "'") 
                                                          , String.Concat("'", terr.Materno, "'") 
                                                          , String.Concat("'", terr.Nombres, "'")
                                                          , terr.Seccion
                                                          });
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public void SaveLider(MLider terr)
        {
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DB.Insert("Lider", new object[] { "null"
                                                          , terr.Territorial
                                                          , String.Concat("'", terr.Paterno, "'") 
                                                          , String.Concat("'", terr.Materno, "'") 
                                                          , String.Concat("'", terr.Nombres, "'")
                                                          , terr.Seccion
                                                          });
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public void SavePromovido(MPromovido prom)
        {
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                DB.Insert("Promovido", new object[] { "null"
                                                          , prom.LiderId
                                                          , String.Concat("'", prom.Paterno, "'") 
                                                          , String.Concat("'", prom.Materno, "'") 
                                                          , String.Concat("'", prom.Nombres, "'")
                                                          , prom.Seccion
                                                          });
            }
            catch (Exception E)
            {
                throw E;
            }
        }
        #endregion
    }
}