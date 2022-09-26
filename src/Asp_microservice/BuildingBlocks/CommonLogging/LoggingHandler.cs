using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace CommonLogging
{
    public class LoggingHandler : DelegatingHandler
    {
        private readonly ILogger<LoggingHandler> _logger;
        public LoggingHandler(ILogger<LoggingHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Sending request to {Url}", request.RequestUri);
                var response = await base.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Received as success response from {Url}", response.RequestMessage.RequestUri);

                }
                else
                {
                    _logger.LogWarning("Recieved a non - success status code {StatusCode} from {Url}",

                        (int)response.StatusCode, response.RequestMessage.RequestUri);
                }

                return response;
            }
            catch (HttpRequestException ex)
            when (ex.InnerException is SocketException se && se.SocketErrorCode == SocketError.ConnectionRefused)
            {
                var hostWithport = request.RequestUri.IsDefaultPort
                    ? request.RequestUri.DnsSafeHost
                    : $"{request.RequestUri.DnsSafeHost}:{request.RequestUri.Port}";

                _logger.LogCritical(ex, "Unable to connect {Host}.Please check the " +
                    "Configuration to ensure the correct URL for service ", hostWithport);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.BadGateway)
            {
                RequestMessage = request
            };
        }
    }
  }