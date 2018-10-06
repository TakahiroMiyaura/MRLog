// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System;
using System.Collections.Generic;
using System.Linq;
using Com.Reseul.Log4MR.Storages;
using Com.Reseul.Log4MR.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Com.Reseul.Log4MR.Commons
{
    /// <summary>
    ///  ログファイルを出力するための<see cref="IMRLogHandler"/>インターフェースを実装したクラス。
    ///  ログ出力に必要な情報を整理し、ログ出力用キャッシュにデータを蓄積します。
    ///  蓄積されたデータは<see cref="MRLogStorageWriteProcess"/>クラスにより非同期でファイル出力を実施します。
    /// </summary>
    internal sealed class MRLogHandlerImpl : IMRLogHandler
    {

        /// <summary>
        /// フォーマットに従ってログを出力する
        /// </summary>
        /// <param name="logType">ログ種別</param>
        /// <param name="context">コンテキスト</param>
        /// <param name="format">フォーマット</param>
        /// <param name="args">パラメータ</param>
        public void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            MRLogMessageData logMessage = null;
            var param = args;

            if (!(args[args.Length - 1] is MRLogType))
                param = param?.Concat(new object[] {ConvertType(logType)}).ToArray();

            LogCacheStorage.Instance.Enquque(new MRLogMessageData(DateTime.Now, param));
        }

        /// <summary>
        /// 例外に関するログを出力する
        /// </summary>
        /// <param name="exception">例外</param>
        /// <param name="context">コンテキスト</param>
        public void LogException(Exception exception, Object context)
        {
            LogCacheStorage.Instance.Enquque(new MRLogMessageData(DateTime.Now, exception, MRLogType.Error));
        }

        /// <summary>
        /// Unityのログ種別を<see cref="MRLogType"/>に変換します。
        /// </summary>
        /// <param name="logType">ログ種別</param>
        /// <returns>対応する<see cref="MRLogType"/></returns>
        public static MRLogType ConvertType(LogType logType)
        {
            var result = MRLogType.Debug;
            switch (logType)
            {
                case LogType.Log:
                case LogType.Assert:
                    result = MRLogType.Debug;
                    break;
                case LogType.Error:
                case LogType.Exception:
                    result = MRLogType.Error;
                    break;
                case LogType.Warning:
                    result = MRLogType.Warn;
                    break;
            }

            return result;
        }

        /// <summary>
        /// ログ情報として使用するパラメータのプロパティリストを取得設定します。
        /// </summary>
        public List<string> ParamsPropertyList { get; set; }
    }
}