using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.BizTalk.Streaming;
using System.IO;
using System.Xml;
namespace BizTalkComponents.PipelineComponents.EnsureRootNodeFullTag.Internal
{
    class XmlRootNodeTagFullStream : XmlTranslatorStream
    {
        public XmlRootNodeTagFullStream(Stream input)
            : base(new XmlTextReader(input))
        {            
        }

        protected override void TranslateEndElement(bool full)
        {            
            base.TranslateEndElement(full | m_reader.Depth == 0);
        }
    }
}
