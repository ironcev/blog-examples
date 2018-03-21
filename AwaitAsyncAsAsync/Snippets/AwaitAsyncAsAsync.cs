using System.Threading.Tasks;

namespace Snippets
{
    class async : Task<int>
    {
        public async() : base(() => 0) { }
    }

    class AwaitAsyncAsAsync
    {
        async
        void CanYouMakeMeCompilable()
        {
            Task<Task<int>> async = null;
            var var = await async as async;
        }
    }
}
