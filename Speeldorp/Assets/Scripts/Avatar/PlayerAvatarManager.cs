using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAvatarManager : MonoBehaviour
{
    [Tooltip("All Textures")]
    public SpriteRenderer background;
    public SpriteRenderer icon;
    public SpriteRenderer eyes;
    public SpriteRenderer mouth;
    public SpriteRenderer hat;

    [Tooltip("Lists of Options")]
    [SerializeField]
    private List<Color32> backgroundColors;
    [SerializeField]
    private List<Sprite> icons;
    [SerializeField]
    private List<Sprite> textureEyes;
    [SerializeField]
    private List<Sprite> textureMouthes;
    [SerializeField]
    private List<Sprite> textureHats;

    private int backgroundIndex;
    private int iconIndex;
    private int eyesIndex;
    private int mouthIndex;
    private int hatIndex;

    [SerializeField]
    private AvatarID avatar;
    public PhotonView photonView;

    private void Start()
    {
        avatar.LoadData();
        Initialize();
    }

    public void Initialize()
    {
        AssignIndexes();
        photonView.RPC("Setup", RpcTarget.All);
    }

    void AssignIndexes()
    {
        backgroundIndex = avatar.BGIndex;
        iconIndex = avatar.IconIndex;
        eyesIndex = avatar.EyesIndex;
        mouthIndex = avatar.MouthIndex;
        hatIndex = avatar.HatIndex;
    }

    [PunRPC]
    void Setup()
    {
        background.color = backgroundColors[backgroundIndex];
        icon.sprite = icons[iconIndex];
        eyes.sprite = textureEyes[eyesIndex];
        mouth.sprite = textureMouthes[mouthIndex];
        hat.sprite = textureHats[hatIndex];
    }
}
