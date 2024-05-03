using System;
using GamePlay.Core.Structs;

namespace GamePlay.Core.Interfaces
{
    public interface IGameTimer
    {
        void AddSingleEvent(Action call, float waitingTime);

        void AddTickableEvent(TickableEventDelegate call);

        void RemoveTickableEvent(TickableEventDelegate call);
    }
}