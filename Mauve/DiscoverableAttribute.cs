using System;

namespace Mauve
{
    /// <summary>
    /// Represents an <see cref="Attribute"/> that enables explicit discoverability.
    /// </summary>
    public class DiscoverableAttribute : Attribute
    {

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="DiscoverableAttribute"/> instance.
        /// </summary>
        public DiscoverableAttribute() :
            base()
        { }

        #endregion

    }
}
