using UnityEngine;
using System.Collections;

public class DemoPlayerScript : Player {

    float initialX;
    float initialZ;

	// Use this for initialization
	void Start () {
        GeoUTMConverter gc = new GeoUTMConverter();
        gc.ToUTM(initialFakeLat, initialFakeLon);
        initialX = (float)gc.X;
        initialZ = (float)gc.Y;
        RaycastHit hit;
        Vector3 rayPosition = new Vector3(0, 10000, 0);
        if (Physics.Raycast(rayPosition, -Vector3.up, out hit)) {
            transform.position = new Vector3(0, hit.point.y, 0);
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Vector3 rayPosition = new Vector3(transform.position.x, 10000, transform.position.z);
        if (Physics.Raycast(rayPosition, -Vector3.up, out hit)) {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

        /*
        GeoUTMConverter gc = new GeoUTMConverter();
        gc.ToUTM(newLat, newLon);
        x = gc.X - initialX;
        z = gc.Y - initialZ;
        */

        if (Input.GetKey(KeyCode.W)) {
            rigidbody.AddForce(100 * transform.forward);
		} else  if (Input.GetKey(KeyCode.S)) {
			rigidbody.AddForce(-100 * transform.forward);
		}

        x = transform.position.x;
        z = transform.position.z;

	}
}
