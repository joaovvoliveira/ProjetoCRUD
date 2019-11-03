using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.DTO;

namespace Controles
{
    public class Controles
    {
        //Inicio Instancia
        private static Controles instance = null;

        private Controles()
        {

        }

        public static Controles getInstance ()
        {
            if (instance == null)
            {
                instance = new Controles();
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
            BL.ClienteBL.getInstance().EditarCliente(cliente);
        }

        public void ExcluirCliente (ClienteDTO cliente)
        {

        }
        //Fim Metodos
    }
}
