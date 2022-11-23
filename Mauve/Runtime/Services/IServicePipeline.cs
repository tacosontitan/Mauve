using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see langword="interface"/> which represents a service pipeline.
    /// </summary>
    public interface IServicePipeline
    {
        /// <summary>
        /// Adds a terminal <see cref="IMiddleware"/> to the pipeline.
        /// </summary>
        /// <param name="middleware"></param>
        void Run(IMiddleware middleware);
        /// <summary>
        /// Adds a <see cref="IMiddleware"/> to the pipeline.
        /// </summary>
        /// <param name="middleware">The middleware to add.</param>
        /// <returns>The current <see cref="IServicePipeline"/> instance.</returns>
        IServicePipeline Use(IMiddleware middleware);
    }
}
