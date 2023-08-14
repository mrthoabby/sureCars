using Infrastructure.Interfaces;
using sureApp.Infrastructure;

namespace Infrastructure.Helpers
{
    internal class Configurator
    {
        private static readonly List<ICommand> objects = new List<ICommand>();

        public static void AddObject(ICommand obj)
        {
            objects.Add(obj);
        }
        public static void AddObjects(ICommand[] objs)
        {
            objects.AddRange(objs);
        }

        public static void ExecuteMapping()
        {
            objects.ForEach(obj => obj.ToMap() );
        }

        public static async Task ExecutePreInitializator(ApplicationDbContext context)
        {
            var tasks = objects.Select(async obj =>
            {
                await obj.PreInitializator(context);
            }).ToArray();
            await Task.WhenAll(tasks);
        }
    }
}
