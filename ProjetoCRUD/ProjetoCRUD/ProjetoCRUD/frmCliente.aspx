<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="ProjetoCRUD.frmCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AreaDeTrabalho" runat="server">
    <!DOCTYPE html>
    <html>
        <head>
            <meta charset="utf-8" />
        </head>
        <body>
            <!-- Criando o formulário -->
            <fieldset>
			        <div class="Dados">	
                        <br />
				        <h3 id="inserirDados">Insira os Dados abaixo:</h3><span>&nbsp ID: 
                        <asp:TextBox ID="txbId" runat="server" Width="44px"></asp:TextBox><br />
                        </span><br />
                        <div class="nome">Nome:<br>
					        <asp:TextBox type="text" name="txbNome" runat="server" required="required" placeholder="Digite seu Nome" autofocus="" ID="txbNome" ></asp:TextBox>
				        </div>&nbsp
				        <div class="nasc">Sobrenome:<br>
					        <asp:TextBox type="text" name="txbSobrenome"  runat="server" required="required" ID="txbSobrenome"></asp:TextBox>
				        </div><br />
                        <br>
				        <div class="email">Email:<br>
					        <asp:TextBox type="text" name="txbEmail" runat="server" required="required" placeholder="Ex: Unip@Unipx.com.br" ID="txbEmail"></asp:TextBox>
				        </div>&nbsp
				        <div class="cpf">CPF:<br>
					        <asp:TextBox type="text" name="txbCpf" runat="server" required="required" placeholder="000.000.000.00" ID="txbCPF"></asp:TextBox>
				        </div><br />
				        <br />
				        <div class="telefone">Telefone:<br>
					        <asp:TextBox type="text" name="txbTelefone" runat="server" required="required" placeholder="00000.0000" ID="txbTelefone"></asp:TextBox>
				        </div>&nbsp
				        <div class="cep">Cep:<br>
					        <asp:TextBox type="text" name="txbCep" runat="server" required="required" placeholder="00000-00" ID="txbCEP"></asp:TextBox>
				        </div><br />
				        <br>
				        <div class="rua">Rua:<br>
					        <asp:TextBox type="text" name="txbRua" runat="server" required="required" placeholder="Digite o nome da rua" ID="txbRua"></asp:TextBox>
				        </div>&nbsp
				        <div class="ncasa">Nº:<br>
					        <asp:TextBox type="text" name="txbNCasa" runat="server" required="required" placeholder="Número" ID="txbNumero"></asp:TextBox>
				        </div><br><br />
				        <div class="bairro">Bairro:<br>
					        <asp:TextBox type="text" name="txbBairro" runat="server" required="required" placeholder="Digite o Bairro" ID="txbBairro"></asp:TextBox>
				        </div>&nbsp
				        <div class="cidade">Cidade:<br>
					        <asp:TextBox type="text" name="txbCidade" runat="server" required="required" placeholder="Digite a Cidade" ID="txbCidade"></asp:TextBox>
				        </div>
				        <!-- "placeholder" é a palavra que fica no input antes de preenche-lo" -->
			        </div>
            </fieldset>
			        <br>
            <div class="botoes">
                    <asp:Button class="btn btn-success" ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                    <asp:Button class="btn btn-danger" ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
                    <br>
            </div>    
                <asp:GridView ID="gvConsultaClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="gvConsultaClientes_SelectedIndexChanged" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="CodCliente" HeaderText="Cod.Cliente" Visible="true"/>
                        <asp:BoundField DataField="Nome"  HeaderText="Nome" Visible="true"/>
                        <asp:BoundField DataField="CPF" HeaderText="CPF" Visible="true"/>
                        <asp:BoundField DataField="Telefone" HeaderText="Telefone" Visible="true"/>
                        <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" Visible="true" DataFormatString="{0:dd-mm-yyyy}" />
                        <asp:BoundField DataField="Email" HeaderText="Email" Visible="true"/>
                        <asp:BoundField DataField="Rua" HeaderText="Rua" Visible="true" />
                        <asp:BoundField DataField="Numero" HeaderText="Numero" Visible="true" />
                        <asp:BoundField DataField="Bairro" HeaderText="Bairro" Visible="true" />
                        <asp:BoundField DataField="Cidade" HeaderText="Cidade" Visible="true" />
                        <asp:BoundField DataField="Cep" HeaderText="Cep" Visible="true" />
                
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
        </body>
    </html>
    </asp:Content>
