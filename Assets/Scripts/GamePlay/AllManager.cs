using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllManager : MonoBehaviour
{
    public static AllManager _instance { get; private set; }
    public BuildManager buildManager;
    [SerializeField] private BuildMenuCongif _buildMenuCongif;

    public static AllManager Instance()
    {
        return _instance;
    }
    // Start is called before the first frame update
    void Start()
    {
      //  buildManager = new BuildManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
