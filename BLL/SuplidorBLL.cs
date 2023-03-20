using System.Linq.Expressions;

public class SuplidorBLL
{
    private Contexto _contexto;

    public SuplidorBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int suplidorId)
    {
        return _contexto.Suplidor.Any(o => o.SuplidorId == suplidorId);
    }

    private bool Insertar(Suplidor suplidor)
    {
        _contexto.Suplidor.Add(suplidor);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Suplidor suplidor)
    {
        var existe = _contexto.Suplidor.Find(suplidor.SuplidorId);
        if(existe != null)
        {
            _contexto.Entry(existe).CurrentValues.SetValues(suplidor);
            return _contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Suplidor suplidor)
    {
        if (!Existe(suplidor.SuplidorId))
            return this.Insertar(suplidor);
        else
            return this.Modificar(suplidor);
    }

    public bool Eliminar(int suplidorId)
    {
        var eliminado = _contexto.Suplidor.Where(o => o.SuplidorId == suplidorId).SingleOrDefault();

        if (eliminado != null)
        {
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public Suplidor? Buscar(int suplidorId)
    {
        return _contexto.Suplidor.Where(o => o.SuplidorId == suplidorId).AsNoTracking().SingleOrDefault();
    }

    public List<Suplidor> GetList(Expression<Func<Suplidor, bool>> criterio)
    {
        return _contexto.Suplidor.AsNoTracking().Where(criterio).ToList();
    }
}