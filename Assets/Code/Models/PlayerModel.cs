using System.Runtime.Serialization;
using UnityEngine;

namespace Lab
{
    public sealed class PlayerModel
    {
        public int _health;
        public int _maxHealth;
        public float _speed;
        public float _jumpSpeed;
        public Vector3 _position;
    }
}