using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerMoveController : MonoBehaviour
    {
        [Range(0f, 2f)] [SerializeField] private float _speed = 1f;
        [SerializeField] private float _levelBorderX;
        
        private IHorizontalInputProvider _horizontalInputProvider;

        private void Awake()
        {
            _horizontalInputProvider = new HorizontalInputController();
        }

        private void Update()
        {
            _horizontalInputProvider.OnUpdate();
        }

        private void FixedUpdate()
        {
            var position = transform.position;
            
            position.x += _horizontalInputProvider.GetCurrentInput() * _speed;

            position.x = Mathf.Clamp(position.x, -_levelBorderX, _levelBorderX);
            
            transform.position = position;
        }
    }
}