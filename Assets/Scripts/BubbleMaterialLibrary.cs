using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

[CreateAssetMenu(fileName = "BubbleMaterialLibrary", menuName = "Scriptable Objects/BubbleMaterialLibrary")]
public class BubbleMaterialLibrary : ScriptableObject
{
    public List<UnityEngine.Color> materials;
}
