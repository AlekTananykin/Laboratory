using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    [CreateAssetMenu(
        fileName = "PlayerSettings",
        menuName = "Data/Player/PlayerSettings")]
    public sealed class PlayerData : ScriptableObject
    {
        [SerializeField] private float _speed;
        public float Speed { get => _speed; set => _speed = value; }

    }
}
