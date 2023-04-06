using System.Linq.Expressions;

public class MarcaBLL{

    private Contexto _contexto;

    public MarcaBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public Marca? Buscar(int marcaId)
    {
        return _contexto.Marca.Where(o => o.MarcaId == marcaId).AsNoTracking().SingleOrDefault();
    }
    public List<Marca> GetList(Expression<Func<Marca, bool>> criterio)
    {
        return _contexto.Marca.AsNoTracking().Where(criterio).ToList();
    }
}