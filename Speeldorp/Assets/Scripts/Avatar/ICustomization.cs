using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomization
{
    void SetCurrentItem();
    void ChangeItem(bool next);
}
