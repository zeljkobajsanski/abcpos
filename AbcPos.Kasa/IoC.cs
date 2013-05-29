using AbcPos.Core.Interfaces;
using AbcPos.Core.Repository;
using AbcPos.Kasa.SyncService;
using Ninject;
using ISyncService = AbcPos.Kasa.Services.ISyncService;

namespace AbcPos.Kasa
{
    public class IoC
    {
        private static readonly IoC Instance = new IoC();

        private readonly StandardKernel fKernel = new StandardKernel();

        private IoC()
        {
            fKernel.Bind<ILocalRepository>().ToMethod(x => LocalDatabasePath.GetLocalRepostiory());
            fKernel.Bind<ISyncService>().To<Services.SyncService>();
        }

        public static IoC Singleton()
        {
            return Instance;
        }

        public T Get<T>()
        {
            return fKernel.Get<T>();
        } 
    }
}