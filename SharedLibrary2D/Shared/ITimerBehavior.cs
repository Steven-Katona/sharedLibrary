using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedLibrary2D
{
    public interface ITimerBehavior
    {
        void implementAction(Action<int> result, int value);
        void simpleAction(Action action);
        public int reiterativeAction(Action action, int amount);
    }
}
