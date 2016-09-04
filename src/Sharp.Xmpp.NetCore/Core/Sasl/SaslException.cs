﻿using System;
using System.Runtime.Serialization;

namespace Sharp.Xmpp.Core.Sasl
{
    /// <summary>
    /// The exception is thrown when a Sasl-related error or unexpected condition occurs.
    /// </summary>
    [Serializable]
    internal class SaslException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the SaslException class
        /// </summary>
        public SaslException() : base() { }

        /// <summary>
        /// Initializes a new instance of the SaslException class with its message
        /// string set to <paramref name="message"/>.
        /// </summary>
        /// <param name="message">A description of the error. The content of message is intended
        /// to be understood by humans.</param>
        public SaslException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the SaslException class with its message
        /// string set to <paramref name="message"/> and a reference to the inner exception that
        /// is the cause of this exception.
        /// </summary>
        /// <param name="message">A description of the error. The content of message is intended
        /// to be understood by humans.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public SaslException(string message, Exception inner) : base(message, inner) { }
    }
}