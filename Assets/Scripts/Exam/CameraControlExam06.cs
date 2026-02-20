using UnityEngine;

public class CameraControlExam06 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float offset;
    public Camera targetCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 player1Pos = player1.transform.position;
        Vector3 player2Pos = player2.transform.position;

        // Student code ...

        //Set Camera Pos
        Vector3 avgPos = (player1Pos + player2Pos) / 2;
        avgPos.y = targetCamera.transform.position.y;
        targetCamera.transform.position = avgPos;

        //Set CameraSize
        float cameraToWorldLengh = Screen.width / Screen.height;

        float p1DistanceFormCam = player2Pos.x - targetCamera.transform.position.x;
        float p2DistanceFormCam = player2Pos.z - targetCamera.transform.position.z;
        p1DistanceFormCam = Mathf.Abs(p1DistanceFormCam);
        p2DistanceFormCam = Mathf.Abs(p2DistanceFormCam);

        float newCamSize = Mathf.Max(p1DistanceFormCam, p2DistanceFormCam);
        targetCamera.orthographicSize = newCamSize;
    }
}
