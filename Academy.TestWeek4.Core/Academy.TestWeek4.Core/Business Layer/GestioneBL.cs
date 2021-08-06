using Academy.TestWeek4.Core.Models;
using Academy.TestWeek4.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.TestWeek4.Core.Business_Layer
{
    public class GestioneBL : IGestioneBL

    {

        private readonly IOrdineRepository ordineRepo;
        private readonly IClienteRepository clienteRepo;

        public GestioneBL()
        {
            this.ordineRepo = DependencyContainer.Resolve<IOrdineRepository>();
            this.clienteRepo = DependencyContainer.Resolve<IClienteRepository>();
        }

        public GestioneBL(IOrdineRepository ordineR, IClienteRepository clienteR)
        {
            this.ordineRepo = ordineR;
            this.clienteRepo = clienteR;
        }

        #region Cliente
        public bool CreateCliente(Cliente newCliente)
        {
            if (newCliente == null)
                return false;

            return clienteRepo.Add(newCliente);
        }
        public bool DeleteClienteById(int idCliente)
        {
            if (idCliente <= 0)
                return false;

            Cliente clienteToBeDeleted = this.clienteRepo.GetById(idCliente);

            if (clienteToBeDeleted != null)
                return clienteRepo.Delete(clienteToBeDeleted);

            return false;
        }
        public bool EditCliente(Cliente editedCliente)
        {
            if (editedCliente == null)
                return false;

            return clienteRepo.Update(editedCliente);
        }
        public IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null)
        {
            if (filter != null)
                return clienteRepo.Fetch().Where(filter);

            return clienteRepo.Fetch();
        }
        public Cliente FetchClienteById(int id)
        {
            if (id <= 0)
                return null;

            return clienteRepo.GetById(id);
        }
        #endregion

        #region Ordine
        public bool CreateOrdine(Ordine newOrdine)
        {
            if (newOrdine == null)
                return false;

            return ordineRepo.Add(newOrdine);
        }

        

        public bool DeleteOrdineById(int idOrdine)
        {
            if (idOrdine <= 0)
                return false;

            Ordine ordineBeDeleted = this.ordineRepo.GetById(idOrdine);

            if (ordineBeDeleted != null)
                return ordineRepo.Delete(ordineBeDeleted);

            return false;
        }

        

        public bool EditOrdine(Ordine editedOrdine)
        {
            if (editedOrdine == null)
                return false;

            return ordineRepo.Update(editedOrdine);
        }

        

        

        public Ordine FetchOrdineById(int id)
        {
            if (id <= 0)
                return null;

            return ordineRepo.GetById(id);
        }

        public IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null)
        {
            if (filter != null)
                return ordineRepo.Fetch().Where(filter);

            return ordineRepo.Fetch();
        }
        #endregion

        #region Pragmatic REST

        public bool OrdineCliente(int idCliente, string codiceOrdine)
        {
            if (idCliente <= 0 || string.IsNullOrEmpty(codiceOrdine))
                return false;

            var ordinatoCliente = clienteRepo.GetById(idCliente);

            if (ordinatoCliente == null)
                return false;

            return ordineRepo.Add(new Ordine()
            {
                Cliente = ordinatoCliente,
                DataOrdine = DateTime.Now,
                CodiceOrdine = codiceOrdine
            });
        }

        

        #endregion


    }
}
