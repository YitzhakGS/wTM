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
                if (Session["UsuarioLog"] == null)
                {
                    CUsuario usuario = new CUsuario
                    {
                        pkUsuario = 4, // Asignar el ID de usuario 5
                        fkRol = 3,       // Puedes asignar otros valores necesarios al objeto usuario aquí
                    };
                    Session["UsuarioLog"] = usuario;
                }
                MostrarTickets();
                listarDepartamentos();
            }
        }

        private void listarDepartamentos()
        {
            DataSet ds = objTicket.listarDepartamentos(); //lo correcto seria crear una clase y otra tabla para las empresas y traer el objeto para mandar el dato de que empresa se quieren los departamentos, asi como cambiar los SP
            if (ds.Tables[0].Rows.Count >= 0)
            {
                ddlArea.DataSource = ds;
                ddlArea.DataValueField = "Id_Departamento";
                ddlArea.DataTextField = "Dep_Nombre";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("Seleccione el Departamento o Area", "0"));
            };
        }

        private void MostrarTickets()
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
                    fkUsuario = usuario.pkUsuario,
                    Ticket_Titulo = txtTitulo.Text,
                    Tick_Descripcion = txtDescripcion.Text,
                    fkEstado = (int)EStatusTicket.Activo,
                    fkArea = ddlArea.SelectedIndex,
                };
                if (objTicket.InsertarTickets(ticket))
                {
                    MostrarTickets();
                    ScriptManager.RegisterStartupScript(this, GetType(), "TicketEnviado", "Swal.fire({ title: 'Ticket Enviado', text: 'Tu solicitud ha sido enviada exitosamente', icon: 'success', confirmButtonText: 'Aceptar' });", true);
                }
            };
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = "";
            ddlArea.SelectedIndex = 0;
            //ddlPrioridad.SelectedIndex = 0;
            txtDescripcion.Text = "";

            // Un mensaje de cancelación, seria mas el de confirmacion pero ando viendo si necesito la base o no
            ScriptManager.RegisterStartupScript(this, GetType(), "TicketCancelado", "Swal.fire({ title: 'Ticket Cancelado', text: 'Has cancelado la creación del ticket.', icon: 'info', confirmButtonText: 'Aceptar' });", true);

        }
    }
}