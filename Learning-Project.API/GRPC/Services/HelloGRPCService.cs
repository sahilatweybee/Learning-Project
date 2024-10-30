using Grpc.Core;

namespace Learning_Project.API.GRPC.Services
{
    
    public class HelloGRPCService : HelloGRPC.HelloGRPCBase
    {
        private ILogger<HelloGRPCService> _logger;

        public HelloGRPCService(ILogger<HelloGRPCService> logger)
        {
            _logger = logger;
        }


        public override Task<GreetResponse> Greet(GreetRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GreetResponse
            {
                Content = "Hello " + request.Name
            });
        }
    }
}
