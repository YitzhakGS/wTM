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
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        WUsuario wUsuario;
        static int pkUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            wUsuario = new WUsuario();
            if (!IsPostBack) //Pregunta si es la primera vez que se cargar una pagina, sirve para cargar metodos; IsPostBack se refiere al viaje que hace hacia el servidor cuando se cargar por ejemplo una accion con un boton
            {
                ListUsuarios();
            }
        }

        private void ListUsuarios()
        {
            DataSet ds = wUsuario.ListDatos(2);
            grdListUsuarios.DataSource = ds;
            grdListUsuarios.DataBind(); //Esto hace el enlace
        }

        protected void grdDenuncias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            if (e.CommandName == "eliminar")
            {

                pkUsuario = Convert.ToInt32(row.Cells[2].Text);


                string jsCode = @"
                    Swal.fire({
                      title: '¿Estás seguro de eliminar?',
                      text: 'No podrás revertir esta acción.',
                      icon: 'warning',
                      showCancelButton: true,
                      confirmButtonColor: '#3085d6',
                      cancelButtonColor: '#d33',
                      confirmButtonText: 'Sí, eliminar.'
                    }).then((result) => {
                      if (result.isConfirmed) {
                        document.getElementById('" + btnEliminar.ClientID + @"').click();
                      } else {
                        Swal.fire('Cancelado', 'El registro no se elimino.', 'error');
                      }
                    })";

                ClientScript.RegisterStartupScript(this.GetType(), "DeleteAlert", jsCode, true);

            }
            else if (e.CommandName == "editar")
            {
                lblActualizar.Visible = true;
                lblRegistrar.Visible = false;
                pkUsuario = Convert.ToInt32(row.Cells[2].Text);
                txtNombre.Text = row.Cells[3].Text;
                txtApellidos.Text = row.Cells[4].Text;
                txtEmail.Text = row.Cells[5].Text;
                txtPassword.Text = row.Cells[6].Text;
                txtTelefono.Text = row.Cells[7].Text;
                drpArea.SelectedValue = row.Cells[10].Text;
                btnActualizar.Visible = true;
                btnEnviar.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "setTimeout(AbrirModal, 0);", true);
            }
        }

        protected void grdListDenuncias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[8].Visible = false;

            //if (e.Row.Cells[7].Text == "Finalizado")
            //{
            //    e.Row.BackColor = System.Drawing.Color.LightGreen;
            //}
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (wUsuario.DeleteUsuario(pkUsuario))
            {
                ListUsuarios();
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>Swal.fire({\r\n  title: \'Eliminado\',\r\n  text: \'Eliminación exitosa!\',\r\n  icon: \'success\'\r\n}); </script>");

            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            CUsuario nuevo = new CUsuario();
            nuevo.nombre = txtNombre.Text;
            nuevo.apellidos = txtApellidos.Text;
            nuevo.telefono = txtTelefono.Text;
            nuevo.correo = txtEmail.Text;
            nuevo.password = txtPassword.Text;
            nuevo.status = drpArea.SelectedValue;

            if (wUsuario.RegistrarUsuario(nuevo))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>Swal.fire({ title: 'Registrado', text: 'Registro exitoso!', icon: 'success' });</script>");
                Limpiar();
                ListUsuarios();
            }
            else
            {
                Response.Write("<script>alert('Error al registrar la denuncia')</script>");
            }
        }

        protected void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnEnviar.Visible = true;
            btnActualizar.Visible = false;
            lblActualizar.Visible = false;
            lblRegistrar.Visible = true;
        }

        protected void btnRegModal_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnEnviar.Visible = true;
            btnActualizar.Visible = false;
            lblActualizar.Visible = false;
            lblRegistrar.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "setTimeout(AbrirModal, 0);", true);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            CUsuario nuevo = new CUsuario();
            nuevo.pkUsuario = pkUsuario;
            nuevo.nombre = txtNombre.Text;
            nuevo.apellidos = txtApellidos.Text;
            nuevo.telefono = txtTelefono.Text;
            nuevo.correo = txtEmail.Text;
            nuevo.password = txtPassword.Text;
            nuevo.status = drpArea.SelectedValue;

            if (wUsuario.UpdateUsuario(nuevo))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script>Swal.fire({ title: 'Actualizado', text: 'Registro actualizado!', icon: 'success' });</script>");
                ListUsuarios();
            }
            else
            {
                Response.Write("<script>alert('Error al actualizar el usuario')</script>");
            }
            Limpiar();
        }

        
    }
}