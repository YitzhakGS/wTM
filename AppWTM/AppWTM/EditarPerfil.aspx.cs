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
    public partial class EditarPerfil : System.Web.UI.Page
    {
        // Campo de clase
        WUsuario wUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicializa el campo de clase, no una nueva variable local
            wUsuario = new WUsuario();

            if (!IsPostBack) // Ejecutar solo en la primera carga
            {
                ListarAreas();
            }
        }

        private void ListarAreas()
        {
            DataSet ds = wUsuario.ListAreas(2);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpArea.DataSource = ds;
                drpArea.DataValueField = "Id_Departamento";
                drpArea.DataTextField = "Dep_Nombre";
                drpArea.DataBind();
                drpArea.Items.Insert(0, "Seleccione...");
            }
        }
    }
}
