using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.TestWeek4.Core.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente GetByCodiceCliente(string codiceCliente);
    }
}
