using System.Runtime.Serialization;
using UnityEngine;

namespace Lab
{
    [CreateAssetMenu(fileName = "PlayerModel", 
        menuName = "GameData/Models/PlayerData")]
    public sealed class PlayerData : ScriptableObject
    {
        public int _health;
        public int _maxHealth;
        public float _speed;
        public float _jumpSpeed;
        public Vector3 _position;
    }
}