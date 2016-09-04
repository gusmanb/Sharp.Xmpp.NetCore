﻿using System;
using System.Runtime.Serialization;

namespace Sharp.Xmpp
{
    /// <summary>
    /// The exception that is thrown when a generic XMPP error condition has been encountered.
    /// </summary>
    [Serializable()]
    public class XmppException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the XmppException class
        /// </summary>
        public XmppException() : base() { }

        /// <summary>
        /// Initializes a new instance of the XmppException class with its message
        /// string set to <paramref name="message"/>.
        /// </summary>
        /// <param name="message">A description of the error. The content of message is intended
        /// to be understood by humans.</param>
        public XmppException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the XmppException class with its message
        /// string set to <paramref name="message"/> and a reference to the inner exception that
        /// is the cause of this exception.
        /// </summary>
        /// <param name="message">A description of the error. The content of message is intended
        /// to be understood by humans.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        public XmppException(string message, Exception inner) : base(message, inner) { }

    }
}