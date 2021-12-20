using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCustomization : Customization
{
    [SerializeField]
    private List<Color32> backgroundColors;
    public RawImage colorpreview;
    public RawImage backgroundImage;
    public int colorindex;
    public override void ChangeItem(bool next)
    {
        //Check if the next option is true, otherwhise it will go to the previous color
        if (next)
        {
            index++;
            if (index > (backgroundColors.Count - 1))
            {
                index = 0;
            }
        }
        else
        {
            index--;
            if (index < 0)
            {
                index = (backgroundColors.Count - 1);
            }
        }
        SetCurrentItem();                                                     
    }

    public override void SetCurrentItem()
    {
        colorpreview.color = backgroundColors[index];
        backgroundImage.color = colorpreview.color;
    }

    public override void SetRandom()
    {
        index = Random.Range(0, backgroundColors.Count);
        SetCurrentItem();
    }
}
