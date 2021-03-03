using UnityEngine;

namespace Lab
{
    [CreateAssetMenu(fileName = "PlayerModel", 
        menuName = "GameData/Models/PlayerModel")]
    public sealed class PlayerModel : ScriptableObject
    {
        public GameObject _playerPrefab;
        public int _health;
        public int _maxHealth;
        public float _speed;
        public float _jumpSpeed;

        public Vector3 _position;

    }
}