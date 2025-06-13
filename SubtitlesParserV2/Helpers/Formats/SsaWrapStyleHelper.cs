﻿namespace SubtitlesParserV2.Helpers.Formats
{
	/// <summary>
	/// Represents a Wrap Style used by Advanced SSA
	/// </summary>
	// Note: the spec doc doesn't actually specify a name, just a number and a description, so I took some creative liberties
	internal enum SsaWrapStyleHelper
    {
        /// <summary>
        /// Smart wrapping, lines are evenly broken
        /// </summary>
        Smart = 0,
        /// <summary>
        /// End-of-line word wrapping, only \N breaks
        /// </summary>
        EndOfLine = 1,
        /// <summary>
        /// No word wrapping, \n \N both breaks
        /// </summary>
        None = 2,
        /// <summary>
        /// Same as Smart, but the lower line gets wider
        /// </summary>
        SmartWideLowerLine = 3
    }

    /// <summary>
    ///  Extension methods for parsing to a wrap style
    /// </summary>
    internal static class SsaWrapStyleExtensions
    {
        /// <summary>
        /// Parse a string into a wrap style
        ///
        /// Invalid input strings will return `SsaWrapStyle.None`
        /// </summary>
        /// <param name="rawString">A string representation of a wrap style value</param>
        /// <returns>A SsaWrapStyle corresponding to the value parsed from the input string</returns>
        public static SsaWrapStyleHelper FromString(this string rawString) =>
            int.TryParse(rawString, out int rawInt) == false ?
                SsaWrapStyleHelper.None : // basically an arbitrary choice, could also throw an exception here instead
                rawInt.FromInt();

        /// <summary>
        /// Parse an integer into a wrap style
        ///
        /// Integers outside the range of valid wrap styles will default to `SsaWrapStyle.None`
        /// </summary>
        /// <param name="rawInt">An integer inside the range of values representing a wrap style</param>
        /// <returns>A SsaWrapStyle corresponding to the integer value specified</returns>
        public static SsaWrapStyleHelper FromInt(this int rawInt) =>
            rawInt switch
            {
                0 => SsaWrapStyleHelper.Smart,
                1 => SsaWrapStyleHelper.EndOfLine,
                2 => SsaWrapStyleHelper.None,
                3 => SsaWrapStyleHelper.SmartWideLowerLine,
                _ => SsaWrapStyleHelper.None
            };
    }
}
