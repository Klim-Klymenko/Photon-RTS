using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.GameEngine
{
    [RequireComponent(typeof(NetworkRunner))]
    [RequireComponent(typeof(NetworkSceneManagerDefault))]
    internal sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private NetworkRunner _runner;

        [SerializeField]
        private NetworkSceneManagerDefault _sceneManager;
        
        [SerializeField] 
        private string _sessionName;

        private void OnValidate()
        {
            _runner = GetComponent<NetworkRunner>();
            _sceneManager = GetComponent<NetworkSceneManagerDefault>();
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(0,0,200,40), "Host"))
            {
                StartGame(GameMode.Host);
            }
            
            else if (GUI.Button(new Rect(0,40,200,40), "Join"))
            {
                StartGame(GameMode.Client);
            }
        }

        private async void StartGame(GameMode gameMode)
        {
            _runner.ProvideInput = true;

            SceneRef scene = CreateScene();
            
            await _runner.StartGame(new StartGameArgs
            {
                GameMode = gameMode,
                SessionName = _sessionName,
                Scene = scene,
                SceneManager = _sceneManager
            });
        }

        private SceneRef CreateScene()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneRef scene = SceneRef.FromIndex(sceneIndex);
            return scene;
        }
    }
}