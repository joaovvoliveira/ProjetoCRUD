using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.DTO;

namespace Controle
{
    public class Controle
    {
        //Inicio Instancia
        private static Controle instance = null;

        private Controle()
        {

        }

        public static Controle getInstance ()
        {
            if (instance == null)
            {
                instance = new Controle();
            }
            return instance;
        }
        //Fim Instancia

        //Inicio Cadastro Cliente

        public void CadastrarCliente(ClienteDTO cliente)
        {
            try
            {
                BL.ClienteBL.getInstance().CadastrarCliente(cliente);
            }
            catch (Exception ex )
            {

                throw ex;
            }
            
        }

        public List<ClienteDTO>ConsultaCliente()
        {
            return BL.ClienteBL.getInstance().ConsultaCliente();
        }

        public void EditarCliente (ClienteDTO cliente)
        {

        }

        public void ExcluirCliente (ClienteDTO cliente)
        {

        }
        //Fim Metodos
    }
}
