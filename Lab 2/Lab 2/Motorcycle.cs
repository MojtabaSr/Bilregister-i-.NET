using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Motorcycle : IVehicle
    {
        //fields
        string unit = "mph";
        double mpsVal = 0.28;
        //property
        public int Speed { get; set; }
        

        //constructor for creating random speed between 10-100
        public Motorcycle()
        {
            SetSpeed(Utility.rnd.Next(10, 100));
        }

        //method
        public int GetSpeed()
        {
            return Speed;
        }
        //method
        public void SetSpeed(int speed)
        {
            Speed = speed;
        }
        public string GetUnit()
        {
            return unit;
        }
        public double GetMpsVal()
        {
            return mpsVal;
        }
    }
}

