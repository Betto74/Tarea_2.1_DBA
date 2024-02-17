using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Modelos;
using System.Data;

namespace Datos
{
    public class EmployeeDAO
    {

        public Employee login(String usuario, String password)
        {
            Employee emp = null;
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"SELECT * FROM USERS WHERE USERNAME=@USUARIO AND PASSWORD=@PASSWORD";


                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@USUARIO", usuario);
                    sentencia.Parameters.AddWithValue("@PASSWORD", password);

                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);
                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        emp = new Employee()
                        {
                            ID = Convert.ToInt32(fila["ID"]),
                            F_NAME = fila["F_NAME"].ToString(),
                            L_NAME = fila["L_NAME"].ToString(),
                            EMAIL = fila["EMAIL"].ToString(),
                            ADDRESS = fila["ADDRESS"].ToString(),
                            USERNAME = fila["USERNAME"].ToString(),
                            PASSWORD = fila["PASSWORD"].ToString(),
                            CARD = fila["CARD"].ToString(),
                            CCV = fila["CCV"].ToString(),
                            EXP_DATE = fila["EXP_DATE"].ToString(),
                            T_NAME = fila["T_NAME"].ToString()

                        };

                    }
                    
                    return emp;
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
        public Employee getData(int ID)
        {
            Employee emp = null;
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"SELECT * FROM USERS WHERE ID = @ID";

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
                        emp = new Employee()
                        {
                            ID = Convert.ToInt32(fila["ID"]),
                            F_NAME = fila["F_NAME"].ToString(),
                            L_NAME = fila["L_NAME"].ToString(),
                            EMAIL = fila["EMAIL"].ToString(),
                            ADDRESS = fila["ADDRESS"].ToString(),
                            USERNAME = fila["USERNAME"].ToString(),
                            PASSWORD = fila["PASSWORD"].ToString(),
                            CARD = fila["CARD"].ToString(),
                            CCV = fila["CCV"].ToString(),
                            EXP_DATE = fila["EXP_DATE"].ToString(),
                            T_NAME = fila["T_NAME"].ToString()

                        };

                    }

                    return emp;
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

        public Employee decrypt(int ID, String CLAVE)
        {
            Employee emp = null;
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"SELECT CONVERT(AES_DECRYPT(CARD,@CLAVE) USING UTF8MB4) AS CARD,
                                        CONVERT(AES_DECRYPT(CCV,@CLAVE) USING UTF8MB4) AS CCV,
                                        CONVERT(AES_DECRYPT(EXP_DATE,@CLAVE) USING UTF8MB4) AS EXP_DATE,
                                        CONVERT(AES_DECRYPT(T_NAME,@CLAVE) USING UTF8MB4) AS T_NAME
                                        FROM USERS
                                        WHERE ID = @ID";

                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@ID", ID);
                    sentencia.Parameters.AddWithValue("@CLAVE", CLAVE);
              
                

                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);
      


                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        emp = new Employee()
                        {
                            CARD = fila["CARD"].ToString(),
                            CCV = fila["CCV"].ToString(),
                            EXP_DATE = fila["EXP_DATE"].ToString(),
                            T_NAME = fila["T_NAME"].ToString()   

                        };

                    }

                    return emp;
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

        public String decryptPassword(String PASSWORD)
        {
            
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"SELECT SHA1(@PASSWORD)";

                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@PASSWORD", PASSWORD);
                    


                    sentencia.Connection = Conexion.conexion;

                    

                    return sentencia.ExecuteScalar().ToString();
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

        public Boolean update(Employee EMPLEADO , String CLAVE)
        {
            Employee emp = null;
            if (Conexion.Conectar())
            {
                try
                {

                    String select = @"UPDATE USERS SET F_NAME = @F_NAME, L_NAME = @L_NAME, EMAIL = @EMAIL, ADDRESS = @ADDRESS, PASSWORD = sha1(@PASSWORD), CARD = aes_encrypt(@CARD,@CLAVE), CCV = aes_encrypt(@CCV,@CLAVE),
                                        EXP_DATE = aes_encrypt(@EXP_DATE,@CLAVE),
                                        T_NAME = aes_encrypt(@T_NAME ,@CLAVE)
                                        WHERE ID = @ID";

                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@F_NAME", EMPLEADO.F_NAME);
                    sentencia.Parameters.AddWithValue("@L_NAME", EMPLEADO.L_NAME);
                    sentencia.Parameters.AddWithValue("@EMAIL", EMPLEADO.EMAIL);
                    sentencia.Parameters.AddWithValue("@ADDRESS", EMPLEADO.ADDRESS);
                    sentencia.Parameters.AddWithValue("@PASSWORD", EMPLEADO.PASSWORD);
                    sentencia.Parameters.AddWithValue("@CARD", EMPLEADO.CARD);
                    sentencia.Parameters.AddWithValue("@CCV", EMPLEADO.CCV);
                    sentencia.Parameters.AddWithValue("@EXP_DATE", EMPLEADO.EXP_DATE);
                    sentencia.Parameters.AddWithValue("@T_NAME", EMPLEADO.T_NAME);
                    sentencia.Parameters.AddWithValue("@ID", EMPLEADO.ID);
                    sentencia.Parameters.AddWithValue("@CLAVE", CLAVE);


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
