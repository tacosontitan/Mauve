using Mauve.Patterns;

namespace Mauve.Runtime.Processing
{
    public interface IPipeline<T>
    {
        /// <summary>
        /// Adds a terminal <see cref="IMiddleware{T}"/> to the pipeline.
        /// </summary>
        /// <param name="middleware"></param>
        void Run(IMiddleware<T> middleware);
        /// <summary>
        /// Adds a <see cref="IMiddleware{T}"/> to the pipeline.
        /// </summary>
        /// <param name="middleware">The middleware to add.</param>
        /// <returns>The current <see cref="IPipeline{T}"/> instance.</returns>
        IPipeline<T> Use(IMiddleware<T> middleware);
    }
}
