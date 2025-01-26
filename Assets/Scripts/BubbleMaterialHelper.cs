using UnityEngine;

public class BubbleMaterialHelper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BubbleMaterialLibrary library;
    public static BubbleMaterialHelper Singleton;
    private void Awake()
    {
        Singleton = this;
    }

    public static UnityEngine.Color GetColorForRank(int rank)
    {
        
        if (rank <= Singleton.library.materials.Count)
        {
            return Singleton.library.materials[rank - 1];
        }

        Debug.LogError("Invalid rank provided");
        return Singleton.library.materials[0];
    }
}   