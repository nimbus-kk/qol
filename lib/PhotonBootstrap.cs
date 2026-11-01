using System.Collections;
using nim_qol;
using Photon.Pun;
using UnityEngine;

public class PhotonBootstrap : MonoBehaviour
{
    private bool _registered = false;

    void Start()
    {
        StartCoroutine(WaitAndRegister());
    }

    private IEnumerator WaitAndRegister()
    {
        while (!_registered)
        {
            if (PhotonNetwork.PhotonServerSettings != null)
            {
                PhotonNetwork.AddCallbackTarget(Plugin.GameState);
                _registered = true;
                Destroy(this);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
