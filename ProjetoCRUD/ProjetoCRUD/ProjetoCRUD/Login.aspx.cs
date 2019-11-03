using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controle.DAL;
using Controle;

namespace ProjetoCRUD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Controle.BL.ClienteBL clienteBL = new Controle.BL.ClienteBL();
            Controle.Controles controle = new Controle.Controles();
        }
        
    }
}