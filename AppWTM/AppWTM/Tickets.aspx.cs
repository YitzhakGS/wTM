using AppWTM.Model;
using AppWTM.Presenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWTM
{
    public partial class Tickets : System.Web.UI.Page
    {
        WTickets objTicket;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            objTicket = new WTickets();
            if (!IsPostBack)
            {
                listarTickets();
                listarDepartamentos();
            }
        }

        private void listarDepartamentos()
        {
            DataSet ds = objTicket.listarDepartamentos(); //lo correcto seria crear una clase y otra tabla para las empresas y traer el objeto para mandar el dato de que empresa se quieren los departamentos, asi como cambiar los SP
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlArea.DataSource = ds;
                ddlArea.DataValueField = "Id_Departamento";
                ddlArea.DataTextField = "Dep_Nombre";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("Seleccione el Departamento o Area", "0"));
            };
        }

        private void listarTickets()
        {
            if (Session["UsuarioLog"] != null)
            {
                CUsuario usuario = (CUsuario)Session["UsuarioLog"];
                DataSet ds = objTicket.listarTickets(usuario);
                dgrTickets.DataSource = ds;
                dgrTickets.DataBind();
            };
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if(Session["UsuarioLog"] != null)
            {
                CUsuario usuario = (CUsuario)Session["UsuarioLog"];
                CTickets ticket = new CTickets
                {
                    fkUsuario = usuario.Id_Usuario,
                    Ticket_Titulo = txtTitulo.Text,
                    Tick_Descripcion = txtDescripcion.Text,
                    fkPrioridad = usuario.fkPrioridad,
                    fkEstado = (int)EStatusTicket.Activo
                };
            };
            
        }
    }
}