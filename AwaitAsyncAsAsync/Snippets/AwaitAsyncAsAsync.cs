using System.Threading.Tasks;

namespace Snippets
{
    public class async : Task<int>
    {
        public async() : base(() => 0) { }
    }

    public class AwaitAsyncAsAsync
    {
        async
        void CanYouMakeMeCompilable()
        {
            Task<Task<int>> async = null;
            var var = await async as async;
        }
    }
}
