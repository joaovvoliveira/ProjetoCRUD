using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo.DTO
{
    public class ClienteDTO
    {
        private int codCliente;
        private String cl_nome;
        private String cl_cpf;
        private String cl_sobrenome;
        private String cl_email;
        private String cl_telefone;
        private String cl_rua;
        private String cl_numero;
        private String cl_bairro;
        private String cl_cidade;
        private String cl_cep;

        private String usuario;
        private String senha;

        public int CodCliente { get => codCliente; set => codCliente = value; }
        public string Cl_nome { get => cl_nome; set => cl_nome = value; }
        public string Cl_sobrenome { get => cl_sobrenome; set => cl_sobrenome = value; }
        public string Cl_email { get => cl_email; set => cl_email = value; }
        public string Cl_telefone { get => cl_telefone; set => cl_telefone = value; }
        public string Cl_rua { get => cl_rua; set => cl_rua = value; }
        public string Cl_numero { get => cl_numero; set => cl_numero = value; }
        public string Cl_bairro { get => cl_bairro; set => cl_bairro = value; }
        public string Cl_cidade { get => cl_cidade; set => cl_cidade = value; }
        public string Cl_cep { get => cl_cep; set => cl_cep = value; }
        public string Cl_cpf { get => cl_cpf; set => cl_cpf = value; }
        public string Cl_usuario { get => usuario; set => usuario = value; }
        public string Cl_senha { get => senha; set => senha = value; }
    }
}
