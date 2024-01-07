namespace Microservice_Auth
{
    public class ApiKeyAuthHandler
    {
        private readonly RequestDelegate next;

        public ApiKeyAuthHandler(RequestDelegate next) {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("unauthorized");
                return;
            }

            var apiKey = context.Request.Headers["Authorization"].ToString();

            if(string.IsNullOrEmpty(apiKey) || !string.Equals(apiKey,"api_1234567890",StringComparison.InvariantCulture))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("unauthorized");
                return;
            }

            context.Request.Headers.Add("Account", "12345");
            await next(context);
        }
    }
}
