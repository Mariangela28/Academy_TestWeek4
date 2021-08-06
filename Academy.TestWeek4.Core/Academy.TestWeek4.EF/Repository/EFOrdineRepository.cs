using Academy.TestWeek4.Core.Models;
using Academy.TestWeek4.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.TestWeek4.EF.Repository
{
    public class EFOrdineRepository : IOrdineRepository
    {
        private readonly GestioneContext ctx;

        public EFOrdineRepository() : this(new GestioneContext()) { }

        public EFOrdineRepository(GestioneContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Ordine newOrdine)
        {
            if (newOrdine == null)
                return false;

            try
            {
                ctx.Ordini.Add(newOrdine);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Ordine item)
        {
            if (item == null)
                return false;

            try
            {
                var cliente = ctx.Ordini.Find(item.ID);

                if (cliente != null)
                    ctx.Ordini.Remove(cliente);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ordine> Fetch()
        {
            try
            {
                return ctx.Ordini.ToList();
            }
            catch (Exception)
            {
                return new List<Ordine>();
            }
        }

        public Ordine GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Ordini.Find(id);
        }

        public bool Update(Ordine updatedOrdine)
        {
            if (updatedOrdine == null)
                return false;

            try
            {
                ctx.Ordini.Update(updatedOrdine);
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
