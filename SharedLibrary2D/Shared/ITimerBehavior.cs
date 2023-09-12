using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedLibrary2D
{
    public interface ITimerBehavior
    {

        bool implementAction(Action result, bool bool_result);
        void Behave(Action Behavior);
    }
}
