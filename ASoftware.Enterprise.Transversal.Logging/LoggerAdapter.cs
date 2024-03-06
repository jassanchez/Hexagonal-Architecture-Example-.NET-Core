﻿using ASoftware.Enterprise.Transversal.Common;
using Microsoft.Extensions.Logging;

namespace ASoftware.Enterprise.Transversal.Logging {
    public class LoggerAdapter<T> : IAppLogger<T> {

        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogError(string message, params object[] args) {
            _logger.LogError(message, args);
        }

        public void LogInfo(string message, params object[] args) {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args) {
            _logger.LogWarning(message, args);
        }
    }
}
