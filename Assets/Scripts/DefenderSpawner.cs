using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());//SpawnDefender(GetSquareClicked(); in updated code
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    //figure out which exact square was clicked in the game world
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition); // wherever the click position is, we convert that 
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newx = Mathf.RoundToInt(rawWorldPosition.x);
        float newy = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newx, newy); 
    }

    private void SpawnDefender(Vector2 roundedPosition)
    {
        Defender newDefender = Instantiate(defender, GetSquareClicked(), Quaternion.identity) as Defender; // spawn defender at position**
        Debug.Log(roundedPosition);
    }

    //private void SpawnDefender(Vector2 worldPosition)
    //    {
    //  GameObject newDefender = Instantiate(defenderType, worldPosition, Quaternion.identity) as GameObject; // spawn defender at position**
    //}
    
}
