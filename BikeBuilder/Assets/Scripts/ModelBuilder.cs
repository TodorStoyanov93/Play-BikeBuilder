using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBuilder : MonoBehaviour
{
    [SerializeField] private List<GameObject> frames;
    [SerializeField] private List<Wheels> wheels;

    [SerializeField] private GameObject bike;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetFrame(string frame_id)
    {
        var frame = frames.Find(f => f.name == frame_id);
        SetFrame(frame);
    }

    public void SetFrame(GameObject newFramePrefab)
    {
        GameObject oldFrame = bike.transform.GetChild(0).gameObject;

        var front_wheel = oldFrame.transform.Find("front_wheel").gameObject.transform.GetChild(0);
        var rear_wheel = oldFrame.transform.Find("rear_wheel").gameObject.transform.GetChild(0);

        GameObject newFrame = Instantiate(newFramePrefab, bike.transform.position, bike.transform.rotation, bike.transform);

        front_wheel.SetParent(newFrame.transform.Find("front_wheel").gameObject.transform, true);
        rear_wheel.SetParent(newFrame.transform.Find("rear_wheel").gameObject.transform, true);

        Destroy(oldFrame);
    }

    public void SetWheels(string wheels_id)
    {
        var frontWheelAnchor = GameObject.FindGameObjectsWithTag("FrontWheel")[0].transform;
        var frontWheel = frontWheelAnchor.GetChild(0).gameObject;
        var rearWheelAnchor = GameObject.FindGameObjectsWithTag("RearWheel")[0].transform;
        var rearWheel = rearWheelAnchor.GetChild(0).gameObject;
        var wheelsSO = wheels.Find(w => w.name == wheels_id);

        var newFrontWheel = Instantiate(wheelsSO.frontWheelPrefab, frontWheel.transform.position, frontWheel.transform.rotation, frontWheelAnchor);
        var newRearWheel = Instantiate(wheelsSO.rearWheelPrefab, rearWheel.transform.position, rearWheel.transform.rotation, rearWheelAnchor);

        Destroy(frontWheel);
        Destroy(rearWheel);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public static class TransformEx
{
    public static Transform Clear(this Transform transform)
    {
        foreach (Transform child in transform)
        {
            Object.Destroy(child.gameObject);
        }
        return transform;
    }
}
