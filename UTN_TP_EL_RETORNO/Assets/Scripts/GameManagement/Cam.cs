using UnityEngine;

namespace UTN_TP.GameManagement
{
    public class Cam
    {
        public Camera cam;
        public Cam(Camera camera = null) => cam = camera ? camera : Camera.main;
    }
}
