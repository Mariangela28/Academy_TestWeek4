using Academy.TestWeek4.Core;
using Academy.TestWeek4.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.TestWeek4.EF.Repository
{
    public class EFClienteRepository : IClienteRepository
    {
        private readonly GestioneContext ctx;

        public EFClienteRepository() : this(new GestioneContext()) { }

        public EFClienteRepository(GestioneContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Cliente newCliente)
        {
            if (newCliente == null)
                return false;

            try
            {
                ctx.Clienti.Add(newCliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Cliente item)
        {
            if (item == null)
                return false;

            try
            {
                var cliente = ctx.Clienti.Find(item.ID);

                if (cliente != null)
                    ctx.Clienti.Remove(cliente);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> Fetch()
        {
            try
            {
                return ctx.Clienti.Include(b => b.Ordini).ToList();
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public Cliente GetByCodiceCliente(string codiceCliente)
        {
            if (string.IsNullOrEmpty(codiceCliente))
                return null;

            try
            {
                var cliente = ctx.Clienti.Find(codiceCliente);

                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Cliente GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Clienti.Find(id);
        }

        public bool Update(Cliente updatedCliente)
        {
            if (updatedCliente == null)
                return false;

            try
            {
                ctx.Clienti.Update(updatedCliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
