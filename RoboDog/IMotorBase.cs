﻿using MonoBrickFirmware.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoboDog
{
   public interface IMotorBase
    {
        
            OutputBitfield BitField { get; set; }
            List<MotorPort> PortList { get; }

            void Brake();
            void CancelPolling();
            bool IsRunning();
            void Off();
            void SetPower(sbyte power);
            WaitHandle WaitForMotorsToStartAndStop();
            WaitHandle WaitForMotorsToStop();
        
    }
}
