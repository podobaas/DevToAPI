## Pull requests

1. Fork the repo and create your branch from `master`.
2. If you've added code that should be tested, add tests.
3. If you've changed APIs, update the documentation.
4. Ensure the test suite passes.
5. Issue that pull request!

## Code Style

1. Client implementation **must be** *internal* and *sealed* and inherit from interface and ClientBase class
   ```csharp
    internal sealed class NewClient: ClientBase, INewClient
   ```
2. Response models **must be** *immutable* and **must not** *inherit*
   ```csharp
    public sealed class NewClass
    {
        [JsonProperty("my_property")]
        public string MyProperty { get; private set; } 
    }
   ```
3. The endpoint **must have** documentation and link to the original documentation
   ```csharp
        /// <summary>
        /// Retrieve a list of the followers they have.
        /// </summary>
        /// <remarks>
        /// See the <a href="https://docs.dev.to/api/#operation/getFollowers">getFollowers</a> for more information
        /// </remarks>
        /// <param name="action">Query params</param>
        /// <returns></returns>
        Task<IPagination<UserFollower>> GetAsync(Action<PageQueryOption> action = null);
   ```
4. All asynchronous methods **must be** marked with the *Async* suffix

5. That's all :)