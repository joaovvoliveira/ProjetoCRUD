using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.DTO;

namespace Controle.BL
{
    public class ClienteBL
    {
        //Inicio Instancia
        private static ClienteBL instance = null;

        private ClienteBL()
        {

        }

        public static ClienteBL getInstance()
        {
            if (instance == null)
            {
                instance = new ClienteBL();
            }
            return instance;
        }
        //Fim Instancia

        //Inicio Metodos

        public void CadastrarCliente(ClienteDTO cliente)
        {
            try
            {
                DAL.ClienteDAO.getInstance().CadastrarCliente(cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ClienteDTO> ConsultaCliente()
        {
            return DAL.ClienteDAO.getInstance().ConsultaCliente();
        }

        public void EditarCliente(ClienteDTO cliente)
        {
            DAL.ClienteDAO.getInstance().EditarCliente(cliente);
        }

        public void ExcluirCliente(ClienteDTO cliente)
        {

        }

        public Boolean ValidarLogin(ClienteDTO cliente)
        {
            return DAL.ClienteDAO.getInstance().ValidarLogin(cliente);
        }
        //Fim Metodos
    }
}
