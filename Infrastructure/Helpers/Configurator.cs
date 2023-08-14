using Infrastructure.Interfaces;
using sureApp.Infrastructure;

namespace Infrastructure.Helpers
{
    internal class Configurator
    {
        private static readonly Queue<ICommand> objectsToMap = new Queue<ICommand>();
        private static readonly Queue<ICommand> objectsToInitialice = new Queue<ICommand>();

        public static void AddObject(ICommand obj)
        {
            objectsToMap.Enqueue(obj);
            objectsToInitialice.Enqueue(obj);
        }
        public static async void ExecuteMapping()
        {
            while (objectsToMap.Count > 0)
            {
                var element = objectsToMap.Dequeue();
                element.ToMap();
            }
        }

        public static async Task ExecutePreInitializator(ApplicationDbContext context, CreateAutoincrementalEntitys counter)
        {
            while (objectsToInitialice.Count > 0)
            {
                var element = objectsToInitialice.Dequeue();
               await element.PreInitializator(context, counter);
            }
        }
    }
}
