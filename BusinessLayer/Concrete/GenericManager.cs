using BusinessLayer.Abstract;
using DataAccessLayer.Abstcart;

public class GenericManager<T> : IGenericService<T> where T : class, new()
{
    private readonly IGenericDal<T> _genericDAL;

    public GenericManager(IGenericDal<T> genericDAL)
    {
        _genericDAL = genericDAL;
    }

    public void Ekle(T t)
    {
        _genericDAL.Ekle(t);
    }

    public T GetirID(int id)
    {
        return _genericDAL.GetirID(id);
    }

    public void Guncelle(T t)
    {
        _genericDAL.Guncelle(t);
    }

    public void Sil(T t)
    {
        _genericDAL.Sil(t);
    }

    public List<T> TumunuGetir()
    {
        return _genericDAL.TumunuGetir();
    }
}
