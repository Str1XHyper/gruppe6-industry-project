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
    public int colorindex;

    [Header("Icon Pictures")]
    [SerializeField]
    private List<Texture> icons;
    public RawImage iconpreview;
    public RawImage iconImage;
    public int iconindex;

    // Start is called before the first frame update
    void Start()
    {
        InitializeSetup();
    }

    private void InitializeSetup()
    {
        SetColors();
        SetIcons();
    }

    private void SetIcons()
    {
        iconpreview.texture = icons[iconindex];
        iconImage.texture = iconpreview.texture;
    }

    private void SetColors()
    {
        colorpreview.color = backgroundColors[colorindex];
        backgroundImage.color = colorpreview.color;
    }
    
    public void ChangeIcon(bool next)
    {
        //Check if the next option is true, otherwhise it will go to the previous color
        if (next)
        {
            iconindex++;
            if (iconindex > (icons.Count - 1))
            {
                iconindex = 0;
            }
        }
        else
        {
            iconindex--;
            if (iconindex < 0)
            {
                iconindex = (icons.Count - 1);
            }
        }
        SetIcons();
    }

    public void ChangeColor(bool next)
    {
        //Check if the next option is true, otherwhise it will go to the previous color
        if(next)
        {
            colorindex++;
            if(colorindex > (backgroundColors.Count - 1))
            {
                colorindex = 0;
            }
        }
        else
        {
            colorindex--;
            if(colorindex < 0)
            {
                colorindex = (backgroundColors.Count - 1);
            }
        }
        SetColors();
    }
    public void Randomize()
    {
        colorindex = Random.Range(0, (backgroundColors.Count));
        iconindex = Random.Range(0, (icons.Count));
        InitializeSetup();
    }

}
