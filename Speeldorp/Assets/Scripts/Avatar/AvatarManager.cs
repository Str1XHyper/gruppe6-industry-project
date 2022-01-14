using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public List<Customization> customizables;

    [SerializeField]
    private AvatarID avatar;

    private void Start()
    {
            avatar.LoadData();
            SetUp();
    }

    public void Save()
    {
        avatar.BGIndex = customizables[0].index;
        avatar.IconIndex = customizables[1].index;
        avatar.EyesIndex = customizables[2].index;
        avatar.MouthIndex = customizables[3].index;
        avatar.HatIndex = customizables[4].index;
        avatar.SaveData();
    }

    void SetUp()
    {
        customizables[0].index = avatar.BGIndex;
        customizables[1].index = avatar.IconIndex;
        customizables[2].index = avatar.EyesIndex;
        customizables[3].index = avatar.MouthIndex;
        customizables[4].index = avatar.HatIndex;

        foreach (Customization c in customizables)
        {
            c.SetCurrentItem();
        }
    }
    public void Randomize()
    {
        foreach (Customization i in customizables)
        {
            i.SetRandom();
        }
    }
}
