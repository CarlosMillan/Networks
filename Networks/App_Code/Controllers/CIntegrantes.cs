using Networks.Models;
using SQLiteDBManger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
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
                DataTable Table = DB.GetTable("Coordinador", new object[] { "ID", 
                                                                                     "ApellidoPaterno", 
                                                                                     "ApellidoMaterno", 
                                                                                     "Nombres",
                                                                                     "SeccionId"
                                                                                    });

                foreach (DataRow Row in Table.Rows)
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
                DataTable Table = DB.GetTable("Territorial", new object[] { IntegrantsColumns.Id, 
                                                                                     IntegrantsColumns.Paterno, 
                                                                                     IntegrantsColumns.Materno, 
                                                                                     IntegrantsColumns.Nombres,
                                                                                     IntegrantsColumns.Seccion,
                                                                                     IntegrantsColumns.Coordinador
                                                                                    });

                foreach (DataRow Row in Table.Rows)
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
                DataTable Table = DB.GetTable("Lider", new object[] { "ID", 
                                                                                     "ApellidoPaterno", 
                                                                                     "ApellidoMaterno", 
                                                                                     "Nombres",
                                                                                     "SeccionId",
                                                                                     "TerritorialId"
                                                                                    });

                foreach (DataRow Row in Table.Rows)
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
                DataTable Table = DB.GetTable("Promovido", new object[] { "ID", 
                                                                                "ApellidoPaterno", 
                                                                                "ApellidoMaterno", 
                                                                                "Nombres",
                                                                                "SeccionId",
                                                                                "LiderId"
                                                                            });

                foreach (DataRow Row in Table.Rows)
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
        public bool SaveCoordinador(MCoordinador coor)
        {
            bool Saved = false;
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder WhereStatement = new StringBuilder();
                WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                            , Extensions.SParam(coor.Paterno)
                                            , Extensions.SParam(coor.Materno)
                                            , Extensions.SParam(coor.Nombres));
                object ID =  DB.GetValue("Coordinador", "ID", WhereStatement.ToString());

                if (ID == null)
                {
                    DB.Insert(_type.ToString(), new object[] { "ID", "null"
                                                              , IntegrantsColumns.Paterno, Extensions.SParam(coor.Paterno)
                                                              , IntegrantsColumns.Materno, Extensions.SParam(coor.Materno)
                                                              , IntegrantsColumns.Nombres, Extensions.SParam(coor.Nombres)
                                                              , IntegrantsColumns.Seccion, coor.Seccion                                                             
                                                              });
                    Saved = true;
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Saved;
        }

        public bool SaveTerritorial(MTerritorial terr)
        {
            bool Saved = false;
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder WhereStatement = new StringBuilder();
                WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                            , Extensions.SParam(terr.Paterno)
                                            , Extensions.SParam(terr.Materno)
                                            , Extensions.SParam(terr.Nombres));
                object ID = DB.GetValue("Territorial", "ID", WhereStatement.ToString());

                if (ID == null)
                {
                    DB.Insert("Territorial", new object[] { "ID", "null"
                                                          ,  IntegrantsColumns.Coordinador, terr.CoordinadorId
                                                           , IntegrantsColumns.Paterno, Extensions.SParam(terr.Paterno)
                                                           , IntegrantsColumns.Materno, Extensions.SParam(terr.Materno)
                                                           , IntegrantsColumns.Nombres, Extensions.SParam(terr.Nombres)
                                                           , IntegrantsColumns.Seccion, terr.Seccion
                                                          });
                    Saved = true;
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Saved;
        }

        public bool SaveLider(MLider lid)
        {
            bool Saved = false; 
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder WhereStatement = new StringBuilder();
                WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                            , Extensions.SParam(lid.Paterno)
                                            , Extensions.SParam(lid.Materno)
                                            , Extensions.SParam(lid.Nombres));
                object ID = DB.GetValue("Lider", "ID", WhereStatement.ToString());

                if (ID == null)
                {
                    DB.Insert("Lider", new object[] { "ID" ,"null"
                                                     , IntegrantsColumns.Territorial, lid.Territorial
                                                     , IntegrantsColumns.Paterno, Extensions.SParam(lid.Paterno)
                                                     , IntegrantsColumns.Materno, Extensions.SParam(lid.Materno)
                                                     , IntegrantsColumns.Nombres, Extensions.SParam(lid.Nombres)
                                                     , IntegrantsColumns.Seccion, lid.Seccion
                                                     });
                    Saved = true;
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Saved;
        }

        public bool SavePromovido(MPromovido prom)
        {
            bool Saved = false;
            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder WhereStatement = new StringBuilder();
                WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                            , Extensions.SParam(prom.Paterno)
                                            , Extensions.SParam(prom.Materno)
                                            , Extensions.SParam(prom.Nombres));
                object ID = DB.GetValue("Promovido", "ID", WhereStatement.ToString());

                if (ID == null)
                {
                    DB.Insert("Promovido", new object[] { "ID", "null"
                                                          ,IntegrantsColumns.Lider,  prom.LiderId
                                                          ,IntegrantsColumns.Paterno, Extensions.SParam(prom.Paterno)
                                                          ,IntegrantsColumns.Materno, Extensions.SParam(prom.Materno)
                                                          ,IntegrantsColumns.Nombres, Extensions.SParam(prom.Nombres)
                                                          ,IntegrantsColumns.Seccion, prom.Seccion
                                                          });

                    Saved = true;
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Saved;
        }
        #endregion

        #region Search
        public List<MTerritorial> SearchTerritorial(params object[] criterios)
        {
            List<MTerritorial> Result = new List<MTerritorial>();

            try
            {
                if (criterios.Length > 0 && (criterios.Length % 2) == 0)
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatment = new StringBuilder();
                    WhereStatment.Append("WHERE ");

                    for (int Index = 0; Index < criterios.Length; Index++)
                    {
                        WhereStatment.AppendFormat(@"{0} {1} {2} AND "
                                                    , criterios[Index]
                                                    , criterios[Index + 1].ToString().Contains("'") ? "like '%' || " : "="
                                                    , criterios[Index + 1].ToString().Contains("'") ? criterios[++Index] + " || '%'" : criterios[++Index]);
                    }

                    WhereStatment = WhereStatment.Remove(WhereStatment.Length - 4, 4);
                    DataTable Table = DB.GetTable("Territorial", WhereStatment.ToString(), "*");

                    foreach (DataRow Row in Table.Rows)
                        Result.Add(new MTerritorial(Int32.Parse(Row["ID"].ToString())
                                                    , Row["ApellidoPaterno"].ToString()
                                                    , Row["ApellidoMaterno"].ToString()
                                                    , Row["Nombres"].ToString()
                                                    , Int32.Parse(Row["SeccionId"].ToString())
                                                    , Int32.Parse(Row["CoordinadorId"].ToString())
                                                    ));
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }
        #endregion
    }

    public static class IntegrantsColumns
    {
        public static string Id = "ID";
        public static string Paterno = "ApellidoPaterno";
        public static string Materno = "ApellidoMaterno";
        public static string Nombres = "Nombres";
        public static string Seccion = "SeccionId";
        public static string Lider = "LiderId";
        public static string Territorial = "TerritorialId";
        public static string Coordinador = "CoordinadorID";
    }
}