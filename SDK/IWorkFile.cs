using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDK
{
    public interface IWorkFile
    {
        string ReadFile();

        void WriteFile(string WriteString);

    }
}
