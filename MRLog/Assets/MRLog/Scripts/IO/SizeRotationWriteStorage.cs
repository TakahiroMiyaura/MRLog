// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Threading.Tasks;
using Com.Reseul.Log4MR.Commons;

namespace Com.Reseul.Log4MR.IO
{
    /// <summary>
    /// ログ出力時にサイズに応じてログファイルをローテーションする<see cref="SizeRotationWriteStorage"/>クラス
    /// </summary>
    public class SizeRotationWriteStorage : WriteStorageBase
    {
        public SizeRotationWriteStorage(IWriteStorage next) : base(next)
        {
        }

        /// <summary>
        /// ログ内容を同期的にストレージに出力する。
        /// このクラスでは<see cref="ValidateSizeRotate"/>メソッドを利用してログファイルをサイズで
        /// ローテーションを行い、コンストラクタで設定された移譲先の<see cref="IWriteStorage"/>を実装した
        /// ログ出力処理を依頼します。
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public override void WriteStorage(StorageInfo info, MRLogMessageData logMessage)
        {
            ValidateSizeRotate();
            if (Next != null) Next.WriteStorage(info, logMessage);
        }

        /// <summary>
        /// ログ内容を非同期的にストレージに出力する。
        /// このクラスでは<see cref="ValidateSizeRotate"/>メソッドを利用してログファイルをサイズで
        /// ローテーションを行い、コンストラクタで設定された移譲先の<see cref="IWriteStorage"/>を実装した
        /// ログ出力処理を依頼します。
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public override async Task WriteStorageAsync(StorageInfo info, MRLogMessageData logMessage)
        {
            ValidateSizeRotate();
            if (Next != null) await Next.WriteStorageAsync(info, logMessage);
        }

        /// <summary>
        /// ログファイルのサイズに応じてファイルのローテーションを実行します。
        /// </summary>
        public void ValidateSizeRotate()
        {
            //TODO:サイズローテーションの処理を入れる
        }
    }
}