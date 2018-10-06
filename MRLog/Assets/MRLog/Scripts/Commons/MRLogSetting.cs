// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Com.Reseul.Log4MR.Unity;

#if !UNITY_EDITOR
using Windows.Data.Json;
using Windows.Storage;
using Windows.System;
#endif

namespace Com.Reseul.Log4MR.Commons
{
    /// <summary>
    /// <see cref="MRLog"/>でログを出力するための外部設定ファイルを読込み情報を管理するクラス
    /// </summary>
    public class MRLogSetting
    {
        /// <summary>
        /// 設定ファイルから読込んだ情報をもつ唯一の<see cref="MRLogSetting"/>インスタンス
        /// </summary>
        private static MRLogSetting _logSettings;

        /// <summary>
        /// 同期用ロックオブジェクト
        /// </summary>
        private static object _lockObject = new object();

        /// <summary>
        /// 外部設定ファイル名をもつフィールド
        /// </summary>
        private static string _logSettingsFileName = "MRLogSettings.json";

        /// <summary>
        /// ファイブ設定ファイル名を取得/設定します。
        /// </summary>
        public static string LogSettingsFileName
        {
            get { return _logSettingsFileName; }
            set { _logSettingsFileName = value; }
        }

#if !UNITY_EDITOR
        /// <summary>
        /// 外部設定ファイルが存在する<see cref="StorageFolder"/>を持つフィールド
        /// </summary>
        private static StorageFolder _logSettingStorageFolder = ApplicationData.Current.LocalFolder;

        /// <summary>
        /// 外部設定ファイルが存在する<see cref="StorageFolder"/>を取得/設定します。
        /// </summary>
        public static StorageFolder LogSettingStorageFolder
        {
            get { return _logSettingStorageFolder; }
            set { _logSettingStorageFolder = value; }
        }
#endif

        /// <summary>
        ///     設定ファイルをロードします。引数のパスについては現時点では無視しファイル名のみ使用します。
        ///     ファイルはアプリケーションのローカルフォルダに記述します。
        /// </summary>
        /// <param name="FilePath">ファイルパス</param>
        public static async Task<MRLogSetting> Load()
        {
            if (_logSettings == null)
            {
                lock (_lockObject)
                {
                    if (_logSettings == null) _logSettings = new MRLogSetting();
                }

                try
                {
#if !UNITY_EDITOR
                    var asyncOperation = await _logSettingStorageFolder.GetFileAsync(_logSettingsFileName);
                    var json = await FileIO.ReadTextAsync(asyncOperation);
                    var value = JsonValue.Parse(json);

                    _logSettings.LogRootPath = GetKnownStorageFolder(value.GetObject().GetNamedString("LogRootPath"));
                    _logSettings.LogLayout = value.GetObject().GetNamedString("LogLayout");
                    _logSettings.FileName = value.GetObject().GetNamedString("FileName");
                    _logSettings.LogLevel = value.GetObject().GetNamedString("LogLevel");
                    _logSettings.RotateType = value.GetObject().GetNamedString("RotateType");
#endif
                }
                catch (Exception e)
                {
                    Debug.Fail("Load Error:" + e);
                }
            }

            return _logSettings;
        }

#if !UNITY_EDITOR
        /// <summary>
        /// 引数の文字列に従ったフォルダに対応する<see cref="StorageFolder"/>を返します。<br />
        /// <list type="bullet" | "number" | "table">  
        /// <listheader>  
        /// <term>設定文字列</term>  
        /// <description>対応する<see cref="StorageFolder"/></description>  
        /// </listheader>  
        /// <item>  
        /// <term>LocalFolder</term>  
        /// <description>ApplicationData.Current.LocalFolder</description>  
        /// </item>
        /// <item>  
        /// <term>LocalCacheFolder</term>  
        /// <description>ApplicationData.Current.LocalCacheFolder</description>  
        /// </item>
        /// <item>  
        /// <term>SharedLocalFolder</term>  
        /// <description>ApplicationData.Current.SharedLocalFolder</description>  
        /// </item>
        /// <item>  
        /// <term>RoamingFolder</term>  
        /// <description>ApplicationData.Current.RoamingFolder</description>  
        /// </item>
        /// <item>  
        /// <term>TemporaryFolder</term>  
        /// <description>ApplicationData.Current.TemporaryFolder</description>  
        /// </item>
        /// <item>  
        /// <term>そのほか</term>  
        /// <description>ApplicationData.Current.GetPublisherCacheFolderから取得できる<see cref="StorageFolder"/></description>  
        /// </item>
        /// </list>  
        /// </summary>
        /// <param name="folderType"></param>
        /// <returns></returns>
        private static StorageFolder GetKnownStorageFolder(string folderType)
        {
            StorageFolder result = ApplicationData.Current.LocalFolder;
            switch (folderType.ToLower())
            {
                case "localfolder":
                    result = ApplicationData.Current.LocalFolder;
                    break;
                case "localcachefolder":
                    result = ApplicationData.Current.LocalCacheFolder;
                    break;
                case "sharedlocalfolder":
                    result = ApplicationData.Current.SharedLocalFolder;
                    break;
                case "roamingfolder":
                    result = ApplicationData.Current.RoamingFolder;
                    break;
                case "temporaryfolder":
                    result = ApplicationData.Current.TemporaryFolder;
                    break;
                default:
                    result = ApplicationData.Current.GetPublisherCacheFolder(folderType);
                    break;
                
            }

            return result;
        }

        /// <summary>
        ///     ログ出力ファイルのルートパス（UWPのStorageFolderからとれるパス）
        ///     現時点ではLocalFolder固定
        /// </summary>
        public StorageFolder LogRootPath
        {
            get { return ApplicationData.Current.LocalFolder; }
            set { }
        }
        
#endif

        /// <summary>
        ///     <see cref="LogRootPath" />からの相対パス＋ファイル名
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        ///     ファイルのローテーション種別
        ///     現時点では未実装
        /// </summary>
        //TODO:後でちゃんと使えるようにする（とりあえずNone固定）
        public string RotateType
        {
            get { return "None"; }
            set { }
        }

        /// <summary>
        ///     現時点では未実装
        ///     ログ出力時のフォーマットを指定する。
        ///     %d:ログ日時の出力
        ///     %L:行番号の出力（未実装）
        ///     %m:メッセージを出力
        ///     %n:改行文字の出力
        ///     %p:ログレベルの出力
        ///     %t:ログを生成したスレッドの出力（未実装）
        ///     %M:ログを出力したメソッド名（未実装）
        ///     %tag:ログ出力時に指定したタグ名（未実装）
        /// </summary>
        //TODO:フォーマットはまだ適当。後でちゃんと見直す。
        public string LogLayout { private set; get; }

        /// <summary>
        ///     現時点では未実装
        ///     出力するログレベル。指定未満のログは出力されない。
        ///     Trace < Debug < Info < Warn < Error < Fatal, ALLはすべて出力
        /// </summary>
        public string LogLevel { private set; get; }
    }
}