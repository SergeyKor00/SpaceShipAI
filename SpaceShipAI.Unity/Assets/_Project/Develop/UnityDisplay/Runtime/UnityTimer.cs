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
        private List<TickableEventDelegate> _tickableEventToRemove = new List<TickableEventDelegate>();
        private List<TickableEventDelegate> _tickableEventsToAdd = new List<TickableEventDelegate>();
        public void AddSingleEvent(Action call, float waitingTime)
        {
            
        }

        public void AddTickableEvent(TickableEventDelegate call)
        {
            _tickableEventsToAdd.Add(call);
            
        }

        public void RemoveTickableEvent(TickableEventDelegate call)
        {
            _tickableEventToRemove.Add(call);
        }

        private void Update()
        {
            if (_tickableEventsToAdd.Count > 0)
            {
                _tickableEvents.AddRange(_tickableEventsToAdd);
                _tickableEventsToAdd.Clear();
            }
            
            
            foreach (var t in _tickableEvents)
            {
                t.Invoke(Time.deltaTime);
            }

            if (_tickableEventToRemove.Count > 0)
            {
                foreach (var t in _tickableEventToRemove)
                {
                    _tickableEvents.Remove(t);
                }
                _tickableEventToRemove.Clear();
            }
        }
    }
}