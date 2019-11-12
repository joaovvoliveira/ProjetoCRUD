using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoCRUD
{
    public partial class frmPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCliente.aspx");
        }

        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }
    }
}