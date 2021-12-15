using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCustomization : MonoBehaviour, ICustomization
{
    [SerializeField]
    private List<Color32> backgroundColors;
    public RawImage colorpreview;
    public RawImage backgroundImage;
    public int colorindex;
    public void ChangeItem(bool next)
    {
        //Check if the next option is true, otherwhise it will go to the previous color
        if (next)
        {
            colorindex++;
            if (colorindex > (backgroundColors.Count - 1))
            {
                colorindex = 0;
            }
        }
        else
        {
            colorindex--;
            if (colorindex < 0)
            {
                colorindex = (backgroundColors.Count - 1);
            }
        }
        SetCurrentItem();                                                     
    }

    public void SetCurrentItem()
    {
        colorpreview.color = backgroundColors[colorindex];
        backgroundImage.color = colorpreview.color;
    }

}
