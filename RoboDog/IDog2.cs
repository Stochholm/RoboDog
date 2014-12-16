using MonoBrickFirmware.Movement;
using System;
using System.Collections.Generic;
namespace RoboDog
{
    public interface IDog2
    {
      
        IMemory Memory { get; }
        int Age { get; }
        int BladderLevel { get; set; }
        string Name { get; set; }
        int Fullness { get; set; }
        int Happiness { get; set; }
        DateTime DateOfBirth { get; }
        DogEyes Eyes { get; }
        DogSound Sound { get; }        
       
        void Pee();
        void Drink();
        void Stay();
        
        string ToString();
        
    }
}
