using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizTalkComponents.Utils;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using IComponent = Microsoft.BizTalk.Component.Interop.IComponent;
using System.ComponentModel;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Microsoft.XLANGs.BaseTypes;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using Microsoft.BizTalk.Streaming;
using System.Text.RegularExpressions;
using BizTalkComponents.PipelineComponents.EnsureRootNodeFullTag.Internal;

namespace BizTalkComponents.PipelineComponents.EnsureRootNodeFullTag
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [System.Runtime.InteropServices.Guid("9d0e4103-4cce-4536-83fa-4a5040674ad6")]
    public partial class EnsureRootNodeFullTag : IBaseComponent, IComponent, IComponentUI, IPersistPropertyBag
    {

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            if (Disabled)
            {
                return pInMsg;
            }
            string errorMessage;
            if (!Validate(out errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            var data = pInMsg.BodyPart.GetOriginalDataStream();
            data = new XmlRootNodeTagFullStream(data);
            pContext.ResourceTracker.AddResource(data);
            pInMsg.BodyPart.Data = data;
            return pInMsg;
        }
    }
}