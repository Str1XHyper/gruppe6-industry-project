using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryCustomization : Customization
{
    [SerializeField]
    private List<Texture> textures;
    public RawImage texturepreview;
    public RawImage textureimage;
    public int textureindex;
    public override void ChangeItem(bool next)
    {
        //Check if the next option is true, otherwhise it will go to the previous color
        if (next)
        {
            index++;
            if (index > (textures.Count - 1))
            {
                index = 0;
            }
        }
        else
        {
            index--;
            if (index < 0)
            {
                index = (textures.Count - 1);
            }
        }
        SetCurrentItem();
    }

    public override void SetCurrentItem()
    {
        CheckIfEmpty();
        texturepreview.texture = textures[index];
        textureimage.texture = texturepreview.texture;
    }

    void CheckIfEmpty()
    {
        if(index == 0)
        {
            textureimage.color = Color.clear;
            texturepreview.color = Color.clear;
        }
        else
        {
            textureimage.color = Color.white;
            texturepreview.color = Color.white;
        }
    }

    public override void SetRandom()
    {
        index = Random.Range(0, textures.Count);
        SetCurrentItem();
    }

}
