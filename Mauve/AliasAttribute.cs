using System;
using System.Collections.Generic;
using System.Linq;

namespace Mauve
{
    /// <summary>
    /// An <see cref="Attribute"/> designed for aliasing objects and their members.
    /// </summary>
    public class AliasAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// The aliases assigned to the object or member this attribute is applied to.
        /// </summary>
        public IReadOnlyList<string> Values { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="AliasAttribute"/> instance with the specified aliases.
        /// </summary>
        /// <param name="aliases">The aliases assigned to the object or member this attribute is applied to.</param>
        public AliasAttribute(params string[] aliases) =>
            Values = aliases.ToList().AsReadOnly();

        #endregion

    }
}
