using System;

namespace lamar.dependecy.injection.infrastructor.Logger
{
    public interface ILogger
    {
        void Info(string message, Exception ex = null);
    }
}