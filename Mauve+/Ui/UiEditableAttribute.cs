using System;

namespace Mauve.Ui
{
    /// <summary>
    /// Represents an <see cref="Attribute"/> for allowing manipulation through a user interface.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class UiEditableAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// The display name to be used in the user interface.
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// The description to be given in the user interface.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The default value to be used in the user interface.
        /// </summary>
        public object DefaultValue { get; set; }
        /// <summary>
        /// The <see cref="ControlType"/> that should be used to edit in the user interface.
        /// </summary>
        public ControlType ControlType { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="UiEditableAttribute"/> using the specified display name and <see cref="ControlType"/>.
        /// </summary>
        /// <param name="displayName">The display name to be used in the user interface.</param>
        /// <param name="controlType">The <see cref="ControlType"/> that should be used to edit in the user interface.</param>
        public UiEditableAttribute(string displayName, ControlType controlType) :
            this(displayName, null, null, controlType)
        { }
        /// <summary>
        /// Creates a new instance of <see cref="UiEditableAttribute"/> using the specified display name, default value, and <see cref="ControlType"/>.
        /// </summary>
        /// <param name="displayName">The display name to be used in the user interface.</param>
        /// <param name="defaultValue">The default value to be used in the user interface.</param>
        /// <param name="controlType">The <see cref="ControlType"/> that should be used to edit in the user interface.</param>
        public UiEditableAttribute(string displayName, object defaultValue, ControlType controlType) :
            this(displayName, null, defaultValue, controlType)
        { }
        /// <summary>
        /// Creates a new instance of <see cref="UiEditableAttribute"/> using the specified display name, description, and <see cref="ControlType"/>.
        /// </summary>
        /// <param name="displayName">The display name to be used in the user interface.</param>
        /// <param name="description">The description to be given in the user interface.</param>
        /// <param name="controlType">The <see cref="ControlType"/> that should be used to edit in the user interface.</param>
        public UiEditableAttribute(string displayName, string description, ControlType controlType) :
            this(displayName, description, null, controlType)
        { }
        /// <summary>
        /// Creates a new instance of <see cref="UiEditableAttribute"/> using the specified display name, description, default value, and <see cref="ControlType"/>.
        /// </summary>
        /// <param name="displayName">The display name to be used in the user interface.</param>
        /// <param name="description">The description to be given in the user interface.</param>
        /// <param name="defaultValue">The default value to be used in the user interface.</param>
        /// <param name="controlType">The <see cref="ControlType"/> that should be used to edit in the user interface.</param>
        public UiEditableAttribute(string displayName, string description, object defaultValue, ControlType controlType)
        {
            DisplayName = displayName;
            Description = description;
            DefaultValue = defaultValue;
            ControlType = controlType;
        }

        #endregion

    }
}
