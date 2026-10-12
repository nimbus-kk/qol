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
        }

        public void OnPlayerLeftRoom(Player otherPlayer)
        {
        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
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
    }
}