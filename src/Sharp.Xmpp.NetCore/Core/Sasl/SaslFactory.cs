﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sharp.Xmpp.Core.Sasl
{
    /// <summary>
    /// A factory class for producing instances of Sasl mechanisms.
    /// </summary>
    internal static class SaslFactory
    {
        /// <summary>
        /// A dictionary of Sasl mechanisms registered with the factory class.
        /// </summary>
        private static Dictionary<string, Type> Mechanisms
        {
            get;
            set;
        }

        /// <summary>
        /// Creates an instance of the Sasl mechanism with the specified
        /// name.
        /// </summary>
        /// <param name="name">The name of the Sasl mechanism of which an
        /// instance will be created.</param>
        /// <returns>An instance of the Sasl mechanism with the specified name.</returns>
        /// <exception cref="ArgumentNullException">The name parameter is null.</exception>
        /// <exception cref="SaslException">A Sasl mechanism with the
        /// specified name is not registered with Sasl.SaslFactory.</exception>
        public static SaslMechanism Create(string name)
        {
            name.ThrowIfNull("name");
            if (!Mechanisms.ContainsKey(name))
            {
                throw new SaslException("A Sasl mechanism with the specified name " +
                    "is not registered with Sasl.SaslFactory.");
            }
            Type t = Mechanisms[name];
            object o = Activator.CreateInstance(t, true);
            return o as SaslMechanism;
        }

        /// <summary>
        /// Registers a Sasl mechanism with the factory using the specified name.
        /// </summary>
        /// <param name="name">The name with which to register the Sasl mechanism
        /// with the factory class.</param>
        /// <param name="t">The type of the class implementing the Sasl mechanism.
        /// The implementing class must be a subclass of Sasl.SaslMechanism.</param>
        /// <exception cref="ArgumentNullException">The name parameter or the t
        /// parameter is null.</exception>
        /// <exception cref="ArgumentException">The class represented by the
        /// specified type does not derive from Sasl.SaslMechanism.</exception>
        /// <exception cref="SaslException">The Sasl mechanism could not be
        /// registered with the factory. Refer to the inner exception for error
        /// details.</exception>
        public static void Add(string name, Type t)
        {
            name.ThrowIfNull("name");
            t.ThrowIfNull("t");

            var tInfo = t.GetTypeInfo();

            if (!tInfo.IsSubclassOf(typeof(SaslMechanism)))
            {
                throw new ArgumentException("The type t must be a subclass " +
                    "of Sasl.SaslMechanism");
            }
            try
            {
                Mechanisms.Add(name, t);
            }
            catch (Exception e)
            {
                throw new SaslException("Registration of Sasl mechanism failed.", e);
            }
        }

        /// <summary>
        /// Static class constructor. Initializes static properties.
        /// </summary>
        static SaslFactory()
        {
            Mechanisms = new Dictionary<string, Type>(
                StringComparer.OrdinalIgnoreCase);

            // Could be moved to App.config to support SASL "plug-in" mechanisms.
            var list = new Dictionary<string, Type>() {
				{ "PLAIN", typeof(Sasl.Mechanisms.SaslPlain) },
				{ "DIGEST-MD5", typeof(Sasl.Mechanisms.SaslDigestMd5) },
				{ "SCRAM-SHA-1", typeof(Sasl.Mechanisms.SaslScramSha1) },
			};
            foreach (string key in list.Keys)
                Mechanisms.Add(key, list[key]);
        }
    }
}