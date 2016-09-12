using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Goudkoorts
{
    class MusicController
    {
         private Thread Thread { get; set; }

        private ManualResetEventSlim Mutex { get; set; }

        public MusicController()
        {
            this.Mutex = new ManualResetEventSlim(false);

            this.Thread = new Thread(this.PlayThread);
            this.Thread.Start();
        }

        public void Play()
        {
            this.Mutex.Set();
        }

        public void Stop()
        {
            this.Mutex.Reset();
        }

        private static IEnumerable<Action> PlaySong()
        {
            yield return () => Console.Beep(658, 125);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(990, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1188, 250);
            yield return () => Console.Beep(1320, 125);
            yield return () => Console.Beep(1188, 125);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(990, 250);
            yield return () => Console.Beep(880, 500);
            yield return () => Console.Beep(880, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(1188, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(990, 750);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1188, 500);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(1056, 500);
            yield return () => Console.Beep(880, 500);
            yield return () => Console.Beep(880, 500);
            yield return () => Thread.Sleep(250);
            yield return () => Console.Beep(1188, 500);
            yield return () => Console.Beep(1408, 250);
            yield return () => Console.Beep(1760, 500);
            yield return () => Console.Beep(1584, 250);
            yield return () => Console.Beep(1408, 250);
            yield return () => Console.Beep(1320, 750);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(1188, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(990, 500);
            yield return () => Console.Beep(990, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1188, 500);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(1056, 500);
            yield return () => Console.Beep(880, 500);
            yield return () => Console.Beep(880, 500);
            yield return () => Thread.Sleep(500);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(990, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1188, 250);
            yield return () => Console.Beep(1320, 125);
            yield return () => Console.Beep(1188, 125);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(990, 250);
            yield return () => Console.Beep(880, 500);
            yield return () => Console.Beep(880, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(1188, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(990, 750);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1188, 500);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(1056, 500);
            yield return () => Console.Beep(880, 500);
            yield return () => Console.Beep(880, 500);
            yield return () => Thread.Sleep(250);
            yield return () => Console.Beep(1188, 500);
            yield return () => Console.Beep(1408, 250);
            yield return () => Console.Beep(1760, 500);
            yield return () => Console.Beep(1584, 250);
            yield return () => Console.Beep(1408, 250);
            yield return () => Console.Beep(1320, 750);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(1188, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(990, 500);
            yield return () => Console.Beep(990, 250);
            yield return () => Console.Beep(1056, 250);
            yield return () => Console.Beep(1188, 500);
            yield return () => Console.Beep(1320, 500);
            yield return () => Console.Beep(1056, 500);
            yield return () => Console.Beep(880, 500);
            yield return () => Console.Beep(880, 500);
            yield return () => Thread.Sleep(500);
            yield return () => Console.Beep(660, 1000);
            yield return () => Console.Beep(528, 1000);
            yield return () => Console.Beep(594, 1000);
            yield return () => Console.Beep(495, 1000);
            yield return () => Console.Beep(528, 1000);
            yield return () => Console.Beep(440, 1000);
            yield return () => Console.Beep(419, 1000);
            yield return () => Console.Beep(495, 1000);
            yield return () => Console.Beep(660, 1000);
            yield return () => Console.Beep(528, 1000);
            yield return () => Console.Beep(594, 1000);
            yield return () => Console.Beep(495, 1000);
            yield return () => Console.Beep(528, 500);
            yield return () => Console.Beep(660, 500);
            yield return () => Console.Beep(880, 1000);
            yield return () => Console.Beep(838, 2000);
            yield return () => Console.Beep(660, 1000);
            yield return () => Console.Beep(528, 1000);
            yield return () => Console.Beep(594, 1000);
            yield return () => Console.Beep(495, 1000);
            yield return () => Console.Beep(528, 1000);
            yield return () => Console.Beep(440, 1000);
            yield return () => Console.Beep(419, 1000);
            yield return () => Console.Beep(495, 1000);
            yield return () => Console.Beep(660, 1000);
            yield return () => Console.Beep(528, 1000);
            yield return () => Console.Beep(594, 1000);
            yield return () => Console.Beep(495, 1000);
            yield return () => Console.Beep(528, 500);
            yield return () => Console.Beep(660, 500);
            yield return () => Console.Beep(880, 1000);
            yield return () => Console.Beep(838, 2000);
            yield return () => Thread.Sleep(500);
        }

        private void PlayThread()
        {
            while(true)
            {
                foreach (var action in PlaySong())
                {
                    if (!this.Mutex.IsSet)
                    {
                        this.Mutex.Wait();
                    }

                    action();
                }
            }
        }
    }
}
