using System;
using System.Collections.Generic;
using GamePlay.Core.Interfaces;
using GamePlay.Core.Structs;
using UnityEngine;

namespace UnityDisplay.Runtime
{
    public class UnityTimer : MonoBehaviour, IGameTimer
    {
        private List<Action> _singleEvents;
        private List<TickableEventDelegate> _tickableEvents = new List<TickableEventDelegate>();
        
        public void AddSingleEvent(Action call, float waitingTime)
        {
            
        }

        public void AddTickableEvent(TickableEventDelegate call)
        {
            _tickableEvents.Add(call);
        }

        private void Update()
        {
            foreach (var t in _tickableEvents)
            {
                t.Invoke(Time.deltaTime);
            }
        }
    }
}