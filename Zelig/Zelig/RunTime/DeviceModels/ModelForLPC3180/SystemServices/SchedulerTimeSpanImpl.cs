//
// Copyright (c) Microsoft Corporation.    All rights reserved.
//

namespace Microsoft.DeviceModels.Chipset.LPC3180.Runtime
{
    using System;

    using RT = Microsoft.Zelig.Runtime;
    using TS = Microsoft.Zelig.Runtime.TypeSystem;


    //
    // We use the RTC time resolution for the internal time.
    //
    [RT.ExtendClass(typeof(RT.SchedulerTimeSpan), NoConstructors=true)]
    public struct SchedulerTimeSpanImpl
    {
        //
        // Helper Methods
        //

        private static long ConvertFromMillisecondsToDeltaUnits( long milliSeconds )
        {
            return (long)((double)milliSeconds * RatioFromMillisecondsToDeltaUnits);
        }

        private static long ConvertFromTimeSpanTicksToDeltaUnits( long ticks )
        {
            return (long)((double)ticks * RatioFromTimeSpanTicksToDeltaUnits);
        }

        private static long ConvertFromDeltaUnitsToTimeSpanTicks( long deltaUnits )
        {
            return (long)((double)deltaUnits * RatioFromDeltaUnitsToTimeSpanTicks);
        }

        private static long ConvertFromDeltaUnitsToMilliseconds( long deltaUnits )
        {
            return (long)((double)deltaUnits * RatioFromDeltaUnitsToMilliseconds);
        }

        //
        // Access Methods
        //

        static int HardwareClockFrequency
        {
            [RT.Inline]
            get
            {
                return (int)RT.Configuration.RealTimeClockFrequency;
            }
        }

        static double RatioFromMillisecondsToDeltaUnits
        {
            [RT.Inline]
            get
            {
                return (double)HardwareClockFrequency / (double)1000;
            }
        }

        static double RatioFromTimeSpanTicksToDeltaUnits
        {
            [RT.Inline]
            get
            {
                return (double)HardwareClockFrequency / (double)TimeSpan.TicksPerSecond;
            }
        }

        static double RatioFromDeltaUnitsToMilliseconds
        {
            [RT.Inline]
            get
            {
                return 1.0 / RatioFromMillisecondsToDeltaUnits;
            }
        }

        static double RatioFromDeltaUnitsToTimeSpanTicks
        {
            [RT.Inline]
            get
            {
                return 1.0 / RatioFromTimeSpanTicksToDeltaUnits;
            }
        }
    }
}