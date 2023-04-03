using System.Linq.Expressions;
public class TennisBLL{
    private Contexto _contexto;

    public TennisBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int tenniId)
    {
        return _contexto.Tennis.Any(o => o.TenniId == tenniId);
    }

    private bool Insertar(Tennis tenni)
    {
        _contexto.Tennis.Add(tenni);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Tennis tenni)
    {
        var existe = _contexto.Tennis.Find(tenni.TenniId);
        if(existe != null)
        {
            _contexto.Entry(existe).CurrentValues.SetValues(tenni);
            return _contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Tennis tenni){
        if(!Existe(tenni.TenniId))
            return this.Insertar(tenni);
        else
            return this.Modificar(tenni);
    }

    public bool Eliminar(int tenniId)
    {
        var eliminado  = _contexto.Tennis.Where(o=> o.TenniId == tenniId).SingleOrDefault();

        if(eliminado!=null){
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public Tennis? Buscar(int tenniId)
    {
        return _contexto.Tennis.Where(o => o.TenniId == tenniId).AsNoTracking().SingleOrDefault();
    }

    public List<Tennis> GetList(Expression<Func<Tennis, bool>> criterio)
    {
        return _contexto.Tennis.AsNoTracking().Where(criterio).ToList();
    }

}