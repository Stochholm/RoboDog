using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
//using MonoBrick.EV3;
using MonoBrickFirmware;
using MonoBrickFirmware.Movement;
using MonoBrickFirmware.Display;
using MonoBrickFirmware.Sound;



namespace RoboDog
{
    [Serializable]
    public abstract class AbstractDog2 : IDog2
    {
        private IMotor exMotor;
        private IMemory memory;
        public IDictionary<string, Action> combos;

        private DateTime dateOfBirth;
        private int age;
        private int bladderLevel;
        private int happiness;
        private int fullness;
        private string name;
        private DogSound sound;
        private DogEyes eyes;

        public AbstractDog2(IMemory memory, IMotor exMotor)
        {
            combos = new Dictionary<string, Action>();
            this.memory = memory;
            this.dateOfBirth = DateTime.Now;
            this.age = 0;
            this.fullness = 10;
            this.happiness = 12;
            this.bladderLevel = 0;
            this.name = "RoboDog";
            this.eyes = DogEyes.Neutral;
            this.exMotor = exMotor;
         
        }
        public AbstractDog2(IMemory memory, int fullness, int happiness, int bladderlevel, string name, DogEyes eyes)
        {
            combos = new Dictionary<string, Action>();

            this.memory = memory;
            this.dateOfBirth = DateTime.Now;
            this.age = 0;
            this.fullness = fullness;
            this.happiness = happiness;
            this.bladderLevel = bladderlevel;
            this.name = name;
            this.eyes = eyes;
           

            
        }

       


        public virtual DateTime DateOfBirth
        {
            get { return dateOfBirth; }
        }

        public virtual int Age
        {
            get { return age; }
        }

        public virtual int BladderLevel
        {
            get { return bladderLevel; }
            set { bladderLevel = value; }
        }

        public virtual int Happiness
        {
            get { return happiness; }
            set { happiness = value; }
        }

        public virtual int Fullness
        {
            get { return fullness; }
            set { fullness = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual DogEyes Eyes
        {
            get { return eyes; }
        }

        public virtual DogSound Sound
        {
            get { return sound; }
        }

        
        public virtual void Drink()
        {
           // MakeSound(DogSound.Crunching);//I don't think there is a drinking sound
            bladderLevel += 2;
          //  LcdConsole.WriteLine("Drinking");

            //make dog pee 
            if (bladderLevel > 10)
                Pee();
        }

       
        
        public virtual void Pee()
        {
            //Lift leg 
            exMotor.ResetTacho();
            exMotor.SetSpeed(20);
            exMotor.Off();

            //Motor motor = new Motor(MotorPort.OutA);
            //motor.ResetTacho();
            //motor.SetSpeed(20);
            //System.Threading.Thread.Sleep(2500);
            //motor.Off();
            //System.Threading.Thread.Sleep(2500);

            //Make peeing sound
           // MakeSound(DogSound.Pee);
           // LcdConsole.WriteLine("Peeing");
              
            //Reset bladder
            BladderLevel = 0;
        }
       
      


        public override string ToString()
        {
            return Name;
        }

        public void DoTrick(string name)
        {
            if (combos.ContainsKey(name))
            {
                combos[name].DynamicInvoke(null);
            }
        }

        public virtual IMemory Memory
        {
            get { return memory; }
        }
       
       
    }
}
