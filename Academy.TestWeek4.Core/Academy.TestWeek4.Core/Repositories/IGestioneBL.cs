using Academy.TestWeek4.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.TestWeek4.Core.Repositories
{
    public interface IGestioneBL
    {
        #region Cliente

        IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null);
        Cliente FetchClienteById(int id);
        bool CreateCliente(Cliente newCliente);
        bool EditCliente(Cliente editedCliente);
        bool DeleteClienteById(int idCliente);

        #endregion

        #region Ordine

        IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null);
        Ordine FetchOrdineById(int id);
        bool CreateOrdine(Ordine newOrdine);
        bool EditOrdine(Ordine editedOrdine);
        bool DeleteOrdineById(int idOrdine);

        bool OrdineCliente(int idCliente, string codiceOrdine);
        

        #endregion

    }
}
