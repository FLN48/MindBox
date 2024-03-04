using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MindBox
{
    public delegate void DLoggerMessage(string _message);
    public delegate void DLoggerException(string _message);
    public interface ILogger
    {
        void LogMessage(string _message);
        void LogException(string _exception);
    }
    public class LoggerToAnyOC : ILogger
    {
        public event DLoggerMessage LoggerMessage;
        public event DLoggerException LoggerException;

        public void LogMessage(string _message)
        {
            LoggerMessage?.Invoke(_message);
        }

        public void LogException(string _exception)
        {
            LoggerException?.Invoke(_exception);
        }
    }
}
