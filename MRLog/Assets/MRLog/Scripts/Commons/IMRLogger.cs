// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using UnityEngine;

namespace Com.Reseul.Log4MR.Commons
{
    /// <summary>
    ///     ログレベルに応じたフィルター処理を実施するインターフェース
    /// </summary>
    public interface IMRLogger
    {
        /// <summary>
        ///     ログ出力（デバッグ)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        void Debug(string tag, object message);

        /// <summary>
        ///     ログ出力（情報)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        void Info(string tag, object message);

        /// <summary>
        ///     ログ出力（警告)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        void Warn(string tag, object message);

        /// <summary>
        ///     ログ出力（エラー)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        void Error(string tag, object message);

        /// <summary>
        ///     ログ出力（致命的エラー)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        void Fatal(string tag, object message);


        /// <summary>
        ///     ログフォーマットに従ってログ出力を実施します。
        /// </summary>
        /// <param name="mrLogType">
        ///     <see cref="MRLogType" />
        /// </param>
        /// <param name="format">ログフォーマット</param>
        /// <param name="args">パラメータ</param>
        void LogFormat(MRLogType mrLogType, string format, params object[] args);

        /// <summary>
        ///     ログ出力を実施するハンドラを取得/設定します。
        /// </summary>
        ILogHandler LogHandler { set; get; }

        /// <summary>
        ///     ログ出力の有無を取得/設定します
        /// </summary>
        bool logEnabled { get; set; }

        /// <summary>
        ///     フィルターを行うログレベルを取得/設定します。
        /// </summary>
        MRLogType FilterMrLogType { get; set; }
    }
}