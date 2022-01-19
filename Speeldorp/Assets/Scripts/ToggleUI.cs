using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _AvatarCustomization;
    public bool toggle;
    public void ToggleAC(bool toggle)
    {
        _AvatarCustomization.SetActive(toggle);
    }
    IEnumerator ToggleAvatarCustomization()
    {
        yield return new WaitForSeconds(1);
        ToggleAC(this.toggle);
    }
}
