﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace $safeprojectname$
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        // TODO: Harmonyを使用する場合は、コメントを解除してYourGitHubをGitHubのアカウント名に変更するか、"com.company.project.product "という形式を使用するようにしてください
        //       また、Libs フォルダに Harmony アセンブリへの参照を追加する必要があります
        // public const string HarmonyId = "com.github.YourGitHub.$safeprojectname$";
        // internal static readonly HarmonyLib.Harmony harmony = new HarmonyLib.Harmony(HarmonyId);

        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static $safeprojectname$Controller PluginController { get { return $safeprojectname$Controller.Instance; } }

        [Init]
        /// <summary>
        /// IPAによってプラグインが最初にロードされたときに呼び出される（ゲームが開始されたとき、またはプラグインが無効な状態で開始された場合は有効化されたときのいずれか）
        /// [Init]コンストラクタを使用するメソッドや、InitWithConfigなどの通常のメソッドの前に呼び出されるメソッド
        /// [Init]は1つのコンストラクタにのみ使用してください
        /// </summary>
        public Plugin(IPALogger logger)
        {
            Instance = this;
            Plugin.Log = logger;
            Plugin.Log?.Debug("Logger initialized.");
        }

        #region BSIPA Config
        //BSIPAのConfigを使用する場合は、コメントを外してください。
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Plugin.Log?.Debug("Config loaded");
        }
        */
        #endregion


        #region Disableable

        /// <summary>
        /// プラグインが有効な場合（プラグインが有効な場合はゲーム開始時も含む）に呼び出されます
        /// </summary>
        [OnEnable]
        public void OnEnable()
        {
            new GameObject("$safeprojectname$Controller").AddComponent<$safeprojectname$Controller>();
            //ApplyHarmonyPatches();
        }

        /// <summary>
        /// プラグインが無効化されたときと、Beat Saberの終了時に呼び出される。ここで、Harmonyパッチ、GameObjects、Monobehavioursをクリーンアップすることが重要です
        /// ゲームは、プラグインが起動されていなかったかのような状態にする必要があります
        /// [OnDisable]と書かれたメソッドは、voidかTaskを返さなければなりません
        /// </summary>
        [OnDisable]
        public void OnDisable()
        {
            if(PluginController != null)
                GameObject.Destroy(PluginController);
            //RemoveHarmonyPatches();
        }

        /*
        /// <summary>
        /// プラグインが無効化されたときと、Beat Saberの終了時に呼び出される
        /// プラグインを無効にするために、長時間実行する非同期作業が必要なときのために、Taskを返します
        /// Taskを返す[OnDisable]メソッドは、voidを返すすべての[OnDisable]メソッドの後に呼び出されます
        /// </summary>
        [OnDisable]
        public async Task OnDisableAsync()
        {
            await LongRunningUnloadTask().ConfigureAwait(false);
        }
        */
        #endregion

        // Harmonyを使用する場合は、このセクションのメソッドのコメントを外します
        #region Harmony
        /*
        /// <summary>
        /// このアセンブリに含まれるすべてのHarmonyパッチを適用しようとします
        /// </summary>
        internal static void ApplyHarmonyPatches()
        {
            try
            {
                Plugin.Log?.Debug("Applying Harmony patches.");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Plugin.Log?.Error("Error applying Harmony patches: " + ex.Message);
                Plugin.Log?.Debug(ex);
            }
        }

        /// <summary>
        /// 私たちのHarmonyIdを使用したすべてのHarmonyパッチの削除を試みます
        /// </summary>
        internal static void RemoveHarmonyPatches()
        {
            try
            {
                // Removes all patches with this HarmonyId
                harmony.UnpatchAll(HarmonyId);
            }
            catch (Exception ex)
            {
                Plugin.Log?.Error("Error removing Harmony patches: " + ex.Message);
                Plugin.Log?.Debug(ex);
            }
        }
        */
        #endregion
    }
}
