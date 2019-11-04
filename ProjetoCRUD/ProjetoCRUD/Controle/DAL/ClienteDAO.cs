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
            SqlCommand cmd = new SqlCommand(@"insert into Enderecos(Rua, Numero, Bairro, Cidade, Cep)
                                            values(@Rua, @Numero, @Bairro, @Cidade, @Cep)
                                            declare @Id_Endereco int =@@identity

                                            insert into Pessoas (Nome, CPF, DataNascimento, Email, Telefone, Fk_Enderecos_IdEndereco)
                                            values(@Nome, @CPF, @DataNascimento, @Email, @Telefone, @Id_Endereco)", conn);

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
            String sqlText = (@"select * from Pessoas
                                inner join Enderecos
                                on Pessoas.Fk_Enderecos_IdEndereco = Enderecos.IdEndereco");
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

                    cliente.CodCliente = Convert.ToInt32(dr["IdCliente"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.Cpf = Convert.ToString(dr["CPF"]);
                    cliente.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
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
            SqlCommand cmd = new SqlCommand(@"declare @FkEndereco int
                                            update Pessoas
                                            Set Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento, Email = @Email, Telefone = @Telefone, @FkEndereco = (select Fk_Enderecos_IdEndereco from Pessoas where IdCliente = @IdCliente)
                                            where IdCliente = @IdCliente

                                            update Enderecos
                                            set Rua = @Rua, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade, Cep = @Cep
                                            where IdEndereco = @FkEndereco", conn);

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

      public void ExcluirCliente(ClienteDTO cliente)
      {

      }

      public Boolean ValidarLogin(ClienteDTO cliente)
      {
            String sqlText = String.Format("Select * from LoginUsuarios Where Usuario = '{0}' and Senha = '{1}'", cliente.Usuario, cliente.Senha);

            SqlCommand cmd = new SqlCommand(sqlText, conn);

            

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
                throw ex;
            }
        }

        //Fim Metodos
    }
  
}
