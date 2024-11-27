using AppWTM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AppWTM.Presenter
{
    public class WUsuario
    {
        ManagerBD managerBD;

        public WUsuario()
        {
            managerBD = new ManagerBD();
        }

        public bool ValidarUsuario(ref DataSet ds, CUsuario nuevo)
        {
            bool hayRegistro = false;

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@opcion", SqlDbType.Int) { Value = 2 });
            sqlParameters.Add(new SqlParameter("@correo", SqlDbType.NVarChar) { Value = nuevo.correo });
            sqlParameters.Add(new SqlParameter("@password", SqlDbType.NVarChar) { Value = nuevo.password });
            ds = managerBD.GetData("spuUsuario", sqlParameters.ToArray());
            if (ds.Tables[0].Rows.Count > 0) //revisar
            {
                hayRegistro = true;
            }
            return hayRegistro;
        }

        public bool RegistrarUsuario(CUsuario nuevo)
        {
            bool registrado = false;
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@opcion", 1));
            listParameter.Add(new SqlParameter("@Usu_Nombre ", nuevo.nombre));
            listParameter.Add(new SqlParameter("@Usu_Apellidos", nuevo.apellidos));
            listParameter.Add(new SqlParameter("@Usu_Email", nuevo.correo));
            listParameter.Add(new SqlParameter("@Usu_Password", nuevo.password));
            listParameter.Add(new SqlParameter("@Usu_Telefono", nuevo.telefono));
            listParameter.Add(new SqlParameter("@fkEmpresa ", 1));
            listParameter.Add(new SqlParameter("@fkRol", nuevo.fkRol));
            listParameter.Add(new SqlParameter("@Usu_Status", nuevo.status));
            listParameter.Add(new SqlParameter("@fkArea", nuevo.fkArea));
            registrado = managerBD.UpdateData("spuUsuarios", listParameter.ToArray());
            return registrado;
        }

        public DataSet ListRoles()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@opcion", 3));
            ds = managerBD.GetData("spuUsuario", listParameter.ToArray());


            return ds;
        }

        public DataSet ListDatos(int opcion)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@opcion", opcion));
            ds = managerBD.GetData("spuUsuarios", listParameter.ToArray());
            return ds;
        }

        public bool DeleteUsuario(int pkUsuario)
        {
            bool eliminado = false;
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@opcion", 4));
            listParameter.Add(new SqlParameter("@Id_Usuario", pkUsuario));
            eliminado = managerBD.UpdateData("spuUsuarios", listParameter.ToArray());
            return eliminado;
        }

        public bool UpdateUsuario(CUsuario usuario)
        {
            bool actualizado = false;
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@opcion", 3));
            listParameter.Add(new SqlParameter("@Id_Usuario", usuario.pkUsuario));
            listParameter.Add(new SqlParameter("@Usu_Nombre", usuario.nombre));
            listParameter.Add(new SqlParameter("@Usu_Apellidos", usuario.apellidos));
            listParameter.Add(new SqlParameter("@Usu_Email", usuario.correo));
            listParameter.Add(new SqlParameter("@Usu_Password", usuario.password));
            listParameter.Add(new SqlParameter("@Usu_Telefono", usuario.telefono));
            listParameter.Add(new SqlParameter("@fkEmpresa ", 1));
            listParameter.Add(new SqlParameter("@fkRol", usuario.fkRol));
            listParameter.Add(new SqlParameter("@Usu_Status", usuario.status));
            listParameter.Add(new SqlParameter("@fkArea", usuario.fkArea));
            actualizado = managerBD.UpdateData("spuUsuarios", listParameter.ToArray());
            return actualizado;
        }

        public DataSet ListAreas(int opcion)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameter = new List<SqlParameter>();
            listParameter.Add(new SqlParameter("@opcion", opcion));
            ds = managerBD.GetData("spuDepartamentos", listParameter.ToArray());
            return ds;
        }
    }
}