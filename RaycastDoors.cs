using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDoors : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] Camera Camera;
    [SerializeField] string Name;
    [SerializeField] float Angle, Speed;
    bool fl;    
    // Start is called before the first frame update
    void Start()
    {
        fl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && fl)
        {
            Vector3 point = new Vector3(Camera.pixelWidth/2, Camera.pixelHeight/2, 0);
            Ray ray = Camera.ScreenPointToRay(point);
            if (Physics.Raycast(ray, out hit, 1.6f))
            {
                if(hit.transform.name.Trim().StartsWith(Name))
                {
                    fl = true;
                }
            }
        }

        if (fl)
        {
            float pY;
            pY = Mathf.MoveTowardsAngle(hit.transform.localEulerAngles.y, Angle, Speed * Time.deltaTime);
            hit.transform.localEulerAngles = new Vector3(0, pY, 0);
            if (hit.transform.localEulerAngles.y == Angle) fl = false;
        }
        
    }
}
