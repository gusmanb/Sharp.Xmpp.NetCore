using System;
using System.Runtime.Serialization;

namespace Sharp.Xmpp
{
    /// <summary>
    /// The exception that is thrown when a recoverable XMPP error condition
    /// has been encountered.
    /// </summary>
    [Serializable()]
    public class XmppErrorException : Exception
    {
        /// <summary>
        /// The XMPP error.
        /// </summary>
        public XmppError Error
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the XmppErrorException class
        /// </summary>
        /// <param name="error">The XMPP error that is the reason for the exception.</param>
        /// <exception cref="ArgumentNullException">The error parameter is null.</exception>
        public XmppErrorException(XmppError error)
            : base()
        {
            error.ThrowIfNull("error");
            Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the XmppErrorException class with its message
        /// string set to <paramref name="message"/>.
        /// </summary>
        /// <param name="error">The XMPP error that is the reason for the exception.</param>
        /// <param name="message">A description of the error. The content of message is intended
        /// to be understood by humans.</param>
        /// <exception cref="ArgumentNullException">The error parameter is null.</exception>
        public XmppErrorException(XmppError error, string message)
            : base(message)
        {
            error.ThrowIfNull("error");
            Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the XmppErrorException class with its message
        /// string set to <paramref name="message"/> and a reference to the inner exception that
        /// is the cause of this exception.
        /// </summary>
        /// <param name="error">The XMPP error that is the reason for the exception.</param>
        /// <param name="message">A description of the error. The content of message is intended
        /// to be understood by humans.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        /// <exception cref="ArgumentNullException">The error parameter is null.</exception>
        public XmppErrorException(XmppError error, string message, Exception inner)
            : base(message, inner)
        {
            error.ThrowIfNull("error");
            Error = error;
        }

    }
}