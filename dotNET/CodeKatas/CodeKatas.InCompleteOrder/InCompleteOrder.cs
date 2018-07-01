using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeKatas.InCompleteOrder
{
    public static class Extensionsa
    {
        public static IEnumerable<Task<T>> InCompleteOrder<T>(this IEnumerable<Task<T>> input)
        {
            TaskCompletionSource<T>[] completions = new TaskCompletionSource<T>[input.Count()];
            int resultsSoFar = -1;

            foreach (var task in input)
            {
                task.ContinueWith(result =>
                {
                    var completionIndex = Interlocked.Increment(ref resultsSoFar);
                    var completion = new TaskCompletionSource<T>();
                    completions[completionIndex] = completion;
                    if (result.Exception != null && result.Status == TaskStatus.Faulted)
                    {
                        completion.SetException(result.Exception);
                    }
                    else if (result.Status == TaskStatus.Canceled)
                    {
                        completion.SetCanceled();
                    }
                    else
                    {
                        completion.SetResult(result.Result);
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
            }

            return completions.Select(s => s.Task).ToList();
            
        }
    }
}
