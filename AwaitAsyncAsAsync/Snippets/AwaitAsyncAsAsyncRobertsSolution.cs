using System.Threading.Tasks;

using async = System.Threading.Tasks.Task;

public class AwaitAsyncAsAsyncRobertsSolution
{
    async
    void CanYouMakeMeCompilable()
    {
        var async = new Task<Task>(() => new Task(() => { }));
        var var = await async as async;
    }
}