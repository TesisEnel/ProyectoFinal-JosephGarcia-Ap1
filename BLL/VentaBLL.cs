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
        _contexto.Venta.Add(venta);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Venta venta)
    {
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
        var eliminado = _contexto.Venta.Where(o => o.VentaId == ventaId).SingleOrDefault();

        if (eliminado != null)
        {
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public Venta? Buscar(int ventaId)
    {
        return _contexto.Venta.Where(o => o.VentaId == ventaId).AsNoTracking().SingleOrDefault();
    }

    public List<Venta> GetList(Expression<Func<Venta, bool>> criterio)
    {
        return _contexto.Venta.AsNoTracking().Where(criterio).ToList();
    }

}