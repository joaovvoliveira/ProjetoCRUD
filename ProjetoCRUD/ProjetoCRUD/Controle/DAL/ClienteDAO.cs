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
            SqlCommand cmd = new SqlCommand(@"insert into tb_Enderecos(Rua, Numero, Bairro, Cidade, Cep)
                                            values(@Rua, @Numero, @Bairro, @Cidade, @Cep)
                                            declare @Id_Endereco int =@@identity

                                            insert into tb_Pessoas (Nome, CPF, Sobrenome, Email, Telefone, Fk_Enderecos_IdEndereco, Ativo)
                                            values(@Nome, @CPF, @Sobrenome, @Email, @Telefone, @Id_Endereco, 1)", conn);

           // cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", cliente.Cl_nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.Cl_cpf);
            cmd.Parameters.AddWithValue("@Sobrenome", cliente.Cl_sobrenome);
            cmd.Parameters.AddWithValue("@Email", cliente.Cl_email);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Cl_telefone);
            cmd.Parameters.AddWithValue("@Rua", cliente.Cl_rua);
            cmd.Parameters.AddWithValue("@Numero", cliente.Cl_numero);
            cmd.Parameters.AddWithValue("@Bairro", cliente.Cl_bairro);
            cmd.Parameters.AddWithValue("@Cidade", cliente.Cl_cidade);
            cmd.Parameters.AddWithValue("@Cep", cliente.Cl_cep);
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
                throw new Exception("Erro ao Conectar no Banco de dados", ex);
            }

       }

      public List<ClienteDTO> ConsultaCliente()
      {
            String sqlText = (@"select * from tb_Pessoas
                                inner join tb_Enderecos
                                on tb_Pessoas.Fk_Enderecos_IdEndereco = tb_Enderecos.IdEndereco
                                where Ativo = 1");
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            List<ClienteDTO> ListaClientes = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                ListaClientes = new List<ClienteDTO>();

                while (dr.Read())
                {
                    ClienteDTO cliente = new ClienteDTO();

                    cliente.CodCliente = Convert.ToInt32(dr["IdCliente"]);
                    cliente.Cl_nome = Convert.ToString(dr["Nome"]);
                    cliente.Cl_cpf = Convert.ToString(dr["CPF"]);
                    cliente.Cl_sobrenome = Convert.ToString(dr["Sobrenome"]);
                    cliente.Cl_email = Convert.ToString(dr["Email"]);
                    cliente.Cl_telefone = Convert.ToString(dr["Telefone"]);
                    cliente.Cl_rua = Convert.ToString(dr["Rua"]);
                    cliente.Cl_numero = Convert.ToString(dr["Numero"]);
                    cliente.Cl_bairro = Convert.ToString(dr["Bairro"]);
                    cliente.Cl_cidade = Convert.ToString(dr["Cidade"]);
                    cliente.Cl_cep = Convert.ToString(dr["Cep"]);

                    ListaClientes.Add(cliente);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
                throw new Exception("Erro ao Conectar no Banco de dados", ex);
            }
            return ListaClientes;
      }
       

       public void EditarCliente(ClienteDTO cliente)
      {
            SqlCommand cmd = new SqlCommand(@"declare @FkEndereco int
                                            update tb_Pessoas
                                            Set Nome = @Nome, CPF = @CPF, Sobrenome = @Sobrenome, Email = @Email, Telefone = @Telefone, @FkEndereco = (select Fk_Enderecos_IdEndereco from tb_Pessoas where IdCliente = @IdCliente)
                                            where IdCliente = @IdCliente

                                            update tb_Enderecos
                                            set Rua = @Rua, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade, Cep = @Cep
                                            where IdEndereco = @FkEndereco", conn);

            // cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", cliente.Cl_nome);
            cmd.Parameters.AddWithValue("@CPF", cliente.Cl_cpf);
            cmd.Parameters.AddWithValue("@Sobrenome", cliente.Cl_sobrenome);
            cmd.Parameters.AddWithValue("@Email", cliente.Cl_email);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Cl_telefone);
            cmd.Parameters.AddWithValue("@Rua", cliente.Cl_rua);
            cmd.Parameters.AddWithValue("@Numero", cliente.Cl_numero);
            cmd.Parameters.AddWithValue("@Bairro", cliente.Cl_bairro);
            cmd.Parameters.AddWithValue("@Cidade", cliente.Cl_cidade);
            cmd.Parameters.AddWithValue("@Cep", cliente.Cl_cep);
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
                throw new Exception("Erro ao Conectar no Banco de dados", ex);
            }
        }

      public void ExcluirCliente(ClienteDTO cliente)
      {
            SqlCommand cmd = new SqlCommand(@"update tb_Pessoas
                                              set Ativo = 0
                                              where IdCliente = @IdCliente", conn);

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
                throw new Exception ("Erro ao Conectar no Banco de dados", ex);
            }
        }

      public Boolean ValidarLogin(ClienteDTO cliente)
      {
            String sqlText = String.Format("Select * from tb_LoginUsuarios Where Usuario = '{0}' and Senha = '{1}'", cliente.Cl_usuario, cliente.Cl_senha);

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
                throw new Exception("Erro ao Conectar no Banco de dados", ex);
            }
        }

        //Fim Metodos
    }
  
}
