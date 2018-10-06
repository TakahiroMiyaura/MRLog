// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Collections.Generic;
using UnityEngine;

namespace Com.Reseul.Log4MR.Unity
{
    /// <summary>
    ///  ログファイルを出力するための<see cref="IMRLogHandler"/>インターフェース
    /// </summary>
    internal interface IMRLogHandler : ILogHandler
    {
        /// <summary>
        /// ログ情報として使用するパラメータのプロパティリストを取得設定します。
        /// </summary>
        List<string> ParamsPropertyList { set; get; }
    }
}