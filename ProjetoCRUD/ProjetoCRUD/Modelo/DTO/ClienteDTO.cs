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
        private String nome;
        private String cpf;
        private DateTime dataNascimento;
        private String email;
        private String telefone;
        private String rua;
        private String numero;
        private String bairro;
        private String cidade;
        private String cep;
        private String estado;

        public int CodCliente { get => codCliente; set => codCliente = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DataNascimento { get => dataNascimento; set => dataNascimento = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        
    }
}
