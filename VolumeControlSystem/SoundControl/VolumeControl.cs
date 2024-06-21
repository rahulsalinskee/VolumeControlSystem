using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VolumeControlSystem.SoundControl
{
    public static class VolumeControl
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public static void SetVolume(int volume)
        {
            // Ensure volume is between 0 and 100
            volume = Math.Max(0, Math.Min(100, volume));

            // Convert to the 0-65535 range used by Windows
            uint newVolume = (uint)((65535 * volume) / 100);

            // Set the same volume for both channels
            uint stereoVolume = (newVolume & 0x0000ffff) | (newVolume << 16);

            // Set the volume
            waveOutSetVolume(IntPtr.Zero, stereoVolume);
        }
    }
}
