using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Customization: MonoBehaviour
{
    public int index;
    abstract public void SetCurrentItem();
    abstract public void ChangeItem(bool next);
    abstract public void SetRandom();
}
