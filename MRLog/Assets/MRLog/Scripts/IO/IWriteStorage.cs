// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Threading.Tasks;
using Com.Reseul.Log4MR.Commons;

namespace Com.Reseul.Log4MR.IO
{
    /// <summary>
    /// ファイルストレージにログを出力する機能を実装するインターフェース
    /// </summary>
    public interface IWriteStorage
    {
        /// <summary>
        /// ログ内容を同期的にストレージに出力する
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        void WriteStorage(StorageInfo info, MRLogMessageData logMessage);

        /// <summary>
        /// ログ内容を非同期的にストレージに出力する
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        Task WriteStorageAsync(StorageInfo info, MRLogMessageData logMessage);
    }
}