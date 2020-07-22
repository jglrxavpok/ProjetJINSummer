using System;
using JINSummer.Math;
using UnityEngine;

namespace JINSummer.DebugRendering {
    public class DebugAim : MonoBehaviour {
        public Aim aim;

        public void Update() {
            transform.rotation = Quaternion.Euler(0,0,aim.GetDirection().Angle().ToDegrees());
        }
    }
}
