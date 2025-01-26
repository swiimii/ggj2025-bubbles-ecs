using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

[CreateAssetMenu(fileName = "BubbleMaterialLibrary", menuName = "Scriptable Objects/BubbleMaterialLibrary")]
public class BubbleMaterialLibrary : ScriptableObject
{
    public List<Material> materials;
    public static BubbleMaterialLibrary Singleton;

    private void OnEnable()
    {
        Singleton = this;
        Debug.Log("Color Library Singleton!");
    }

    public static UnityEngine.Color GetColorForRank( int rank )
    {
        if(rank <= Singleton.materials.Count )
        {
            // Debug.Log("Color: " + Singleton.materials[rank - 1].color);
            return Singleton.materials[rank - 1].color;
        }

        Debug.LogError("Invalid rank provided");
        return Singleton.materials[0].color;
    }
}
