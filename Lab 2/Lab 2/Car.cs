using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Car : IVehicle
    {
        //fields
        double mpsVal = 0.45;
        string unit = "mph";
        //property
        public int Speed { get; set; }

        //constructor for creating random speed between 10-100
        public Car()
        {
            SetSpeed(Utility.rnd.Next(10, 100));
        }

        //methods
        public int GetSpeed()
        {
            return Speed;
        }
        
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
