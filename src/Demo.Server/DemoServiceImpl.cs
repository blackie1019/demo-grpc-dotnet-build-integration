using System;
using System.Threading.Tasks;
using Demo.App.Message;
using Demo.Common;
using Grpc.Core;

namespace Demo.Server
{
    public class DemoServiceImpl:DemoService.DemoServiceBase
    {
        public override Task<GreetingResponse> Say(GreetingMsg request, ServerCallContext context)
        {
            var response = new GreetingResponse
            {
                MsgValue = request.Value,
                ReturnValue = $"Received on {DateTime.Now:O}",
            };
            return Task.FromResult(response);
        }

        public override Task<TestResponse> TestWithTestMsg(TestMsg request, ServerCallContext context)
        {
            var response = new TestResponse();//new List<int>();
            var randon = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < 10; i++)
            {
  
                response.Values.Add(request.Data+randon.Next(0, 100).ToString());
            }

            return Task.FromResult(response);
        }
    }
}