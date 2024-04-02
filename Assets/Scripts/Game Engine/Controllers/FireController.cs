using Bullet;
using Fusion;
using Fusion.Input;
using UnityEngine;

namespace GameEngine.Controllers
{
    public sealed class FireController : NetworkBehaviour
    {
        [SerializeField]
        private NetworkInputFacade _input;
        
        [SerializeField]
        private BulletFactory _bulletFactory;
        
        public override void FixedUpdateNetwork()
        {
            if (_input.IsFire)
                _bulletFactory.Create();
        }
    }
}