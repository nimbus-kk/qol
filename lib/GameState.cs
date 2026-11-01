using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace nim_qol
{
    internal sealed class GameState : IMatchmakingCallbacks, IInRoomCallbacks, IPunOwnershipCallbacks, IOnEventCallback
    {
        internal bool InGame { get; private set; }
        internal bool CheatsEnabled { get; private set; }
        internal bool IsHost { get; private set; }
        internal Kobold Kobold { get; private set; }

        // !!! REALLY REALLY IMPORTANT !!!
        // DO NOT ALLOW UNHANDLED ERRORS IN HERE
        //
        // ANY UNHANDLED ERRORS IN A CALLBACK HANDLER
        // WILL STOP KOBOLDKARE FROM EXECUTING ITS OWN CALLBACK HANDLER
        // SUPER NOT GOOD!!!!!!!!

        public void OnCreatedRoom()
        {
            IsHost = true;
            CheatsEnabled = false;
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
            InGame = false;
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
        }

        public void OnJoinedRoom()
        {
            InGame = true;
            IsHost = PhotonNetwork.IsMasterClient;
            CheatsEnabled = false;

            PhotonNetwork.LocalPlayer.SetCustomProperties(
                new Hashtable
                {
                    { MyPluginInfo.PLUGIN_GUID, true }
                }
            );

            foreach (var player in PhotonNetwork.PlayerList)
            {
                Plugin.Logger.LogInfo($"Player.CustomProperties for existing player {player.NickName} ({player.UserId})");
                foreach (var entry in player.CustomProperties)
                {
                    Plugin.Logger.LogInfo($" -> {entry.Key} {entry.Value}");
                }
            }
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            InGame = false;
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
            InGame = false;
        }

        public void OnLeftRoom()
        {
            InGame = false;
        }

        public void OnPlayerEnteredRoom(Player newPlayer)
        {
            Plugin.Logger.LogInfo($"Player.CustomProperties for joining player {newPlayer.NickName} ({newPlayer.UserId})");
            foreach (var entry in newPlayer.CustomProperties)
            {
                Plugin.Logger.LogInfo($" -> {entry.Key} {entry.Value}");
            }
        }

        public void OnPlayerLeftRoom(Player otherPlayer)
        {
        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            Plugin.Logger.LogInfo($"Player.CustomProperties changed for player {targetPlayer.NickName} ({targetPlayer.UserId})");
            foreach (var entry in targetPlayer.CustomProperties)
            {
                Plugin.Logger.LogInfo($" -> {entry.Key} {entry.Value}");
            }
        }

        public void OnMasterClientSwitched(Player newMasterClient)
        {
            IsHost = newMasterClient == PhotonNetwork.LocalPlayer;
        }

        public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
        {
        }

        public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
        {
        }

        public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
        {
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code == NetworkManager.CustomCheatEvent)
            {
                CheatsEnabled = (bool)photonEvent.CustomData;
            }
        }

        internal void SetKobold(Kobold k)
        {
            Kobold = k;
            Kobold.genesChanged += OnGenesChanged;
        }

        private void OnGenesChanged(KoboldGenes newGenes)
        {
            // Plugin.Logger.LogWarning("yay gene change");
        }
    }
}