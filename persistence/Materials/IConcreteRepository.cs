using domain.Materials;

namespace persistence.Materials
{
    public interface IConcreteRepository
    {
        ICollection<Concrete> GetAll();

        Concrete Get(string className);

        Concrete GetById(int id);

        bool Exists(int id);

        bool Create(Concrete entry);

        bool Update(Concrete entry);

        bool Delete(Concrete entry);

        bool Save();
    }
}