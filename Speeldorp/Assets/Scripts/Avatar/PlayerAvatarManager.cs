using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAvatarManager : MonoBehaviour
{
    [Tooltip("All Textures")]
    public RawImage background;
    public RawImage icon;
    public RawImage eyes;
    public RawImage mouth;
    public RawImage hat;

    [Tooltip("Lists of Options")]
    [SerializeField]
    private List<Color32> backgroundColors;
    [SerializeField]
    private List<Texture> icons;
    [SerializeField]
    private List<Texture> textureEyes;
    [SerializeField]
    private List<Texture> textureMouthes;
    [SerializeField]
    private List<Texture> textureHats;

    private int backgroundIndex;
    private int iconIndex;
    private int eyesIndex;
    private int mouthIndex;
    private int hatIndex;

    [SerializeField]
    private AvatarID avatar;

    private void Start()
    {
        avatar.LoadData();
        AssignIndexes();
        Setup();

    }
    
    void AssignIndexes()
    {
        backgroundIndex = avatar.BGIndex;
        iconIndex = avatar.IconIndex;
        eyesIndex = avatar.EyesIndex;
        mouthIndex = avatar.MouthIndex;
        hatIndex = avatar.HatIndex;
    }
    void Setup()
    {
        background.color = backgroundColors[backgroundIndex];
        icon.texture = icons[iconIndex];
        eyes.texture = textureEyes[eyesIndex];
        mouth.texture = textureMouthes[mouthIndex];
        hat.texture = textureHats[hatIndex];
    }
}
