using UniversalUnityHooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WelcomeToTheGame_Mod
{
    public class Class1
    {

        //public GameManager gameManager;

        //[Hook("CameraMovement.LateUpdate")]
        [Hook("HitManManager.SpawnHitman", true)]
        //public static void LateUpdate(CameraMovement cam)
        //public void SpawnHitman(HitmanSpawnDefinition SpawnData)
        public static void SpawnHitman(HitManManager HitmanManager, ref HitmanSpawnDefinition SpawnData)
        {
            //UnityEngine.Debug hDebug = new UnityEngine.Debug();
            //UnityEngine.Logger hLogger = new UnityEngine.Logger(new UnityEngine.De);
            //hLogger.Log("HitMan spawn detected!");

            /** /
                int width = Screen.width;
		        int height = Screen.height;
		        GUIStyle gUIStyle = new GUIStyle();
		        //Rect position = new Rect(0f, 0f, width, height * 2 / 100);
                Rect position = new Rect(0f, 0f, width, height * 2 / 100);
		        gUIStyle.alignment = TextAnchor.UpperLeft;
		        gUIStyle.fontSize = height * 2 / 100;
		        gUIStyle.normal.textColor = new Color(0f, 0f, 0.5f, 1f);
                string lblDbgMode_Status = "Debug Mode: Enabled";
                GUI.Label(position, lblDbgMode_Status, gUIStyle);
            /**/

            HitmanManager.DeSpawn();
            EnemyManager.Clear();
            //hLogger.Log("HitMan forced-despawn!");
        }

        [Hook("PoliceManager.TriggerPowerTrip", true)]
        public static void TriggerPowerTrip(PoliceManager policeManager)
        {
            //while (swatManObject.swatManPool.count > 0)
            //    swatManObject.swatManPool.Pop();
            //policeManager.currentActiveSwatMan
            EnemyManager.Clear();

            EnvironmentManager.PowerBehaviour.ForcePowerOn();
        }

        [Hook("GameManager.Update", true)]
        public static void Update(GameManager gameManager)
        {
            EnemyManager.PoliceManager.StopAllCoroutines();
            EnemyManager.PoliceManager.CancelInvoke();
            EnemyManager.PoliceManager.enabled = false;
            // This causes all sorts of problems! It seems to prevent you from being able to
            // exit the building, it also prevents money from accumulating and the game from
            // auto-saving!!!
                //EnemyManager.Clear();

            //GameManager.StageManager.DebugMode = true;

            /** /
                int width = Screen.width;
		        int height = Screen.height;
		        GUIStyle gUIStyle = new GUIStyle();
		        //Rect position = new Rect(0f, 0f, width, height * 2 / 100);
                Rect position = new Rect(0f, 0f, width, height * 2 / 100);
		        gUIStyle.alignment = TextAnchor.UpperLeft;
		        gUIStyle.fontSize = height * 2 / 100;
		        gUIStyle.normal.textColor = new Color(0f, 0f, 0.5f, 1f);
                string lblDbgMode_Status = "Debug Mode: Enabled";
                GUI.Label(position, lblDbgMode_Status, gUIStyle);
            /**/

            if (EnvironmentManager.PowerState == POWER_STATE.OFF)
                EnvironmentManager.PowerBehaviour.ForcePowerOn();

            //FlashLightBehaviour.Ins.UnLock();
            //float Increase = 0.15f;

            float Increase = 0.01f;
            CurrencyManager.Tick();
            CurrencyManager.AddCurrency(Increase);
            CurrencyManager.AddPendingCurrency(Increase);
            //CurrencyManager.SetCurrency(Increase);
            //CurrencyManager.AddPendingCurrency(0.0001f);
            CurrencyManager.Tick();
            //CurrencyManager.updateCurrencyText(CurrencyManager.CurrentCurrency + Increase);

        }

        [Hook("PowerBehaviour.ForcePowerOff", true)]
        public static void ForcePowerOff(PowerBehaviour powerBehaviour)
        {
            powerBehaviour.SwitchPowerOn();
        }

        [Hook("InteractionManager.LockInteraction", true)]
        public static void LockInteraction(InteractionManager interactionManager)
        {
            interactionManager.UnLockInteraction();
        }

        /** /
            [Hook("WifiHotspotObject.gameLive")]
            public static gameLive(GameManager gameMgr)
            {
                gameManager = gameMgr;
                //GameManager.
            }
        /**/

        /** /
            [Hook("TimeKeeper.updateClock")]
            public static void updateClock(TimeKeeper timeKeeper, ref int gameHour)
            {
                if (gameHour == 15)
                    gameHour = 14;
            }
        /**/
    }
}
