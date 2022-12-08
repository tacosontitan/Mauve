using Mauve.Patterns;

namespace Mauve.Runtime.Processing
{
    internal interface IPipeline
    {
        /// <summary>
        /// Adds a terminal <see cref="IMiddleware"/> to the pipeline.
        /// </summary>
        /// <param name="middleware"></param>
        void Run<T>(IMiddleware<T> middleware);
        /// <summary>
        /// Adds a <see cref="IMiddleware"/> to the pipeline.
        /// </summary>
        /// <param name="middleware">The middleware to add.</param>
        /// <returns>The current <see cref="IPipeline"/> instance.</returns>
        IPipeline Use<T>(IMiddleware<T> middleware);
    }
}
