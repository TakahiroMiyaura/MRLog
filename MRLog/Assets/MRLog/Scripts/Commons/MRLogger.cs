// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Collections.Generic;
using Com.Reseul.Log4MR.Unity;
using UnityEngine;

namespace Com.Reseul.Log4MR.Commons
{
    /// <summary>
    ///     ログレベルに応じたフィルター処理を実施するクラス
    /// </summary>
    public sealed class MRLogger : IMRLogger
    {
        private string _format = "{0} : {1}";

        public MRLogger(ILogHandler logHandler)
        {
            LogHandler = logHandler;
            var log4WinMrHandler = LogHandler as IMRLogHandler;
            if (log4WinMrHandler != null)
                log4WinMrHandler.ParamsPropertyList = new List<string>(new[] {"Tag", "Message", "LogType"});
        }


        private string GetString(object message)
        {
            return message == null ? "null" : message.ToString();
        }


        /// <summary>
        ///     ログ出力（デバッグ)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public void Debug(string tag, object message)
        {
            //TODO:フィルターの追加。というかそもそもこのクラスでやるかどうか。。。
            LogHandler.LogFormat(LogType.Log, null, _format, tag, GetString(message), MRLogType.Debug);
        }

        /// <summary>
        ///     ログ出力（情報)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public void Info(string tag, object message)
        {
            //TODO:フィルターの追加。というかそもそもこのクラスでやるかどうか。。。
            LogHandler.LogFormat(LogType.Log, null, _format, tag, GetString(message), MRLogType.Info);
        }

        /// <summary>
        ///     ログ出力（警告)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public void Warn(string tag, object message)
        {
            //TODO:フィルターの追加。というかそもそもこのクラスでやるかどうか。。。
            LogHandler.LogFormat(LogType.Log, null, _format, tag, GetString(message), MRLogType.Warn);
        }

        /// <summary>
        ///     ログ出力（エラー)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public void Error(string tag, object message)
        {
            //TODO:フィルターの追加。というかそもそもこのクラスでやるかどうか。。。
            LogHandler.LogFormat(LogType.Log, null, _format, tag, GetString(message), MRLogType.Error);
        }


        /// <summary>
        ///     ログ出力（致命的エラー)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public void Fatal(string tag, object message)
        {
            //TODO:フィルターの追加。というかそもそもこのクラスでやるかどうか。。。
            LogHandler.LogFormat(LogType.Log, null, _format, tag, GetString(message), MRLogType.Fatal);
        }

        /// <summary>
        ///     ログフォーマットに従ってログ出力を実施します。
        /// </summary>
        /// <param name="mrLogType">
        ///     <see cref="MRLogType" />
        /// </param>
        /// <param name="format">ログフォーマット</param>
        /// <param name="args">パラメータ</param>
        public void LogFormat(MRLogType mrLogType, string format, params object[] args)
        {
            //TODO:フィルターの追加。というかそもそもこのクラスでやるかどうか。。。
            LogHandler.LogFormat(LogType.Log, null, format, args, mrLogType);
        }

        public ILogHandler LogHandler { get; set; }
        public bool logEnabled { get; set; }
        public MRLogType FilterMrLogType { get; set; }
    }
}