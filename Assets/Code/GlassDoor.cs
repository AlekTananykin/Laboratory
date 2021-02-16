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

        public void Operate(string key)
        {
            if (string.IsNullOrEmpty(key) || 
                0 != _glassDoorKey.CompareTo(key))
                return;

            if (_isDoorOpened)
                return;

            _isDoorOpened = true;
            _animator.SetBool("character_nearby", _isDoorOpened);
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