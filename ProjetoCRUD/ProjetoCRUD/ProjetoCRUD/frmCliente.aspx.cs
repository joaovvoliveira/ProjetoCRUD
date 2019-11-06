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
            cliente.DataNascimento = Convert.ToDateTime(txbDataNascimento.Text);
            cliente.Email = txbEmail.Text;
            cliente.Telefone = txbTelefone.Text;
            cliente.Rua = txbRua.Text;
            cliente.Numero = txbNumero.Text;
            cliente.Bairro = txbBairro.Text;
            cliente.Cidade = txbCidade.Text;
            cliente.Cep = txbCEP.Text;

            if (txbId.Text.Equals(""))
            {
                Controles.Controles.getInstance().CadastrarCliente(cliente);
                Response.Write("<script>alert('cadastrado Com Sucesso');</script>");
            }
            else
            {
                cliente.CodCliente = Convert.ToInt32(txbId.Text);
                Controles.Controles.getInstance().EditarCliente(cliente);
                Response.Write("<script>alert('Alterado com sucesso');</script>");
            }
            limparTextBoxes(this);
            Page_Load();   
        }
        protected void Page_Load()
        {
            gvConsultaClientes.DataSource = Controles.Controles.getInstance().ConsultaCliente();
            gvConsultaClientes.DataBind();
            
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            
            txbId.Text = gvConsultaClientes.SelectedRow.Cells[1].Text;
            txbNome.Text = gvConsultaClientes.SelectedRow.Cells[2].Text;
            txbCPF.Text = gvConsultaClientes.SelectedRow.Cells[3].Text;
            txbTelefone.Text = gvConsultaClientes.SelectedRow.Cells[4].Text;
            txbDataNascimento.Text = gvConsultaClientes.SelectedRow.Cells[5].Text;
            txbEmail.Text = gvConsultaClientes.SelectedRow.Cells[6].Text;
            txbRua.Text = gvConsultaClientes.SelectedRow.Cells[7].Text;
            txbNumero.Text = gvConsultaClientes.SelectedRow.Cells[8].Text;
            txbBairro.Text = gvConsultaClientes.SelectedRow.Cells[9].Text;
            txbCidade.Text = gvConsultaClientes.SelectedRow.Cells[10].Text;
            txbCEP.Text = gvConsultaClientes.SelectedRow.Cells[11].Text;
            //txbEstado.Text = gvConsultaClientes.SelectedRow.Cells[11].ToString();

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        protected void gvConsultaClientes_SelectedIndexChanged(object sender, EventArgs  e)
        {
            
        }

        private void limparTextBoxes(Control control)
        {
            //Faz um laço para todos os controles passados no parâmetro
            foreach (Control ctrl in control.Controls)
            {
                //Se o controle for um TextBox...
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = String.Empty;
                }
                else if (ctrl.Controls.Count > 0)
                {
                    limparTextBoxes(ctrl);
                }
            }
        }
    }
}