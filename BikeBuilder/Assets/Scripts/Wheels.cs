using UnityEngine;

[CreateAssetMenu(fileName ="New Wheels",menuName ="BikePart/Wheels")]
public class Wheels : ScriptableObject
{
    public new string name;
    public GameObject frontWheelPrefab;
    public GameObject rearWheelPrefab;
}