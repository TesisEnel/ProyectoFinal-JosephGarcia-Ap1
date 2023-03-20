using System.Linq.Expressions;
public class ClienteBLL{
    private Contexto _contexto;

    public ClienteBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int clienteId)
    {
        return _contexto.Cliente.Any(o => o.ClienteId == clienteId);
    }

    private bool Insertar(Cliente cliente)
    {
        _contexto.Cliente.Add(cliente);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Cliente cliente)
    {
        var existe = _contexto.Cliente.Find(cliente.ClienteId);
        if(existe != null)
        {
            _contexto.Entry(existe).CurrentValues.SetValues(cliente);
            return _contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Cliente cliente){
        if(!Existe(cliente.ClienteId))
            return this.Insertar(cliente);
        else
            return this.Modificar(cliente);
    }

    public bool Eliminar(int clienteId)
    {
        var eliminado  = _contexto.Cliente.Where(o=> o.ClienteId == clienteId).SingleOrDefault();

        if(eliminado!=null){
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public Cliente? Buscar(int clienteId)
    {
        return _contexto.Cliente.Where(o => o.ClienteId == clienteId).AsNoTracking().SingleOrDefault();
    }

    public List<Cliente> GetList(Expression<Func<Cliente, bool>> criterio)
    {
        return _contexto.Cliente.AsNoTracking().Where(criterio).ToList();
    }

}