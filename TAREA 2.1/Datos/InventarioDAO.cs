using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class InventarioDAO
    {
        public Inventario getData(int ID)
        {
            Inventario inv = null;
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"SELECT FROM INVENTARIO WHERE ID = @ID";

                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    sentencia.Parameters.AddWithValue("@ID", ID);

                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);


                    //Llenar el datatable
                    da.Fill(dt);

                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        inv = new Inventario()
                        {
                            ID = Convert.ToInt32(fila["ID"]),
                            NOMBRECORTO = fila["NOMBRECORTO"].ToString(),
                            DESCRIPCION = fila["DESCRIPCION"].ToString(),
                            SERIE = fila["SERIE"].ToString(),
                            COLOR = fila["COLOR"].ToString(),
                            FECHAADQUISICION = fila["FECHAADQUISICION"].ToString(),
                            TIPOADQUISICION = fila["TIPOADQUISICION"].ToString(),
                            OBSERVACIONES = fila["OBSERVACIONES"].ToString(),
                            AREAS_ID = Convert.ToInt32(fila["AREAS_ID"]),


                        };

                    }

                    return inv;

                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return null;
            }
        }
        public List<Inventario> getAllData()
        {
            
            List<Inventario> invList = new List<Inventario>();
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"SELECT * FROM INVENTARIO";

                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);


                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);

                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow fila in dt.Rows)
                        {
                            Inventario inv = new Inventario()
                            {
                                ID = Convert.ToInt32(fila["ID"]),
                                NOMBRECORTO = fila["NOMBRECORTO"].ToString(),
                                DESCRIPCION = fila["DESCRIPCION"].ToString(),
                                SERIE = fila["SERIE"].ToString(),
                                COLOR = fila["COLOR"].ToString(),
                                FECHAADQUISICION = fila["FECHAADQUISICION"].ToString(),
                                TIPOADQUISICION = fila["TIPOADQUISICION"].ToString(),
                                OBSERVACIONES = fila["OBSERVACIONES"].ToString(),
                                AREAS_ID = Convert.ToInt32(fila["AREAS_ID"]),


                            };
                            invList.Add(inv);
                        }

                    }

                    return invList;
                    
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return null;
            }
        }
        public Boolean insert(Inventario inv)
        {
           
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"INSERT INTO inventario(NOMBRECORTO, DESCRIPCION, SERIE, COLOR, FECHAADQUISICION, TIPOADQUISICION, OBSERVACIONES, AREAS_ID)" +
                        " VALUES(@NOMBRECORTO, @DESCRIPCION, @SERIE, @COLOR, @FECHAADQUISICION, @TIPOADQUISICION, @OBSERVACIONES, @AREAS_ID);";

                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@NOMBRECORTO", inv.NOMBRECORTO);
                    sentencia.Parameters.AddWithValue("@DESCRIPCION", inv.DESCRIPCION);
                    sentencia.Parameters.AddWithValue("@SERIE", inv.SERIE);
                    sentencia.Parameters.AddWithValue("@COLOR", inv.COLOR);
                    sentencia.Parameters.AddWithValue("@FECHAADQUISICION", inv.FECHAADQUISICION);
                    sentencia.Parameters.AddWithValue("@TIPOADQUISICION", inv.TIPOADQUISICION);
                    sentencia.Parameters.AddWithValue("@OBSERVACIONES", inv.OBSERVACIONES);
                    sentencia.Parameters.AddWithValue("@AREAS_ID", inv.AREAS_ID);


                    sentencia.Connection = Conexion.conexion;

                    sentencia.ExecuteNonQuery();
                    return true;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return false;
            }

        }
        public Boolean update(Inventario inv)
        {
           
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"UPDATE inventario
                                        SET NOMBRECORTO = @NOMBRECORTO," +
                                            "DESCRIPCION = @DESCRIPCION," +
                                            "SERIE = @SERIE," +
                                            "COLOR = @COLOR," +
                                            "FECHAADQUISICION = @FECHAADQUISICION," +
                                            "TIPOADQUISICION = @TIPOADQUISICION," +
                                            "OBSERVACIONES = @OBSERVACIONES," +
                                            "AREAS_ID = @AREAS_ID " +
                                        "WHERE ID = @ID";

                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@ID", inv.ID);
                    sentencia.Parameters.AddWithValue("@NOMBRECORTO", inv.NOMBRECORTO);
                    sentencia.Parameters.AddWithValue("@DESCRIPCION", inv.DESCRIPCION);
                    sentencia.Parameters.AddWithValue("@SERIE", inv.SERIE);
                    sentencia.Parameters.AddWithValue("@COLOR", inv.COLOR);
                    sentencia.Parameters.AddWithValue("@FECHAADQUISICION", inv.FECHAADQUISICION);
                    sentencia.Parameters.AddWithValue("@TIPOADQUISICION", inv.TIPOADQUISICION);
                    sentencia.Parameters.AddWithValue("@OBSERVACIONES", inv.OBSERVACIONES);
                    sentencia.Parameters.AddWithValue("@AREAS_ID", inv.AREAS_ID);



                    sentencia.Connection = Conexion.conexion;

                    sentencia.ExecuteNonQuery();
                    return true;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return false;
            }

        }
        public Boolean delete(int ID)
        {

            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"DELETE FROM INVENTARIO WHERE ID = @ID";

                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@ID", ID);



                    sentencia.Connection = Conexion.conexion;

                    sentencia.ExecuteNonQuery();
                    return true;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return false;
            }

        }
    }
}