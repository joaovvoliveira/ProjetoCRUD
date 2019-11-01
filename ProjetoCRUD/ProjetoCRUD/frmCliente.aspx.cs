using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controle;
using Modelo.DTO;

namespace ProjetoCRUD
{
    public partial class frmCliente : System.Web.UI.Page
    {
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ClienteDTO cliente = new ClienteDTO();

            cliente.Nome = txbNome.Text;
            cliente.Cpf = txbCPF.Text;
            cliente.DataNascimento = txbDataNascimento.Text;
            cliente.Email = txbEmail.Text;
            cliente.Telefone = txbTelefone.Text;
            cliente.Rua = txbRua.Text;
            cliente.Numero = txbNumero.Text;
            cliente.Bairro = txbBairro.Text;
            cliente.Cidade = txbCidade.Text;
            cliente.Cep = txbCEP.Text;
            if (txbId.Text.Equals(""))
            {
                Controle.Controle.getInstance().CadastrarCliente(cliente);
            }
            else
            {
                Controle.Controle.getInstance().EditarCliente(cliente);
            }
            Response.Write("<script>alert('cadastrado Com Sucesso');</script>");

        }

        protected void gvConsultaClientes_PageIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            gvConsultaClientes.DataSource = Controle.Controle.getInstance().ConsultaCliente();
            gvConsultaClientes.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        protected void gvConsultaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}