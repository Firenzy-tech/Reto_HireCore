using System;
using System.Collections.Generic;
using System.Text;

namespace HireCore.ConsoleApp.Command
{
    public interface IAuditCommand
    {
        void Execute();
        void Undo();
        void PrintAudit();
    }
}
