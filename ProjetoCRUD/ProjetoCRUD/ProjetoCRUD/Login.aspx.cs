using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controle.DAL;
using Controle;
using Modelo.DTO;

namespace ProjetoCRUD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            ClienteDTO cliente = new ClienteDTO();

            cliente.Usuario = txbUsuairo.Text;
            cliente.Senha = txbSenha.Text;

            if (Controle.BL.ClienteBL.getInstance().ValidarLogin(cliente))
            {

                Response.Redirect("frmInicial.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuario ou Senha Incorretos');</script>");
            }
                
        }
    }
}