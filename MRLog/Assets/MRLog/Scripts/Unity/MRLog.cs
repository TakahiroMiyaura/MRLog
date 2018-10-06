// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System;
using Com.Reseul.Log4MR.Commons;
using UnityEngine;
using UnityEngine.Internal;
using Object = UnityEngine.Object;

namespace Com.Reseul.Log4MR.Unity
{
    /// <summary>
    ///     Windows Mixed Reality Device/HoloLens用ログ出力クラス。
    /// </summary>
    /// <remarks>
    ///     Windows Mixed Reality Device/HoloLens用ログ出力クラスです。
    ///     各ログ出力レベルで以下の条件に応じた出力を行います。
    ///     ・Unity Editor上のデバッグの場合はコンソールログへの内容を出力
    ///     ・実機動作の場合は<see cref="MRLogSetting" />の設定に従ったリソースに対するログ出力
    /// </remarks>
    public class MRLog
    {
        /// <summary>
        ///     スレッド同期用のオブジェクト格納するフィールドです。
        /// </summary>
        private static readonly object _lockObject = new object();

        /// <summary>
        ///     Windows Mixed Reality Device/HoloLens用ロガーを格納するフィールドです。
        /// </summary>
        private static IMRLogger _logger;

        /// <summary>
        ///     Windows Mixed Reality Device/HoloLens用ロガークラス<see cref="Commons.MRLogger" />クラスのインスタンスを取得します。
        /// </summary>
        public static IMRLogger Logger
        {
            get
            {
                if (_logger == null)
                    lock (_lockObject)
                    {
                        if (_logger == null) _logger = new MRLogger(new MRLogSwitchHandler());
                        MRLogStorageWriteProcess.ProcessStart();
                    }

                return _logger;
            }
        }

        /// <summary>
        ///     ログ出力（デバッグ)を実施します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void Debug(object message)
        {
            Logger.Debug(null, message);
        }

        /// <summary>
        ///     ログ出力（デバッグ)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public static void Debug(string tag, object message)
        {
            Logger.Debug(tag, message);
        }

        /// <summary>
        ///     ログ出力（デバッグ)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        /// <param name="context">Unityオブジェクト</param>
        public static void Debug(string tag, object message, Object context)
        {
            //TODO:contextを渡す方法を検討
            Logger.Debug(tag, message);
        }

        /// <summary>
        ///     ログ出力（情報)を実施します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void Info(object message)
        {
            Logger.Info(null, message);
        }

        /// <summary>
        ///     ログ出力（情報)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public static void Info(string tag, object message)
        {
            Logger.Info(tag, message);
        }

        /// <summary>
        ///     ログ出力（情報)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        /// <param name="context">Unityオブジェクト</param>
        public static void Info(string tag, object message, Object context)
        {
            Logger.Info(tag, message);
        }


        /// <summary>
        ///     ログ出力（警告)を実施します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void Warn(object message)
        {
            Logger.Warn(null, message);
        }

        /// <summary>
        ///     ログ出力（警告)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public static void Warn(string tag, object message)
        {
            Logger.Warn(tag, message);
        }

        /// <summary>
        ///     ログ出力（警告)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        /// <param name="context">Unityオブジェクト</param>
        public static void Warn(string tag, object message, Object context)
        {
            //TODO:contextを渡す方法を検討
            Logger.Warn(tag, message);
        }

        /// <summary>
        ///     ログ出力（エラー)を実施します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void Error(object message)
        {
            Logger.Error(null, message);
        }

        /// <summary>
        ///     ログ出力（エラー)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public static void Error(string tag, object message)
        {
            Logger.Error(tag, message);
        }

        /// <summary>
        ///     ログ出力（エラー)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        /// <param name="context">Unityオブジェクト</param>
        public static void Error(string tag, object message, Object context)
        {
            //TODO:contextを渡す方法を検討
            Logger.Error(tag, message);
        }

        /// <summary>
        ///     ログ出力（致命的エラー)を実施します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void Fatal(object message)
        {
            Logger.Fatal(null, message);
        }

        /// <summary>
        ///     ログ出力（致命的エラー)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        public static void Fatal(string tag, object message)
        {
            Logger.Fatal(tag, message);
        }

        /// <summary>
        ///     ログ出力（致命的エラー)を実施します。
        /// </summary>
        /// <param name="tag">タグ名</param>
        /// <param name="message">メッセージ</param>
        /// <param name="context">Unityオブジェクト</param>
        public static void Fatal(string tag, object message, Object context)
        {
            //TODO:contextを渡す方法を検討
            Logger.Fatal(tag, message);
        }

        /// <summary>
        ///     ログフォーマットに従ってログ出力を実施します。
        /// </summary>
        /// <param name="mrLogType">
        ///     <see cref="MRLogType" />
        /// </param>
        /// <param name="format">ログフォーマット</param>
        /// <param name="args">パラメータ</param>
        public static void LogFormat(MRLogType mrLogType, string format, params object[] args)
        {
            Logger.LogFormat(mrLogType, null, format, args);
        }

        /// <summary>
        ///     ログフォーマットに従ってログ出力を実施します。
        /// </summary>
        /// <param name="mrLogType">
        ///     <see cref="MRLogType" />
        /// </param>
        /// <param name="context">メッセージが適用されるオブジェクト</param>
        /// <param name="format">ログフォーマット</param>
        /// <param name="args">パラメータ</param>
        public static void LogFormat(MRLogType mrLogType, Object context, string format, params object[] args)
        {
            //TODO:contextを渡す方法を検討
            Logger.LogFormat(mrLogType, format, args);
        }


        //TODO:Debugクラスのラッパーメソッドをここに実装する？
        public static void LogWarning(string tag, object message)
        {
            UnityEngine.Debug.unityLogger.LogWarning(tag, message);
        }

        public static void LogWarning(string tag, object message, Object context)
        {
            UnityEngine.Debug.unityLogger.LogWarning(tag, message, context);
        }

        public static void LogError(string tag, object message)
        {
            UnityEngine.Debug.unityLogger.LogError(tag, message);
        }

        public static void LogError(string tag, object message, Object context)
        {
            UnityEngine.Debug.unityLogger.LogError(tag, message, context);
        }

        public static void LogException(Exception exception)
        {
            UnityEngine.Debug.unityLogger.LogException(exception);
        }

        public static void LogException(Exception exception, Object context)
        {
            UnityEngine.Debug.unityLogger.LogException(exception, context);
        }

        public static void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            UnityEngine.Debug.DrawLine(start, end, color);
        }

        public static void DrawLine(Vector3 start, Vector3 end)
        {
            UnityEngine.Debug.DrawLine(start, end);
        }

        public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration)
        {
            UnityEngine.Debug.DrawRay(start, dir, color, duration);
        }

        public static void DrawRay(Vector3 start, Vector3 dir, Color color)
        {
            UnityEngine.Debug.DrawRay(start, dir, color);
        }

        public static void DrawRay(Vector3 start, Vector3 dir)
        {
            UnityEngine.Debug.DrawRay(start, dir);
        }

        public static void DrawRay(Vector3 start, Vector3 dir, [DefaultValue("Color.white")] Color color,
            [DefaultValue("0.0f")] float duration, [DefaultValue("true")] bool depthTest)
        {
            UnityEngine.Debug.DrawLine(start, start + dir, color, duration, depthTest);
        }

        public static void Break()
        {
            UnityEngine.Debug.Break();
        }

        public static void DebugBreak()
        {
            UnityEngine.Debug.DebugBreak();
        }

        public static void Assert(bool condition)
        {
            if (condition)
                return;
            UnityEngine.Debug.unityLogger.Log(LogType.Assert, "Assertion failed");
        }

        public static void Assert(bool condition, Object context)
        {
            if (condition)
                return;
            UnityEngine.Debug.unityLogger.Log(LogType.Assert, (object) "Assertion failed", context);
        }

        public static void Assert(bool condition, object message)
        {
            if (condition)
                return;
            UnityEngine.Debug.unityLogger.Log(LogType.Assert, message);
        }

        public static void Assert(bool condition, string message)
        {
            if (condition)
                return;
            UnityEngine.Debug.unityLogger.Log(LogType.Assert, message);
        }

        public static void Assert(bool condition, object message, Object context)
        {
            if (condition)
                return;
            UnityEngine.Debug.unityLogger.Log(LogType.Assert, message, context);
        }

        public static void Assert(bool condition, string message, Object context)
        {
            if (condition)
                return;
            UnityEngine.Debug.unityLogger.Log(LogType.Assert, (object) message, context);
        }

        public static void AssertFormat(bool condition, string format, params object[] args)
        {
            if (condition)
                return;
            UnityEngine.Debug.unityLogger.LogFormat(LogType.Assert, format, args);
        }

        public static void AssertFormat(bool condition, Object context, string format, params object[] args)
        {
            if (condition)
                return;
            UnityEngine.Debug.unityLogger.LogFormat(LogType.Assert, context, format, args);
        }

        public static void LogAssertion(object message)
        {
            UnityEngine.Debug.unityLogger.Log(LogType.Assert, message);
        }

        public static void LogAssertion(object message, Object context)
        {
            UnityEngine.Debug.unityLogger.Log(LogType.Assert, message, context);
        }

        public static void LogAssertionFormat(string format, params object[] args)
        {
            UnityEngine.Debug.unityLogger.LogFormat(LogType.Assert, format, args);
        }

        public static void LogAssertionFormat(Object context, string format, params object[] args)
        {
            UnityEngine.Debug.unityLogger.LogFormat(LogType.Assert, context, format, args);
        }

        /// <summary>
        ///     <para>In the Build Settings dialog there is a check box called "Development Build".</para>
        /// </summary>
        public static bool isDebugBuild => UnityEngine.Debug.isDebugBuild;
    }
}