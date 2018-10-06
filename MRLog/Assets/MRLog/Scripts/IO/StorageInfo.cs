// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

#if !UNITY_EDITOR
using Windows.Storage;
using Com.Reseul.Log4MR.Commons;
#endif

namespace Com.Reseul.Log4MR.IO
{
    public class StorageInfo
    {
        //TODO:ローテーション条件などの情報を格納する。

        /// <summary>
        ///     <see cref="T:System.Object" /> クラスの新しいインスタンスを初期化します。
        /// </summary>
        private StorageInfo()
        {
        }

        private void Load()
        {
#if !UNITY_EDITOR
            var load = MRLogSetting.Load().GetAwaiter().GetResult();
            FileName = load.FileName;
            RootPath = load.LogRootPath;
#endif
        }

        private static readonly object _lockObject = new object();
        private static StorageInfo _instance;

        public static StorageInfo Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null) _instance = new StorageInfo();
                    }

                    _instance.Load();
                }

                return _instance;
            }
        }


#if !UNITY_EDITOR
/// <summary>
/// ログファイルを出力する際のルートパスと設定取得します。
/// </summary>
        public StorageFolder RootPath { get; private set; }
#endif
        /// <summary>
        ///     ログファイル名を設定・取得します。
        /// </summary>
        public string FileName { get; private set; }
    }
}