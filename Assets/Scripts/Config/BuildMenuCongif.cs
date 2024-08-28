using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BuildMenuCongif", menuName = "Config/BuildMenuCongif")]
public class BuildMenuCongif : ScriptableObject
{
    public List<BuildItem> buildDatas = new List<BuildItem>();
}
[System.Serializable]
public class BuildItem
{
    public string name;
    public string price;
    public GameObject prefab;
}