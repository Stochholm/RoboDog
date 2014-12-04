﻿using System;
using System.Threading;
namespace RoboDog
{
    public interface IMotor : IMotorBase
    {
        sbyte GetSpeed();
        int GetTachoCount();
        WaitHandle PowerProfile(sbyte power, uint rampUpSteps, uint constantSpeedSteps, uint rampDownSteps, bool brake);
        WaitHandle PowerProfileTime(byte power, uint rampUpTimeMs, uint constantSpeedTimeMs, uint rampDownTimeMs, bool brake);
        void ResetTacho();
        void SetSpeed(sbyte speed);
        WaitHandle SpeedProfile(sbyte speed, uint rampUpSteps, uint constantSpeedSteps, uint rampDownSteps, bool brake);
        WaitHandle SpeedProfileTime(sbyte speed, uint rampUpTimeMs, uint constantSpeedTimeMs, uint rampDownTimeMs, bool brake);
    }
}
