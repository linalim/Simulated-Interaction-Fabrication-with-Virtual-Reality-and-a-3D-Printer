using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.Extras
{
    public class DrawLineManager : MonoBehaviour
    {
        public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

        public SteamVR_Behaviour_Pose trackedObj;

        private LineRenderer currLine;

        private int numClicks = 0;

        public Vector3[] position_array;
        List<Vector3> pos_list = new List<Vector3>();

        // Update is called once per frame
        void Update()
        {
            if (spawn.GetStateDown(trackedObj.inputSource)) {
                GameObject go = new GameObject();
                currLine = go.AddComponent<LineRenderer>();

                currLine.startWidth = .1f;
                currLine.endWidth = .1f;

                numClicks = 0;
            } else if (spawn.GetState(trackedObj.inputSource)) {
                currLine.positionCount = numClicks + 1;
                currLine.SetPosition(numClicks, trackedObj.transform.position);
                numClicks++;
            }

            //for (int i = 0; i < currLine.positionCount; i++){
            //    pos_list.Add(currLine.GetPosition(i));
            //}
            //position_array = pos_list.ToArray();

            for (int i = 0; i < 50; i++){
                Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
                pos_list.Add(position);
                position_array = pos_list.ToArray();
            }
        }
    }

}

