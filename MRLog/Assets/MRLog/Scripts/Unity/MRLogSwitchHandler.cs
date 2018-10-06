// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System;
using UnityEngine;
using Object = UnityEngine.Object;
#if !UNITY_EDITOR
using Com.Reseul.Log4MR.Commons;
#endif

namespace Com.Reseul.Log4MR.Unity
{
    /// <summary>
    ///     実行環境に応じて出力先を変更するハンドラクラス
    /// </summary>
    public sealed class MRLogSwitchHandler : ILogHandler
    {
        /// <summary>
        ///     実行環境に応じて従来のハンドラ、またはファイル出力用ハンドラの切り替えの設定とともにインスタンス化を実施します。
        /// </summary>
        public MRLogSwitchHandler()
        {
#if UNITY_EDITOR
            _handler = Debug.unityLogger.logHandler;
#else
            _handler = new MRLogHandlerImpl();
            Debug.unityLogger.logHandler = _handler;
#endif
        }

        /// <summary>
        /// 実行時に使用する<see cref="ILogHandler"/>を保持するフィールド
        /// </summary>
        private ILogHandler _handler;

        /// <summary>
        /// フォーマットに従ってログを出力する
        /// </summary>
        /// <param name="logType">ログ種別</param>
        /// <param name="context">コンテキスト</param>
        /// <param name="format">フォーマット</param>
        /// <param name="args">パラメータ</param>
        public void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            _handler.LogFormat(logType, context, format, args);
        }

        /// <summary>
        /// 例外に関するログを出力する
        /// </summary>
        /// <param name="exception">例外</param>
        /// <param name="context">コンテキスト</param>
        public void LogException(Exception exception, Object context)
        {
            _handler.LogException(exception, context);
        }
    }
}