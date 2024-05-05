﻿using GamePlay.Weapon;
using GamePlay.Weapon.Interfaces;
using UnityEngine;

namespace UnityDisplay.Runtime
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/WeaponConfig", order = 0)]
    public class WeaponConfig : ScriptableObject, IWeaponConfig
    {
        [SerializeField] private float _startRange;
        [SerializeField] private float _startPower;
        [SerializeField] private WeaponType _weaponType;
        [SerializeField] private float _missleLifeTime;
        [SerializeField] private float _missleSpeed;

        public float MissleLifeTime => _missleLifeTime;

        public float StartRange => _startRange;
        public float StartPower => _startPower;
        public WeaponType WeaponType => _weaponType;

        public float MissleSpeed => _missleSpeed;
    }
}