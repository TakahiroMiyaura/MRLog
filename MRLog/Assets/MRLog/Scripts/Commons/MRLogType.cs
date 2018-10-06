// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using Com.Reseul.Log4MR.Unity;

namespace Com.Reseul.Log4MR.Commons
{
    /// <summary>
    /// <see cref="MRLog"/>で使用するログ出力種別を定義する列挙値
    /// </summary>
    public enum MRLogType
    {
        /// <summary>
        ///     詳細なデバッグの出力
        /// </summary>
        Trace = 0,

        /// <summary>
        ///     開発用のデバッグメッセージ
        /// </summary>
        Debug = 1,

        /// <summary>
        ///     操作ログなどの情報
        /// </summary>
        Info = 2,

        /// <summary>
        ///     障害ではない注意警告
        /// </summary>
        Warn = 3,

        /// <summary>
        ///     システム停止はしないが、問題となる障害
        /// </summary>
        Error = 4,

        /// <summary>
        ///     システム停止するような致命的な障害
        /// </summary>
        Fatal = 5,

        /// <summary>
        ///     全てのログ
        /// </summary>
        All = -1
    }
}