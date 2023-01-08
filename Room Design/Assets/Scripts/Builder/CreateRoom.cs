using System;
using System.Collections.Generic;
using UnityEngine;

namespace Builder
{
    public class CreateRoom : MonoBehaviour
    {
        public GameObject emptyRoom;
        public GameObject livingRoom;
        public GameObject bathRoom;

        private GameObject _currentRoom;

        private void InstantiateRoom(string template)
        {
            switch (template)
            {
                case "livingRoom":
                    _currentRoom = Instantiate(livingRoom, new Vector3(0, -1, 0), Quaternion.identity);
                    return;
                case "bathRoom":
                    return;
                default:
                    _currentRoom = Instantiate(emptyRoom, new Vector3(0, -1, 0), Quaternion.identity);
                    return;
            }
        }

        private void Show(string template)
        {
            switch (template)
            {
                case "livingRoom":
                    livingRoom.transform.Translate(new Vector3(0, 99, 0));
                    return;
                case "bathRoom":
                    bathRoom.transform.Translate(new Vector3(0, 99, 0));
                    return;
                default:
                    emptyRoom.transform.Translate(new Vector3(0, 99, 0));
                    return;
            }
        }

        private void Awake()
        {
            Debug.LogFormat("Room to instantiate: {0}", StaticStorage.Template ?? "emptyRoom");
            Show(StaticStorage.Template ?? "bathRoom");
        }
    }
}