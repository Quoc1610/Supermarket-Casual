using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator, cellIndicator;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Grid grid;
    [SerializeField] private BuildMenuCongif buildMenuCongif;
    private int selectedIndex=-1;
    [SerializeField]private GameObject gridVisualization;
    private Vector3 posPlace;
    private void Start() {
        gridVisualization.SetActive(false);
    }

    private void StopPlacement()
    {
        Debug.Log("StopPlacement");
        selectedIndex=-1;
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked-=PlaceStructure;
        inputManager.OnReleased-=StopPlacement;
    }
    public void StartPlacement(int index)
    {
       Debug.Log("StartPlacement index"+index);
        selectedIndex=index;
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked+=PlaceStructure;
        inputManager.OnReleased+=StopPlacement;
    }

    private void PlaceStructure()
    {
        Debug.Log("PlaceStructure");
        //if(inputManager.IsPointerOverUI()) return;
        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPos = grid.WorldToCell(mousePos);
        
        GameObject gameObject = Instantiate(buildMenuCongif.buildDatas[selectedIndex].prefab, grid.CellToWorld(gridPos), Quaternion.identity);
        Debug.Log("PlaceStructure"+gameObject);
        posPlace=new Vector3( grid.CellToWorld(gridPos).x+.5f, grid.CellToWorld(gridPos).y, grid.CellToWorld(gridPos).z-.5f);
        gameObject.transform.position=posPlace;
    
    }

    private void Update() {
        if(selectedIndex<0) return;
        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPos = grid.WorldToCell(mousePos);
        mouseIndicator.transform.position = mousePos;
        cellIndicator.transform.position =new Vector3( grid.CellToWorld(gridPos).x, grid.CellToWorld(gridPos).y+.05f, grid.CellToWorld(gridPos).z);
    }
}
