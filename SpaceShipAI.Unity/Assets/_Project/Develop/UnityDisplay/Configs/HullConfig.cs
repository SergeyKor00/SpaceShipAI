using GamePlay.Durability.interfaces;
using UnityEngine;

namespace UnityDisplay.Runtime
{
    [CreateAssetMenu(fileName = "HullConfig", menuName = "Configs/HullConfig", order = 0)]
    public class HullConfig : ScriptableObject, IHullConfig
    {
        [SerializeField] private int _startHealth;
        [SerializeField] private float _contactRadius;

        public int StartHealth => _startHealth;

        public float ContactRadius => _contactRadius;
    }
}