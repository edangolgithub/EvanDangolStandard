using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvanDangol
{
    public interface ICalculator
    {
        int Add(int Number1, int Number2);
    };

    // Interface implementation.
    public class ManagedClass : ICalculator
    {
        public int Add(int Number1, int Number2)
        {
            return Number1 * Number2;
        }
    }
}
