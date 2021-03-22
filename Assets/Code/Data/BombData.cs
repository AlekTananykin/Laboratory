using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    [CreateAssetMenu(fileName ="Bomb", menuName = "GameData/Bombs")]
    public sealed class BombData: ScriptableObject
    {
        public Vector3 _position;
        public string _prefabPath;
    }
}
