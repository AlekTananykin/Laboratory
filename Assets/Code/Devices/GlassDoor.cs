using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{

    public sealed class GlassDoor : MonoBehaviour, IDevice
    {
        private string _glassDoorKey = "GlassDoorKey";
        private Animator _animator;
        private bool _isDoorOpened;

        public string GetTermsOfUse()
        {
            return _glassDoorKey;
        }

        public string Operate(string key)
        {
            if (string.IsNullOrEmpty(key) || 
                0 != _glassDoorKey.CompareTo(key))
                return "Need a key to open the door!";

            if (!_isDoorOpened)
            {
                _isDoorOpened = true;
                _animator.SetBool("character_nearby", _isDoorOpened);
            }

            return "Door is opened";
        }

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _isDoorOpened = false;
        }

        private void OnTriggerExit(Collider player)
        {
            if (!player.CompareTag("Player") || !_isDoorOpened)
                return;

            if (_isDoorOpened)
                _animator.SetBool("character_nearby", false);

            _isDoorOpened = false;
        }
    }
}