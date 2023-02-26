﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using UnityEngine.SceneManagement;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace $safeprojectname$
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        /// <summary>
        /// IPAによってプラグインが最初にロードされたときに呼び出される（ゲームが開始されたとき、またはプラグインが無効な状態で開始された場合は有効化されたときのいずれか）
        /// [Init]コンストラクタを使用するメソッドや、InitWithConfigなどの通常のメソッドの前に呼び出されるメソッド
        /// [Init]は1つのコンストラクタにのみ使用してください
        /// </summary>
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("$projectname$ initialized.");
        }

        #region BSIPA Config
        //BSIPAのConfigを使用する場合は、コメントを外してください。
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        */
        #endregion

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
            new GameObject("$safeprojectname$Controller").AddComponent<$safeprojectname$Controller>();

        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");

        }
    }
}
