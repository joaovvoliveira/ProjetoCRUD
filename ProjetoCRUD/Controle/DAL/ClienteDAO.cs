using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.DTO;

namespace Controle.DAL
{
    public class ClienteDAO : Conexao
    {
        //Inicio Instancia
        private static ClienteDAO instance = null;

        private ClienteDAO()
        {

        }

        public static ClienteDAO getInstance()
        {
            if (instance == null)
            {
                instance = new ClienteDAO();
            }
            return instance;
        }
        //Fim Instancia

        //Inicio Metodos

        public void CadastrarCliente(ClienteDTO cliente)
        {
            SqlCommand cmd = new SqlCommand(@"insert into Clientes (Nome, CPF, DataNascimento, Email, Telefone)
                                            values(@Nome, @CPF, @DataNascimento, @Email, @Telefone)
                                            declare @Id_Cliente int =@@identity

                                            insert into Enderecos(Rua, Numero, Bairro, Cidade, Cep, Fk_Clientes_IdCliente)
                                            values(@Rua, @Numero, @Bairro, @Cidade, @Cep, @Id_Cliente)", conn);
           // cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
            cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@Rua", cliente.Rua);
            cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
            cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
            cmd.Parameters.AddWithValue("@Cep", cliente.Cep);
            cmd.Parameters.AddWithValue("@IdCliente", Convert.ToInt32(cliente.CodCliente));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
                throw ex;
            }

       }

      public List<ClienteDTO> ConsultaCliente()
      {
            String sqlText = (@"select * from Clientes
                                inner join Enderecos
                                on Enderecos.Fk_Clientes_IdCliente = Clientes.IdCLiente");
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            conn.Open();
            List<ClienteDTO> ListaClientes = null;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                ListaClientes = new List<ClienteDTO>();

                while (dr.Read())
                {
                    ClienteDTO cliente = new ClienteDTO();

                    cliente.CodCliente = Convert.ToInt32(dr["IdCLiente"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.Cpf = Convert.ToString(dr["CPF"]);
                    cliente.DataNascimento = Convert.ToString(dr["DataNascimento"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Telefone = Convert.ToString(dr["Telefone"]);
                    cliente.Rua = Convert.ToString(dr["Rua"]);
                    cliente.Numero = Convert.ToString(dr["Numero"]);
                    cliente.Bairro = Convert.ToString(dr["Bairro"]);
                    cliente.Cidade = Convert.ToString(dr["Cidade"]);
                    //cliente.Estado = Convert.ToString(dr["Estado"]);
                    cliente.Cep = Convert.ToString(dr["Cep"]);

                    ListaClientes.Add(cliente);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
                throw ex;
            }
            return ListaClientes;
      }
       

       public void EditarCliente(ClienteDTO cliente)
      {

      }

      public void ExcluirCliente(ClienteDTO cliente)
      {

      }
            //Fim Metodos
    }
  
}
