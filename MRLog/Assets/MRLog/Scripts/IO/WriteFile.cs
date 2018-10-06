// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Com.Reseul.Log4MR.Commons;

#if !UNITY_EDITOR
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Storage;
#endif

namespace Com.Reseul.Log4MR.IO
{
    /// <summary>
    /// ファイルストレージにログを出力するクラス
    /// </summary>
    //TODO:UWPように切り離したうえでdllから参照させるように修正
    public class WriteFile : WriteStorageBase
    {
        /// <summary>
        /// ログ出力処理を委譲する<see cref="IWriteStorage"/>を設定しインスタンスを初期化します。
        /// </summary>
        /// <param name="next">ログ出力処理を委譲する<see cref="IWriteStorage"/>を実装したクラスオブジェクト</param>

        public WriteFile(IWriteStorage next) : base(next)
        {
        }

        /// <summary>
        /// ログ内容を同期的にストレージに出力する
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public override void WriteStorage(StorageInfo info, MRLogMessageData logMessage)
        {
            WriteStorageAsync(info, logMessage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// ログ内容を非同期的にストレージに出力する
        /// </summary>
        /// <param name="info">出力するストレージの情報を持つ<see cref="StorageInfo"/></param>
        /// <param name="logMessage">出力するログのメッセージ</param>
        public override async Task WriteStorageAsync(StorageInfo info, MRLogMessageData logMessage)
        {
            try
            {
#if !UNITY_EDITOR
                var storageFile =
                    await info.RootPath.CreateFileAsync(info.FileName, CreationCollisionOption.OpenIfExists);
                using (var randomAccessStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.Append(logMessage.WriteDate.ToString("yyyy/MM/dd HH:mm:sss"));
                    stringBuilder.Append(",");
                    stringBuilder.AppendFormat("[{0}],{1},{2}", logMessage.MessageArgs[2], logMessage.MessageArgs[0],
                        logMessage.MessageArgs[1]);
                    stringBuilder.AppendLine();
                    var bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());

                    randomAccessStream.Seek(randomAccessStream.Size);
                    await randomAccessStream.WriteAsync(bytes.AsBuffer());
                }
#endif
            }
            catch (Exception e)
            {
                Debug.Fail("WriteLog is Error " + e);
            }
        }
    }
}