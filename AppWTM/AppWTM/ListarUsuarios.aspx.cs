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
            grdListDenuncias.DataSource = ds;
            grdListDenuncias.DataBind(); //Esto hace el enlace
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
                //pkDenuncia = Convert.ToInt32(row.Cells[2].Text);
                //txtFechaSuceso.Text = Convert.ToDateTime(row.Cells[3].Text).ToString("yyyy-MM-dd HH:mm:ss");
                //drpDelitos.SelectedIndex = Convert.ToInt32(row.Cells[6].Text);
                //txtDescripcion.Text = row.Cells[4].Text;
                //btnCancel.Visible = true;
                //esActualizar = true;
                //btnEnviar.Text = "Actualizar";
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
    }
}