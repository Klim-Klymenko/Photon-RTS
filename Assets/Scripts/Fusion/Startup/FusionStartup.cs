using System;
using System.Collections.Generic;
using Fusion.Input;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fusion.Startup
{
    [RequireComponent(typeof(NetworkRunner))]
    [RequireComponent(typeof(NetworkSceneManagerDefault))]
    internal sealed class FusionStartup : MonoBehaviour, INetworkRunnerCallbacks
    {
        [SerializeField]
        private NetworkRunner _runner;

        [SerializeField]
        private NetworkSceneManagerDefault _sceneManager;
        
        [SerializeField] 
        private string _sessionName;

        [SerializeField]
        private NetworkInputSender _networkInputSender;
        
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
            
            if (scene.IsValid)
                new NetworkSceneInfo().AddSceneRef(scene, LoadSceneMode.Additive);
            
            return scene;
        }

        void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
        {
            _networkInputSender.SendInput(ref input);
        }
        
        void INetworkRunnerCallbacks.OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }
        void INetworkRunnerCallbacks.OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }
        void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player) { }
        void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
        void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
        void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
        void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner) { }
        void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason) { }
        void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
        void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
        void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
        void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
        void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
        void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
        void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data) { }
        void INetworkRunnerCallbacks.OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress) { }
        void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner) { }
        void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner) { }
    }
}