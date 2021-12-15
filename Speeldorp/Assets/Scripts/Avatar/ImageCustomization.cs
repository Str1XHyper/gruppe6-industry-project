using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCustomization : MonoBehaviour, ICustomization
{
    [SerializeField]
    private List<Texture> textures;
    public RawImage texturepreview;
    public RawImage textureimage;
    public int textureindex;
    public void ChangeItem(bool next)
    {
        //Check if the next option is true, otherwhise it will go to the previous color
        if (next)
        {
            textureindex++;
            if (textureindex > (textures.Count - 1))
            {
                textureindex = 0;
            }
        }
        else
        {
            textureindex--;
            if (textureindex < 0)
            {
                textureindex = (textures.Count - 1);
            }
        }
        SetCurrentItem();
    }

    public void SetCurrentItem()
    {
        texturepreview.texture = textures[textureindex];
        textureimage.texture = texturepreview.texture;
    }
}
