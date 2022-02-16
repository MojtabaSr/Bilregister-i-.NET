using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    interface IVehicle
    {
        int Speed { get; set; }
        string GetUnit();
        double GetMpsVal();
        //method
        int GetSpeed();
        //method
        void SetSpeed(int speed);

    }
}
