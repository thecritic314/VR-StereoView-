/************************************************************************************

Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

See SampleFramework license.txt for license terms.  Unless required by applicable law
or agreed to in writing, the sample code is provided �AS IS� WITHOUT WARRANTIES OR
CONDITIONS OF ANY KIND, either express or implied.  See the license for specific
language governing permissions and limitations under the license.

************************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class HandedInputSelector : MonoBehaviour
{
    OVRCameraRig m_CameraRig;
    OVRInputModule m_InputModule;

    public GameObject arrow;
    ChangeSprite arrowScript;
    public GameObject menu;
    public GameObject camera_rig;
    OVRManager camera_rig_script;

    // photo distance
    public GameObject dist;
    DistancePhoto distScript;

    public float offset = 10;
    public GameObject rightEye;
    public GameObject mainCamera;

    public TextMesh debugText;

    void Start()
    {
        m_CameraRig = FindObjectOfType<OVRCameraRig>();
        m_InputModule = FindObjectOfType<OVRInputModule>();

        arrowScript = arrow.GetComponent<ChangeSprite>();
        camera_rig_script = camera_rig.GetComponent<OVRManager>();


        distScript = dist.GetComponent<DistancePhoto>();
    }

    void Update()
    {
        // if(OVRInput.GetActiveController() == OVRInput.Controller.LTouch)
        // {
        //     SetActiveController(OVRInput.Controller.LTouch);
        // }
        // else
        // {
        //     SetActiveController(OVRInput.Controller.RTouch);
        // }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch))
        {
            SetActiveController(OVRInput.Controller.RTouch);
        }

        // RIGHT
        // A BUTTON for distance
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            distScript.moveFurther();
        }
        // B BUTTON for distance
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            distScript.moveCloser();
        }

        // LEFT
        // A BUTTON for distance
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            distScript.moveFurther();
        }
        // B BUTTON for distance
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            distScript.moveCloser();
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            Debug.Log("Left centered");

            camera_rig_script = camera_rig.GetComponent<OVRManager>();
            // menu.transform.rotation = new Quaternion( -(rightEye.transform.rotation.x* 360), (rightEye.transform.rotation.y * 360), (rightEye.transform.rotation.z * 360), 1);
            // menu.transform.position = camera_rig.transform.position + camera_rig.transform.forward * offset;
            // menu.transform.rotation = new Quaternion(0.0f, camera_rig.transform.rotation.y, 0.0f, camera_rig.transform.rotation.w);

        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("Right centered");
            // arrowScript.rightClick();
        }
        debugText.text = "Clicked Rel Off Rot: " + camera_rig_script.headPoseRelativeOffsetRotation.y
        +"\n Main Camera y: " + (mainCamera.transform.rotation.y * 360)+ " \n Right Eye y: " + (rightEye.transform.rotation.y * 360);
    }

    void SetActiveController(OVRInput.Controller c)
    {
        Transform t;
        if(c == OVRInput.Controller.LTouch)
        {
            t = m_CameraRig.leftHandAnchor;
        }
        else
        {
            t = m_CameraRig.rightHandAnchor;
        }
        m_InputModule.rayTransform = t;
    }
}
