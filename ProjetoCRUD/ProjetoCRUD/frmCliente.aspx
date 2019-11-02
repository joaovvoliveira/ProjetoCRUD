<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="ProjetoCRUD.frmCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AreaDeTrabalho" runat="server">
    
    <!-- Criando o formulário -->
		<fieldset>
			<legend>Meu Formulário</legend>
			<div class="Dados">	
				<h3>Insira os Dados abaixo:</h3><span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp ID: 
                <asp:TextBox ID="txbId" runat="server" Width="44px"></asp:TextBox>
                </span>&nbsp;
                <div class="nome"> Nome:<br>
					<asp:TextBox type="text" name="txbNome" runat="server" placeholder="Digite seu Nome" autofocus="" ID="txbNome" ></asp:TextBox>
				</div>
				<div class="nasc">Data de Nascimento:<br>
					<asp:TextBox type="date" name="txbNasc" runat="server" placeholder="DD/MM/AAAA" ID="txbDataNascimento"></asp:TextBox>
				</div>				
				<br><br>
				<div class="email">Email:<br>
					<asp:TextBox type="text" name="txbEmail"  runat="server" placeholder="Ex: Unip@Unipx.com.br" ID="txbEmail"></asp:TextBox>
				</div>
				<div class="cpf">CPF:<br>
					<asp:TextBox type="text" name="txbCpf"  runat="server" placeholder="000.000.000.00" ID="txbCPF"></asp:TextBox>
				</div>
				<br><br />
				<div class="telefone">Telefone:<br>
					<asp:TextBox type="text" name="txbTelefone"  runat="server" placeholder="00000.0000" ID="txbTelefone"></asp:TextBox>
				</div>
				<div class="cep">Cep:<br>
					<asp:TextBox type="text" name="txbCep"  runat="server" placeholder="00000-00" ID="txbCEP"></asp:TextBox>
				</div>
				<br><br>
				<div class="rua">Rua:<br>
					<asp:TextBox type="text" name="txbRua"  runat="server" placeholder="Digite o nome da rua" ID="txbRua"></asp:TextBox>
				</div>
				<div class="ncasa">Nº:<br>
					<asp:TextBox type="text" name="txbNCasa" runat="server"  placeholder="Número" ID="txbNumero"></asp:TextBox>
				</div><br><br>
				<div class="bairro">Bairro:<br>
					<asp:TextBox type="text" name="txbBairro" runat="server"  placeholder="Digite o Bairro" ID="txbBairro"></asp:TextBox>
				</div>
				<div class="cidade">Cidade:<br>
					<asp:TextBox type="text" name="txbCidade" runat="server"  placeholder="Digite a Cidade" ID="txbCidade"></asp:TextBox>
				</div>
				<!-- "placeholder" é a palavra que fica no input antes de preenche-lo" -->
			</div>
			<br>
            <asp:Button class="btns" ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            <asp:Button class="btns" ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            <asp:Button class="btns" ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            <br>
        </fieldset>
        
        <asp:GridView ID="gvConsultaClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="gvConsultaClientes_SelectedIndexChanged" OnRowEditing="gvConsultaClientes_RowEditing">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CodCliente" HeaderText="Cod.Cliente" Visible="False"  DataFormatString="{0:p}" />
                <asp:BoundField DataField="Nome"  HeaderText="Nome" DataFormatString="{0:p}"  />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="Telefone" HeaderText="Telefone"/>
                <asp:BoundField DataField="DataNascimento" HeaderText="" Visible="False" />
                <asp:BoundField DataField="Email" HeaderText="Email"/>
                <asp:BoundField DataField="Rua" HeaderText="" Visible="False" />
                <asp:BoundField DataField="Numero" HeaderText="" Visible="False" />
                <asp:BoundField DataField="Bairro" HeaderText="" Visible="False" />
                <asp:BoundField DataField="Cidade" HeaderText="" Visible="False" />
                <asp:BoundField DataField="Cep" HeaderText="" Visible="False" />
                <asp:BoundField DataField="Estado" HeaderText="" Visible="False" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

    </asp:Content>
