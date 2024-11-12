using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using AppWTM.Presenter;

namespace AppWTM.Model
{
    public class WTickets
    {
        ManagerBD objManagerBD;

        public WTickets()
        {
            objManagerBD = new ManagerBD();
        }

        //listar ticket pendientes segun id_Usuario
        public DataSet listarTickets(CUsuario usuario)
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter("opcion", 2));
            listParameters.Add(new SqlParameter("@id_Usuario", cUsuario.idUsuario));
            listParameters.Add(new SqlParameter("@Rol", cUsuario.fkRol));
            ds = objManagerBD.GetData("spuTickets", listParameters.ToArray());

            return ds;

        }

        public DataSet listarDepartamentos()
        {
            DataSet ds = new DataSet();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter("opcion", 2));
            ds = objManagerBD.GetData("spuDepartamentos", listParameters.ToArray());

            return ds;

        }

        public bool InsertarTickets (CTickets cTickets)
        {
            bool registrado = false;

            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter("@opcion", 1));
            listParameters.Add(new SqlParameter("@fkUsuario", cTickets.fkUsuario));
            listParameters.Add(new SqlParameter("@Tick_Titulo", cTickets.Ticket_Titulo));
            listParameters.Add(new SqlParameter("@fkPrioridad", cTickets.fkPrioridad));
            listParameters.Add(new SqlParameter("@Tick_Descripcion", cTickets.Tick_Descripcion));
            listParameters.Add(new SqlParameter("@fkEstado", cTickets.fkEstado));

            registrado = objManagerBD.UpdateData("spuTickets", listParameters.ToArray());
            return registrado;

        }

        public bool EliminarTicket(CTickets cTickets)
        {
            bool eliminado = false;
            List<SqlParameter> listParameters = new List<SqlParameter>();
            listParameters.Add(new SqlParameter("@opcion", 4));
            listParameters.Add(new SqlParameter("@Id_Ticket", cTickets.Id_Ticket));
            eliminado = objManagerBD.UpdateData("spuTickets", listParameters.ToArray());
            return eliminado;
        }

    }
}