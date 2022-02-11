using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ection
{
    public class StateVariables
    {
        public static int actionNumber = 1;
        public static bool canProbkaRotate = true;
        public static bool canMovePressElement = false;
        public static bool canOpenStopor = false;
        public static bool canCloseStopor = false;
        public static bool canMoveFixedPlatform = false;
        public static bool canEnableUstanovka = false;
        public static bool canPressElement = false;
        public static bool canInterectWithTable = false;
        public static bool canOpenUzel = false;
        public static bool canCloseUzel = false;

        public static string elementOnPressPlatform = "TreePressElement";
        public static bool canResetPressuare = false;

        public static void InsertText(GameObject smallWorkWindow, Text smallWorkWindowText, string message)
        {
            smallWorkWindowText.text = message;
            smallWorkWindow.SetActive(true);
        }
    }
}
