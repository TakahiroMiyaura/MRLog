// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Collections.Generic;
using Com.Reseul.Log4MR.Commons;

namespace Com.Reseul.Log4MR.Storages
{
    /// <summary>
    ///     ログ出力非同期で実施するためのメッセージを一時的にキャッシュするクラス
    /// </summary>
    public class LogCacheStorage
    {
        private static volatile LogCacheStorage _storage;
        private static readonly object _lockObject = new object();


        private readonly Queue<MRLogMessageData> _message;

        private LogCacheStorage()
        {
            _message = new Queue<MRLogMessageData>();
        }

        /// <summary>
        ///     このクラスのインスタンスを取得します。
        /// </summary>
        public static LogCacheStorage Instance
        {
            get
            {
                if (_storage == null)
                    lock (_lockObject)
                    {
                        if (_storage == null) _storage = new LogCacheStorage();
                    }

                return _storage;
            }
        }

        /// <summary>
        ///     メッセージをキューに追加します。
        /// </summary>
        /// <param name="logMessage">メッセージ</param>
        public void Enquque(MRLogMessageData logMessage)
        {
            lock (_lockObject)
            {
                _message.Enqueue(logMessage);
            }
        }

        /// <summary>
        ///     格納されたメッセージをすべてでキューします。
        /// </summary>
        /// <returns>メッセージの一覧</returns>
        public IEnumerable<MRLogMessageData> DeququeAll()
        {
            MRLogMessageData[] logMessages;
            lock (_lockObject)
            {
                logMessages = new MRLogMessageData[_message.Count];
                for (var i = 0; i < logMessages.Length; i++) logMessages[i] = _message.Dequeue();
            }

            return logMessages;
        }
    }
}