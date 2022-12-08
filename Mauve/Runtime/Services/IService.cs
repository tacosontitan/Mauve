using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see langword="interface"/> which represents a basic service.
    /// </summary>
    public interface IService
    {

        #region General Methods

        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="dependencies">The <see cref="IDependencyCollection"/> maintained by the service.</param>
        void Configure(IDependencyCollection dependencies);

        #endregion

    }
}
