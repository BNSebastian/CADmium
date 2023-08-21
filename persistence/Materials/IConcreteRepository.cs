using domain.Materials;

namespace persistence.Materials
{
    public interface IConcreteRepository
    {
        ICollection<Concrete> GetAll();

        Concrete Get(string className);

        Concrete GetById(int id);

        bool Exists(string className);

        bool ExistsById(int id);

        bool Create(Concrete entry);

        bool Update(Concrete entry);

        bool Delete(Concrete entry);

        bool Save();
    }
}