using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CurrentlyUsedKeys
{
    //Этот класс будет даваться для каждого отдельного вида дейсвтий, что могут быть совершены игроком.
    //С каждого из таких действий будет требоваться свой ID по каторому и определяется их место в массиве.
    public string[] Latters;
}
