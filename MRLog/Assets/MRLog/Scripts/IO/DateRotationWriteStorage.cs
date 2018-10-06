// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Threading.Tasks;
using Com.Reseul.Log4MR.Commons;

namespace Com.Reseul.Log4MR.IO
{
    /// <summary>
    /// ログ出力時に日付でログファイルをローテーションする<see cref="DateRotationWriteStorage"/>クラス
    /// </summary>
    public class DateRotationWriteStorage : WriteStorageBase
    {
        public DateRotationWriteStorage(IWriteStorage next) : base(next)
        {
        }

        /// <summary>
        /// ログ内容を同期的にストレージに出力する。
        /// このクラスでは<see cref="ValidateDateRotate"/>メソッドを利用してログファイルを日付で
        /// ローテーションを行い、コンストラクタで設定された移譲先の<see cref="IWriteStorage"/>を実装した
        /// ログ出力処理を依頼します。
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public override void WriteStorage(StorageInfo info, MRLogMessageData logMessage)
        {
            ValidateDateRotate();
            if (Next != null) Next.WriteStorage(info, logMessage);
        }

        /// <summary>
        /// ログ内容を非同期的にストレージに出力する。
        /// このクラスでは<see cref="ValidateDateRotate"/>メソッドを利用してログファイルを日付で
        /// ローテーションを行い、コンストラクタで設定された移譲先の<see cref="IWriteStorage"/>を実装した
        /// ログ出力処理を依頼します。
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public override async Task WriteStorageAsync(StorageInfo info, MRLogMessageData logMessage)
        {
            ValidateDateRotate();
            if (Next != null) await Next.WriteStorageAsync(info, logMessage);
        }

        /// <summary>
        /// 日付によりファイルをローテーションを実行します。
        /// </summary>
        public void ValidateDateRotate()
        {
            //TODO:日付ローテーションの処理を入れる
        }
    }
}