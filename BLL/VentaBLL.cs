using System.Linq.Expressions;
public class VentaBLL
{
    private Contexto _contexto;

    public VentaBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int ventaId)
    {
        return _contexto.Venta.Any(o => o.VentaId == ventaId);
    }

    private bool Insertar(Venta venta)
    {
        InsertarDetalle(venta);
        _contexto.Venta.Add(venta);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Venta venta)
    {
        ModificarDetalle(venta);
        var existe = _contexto.Venta.Find(venta.VentaId);
        if (existe != null)
        {
            _contexto.Entry(existe).CurrentValues.SetValues(venta);
            return _contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Venta venta)
    {
        if (!Existe(venta.VentaId))
            return this.Insertar(venta);
        else
            return this.Modificar(venta);
    }

    public bool Eliminar(int ventaId)
    {
        var eliminar = _contexto.Venta.Where(o => o.VentaId == ventaId).SingleOrDefault();

        if (eliminar != null)
        {
            foreach (var item in eliminar.VentaDetalle)
            {
                var Teni = _contexto.Tenis.FirstOrDefault(t => t.MarcaId == item.MarcaId && t.Color == item.Color && t.Size == item.Size);
                if (Teni != null)
                {
                    Teni.Existencia += item.Cantidad;
                    _contexto.Entry(Teni).State = EntityState.Modified;
                    _contexto.SaveChanges();
                }
            }

            _contexto.RemoveRange(eliminar.VentaDetalle);
            _contexto.Entry(eliminar).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    void InsertarDetalle(Venta venta)
    {
        if (venta.VentaDetalle != null)
        {
            foreach (var item in venta.VentaDetalle)
            {
                var Teni = _contexto.Tenis.FirstOrDefault(t => t.MarcaId == item.MarcaId && t.Color == item.Color && t.Size == item.Size);
                if (Teni != null)
                {
                    Teni.Existencia -= item.Cantidad;
                    _contexto.Entry(Teni).State = EntityState.Modified;
                }
            }
            _contexto.SaveChanges();
        }
    }

    void ModificarDetalle(Venta venta)
    {
        var VentaAnterior = _contexto.Venta.Where(o => o.VentaId == venta.VentaId).Include(o => o.VentaDetalle).AsNoTracking().SingleOrDefault();

        if (VentaAnterior != null)
        {
            foreach (var item in VentaAnterior.VentaDetalle)
            {
                var Teni = _contexto.Tenis.FirstOrDefault(t => t.MarcaId == item.MarcaId && t.Color == item.Color && t.Size == item.Size);
                if (Teni != null)
                {
                    Teni.Existencia += item.Cantidad;
                    _contexto.Entry(Teni).State = EntityState.Modified;
                    _contexto.SaveChanges();

                }
            }
        }

        foreach (var item in venta.VentaDetalle)
        {
            var Teni = _contexto.Tenis.FirstOrDefault(t => t.MarcaId == item.MarcaId && t.Color == item.Color && t.Size == item.Size);
            if (Teni != null)
            {
                Teni.Existencia -= item.Cantidad;
                _contexto.Entry(Teni).State = EntityState.Modified;
                _contexto.SaveChanges();

            }
        }
    }

    public Venta? Buscar(int ventaId)
    {
        return _contexto.Venta.Include(o => o.VentaDetalle).Where(o => o.VentaId == ventaId).SingleOrDefault();
    }

    public List<Venta> GetList(Expression<Func<Venta, bool>> criterio)
    {
        return _contexto.Venta.AsNoTracking().Where(criterio).ToList();
    }

}