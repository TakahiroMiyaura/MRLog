// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Threading.Tasks;
using Com.Reseul.Log4MR.Commons;

namespace Com.Reseul.Log4MR.IO
{
    /// <summary>
    /// ストレージにログを出力する<see cref="WriteStorageBase"/>抽象クラス
    /// </summary>
    public abstract class WriteStorageBase : IWriteStorage
    {
        /// <summary>
        /// ログ出力処理を委譲する<see cref="IWriteStorage"/>を実装したオブジェクトを取得設定します。
        /// </summary>
        protected IWriteStorage Next { get; private set; }

        /// <summary>
        /// ログ出力処理を委譲する<see cref="IWriteStorage"/>を設定しインスタンスを初期化します。
        /// </summary>
        /// <param name="next">ログ出力処理を委譲する<see cref="IWriteStorage"/>を実装したクラスオブジェクト</param>
        protected WriteStorageBase(IWriteStorage next)
        {
            Next = next;
        }

        /// <summary>
        /// ログ内容を同期的にストレージに出力する
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public abstract void WriteStorage(StorageInfo info, MRLogMessageData logMessage);

        /// <summary>
        /// ログ内容を非同期的にストレージに出力する
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public abstract Task WriteStorageAsync(StorageInfo info, MRLogMessageData logMessage);
    }
}