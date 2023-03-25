using System;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IAimInputProvider
    {
        public event Action OnLaunch;
        public void OnUpdate();
        public Vector2 GetAimTarget();
    }
}