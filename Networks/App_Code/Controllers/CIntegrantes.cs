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
        public enum TypeIntegrante {Coordinador, Territorial, Lider, Promovido, L50, L2_50, L12}
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
                StringBuilder OrderByStatment = new StringBuilder();
                StringBuilder Columns = new StringBuilder();
                Columns.AppendFormat("{0}, {1}, {2}", IntegrantsColumns.Paterno, IntegrantsColumns.Materno, IntegrantsColumns.Nombres);

                OrderByStatment.AppendFormat(@"ORDER BY {0}", Columns.ToString());
                DataTable Table = DB.GetTable("Coordinador", OrderByStatment.ToString(), new object[] { IntegrantsColumns.Id + "," + Columns.ToString() });

                foreach (DataRow Row in Table.Rows)
                    Result.Add(new MCoordinador(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                , Row[IntegrantsColumns.Paterno].ToString()
                                                , Row[IntegrantsColumns.Materno].ToString()
                                                , Row[IntegrantsColumns.Nombres].ToString()                                               
                                                ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MCoordinador> GetCoordindoresTable()
        {
            List<MCoordinador> Result = new List<MCoordinador>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder OrderByStatment = new StringBuilder();
                OrderByStatment.AppendFormat(@"ORDER BY {0} DESC LIMIT {1}", IntegrantsColumns.Id, ConfigurationManager.AppSettings["MaxElementsPerPage"]);
                DataTable Table = DB.GetTable("Coordinador", OrderByStatment.ToString(), new object[] { "*" });

                foreach (DataRow Row in Table.Rows)
                    Result.Add(new MCoordinador(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                , Row[IntegrantsColumns.Paterno].ToString()
                                                , Row[IntegrantsColumns.Materno].ToString()
                                                , Row[IntegrantsColumns.Nombres].ToString()
                                                , Int32.Parse(Row[IntegrantsColumns.Seccion].ToString())
                                                , Row[IntegrantsColumns.Calle].ToString()
                                                , Row[IntegrantsColumns.Colonia].ToString()
                                                , Row[IntegrantsColumns.Email].ToString()
                                                , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                , Row[IntegrantsColumns.TelefonoNextel].ToString()
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
                StringBuilder OrderByStatment = new StringBuilder();
                StringBuilder Columns = new StringBuilder();
                Columns.AppendFormat("{0}, {1}, {2}", IntegrantsColumns.Paterno, IntegrantsColumns.Materno, IntegrantsColumns.Nombres);

                OrderByStatment.AppendFormat(@"ORDER BY {0}", Columns.ToString());
                DataTable Table = DB.GetTable("Territorial", OrderByStatment.ToString(), new object[] { IntegrantsColumns.Id + "," + Columns.ToString() });

                foreach (DataRow Row in Table.Rows)
                    Result.Add(new MTerritorial(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                , Row[IntegrantsColumns.Paterno].ToString()
                                                , Row[IntegrantsColumns.Materno].ToString()
                                                , Row[IntegrantsColumns.Nombres].ToString()
                                                ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MTerritorial> GetTerrotorialesTable()
        {
            List<MTerritorial> Result = new List<MTerritorial>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder OrderByStatment = new StringBuilder();
                OrderByStatment.AppendFormat(@"ORDER BY {0} DESC LIMIT {1}", IntegrantsColumns.Id, ConfigurationManager.AppSettings["MaxElementsPerPage"]);
                DataTable Table = DB.GetTable("Territorial", OrderByStatment.ToString(), new object[] { "*" });

                foreach (DataRow Row in Table.Rows)
                    Result.Add(new MTerritorial(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                , Int32.Parse(Row[IntegrantsColumns.Coordinador].ToString())
                                                , Row[IntegrantsColumns.Paterno].ToString()
                                                , Row[IntegrantsColumns.Materno].ToString()
                                                , Row[IntegrantsColumns.Nombres].ToString()
                                                , Int32.Parse(Row[IntegrantsColumns.Seccion].ToString())
                                                , Row[IntegrantsColumns.Calle].ToString()
                                                , Row[IntegrantsColumns.Colonia].ToString()
                                                , Row[IntegrantsColumns.Email].ToString()
                                                , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                , Row[IntegrantsColumns.TelefonoNextel].ToString()
                                                , Row[IntegrantsColumns.ClaveElector].ToString()
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
                StringBuilder OrderByStatment = new StringBuilder();
                StringBuilder Columns = new StringBuilder();
                Columns.AppendFormat("{0}, {1}, {2}", IntegrantsColumns.Paterno, IntegrantsColumns.Materno, IntegrantsColumns.Nombres);

                OrderByStatment.AppendFormat(@"ORDER BY {0}", Columns.ToString());
                DataTable Table = DB.GetTable("Lider", OrderByStatment.ToString(), new object[] { IntegrantsColumns.Id + "," + Columns.ToString() });

                foreach (DataRow Row in Table.Rows)
                    Result.Add(new MLider(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                        , Row[IntegrantsColumns.Paterno].ToString()
                                        , Row[IntegrantsColumns.Materno].ToString()
                                        , Row[IntegrantsColumns.Nombres].ToString()                                        
                                        ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MLider> GetLideresTable()
        {
            List<MLider> Result = new List<MLider>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder OrderByStatment = new StringBuilder();
                OrderByStatment.AppendFormat(@"ORDER BY {0} DESC LIMIT {1}", IntegrantsColumns.Id, ConfigurationManager.AppSettings["MaxElementsPerPage"]);
                DataTable Table = DB.GetTable("Lider", OrderByStatment.ToString(), new object[] { "*" });

                foreach (DataRow Row in Table.Rows)
                    Result.Add(new MLider(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                , Int32.Parse(Row[IntegrantsColumns.Territorial].ToString())
                                                , Row[IntegrantsColumns.Paterno].ToString()
                                                , Row[IntegrantsColumns.Materno].ToString()
                                                , Row[IntegrantsColumns.Nombres].ToString()
                                                , Int32.Parse(Row[IntegrantsColumns.Seccion].ToString())
                                                , Row[IntegrantsColumns.Calle].ToString()
                                                , Row[IntegrantsColumns.Colonia].ToString()
                                                , Row[IntegrantsColumns.Email].ToString()
                                                , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                , Row[IntegrantsColumns.TelefonoNextel].ToString()
                                                , Row[IntegrantsColumns.ClaveElector].ToString()
                                                ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MPromovido> GetPromovidosTable()
        {
            List<MPromovido> Result = new List<MPromovido>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder OrderByStatment = new StringBuilder();
                OrderByStatment.AppendFormat(@"ORDER BY {0} DESC LIMIT {1}", IntegrantsColumns.Id, ConfigurationManager.AppSettings["MaxElementsPerPage"]);
                DataTable Table = DB.GetTable("Promovido", OrderByStatment.ToString(), new object[] { "*" });

                foreach (DataRow Row in Table.Rows)
                    Result.Add(new MPromovido(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                , Int32.Parse(Row[IntegrantsColumns.Lider].ToString())
                                                , Row[IntegrantsColumns.Paterno].ToString()
                                                , Row[IntegrantsColumns.Materno].ToString()
                                                , Row[IntegrantsColumns.Nombres].ToString()
                                                , Int32.Parse(Row[IntegrantsColumns.Seccion].ToString())
                                                , Row[IntegrantsColumns.Calle].ToString()
                                                , Row[IntegrantsColumns.Colonia].ToString()
                                                , Row[IntegrantsColumns.Email].ToString()
                                                , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                , Row[IntegrantsColumns.TelefonoNextel].ToString()
                                                , Row[IntegrantsColumns.ClaveElector].ToString()
                                                , Row[IntegrantsColumns.Parentesco].ToString()
                                                ));

            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MIntegrante> Get50()
        {
            return GetIntegrant("Los50");
        }

        public List<MIntegrante> Get50_2()
        {
            return GetIntegrant("Los50_2");
        }

        public List<MIntegrante> Get12()
        {
            return GetIntegrant("Los12");
        }

        private List<MIntegrante> GetIntegrant(string tablename)
        {
            List<MIntegrante> Result = new List<MIntegrante>();

            try
            {
                DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                StringBuilder OrderByStatment = new StringBuilder();
                OrderByStatment.AppendFormat(@"ORDER BY {0}, {1}, {2}", IntegrantsColumns.Paterno, IntegrantsColumns.Materno, IntegrantsColumns.Nombres);
                DataTable Table = DB.GetTable(tablename, OrderByStatment.ToString(), new object[] { "*" });

                foreach (DataRow Row in Table.Rows)
                    Result.Add(new MIntegrante(Int32.Parse(Row[IntegrantsColumns.Id].ToString())                                                
                                                , Row[IntegrantsColumns.Paterno].ToString()
                                                , Row[IntegrantsColumns.Materno].ToString()
                                                , Row[IntegrantsColumns.Nombres].ToString()                                                
                                                , Row[IntegrantsColumns.Calle].ToString()
                                                , Row[IntegrantsColumns.Colonia].ToString()
                                                , Row[IntegrantsColumns.Email].ToString()
                                                , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                , Row[IntegrantsColumns.TelefonoNextel].ToString()
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
                if (!String.IsNullOrEmpty(coor.Paterno) && !String.IsNullOrEmpty(coor.Materno) && !String.IsNullOrEmpty(coor.Nombres))
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatement = new StringBuilder();
                    WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                                , Extensions.SParam(coor.Paterno)
                                                , Extensions.SParam(coor.Materno)
                                                , Extensions.SParam(coor.Nombres));
                    object ID = DB.GetValue("Coordinador", IntegrantsColumns.Id, WhereStatement.ToString());

                    if (ID == null)
                    {
                        DB.Insert("Coordinador", new object[] { IntegrantsColumns.Id, "null"
                                                              , IntegrantsColumns.Paterno, Extensions.SParam(coor.Paterno)
                                                              , IntegrantsColumns.Materno, Extensions.SParam(coor.Materno)
                                                              , IntegrantsColumns.Nombres, Extensions.SParam(coor.Nombres)
                                                              , IntegrantsColumns.Seccion, coor.Seccion
                                                              , IntegrantsColumns.Calle, Extensions.SParam(coor.Calle)
                                                              , IntegrantsColumns.Colonia, Extensions.SParam(coor.Colonia)
                                                              , IntegrantsColumns.Email, Extensions.SParam(coor.Email)
                                                              , IntegrantsColumns.TelefonoDomicilio, Extensions.SParam(coor.Domicilio)
                                                              , IntegrantsColumns.TelefonoOficina, Extensions.SParam(coor.Oficina)
                                                              , IntegrantsColumns.TelefonoNextel, Extensions.SParam(coor.Nextel)
                                                              });
                        Saved = true;
                    }
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
                if (!String.IsNullOrEmpty(terr.Paterno) && !String.IsNullOrEmpty(terr.Materno) && !String.IsNullOrEmpty(terr.Nombres))
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatement = new StringBuilder();
                    WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                                , Extensions.SParam(terr.Paterno)
                                                , Extensions.SParam(terr.Materno)
                                                , Extensions.SParam(terr.Nombres));
                    object ID = DB.GetValue("Territorial", IntegrantsColumns.Id, WhereStatement.ToString());

                    if (ID == null)
                    {
                        DB.Insert("Territorial", new object[] { IntegrantsColumns.Id, "null"
                                                            , IntegrantsColumns.Coordinador, terr.CoordinadorId
                                                            , IntegrantsColumns.Paterno, Extensions.SParam(terr.Paterno)
                                                            , IntegrantsColumns.Materno, Extensions.SParam(terr.Materno)
                                                            , IntegrantsColumns.Nombres, Extensions.SParam(terr.Nombres)
                                                            , IntegrantsColumns.Seccion, terr.Seccion
                                                            , IntegrantsColumns.Calle, Extensions.SParam(terr.Calle)
                                                            , IntegrantsColumns.Colonia, Extensions.SParam(terr.Colonia)
                                                            , IntegrantsColumns.Email, Extensions.SParam(terr.Email)
                                                            , IntegrantsColumns.TelefonoDomicilio, Extensions.SParam(terr.Domicilio)
                                                            , IntegrantsColumns.TelefonoOficina, Extensions.SParam(terr.Oficina)
                                                            , IntegrantsColumns.TelefonoNextel, Extensions.SParam(terr.Nextel)
                                                            , IntegrantsColumns.ClaveElector, Extensions.SParam(terr.Elector)
                                                          });
                        Saved = true;
                    }
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
                if (!String.IsNullOrEmpty(lid.Paterno) && !String.IsNullOrEmpty(lid.Materno) && !String.IsNullOrEmpty(lid.Nombres))
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatement = new StringBuilder();
                    WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                                , Extensions.SParam(lid.Paterno)
                                                , Extensions.SParam(lid.Materno)
                                                , Extensions.SParam(lid.Nombres));
                    object ID = DB.GetValue("Lider", IntegrantsColumns.Id, WhereStatement.ToString());

                    if (ID == null)
                    {
                        DB.Insert("Lider", new object[] { IntegrantsColumns.Id ,"null"
                                                    , IntegrantsColumns.Territorial, lid.Territorial
                                                    , IntegrantsColumns.Paterno, Extensions.SParam(lid.Paterno)
                                                    , IntegrantsColumns.Materno, Extensions.SParam(lid.Materno)
                                                    , IntegrantsColumns.Nombres, Extensions.SParam(lid.Nombres)
                                                    , IntegrantsColumns.Seccion, lid.Seccion
                                                    , IntegrantsColumns.Calle, Extensions.SParam(lid.Calle)
                                                    , IntegrantsColumns.Colonia, Extensions.SParam(lid.Colonia)
                                                    , IntegrantsColumns.Email, Extensions.SParam(lid.Email)
                                                    , IntegrantsColumns.TelefonoDomicilio, Extensions.SParam(lid.Domicilio)
                                                    , IntegrantsColumns.TelefonoOficina, Extensions.SParam(lid.Oficina)
                                                    , IntegrantsColumns.TelefonoNextel, Extensions.SParam(lid.Nextel)
                                                    , IntegrantsColumns.ClaveElector, Extensions.SParam(lid.Elector)
                                                     });
                        Saved = true;
                    }
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
                if (!String.IsNullOrEmpty(prom.Paterno) && !String.IsNullOrEmpty(prom.Materno) && !String.IsNullOrEmpty(prom.Nombres))
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatement = new StringBuilder();
                    WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                                , Extensions.SParam(prom.Paterno)
                                                , Extensions.SParam(prom.Materno)
                                                , Extensions.SParam(prom.Nombres));
                    object ID = DB.GetValue("Promovido", IntegrantsColumns.Id, WhereStatement.ToString());

                    if (ID == null)
                    {
                        DB.Insert("Promovido", new object[] { IntegrantsColumns.Id, "null"
                                                        , IntegrantsColumns.Lider, prom.LiderId
                                                        , IntegrantsColumns.Paterno, Extensions.SParam(prom.Paterno)
                                                        , IntegrantsColumns.Materno, Extensions.SParam(prom.Materno)
                                                        , IntegrantsColumns.Nombres, Extensions.SParam(prom.Nombres)
                                                        , IntegrantsColumns.Seccion, prom.Seccion
                                                        , IntegrantsColumns.Calle, Extensions.SParam(prom.Calle)
                                                        , IntegrantsColumns.Colonia, Extensions.SParam(prom.Colonia)
                                                        , IntegrantsColumns.Email, Extensions.SParam(prom.Email)
                                                        , IntegrantsColumns.TelefonoDomicilio, Extensions.SParam(prom.Domicilio)
                                                        , IntegrantsColumns.TelefonoOficina, Extensions.SParam(prom.Oficina)
                                                        , IntegrantsColumns.TelefonoNextel, Extensions.SParam(prom.Nextel)
                                                        , IntegrantsColumns.ClaveElector, Extensions.SParam(prom.Elector)
                                                        , IntegrantsColumns.Parentesco, Extensions.SParam(prom.Parentesco)
                                                          });

                        Saved = true;
                    }
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Saved;
        }

        public bool Save50(MIntegrante inte)
        {
            return SaveIntegrant("Los50", inte);
        }

        public bool Save50_2(MIntegrante inte)
        {
            return SaveIntegrant("Los50_2", inte);
        }

        public bool Save12(MIntegrante inte)
        {
            return SaveIntegrant("Los12", inte);
        }
        
        private bool SaveIntegrant(string tablename, MIntegrante inte)
        {
            bool Saved = false;
            try
            {
                if (!String.IsNullOrEmpty(inte.Paterno) && !String.IsNullOrEmpty(inte.Materno) && !String.IsNullOrEmpty(inte.Nombres))
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatement = new StringBuilder();
                    WhereStatement.AppendFormat(@"ApellidoPaterno like {0}
                                              and ApellidoMaterno like {1}
                                              and Nombres like {2}"
                                                , Extensions.SParam(inte.Paterno)
                                                , Extensions.SParam(inte.Materno)
                                                , Extensions.SParam(inte.Nombres));
                    object ID = DB.GetValue(tablename, IntegrantsColumns.Id, WhereStatement.ToString());

                    if (ID == null)
                    {
                        DB.Insert(tablename, new object[] { IntegrantsColumns.Id, "null"
                                                              , IntegrantsColumns.Paterno, Extensions.SParam(inte.Paterno)
                                                              , IntegrantsColumns.Materno, Extensions.SParam(inte.Materno)
                                                              , IntegrantsColumns.Nombres, Extensions.SParam(inte.Nombres)                                                              
                                                              , IntegrantsColumns.Calle, Extensions.SParam(inte.Calle)
                                                              , IntegrantsColumns.Colonia, Extensions.SParam(inte.Colonia)
                                                              , IntegrantsColumns.Email, Extensions.SParam(inte.Email)
                                                              , IntegrantsColumns.TelefonoDomicilio, Extensions.SParam(inte.Domicilio)
                                                              , IntegrantsColumns.TelefonoOficina, Extensions.SParam(inte.Oficina)
                                                              , IntegrantsColumns.TelefonoNextel, Extensions.SParam(inte.Nextel)
                                                              });
                        Saved = true;
                    }
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
                    StringBuilder OrderByStatment = new StringBuilder();
                    WhereStatment.Append("WHERE ");
                    OrderByStatment.AppendFormat(@"ORDER BY {0}, {1}, {2}", IntegrantsColumns.Paterno, IntegrantsColumns.Materno, IntegrantsColumns.Nombres);

                    for (int Index = 0; Index < criterios.Length; Index++)
                    {
                        WhereStatment.AppendFormat(@"{0} {1} {2} AND "
                                                    , criterios[Index]
                                                    , criterios[Index + 1].ToString().Contains("'") ? "like '%' || " : "="
                                                    , criterios[Index + 1].ToString().Contains("'") ? criterios[++Index] + " || '%'" : criterios[++Index]);
                    }

                    WhereStatment = WhereStatment.Remove(WhereStatment.Length - 4, 4);
                    DataTable Table = DB.GetTable("Territorial", WhereStatment.ToString(), OrderByStatment.ToString(), new object[] { "*" });

                    foreach (DataRow Row in Table.Rows)
                        Result.Add(new MTerritorial(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                    , Int32.Parse(Row[IntegrantsColumns.Coordinador].ToString())
                                                    , Row[IntegrantsColumns.Paterno].ToString()
                                                    , Row[IntegrantsColumns.Materno].ToString()
                                                    , Row[IntegrantsColumns.Nombres].ToString()
                                                    , Int32.Parse(Row[IntegrantsColumns.Seccion].ToString())
                                                    , Row[IntegrantsColumns.Calle].ToString()
                                                    , Row[IntegrantsColumns.Colonia].ToString()
                                                    , Row[IntegrantsColumns.Email].ToString()
                                                    , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                    , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                    , Row[IntegrantsColumns.TelefonoNextel].ToString()
                                                    , Row[IntegrantsColumns.ClaveElector].ToString()
                                                    ));
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MLider> SearchLider(params object[] criterios)
        {
            List<MLider> Result = new List<MLider>();

            try
            {
                if (criterios.Length > 0 && (criterios.Length % 2) == 0)
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatment = new StringBuilder();
                    StringBuilder OrderByStatment = new StringBuilder();
                    WhereStatment.Append("WHERE ");
                    OrderByStatment.AppendFormat(@"ORDER BY {0}, {1}, {2}", IntegrantsColumns.Paterno, IntegrantsColumns.Materno, IntegrantsColumns.Nombres);

                    for (int Index = 0; Index < criterios.Length; Index++)
                    {
                        WhereStatment.AppendFormat(@"{0} {1} {2} AND "
                                                    , criterios[Index]
                                                    , criterios[Index + 1].ToString().Contains("'") ? "like '%' || " : "="
                                                    , criterios[Index + 1].ToString().Contains("'") ? criterios[++Index] + " || '%'" : criterios[++Index]);
                    }

                    WhereStatment = WhereStatment.Remove(WhereStatment.Length - 4, 4);
                    DataTable Table = DB.GetTable("Lider", WhereStatment.ToString(), OrderByStatment.ToString(), new object[] { "*" });

                    foreach (DataRow Row in Table.Rows)
                        Result.Add(new MLider(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                    , Int32.Parse(Row[IntegrantsColumns.Territorial].ToString())
                                                    , Row[IntegrantsColumns.Paterno].ToString()
                                                    , Row[IntegrantsColumns.Materno].ToString()
                                                    , Row[IntegrantsColumns.Nombres].ToString()
                                                    , Int32.Parse(Row[IntegrantsColumns.Seccion].ToString())
                                                    , Row[IntegrantsColumns.Calle].ToString()
                                                    , Row[IntegrantsColumns.Colonia].ToString()
                                                    , Row[IntegrantsColumns.Email].ToString()
                                                    , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                    , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                    , Row[IntegrantsColumns.TelefonoNextel].ToString()
                                                    , Row[IntegrantsColumns.ClaveElector].ToString()
                                                    ));
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MPromovido> SearchPromovido(params object[] criterios)
        {
            List<MPromovido> Result = new List<MPromovido>();

            try
            {
                if (criterios.Length > 0 && (criterios.Length % 2) == 0)
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatment = new StringBuilder();
                    StringBuilder OrderByStatment = new StringBuilder();
                    WhereStatment.Append("WHERE ");
                    OrderByStatment.AppendFormat(@"ORDER BY {0}, {1}, {2}", IntegrantsColumns.Paterno, IntegrantsColumns.Materno, IntegrantsColumns.Nombres);

                    for (int Index = 0; Index < criterios.Length; Index++)
                    {
                        WhereStatment.AppendFormat(@"{0} {1} {2} AND "
                                                    , criterios[Index]
                                                    , criterios[Index + 1].ToString().Contains("'") ? "like '%' || " : "="
                                                    , criterios[Index + 1].ToString().Contains("'") ? criterios[++Index] + " || '%'" : criterios[++Index]);
                    }

                    WhereStatment = WhereStatment.Remove(WhereStatment.Length - 4, 4);
                    DataTable Table = DB.GetTable("Promovido", WhereStatment.ToString(), OrderByStatment.ToString(), new object[] { "*" });

                    foreach (DataRow Row in Table.Rows)
                        Result.Add(new MPromovido(Int32.Parse(Row[IntegrantsColumns.Id].ToString())
                                                    , Int32.Parse(Row[IntegrantsColumns.Lider].ToString())
                                                    , Row[IntegrantsColumns.Paterno].ToString()
                                                    , Row[IntegrantsColumns.Materno].ToString()
                                                    , Row[IntegrantsColumns.Nombres].ToString()
                                                    , Int32.Parse(Row[IntegrantsColumns.Seccion].ToString())
                                                    , Row[IntegrantsColumns.Calle].ToString()
                                                    , Row[IntegrantsColumns.Colonia].ToString()
                                                    , Row[IntegrantsColumns.Email].ToString()
                                                    , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                    , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                    , Row[IntegrantsColumns.TelefonoNextel].ToString()
                                                    , Row[IntegrantsColumns.ClaveElector].ToString()
                                                    , Row[IntegrantsColumns.Parentesco].ToString()
                                                    ));
                }
            }
            catch (Exception E)
            {
                throw E;
            }

            return Result;
        }

        public List<MIntegrante> Search50(params object[] criterios)
        {
            return SearchIntegrant("Los50", criterios);
        }

        public List<MIntegrante> Search50_2(params object[] criterios)
        {
            return SearchIntegrant("Los50_2", criterios);
        }
        
        private List<MIntegrante> SearchIntegrant(string tablename, params object[] criterios)
        {
            List<MIntegrante> Result = new List<MIntegrante>();

            try
            {
                if (criterios.Length > 0 && (criterios.Length % 2) == 0)
                {
                    DBManager DB = new DBManager(ConfigurationManager.AppSettings["SQLiteDB"]);
                    StringBuilder WhereStatment = new StringBuilder();
                    StringBuilder OrderByStatment = new StringBuilder();
                    WhereStatment.Append("WHERE ");
                    OrderByStatment.AppendFormat(@"ORDER BY {0}, {1}, {2}", IntegrantsColumns.Paterno, IntegrantsColumns.Materno, IntegrantsColumns.Nombres);

                    for (int Index = 0; Index < criterios.Length; Index++)
                    {
                        WhereStatment.AppendFormat(@"{0} {1} {2} AND "
                                                    , criterios[Index]
                                                    , criterios[Index + 1].ToString().Contains("'") ? "like '%' || " : "="
                                                    , criterios[Index + 1].ToString().Contains("'") ? criterios[++Index] + " || '%'" : criterios[++Index]);
                    }

                    WhereStatment = WhereStatment.Remove(WhereStatment.Length - 4, 4);
                    DataTable Table = DB.GetTable(tablename, WhereStatment.ToString(), OrderByStatment.ToString(), new object[] {"*"});

                    foreach (DataRow Row in Table.Rows)
                        Result.Add(new MIntegrante(Int32.Parse(Row[IntegrantsColumns.Id].ToString())                                                    
                                                    , Row[IntegrantsColumns.Paterno].ToString()
                                                    , Row[IntegrantsColumns.Materno].ToString()
                                                    , Row[IntegrantsColumns.Nombres].ToString()                                                    
                                                    , Row[IntegrantsColumns.Calle].ToString()
                                                    , Row[IntegrantsColumns.Colonia].ToString()
                                                    , Row[IntegrantsColumns.Email].ToString()
                                                    , Row[IntegrantsColumns.TelefonoDomicilio].ToString()
                                                    , Row[IntegrantsColumns.TelefonoOficina].ToString()
                                                    , Row[IntegrantsColumns.TelefonoNextel].ToString()
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
        public static string Calle = "Calle";
        public static string Colonia = "Colonia";
        public static string Email = "Email";
        public static string Seccion = "SeccionId";
        public static string TelefonoDomicilio = "TelefonoDomicilio";
        public static string TelefonoOficina = "TelefonoOficina";
        public static string TelefonoNextel = "TelefonoNextel";
        public static string Lider = "LiderId";
        public static string Territorial = "TerritorialId";
        public static string Coordinador = "CoordinadorID";
        public static string ClaveElector = "ClaveElector";
        public static string Parentesco = "Relacion";
    }
}