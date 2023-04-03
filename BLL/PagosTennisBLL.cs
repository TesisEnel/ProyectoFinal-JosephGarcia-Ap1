using System.Linq.Expressions;

public class PagosTennisBLL
{
    public Contexto _contexto;

    public PagosTennisBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int pagoId)
    {
        return _contexto.PagosTennis.Any(o => o.PagoId == pagoId);
    }

    private bool Insertar(PagosTennis pagosTennis)
    {
        InsertarDetalle(pagosTennis);
        _contexto.PagosTennis.Add(pagosTennis);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(PagosTennis pagosTennis)
    {
        //ModificarDetalle(pagosTennis);
        _contexto.Entry(pagosTennis).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(PagosTennis pagosTennis)
    {
        if (!Existe(pagosTennis.PagoId))
            return this.Insertar(pagosTennis);
        else
            return this.Modificar(pagosTennis);
    }

    public bool Eliminar(int pagoId)
    {
        var eliminado = _contexto.PagosTennis.Where(o => o.PagoId == pagoId).SingleOrDefault();

        if (eliminado != null)
        {
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public PagosTennis? Buscar(int pagoId)
    {
        return _contexto.PagosTennis.Where(o => o.PagoId == pagoId).AsNoTracking().SingleOrDefault();
    }

    public List<PagosTennis> GetList(Expression<Func<PagosTennis, bool>> criterio)
    {
        return _contexto.PagosTennis.AsNoTracking().Where(criterio).ToList();
    }

    void InsertarDetalle(PagosTennis pagosTennis)
    {
        if (pagosTennis.DetallePagosTennis != null)
        {
            foreach (var item in pagosTennis.DetallePagosTennis)
            {
                var cliente = _contexto.Cliente.Find(item.ClienteId);
                if (cliente != null)
                {
                    cliente.TotalGastado = cliente.TotalGastado + item.ValorPago;
                    _contexto.Entry(cliente).State = EntityState.Modified;
                    _contexto.SaveChanges();
                }
            }
        }
    }


}