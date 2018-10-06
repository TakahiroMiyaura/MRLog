// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System;
using System.Threading;
using System.Threading.Tasks;
using Assets.Log4WinMR.Scripts.IO;
using Com.Reseul.Log4MR.Storages;

namespace Com.Reseul.Log4MR.Commons
{
    /// <summary>
    /// キャッシュされたログ情報を非同期でストレージに出力するクラス
    /// </summary>
    public class MRLogStorageWriteProcess
    {

        /// <summary>
        /// ログ情報がキャッシュされている<see cref="LogCacheStorage"/>オブジェクトを持つフィールド
        /// </summary>
        private static readonly LogCacheStorage _storage = LogCacheStorage.Instance;

        /// <summary>
        /// 非同期で実行するための<see cref="Timer"/>オブジェクトを持つフィールド
        /// </summary>
        private static Timer _writeLogTimer;

        /// <summary>
        /// 処理時点でキャッシュされているログ情報をすべてストレージに出力する。
        /// </summary>
        /// <returns></returns>
        private static async Task MessageWriteTask()
        {
            foreach (var message in _storage.DeququeAll())
                await WriteStorageManager.Instance.WriteStorageAsync(message);
        }

        /// <summary>
        /// キャッシュされているログをストレージに出力するための<see cref="Timer"/>を有効に処理を実行する。
        /// </summary>
        public static void ProcessStart()
        {
            //TODO:繰り返し間隔はパラメータ化した方がいいかも
            _writeLogTimer = new Timer(async s => { await MessageWriteTask(); },
                null, TimeSpan.FromMilliseconds(250), Timeout.InfiniteTimeSpan);
        }
    }
}