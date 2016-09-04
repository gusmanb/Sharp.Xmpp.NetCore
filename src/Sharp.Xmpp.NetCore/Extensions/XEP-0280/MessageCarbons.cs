using Sharp.Xmpp.Core;
using Sharp.Xmpp.Im;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sharp.Xmpp.Extensions
{
    internal class MessageCarbons : XmppExtension
    {
        private static readonly string[] _namespaces = { "urn:xmpp:carbons:2" };
        private EntityCapabilities ecapa;

        public override IEnumerable<string> Namespaces
        {
            get { return _namespaces; }
        }

        public override Extension Xep
        {
            get { return Extension.MessageCarbons; }
        }

        public override void Initialize()
        {
            ecapa = im.GetExtension<EntityCapabilities>();
        }

        public async Task EnableCarbons(bool enable = true)
        {
            if (!await ecapa.Supports(im.Jid.Domain, Extension.MessageCarbons))
            {
                throw new NotSupportedException("The XMPP server does not support " +
                    "the 'Message Carbons' extension.");
            }
            var iq = await im.IqRequest(IqType.Set, null, im.Jid,
                Xml.Element(enable ? "enable" : "disable", _namespaces[0]));
            if (iq.Type == IqType.Error)
                throw Util.ExceptionFromError(iq, "Message Carbons could not " +
                    "be enabled.");
        }

        public MessageCarbons(XmppIm im) :
            base(im)
        {
            
        }
    }
}