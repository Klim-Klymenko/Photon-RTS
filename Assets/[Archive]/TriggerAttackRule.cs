// using UnityEngine;
//
// namespace Game.GameEngine.Entities
// {
//     [RequireComponent(typeof(DealDamageComponent))]
//     public sealed class TriggerAttackRule : MonoBehaviour
//     {
//         private DealDamageComponent _dealDamageComponent;
//
//         private void Awake()
//         {
//             _dealDamageComponent = this.GetComponent<DealDamageComponent>();
//         }
//
//         private void OnTriggerEnter(Collider other)
//         {
//             _dealDamageComponent.DealDamage(other.gameObject);
//         }
//     }
// }