using UnityEngine;

namespace Game.GameEngine.GameContext
{
    public sealed class PlayerProvider : MonoBehaviour
    {
        public GameObject CurrentPlayer
        {
            get { return this.currentPlayer; }
            set { this.currentPlayer = value; }
        }

        [SerializeField]
        private GameObject currentPlayer;

        public T GetComponentOfCurrentPlayer<T>()
        {
            return this.CurrentPlayer.GetComponent<T>();
        }
    }
}