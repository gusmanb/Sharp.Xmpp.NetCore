### Introduction

This repository contains an easy-to-use and well-documented .NET assembly for communicating with
an XMPP server. It supports basic Instant Messaging and Presence funtionality as well as a variety
of XMPP extensions.


### Supported XMPP Features

The library fully implements the [XMPP Core](http://xmpp.org/rfcs/rfc3920.html) and 
[XMPP IM](http://xmpp.org/rfcs/rfc3921.html) specifications and thusly provides the basic XMPP instant
messaging (IM) and presence functionality. In addition, the library offers support for most of the
optional procotol extensions. More specifically, the following features are supported:

+ SASL Authentication (PLAIN, DIGEST-MD5, and SCRAM-SHA-1)
+ User Avatars
+ SOCKS5 and In-Band File-Transfer
+ In-Band Registration
+ User Mood
+ User Tune
+ User Activity
+ Simplified Blocking
+ API designed to be very easy to use
+ Well documented with lots of example code
+ Free to use in commercial and personal projects (MIT License)


### Where to get it

You can always get the latest binary package on [Nuget](http://www.nuget.org/packages/S22.Xmpp) or
download the binaries as a .zip archive from [GitHub](http://smiley22.github.com/Downloads/S22.Xmpp.zip). 
The [documentation](http://smiley22.github.com/S22.Xmpp/Documentation/) is also available for offline viewing 
as HTML or CHM and can be downloaded from 
[here](http://smiley22.github.com/Downloads/S22.Xmpp.Html.Documentation.zip) and 
[here](http://smiley22.github.com/Downloads/S22.Xmpp.Chm.Documentaton.zip), respectively.


### Usage & Examples

To use the library add the S22.Xmpp.dll assembly to your project references in Visual Studio. Here's
a simple example that initializes a new instance of the XmppClient class and connects to an XMPP
server:

	using System;
	using S22.Xmpp;
	using S22.Xmpp.Client;

	namespace Test {
		class Program {
			static void Main(string[] args) {
				/* connect on port 5222 using TLS/SSL if available */
				using (var client = new XmppClient("jabber.se", "username", "password"))
				{
					Console.WriteLine("Connected as " + client.Jid);
				}
			}
		}
	}

Please see the [documentation](http://smiley22.github.com/S22.Xmpp/Documentation/) for a getting started
guide, examples and details on using the classes and methods exposed by the S22.Xmpp assembly.


### Credits

The Sharp.Xmpp library is copyright © 2015 Panagiotis Georgiou Stathopoulos.
The initial S22.Xmpp library is copyright © 2013-2014 Torben Könke.


### License

This library is released under the [MIT license](https://github.com/pgstath/Sharp.Xmpp/blob/master/License.md).


### Bug reports

Please send your bug reports to [pgstath@gmail.com](mailto:pgstath@gmail.com) or create a new
issue on the GitHub project homepage.
