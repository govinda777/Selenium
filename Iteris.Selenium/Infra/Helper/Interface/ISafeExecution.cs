using System;

namespace Selenium.Infra.Helper.Interface
{
    public interface ISafeExecution
    {
        void Execute(Action action);
        T Execute<T>(Func<T> action);
        void ExecuteWithEvidence(Action action);
        void ExecuteWithEvidence(string evidenceName, Action action);
        T ExecuteWithEvidence<T>(Func<T> action);
        T ExecuteWithEvidence<T>(string evidenceName, Func<T> action);
    }
}