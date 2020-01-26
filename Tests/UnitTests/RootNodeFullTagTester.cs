using System;
using BizTalkComponents.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winterdom.BizTalk.PipelineTesting;
using Microsoft.BizTalk.Component;
using System.Net.Mail;
using BizTalkComponents.PipelineComponents.EnsureRootNodeFullTag;
using System.Text;
using System.IO;
namespace BizTalkComponents.PipelineComponents.EnsureRootNodeFullTag.Tests.UnitTests
{
    [TestClass]
    public class RootNodeFullTagTest
    {
        [TestMethod]
        public void TestSelfClosedRootNodeTag()
        {
            var pipeline = PipelineFactory.CreateEmptyReceivePipeline();
            var component = new EnsureRootNodeFullTag();
            pipeline.AddComponent(component, PipelineStage.Decode);                        
            var message = MessageHelper.CreateFromString(@"<TestMessage xmlns=""https://someschema"" />");
            var output = pipeline.Execute(message);
            var retStr= MessageHelper.ReadString(message);
            Assert.IsTrue(retStr.EndsWith(@"</TestMessage>"));
        }

        [TestMethod]
        public void TestFullRootNodeTag()
        {
            var pipeline = PipelineFactory.CreateEmptyReceivePipeline();
            var component = new EnsureRootNodeFullTag();
            pipeline.AddComponent(component, PipelineStage.Decode);
            var message = MessageHelper.CreateFromString(@"<TestMessage xmlns=""https://someschema""><Field1/></TestMessage>");
            var output = pipeline.Execute(message);
            var retStr = MessageHelper.ReadString(message);
            Assert.IsTrue(retStr.EndsWith(@"</TestMessage>"));
        }
    }
}
