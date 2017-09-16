// Script by Isti

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Dollhouse.Custom.Apartment
{
    public class PowerUps : MonoBehaviour
    {
        [Header("The Player")]
        public GameObject player;

        [Header("Time Scales")]
        public float slowTimeScale;
        public float fastTimeScale;

        [Header("Transform Scales")]
        public float shrinkScaleX;
        public float shrinkScaleY;
        public float growScaleX;
        public float growScaleY;


        public enum Type
        {
            Invulnerability,
            Teleportation,
            SlowTime,
            Shrink,
            XRay,
            FastTime,
            Grow,
            Blind,
            Reverse,
            Sticky
        };
        public Type type;

        // Use this for initialization
        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (type)
            {
                case Type.Invulnerability:

                    break;
                case Type.Teleportation:

                    break;
                case Type.SlowTime:
                    Time.timeScale = slowTimeScale;
                    break;
                case Type.Shrink:
                    player.transform.localScale = new Vector3(shrinkScaleX, shrinkScaleY);
                    break;
                case Type.XRay:

                    break;
                case Type.FastTime:
                    Time.timeScale = fastTimeScale;
                    break;
                case Type.Grow:
                    player.transform.localScale = new Vector3(growScaleX, growScaleY);
                    break;
                case Type.Blind:

                    break;
                case Type.Reverse:

                    break;
                case Type.Sticky:

                    break;
                default:

                    break;
            }

        }
    }
}