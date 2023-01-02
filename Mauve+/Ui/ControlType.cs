namespace Mauve.Ui
{
    /// <summary>
    /// Represents an <see langword="enum"/> containing values which represent basic controls in a user interface.
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// Represents an unspecified or unsupported <see cref="ControlType"/>.
        /// </summary>
        None = 0,
        /// <summary>
        /// A toggle based control used to handle <see langword="bool"/> values (e.g. switches, toggles, checkboxes, radio buttons).
        /// </summary>
        Toggle = 1,
        /// <summary>
        /// A text based control capable of manipulating <see langword="string"/> values.
        /// </summary>
        Textbox = 2,
        /// <summary>
        /// A selection focused control capable of selecting one or more values from a collection.
        /// </summary>
        Dropdown = 3,
        /// <summary>
        /// A control capable of handling values within a range.
        /// </summary>
        Slider = 4,
        /// <summary>
        /// A control capable of handling complex data.
        /// </summary>
        Picker = 5
    }
}
