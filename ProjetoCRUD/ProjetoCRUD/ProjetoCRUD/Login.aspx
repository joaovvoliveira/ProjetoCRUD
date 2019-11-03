<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoCRUD.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login de Acesso</title>
    <link rel="stylesheet" type="text/css" href="CSS/CRUDStyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="TelaLogin">
		<header class="headerLogin">
				<img src="logoCrud.png" id="logoLogin" width="50" height="50"/>	
				<h3 id="tituloLogin"> ProjetoCrud </h3>
		</header>
		<div class="corpoLogin">
			Seja bem vindo !<br/>
			Valide seus dados para entrar<br/>
			Usuário:<br/>
			<input type="text" name="txbUsuario"/><br/>
			Senha:<br/>
			<input type="password" name="txbSenha"/><br/>
            <asp:Button ID="btnLogar" runat="server" Text="Entrar" OnClick="btnLogar_Click1" />
            </div>
        </div>
    </form>
</body>
</html>
