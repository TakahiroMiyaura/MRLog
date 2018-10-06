// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System;

namespace Com.Reseul.Log4MR.Commons
{
    public class MRLogMessageData
    {
        /// <summary>
        ///     <see cref="T:System.Object" /> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="writeDate">書込み日時</param>
        /// <param name="messageArgs">メッセージ情報</param>
        public MRLogMessageData(DateTime writeDate, params object[] messageArgs)
        {
            MessageArgs = messageArgs;
            WriteDate = writeDate;
        }

        /// <summary>
        /// ログメッセージ情報を取得します。
        /// </summary>
        public object[] MessageArgs { get; private set; }

        /// <summary>
        /// ログ出力日時を取得します。
        /// </summary>
        public DateTime WriteDate { get; private set; }
    }
}