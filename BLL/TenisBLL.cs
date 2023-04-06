using System.Linq.Expressions;
public class TenisBLL{
    private Contexto _contexto;

    public TenisBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int teniId)
    {
        return _contexto.Tenis.Any(o => o.TeniId == teniId);
    }

    private bool Insertar(Tenis teni)
    {
        _contexto.Tenis.Add(teni);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Tenis teni)
    {
        var existe = _contexto.Tenis.Find(teni.TeniId);
        if(existe != null)
        {
            _contexto.Entry(existe).CurrentValues.SetValues(teni);
            return _contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Tenis teni){
        if(!Existe(teni.TeniId))
            return this.Insertar(teni);
        else
            return this.Modificar(teni);
    }

    public bool Eliminar(int teniId)
    {
        var eliminado  = _contexto.Tenis.Where(o=> o.TeniId == teniId).SingleOrDefault();

        if(eliminado!=null){
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public Tenis? Buscar(int teniId)
    {
        return _contexto.Tenis.Where(o => o.TeniId == teniId).AsNoTracking().SingleOrDefault();
    }

    public List<Tenis> GetList(Expression<Func<Tenis, bool>> criterio)
    {
        return _contexto.Tenis.AsNoTracking().Where(criterio).ToList();
    }

}