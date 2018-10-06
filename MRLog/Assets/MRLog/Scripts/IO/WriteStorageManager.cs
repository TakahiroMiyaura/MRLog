// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Threading.Tasks;
using Com.Reseul.Log4MR.Commons;
using Com.Reseul.Log4MR.IO;

namespace Assets.Log4WinMR.Scripts.IO
{
    /// <summary>
    /// ログファイルをストレージに出力するための管理クラス。
    /// </summary>
    public class WriteStorageManager
    {
        /// <summary>
        /// 同期用のロックオブジェクト
        /// </summary>
        private static readonly object _lockObject = new object();

        /// <summary>
        /// このクラスの唯一のインスタンを保持するフィールド
        /// </summary>
        private static WriteStorageManager _manager;

        /// <summary>
        /// ストレージにログを出力する<see cref="WriteStorageBase"/>を継承したオブジェクトを持つフィールド
        /// </summary>
        private WriteStorageBase _writeStorage;

        /// <summary>
        /// <see cref="WriteStorageManager"/>のインスタンスを取得します。
        /// </summary>
        public static WriteStorageManager Instance
        {
            get
            {
                if (_manager == null)
                    lock (_lockObject)
                    {
                        if (_manager == null) _manager = new WriteStorageManager();
                    }

                return _manager;
            }
        }

        private WriteStorageManager()
        {
            //TODO:ログのローテーションタイプに応じて使用するWriteStorageBaseを変更する。
            _writeStorage = new SizeRotationWriteStorage(new WriteFile(null));
        }

        /// <summary>
        /// ログ内容を同期的にストレージに出力する
        /// </summary>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public void WriteStorage(MRLogMessageData logMessage)
        {
            _writeStorage.WriteStorage(StorageInfo.Instance, logMessage);
        }

        /// <summary>
        /// ログ内容を非同期的にストレージに出力する
        /// </summary>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public async Task WriteStorageAsync(MRLogMessageData logMessage)
        {
            await _writeStorage.WriteStorageAsync(StorageInfo.Instance, logMessage);
        }
    }
}