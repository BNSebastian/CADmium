using domain.Materials;

namespace persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            await SeedConcreteData(context);
        }

        public static async Task SeedConcreteData(DataContext context)
        {
            // check if there are any activities in the database
            if (context.Concrete.Any()) return;

            // if there aren't any activities in the DB continue
            var concrete = new List<Concrete>
            {
                new Concrete
                {
                    Class = "C20/25",
                    CharacteristicCompressiveStrength = 20.0f,
                    CharacteristicTensileStrength = 1.5f,
                }
            };

            await context.Concrete.AddRangeAsync(concrete);
            await context.SaveChangesAsync();
        }
    }
}