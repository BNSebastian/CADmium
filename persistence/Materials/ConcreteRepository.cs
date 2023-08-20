using domain.Materials;

namespace persistence.Materials
{
    public class ConcreteRepository : IConcreteRepository
    {
        private readonly DataContext _context;

        public ConcreteRepository(DataContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public bool Create(Concrete entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));

            _context.Add(entry);
            return Save();
        }

        public bool Delete(Concrete entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));

            _context.Remove(entry);
            return Save();
        }

        public bool Exists(int id)
        {
            return _context
                .Concrete
                .Any(current => current.Id == id);
        }

        public Concrete Get(string className)
        {
            return _context
                .Concrete
                .FirstOrDefault(current => current.Class == className)!;
        }

        public Concrete GetById(int id)
        {
            return _context
                .Concrete
                .FirstOrDefault(current => current.Id == id)!;
        }

        public ICollection<Concrete> GetAll()
        {
            return _context
                .Concrete
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Concrete entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));

            _context.Update(entry);
            return Save();
        }
    }
}