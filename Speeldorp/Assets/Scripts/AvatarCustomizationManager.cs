using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarCustomizationManager : MonoBehaviour
{
    [Header("Background Colors")]
    [SerializeField]
    private List<Color32> backgroundColors;
    public RawImage colorpreview;
    public RawImage backgroundImage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetColorToPreview();
    }

    void SetColorToPreview()
    {
        backgroundImage.color = colorpreview.color;
    }
}
