using Fusion;
using UnityEngine;

namespace Bullet
{
    public sealed class BulletFactory : NetworkBehaviour
    {
        [SerializeField]
        private NetworkPrefabRef _bulletPrefab;

        [SerializeField]
        private Transform _playerTransform;
        
        [SerializeField]
        private Transform _firePoint;

        [SerializeField]
        private float _bulletSpeed;
        
        public void Create()
        {
            if (Object.HasStateAuthority)
                SpawnBullet(_bulletPrefab, _firePoint.position, _firePoint.rotation);

            else if (Object.HasInputAuthority)
                RPC_BulletSpawnRequest(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
        public void RPC_BulletSpawnRequest(NetworkPrefabRef bulletPrefab, Vector3 position, Quaternion rotation)
        {
            SpawnBullet(bulletPrefab, position, rotation);
        }
        
        private void SpawnBullet(NetworkPrefabRef bulletPrefab, Vector3 position, Quaternion rotation)
        {
            NetworkObject bullet = Runner.Spawn(bulletPrefab, position, rotation);
            bullet.GetComponent<Rigidbody>().velocity = _playerTransform.forward * _bulletSpeed;
        }
    }
}