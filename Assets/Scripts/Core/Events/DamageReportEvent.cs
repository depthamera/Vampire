using UnityEngine;

namespace Depthamera.Vampire.Core.Events
{
    public readonly struct DamageReportEvent
    {
        public readonly DamageInfo Incoming;

        public readonly DamageInfo Result;

        public readonly GameObject Victim;

        public DamageReportEvent(DamageInfo incoming, DamageInfo result, GameObject victim)
        {
            Incoming = incoming;
            Result = result;
            Victim = victim;
        }
    }
}