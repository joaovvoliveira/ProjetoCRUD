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
                Response.Write("<script>alert('cadastrado Com Sucesso');</script>");
            }
            else
            {
                Controle.Controle.getInstance().EditarCliente(cliente);
                Response.Write("<script>alert('Alterado com sucesso');</script>");
            }
            Page_Load();   
        }
        protected void Page_Load()
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
             
            //txbId.Text = gvConsultaClientes.SelectedRow.Cells[0];
            //txbNome.Text = nome.Text;
            txbCPF.Text = gvConsultaClientes.SelectedRow.Cells[2].ToString();
            txbTelefone.Text = gvConsultaClientes.SelectedRow.Cells[3].ToString();
            txbDataNascimento.Text = gvConsultaClientes.SelectedRow.Cells[4].ToString();
            txbEmail.Text = gvConsultaClientes.SelectedRow.Cells[5].ToString();
            txbRua.Text = gvConsultaClientes.SelectedRow.Cells[6].ToString();
            txbNumero.Text = gvConsultaClientes.SelectedRow.Cells[7].ToString();
            txbBairro.Text = gvConsultaClientes.SelectedRow.Cells[8].ToString();
            txbCidade.Text = gvConsultaClientes.SelectedRow.Cells[9].ToString();
            txbCEP.Text = gvConsultaClientes.SelectedRow.Cells[10].ToString();
            //txbEstado.Text = gvConsultaClientes.SelectedRow.Cells[11].ToString();
        }
    }
}