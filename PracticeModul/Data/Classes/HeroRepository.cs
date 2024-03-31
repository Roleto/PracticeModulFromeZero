using PracticeModul.Data.Interfaces;
using PracticeModul.Models;
namespace PracticeModul.Data.Classes
{
    public class HeroRepository : IRepository<Hero>
    {
        HeroDbContext context;

        public HeroRepository(HeroDbContext context)
        {
            this.context = context;
        }

        public void Create(Hero hero)
        {   
            var heroSameName = context.Heroes.FirstOrDefault(h => h.Name == hero.Name);

            if (heroSameName != null)
                throw new ArgumentException("Hero with this name already exists");

            context.Heroes.Add(hero);
            context.SaveChanges();
        }
        public IEnumerable<Hero> Read()
        {
            return context.Heroes;
        }

        public Hero? Read(string id)
        {
            return context.Heroes.FirstOrDefault(t => t.Id == id);
        }

        public Hero? ReadFromName(string name)
        {
            return context.Heroes.FirstOrDefault(t => t.Name == name);
        }

        public void Update(Hero item)
        {
            var old = Read(item.Id);
            old.Name = item.Name;
            old.Kast = item.Kast;
            old.Level = item.Level;
            old.HasMount = item.HasMount;
            old.Exp = item.Exp;
            old.Str = item.Str;
            old.Dex = item.Dex;
            old.Inte = item.Inte;
            old.Vit = item.Vit;
            old.Luck = item.Luck;
            context.SaveChanges();
        }
        public void Delete(string id)
        {
            Hero hero = Read(id);
            context.Heroes.Remove(hero);
            context.SaveChanges();
        }
    }
}
