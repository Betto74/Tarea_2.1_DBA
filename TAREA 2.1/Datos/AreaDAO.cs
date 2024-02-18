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
    public class AreaDAO
    {
        public Area getData(int ID)
        {
            Area area = null;
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"SELECT FROM AREAS WHERE ID = @ID";

                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@ID", ID);

                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);

                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        area = new Area()
                        {
                            ID = Convert.ToInt32(fila["ID"]),
                            NOMBRE = fila["NOMBRE"].ToString(),
                            UBICACION = fila["UBICACION"].ToString(),


                        };

                    }

                    return area;
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
        public List<Area> getAllData()
        {

            List<Area> areaList = new List<Area>();
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"SELECT * FROM AREAS";

                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros

                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);

                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow fila in dt.Rows)
                        {
                            Area area = new Area()
                            {
                                ID = Convert.ToInt32(fila["ID"]),
                                NOMBRE = fila["NOMBRE"].ToString(),
                                UBICACION = fila["UBICACION"].ToString(),


                            };
                            areaList.Add(area);
                        }


                    }
                    

                    return areaList;
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
        public Boolean insert(Area area)
        {
            
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"INSERT INTO AREAS(NOMBRE,UBICACION) VALUES(@NAME, @UBICATION)";

                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@NAME", area.NOMBRE);
                    sentencia.Parameters.AddWithValue("@UBICATION", area.UBICACION);

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
        public Boolean update(Area area)
        {
          
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"UPDATE AREAS SET NOMBRE = @NAME, UBICACION = @UBICATION WHERE ID = @ID";

                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@NAME", area.NOMBRE);
                    sentencia.Parameters.AddWithValue("@UBICATION", area.UBICACION);
                    sentencia.Parameters.AddWithValue("@ID", area.ID);



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

                    String select = @"DELETE FROM AREAS WHERE ID = @ID";

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
