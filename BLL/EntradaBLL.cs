using System.Linq.Expressions;
public class EntradaBLL
{
    private Contexto _contexto;

    public EntradaBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int entradaId)
    {
        return _contexto.Entrada.Any(o => o.EntradaId == entradaId);
    }

    private bool Insertar(Entrada entrada)
    {
        var Teni = _contexto.Tenis.FirstOrDefault(t => t.MarcaId == entrada.MarcaId && t.Color == entrada.Color && t.Size == entrada.Size);
        if (Teni != null)
        {
            Teni.Existencia += entrada.Cantidad;
            _contexto.Entry(Teni).State = EntityState.Modified;
            _contexto.Entrada.Add(entrada);
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    private bool Modificar(Entrada entrada)
    {
        var existe = _contexto.Entrada.Find(entrada.EntradaId);
        if (existe != null)
        {
            var Teni = _contexto.Tenis.Find(existe.MarcaId);
            if (Teni != null)
            {
                Teni.Existencia += entrada.Cantidad;
                _contexto.Entry(Teni).State = EntityState.Modified;
            }
            _contexto.Entry(existe).CurrentValues.SetValues(entrada);
            return _contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Entrada entrada)
    {
        if (!Existe(entrada.EntradaId))
            return this.Insertar(entrada);
        else
            return this.Modificar(entrada);
    }

    public bool Eliminar(int entradaId)
    {
        var eliminado = _contexto.Entrada.Where(o => o.EntradaId == entradaId).SingleOrDefault();

        if (eliminado != null)
        {
            var Teni = _contexto.Tenis.Find(eliminado.MarcaId);
            if (Teni != null && _contexto.Entrada.Any(o => o.EntradaId == entradaId))
            {
                Teni.Existencia -= eliminado.Cantidad;
                _contexto.Entry(Teni).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public Entrada? Buscar(int entradaId)
    {
        return _contexto.Entrada.Where(o => o.EntradaId == entradaId).AsNoTracking().SingleOrDefault();
    }

    public List<Entrada> GetList(Expression<Func<Entrada, bool>> criterio)
    {
        return _contexto.Entrada.AsNoTracking().Where(criterio).ToList();
    }

}