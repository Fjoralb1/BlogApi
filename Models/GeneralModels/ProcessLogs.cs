namespace DevAlApplication.Models.GeneralModels
{
    public class ProcessLogs
    {
        private readonly ILogger _logger;
        public ProcessLogs(ILogger logger)
        {

            _logger = logger;
        }

        public void StartLog(string methodName)
        {
            string formattedMessage = Logger.Information + "" + "Started logging for method: " + "" + methodName;
            _logger.LogInformation(formattedMessage);
        }


        public void AddLogs(string message)
        {
            string formattedMessage = "Log: " + message;
            _logger.LogInformation(formattedMessage);
        }


        public void EndLog(string methodName)
        {
            string formattedMessage = Logger.Information + "Finished logging for method: " + methodName;
            _logger.LogInformation(formattedMessage);
        }

        public IDisposable BeginScope(string methodNAme)
        {
            return _logger.BeginScope(methodNAme);
        }
    }

    public enum Logger
    {
        Information,
        Warning,
        Error
    }
}
