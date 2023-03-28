using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BallLauncher : MonoBehaviour
    {
        public event Action OnLaunched;
        
        [SerializeField] private float _launchSpeed = 1f;
        [SerializeField] private Rigidbody2D _ball;
        [SerializeField] private AimInputProviderBase _inputProvider;

        private void Start()
        {
            _inputProvider.OnLaunch += Launch;

            // шар будет следить за платформой
            _ball.transform.parent = transform;
        }

        // срабатывает по подписке - кто то вызвал событие OnLaunch
        private void Launch()
        {
            // отписались, чтобы больше не получать вызов
            _inputProvider.OnLaunch -= Launch;

            // вектор направления из шара в позицию мышки (прицела)
            var shootDirection = _inputProvider.GetAimTarget() - _ball.position;
            
            // делаем вектор направления в длину равным скорости запуска
            shootDirection.Normalize();
            shootDirection *= _launchSpeed;
            
            // запускаем шар с полученной силой
            _ball.transform.parent = null;
            _ball.AddForce(shootDirection, ForceMode2D.Impulse);
            
            OnLaunched?.Invoke();
        }

        // private void OnDrawGizmos()
        // {
        //     if (!Application.isPlaying) return;
        //     
        //     Gizmos.color = Color.red;
        //
        //     var targetPos = _inputProvider.GetAimTarget();
        //     var initialPos = transform.position;
        //
        //     Gizmos.DrawLine(initialPos, targetPos);
        // }
    }
}