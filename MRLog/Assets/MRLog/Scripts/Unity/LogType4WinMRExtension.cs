using Com.Reseul.Log4MR.Commons;
using UnityEngine;

namespace Assets.Log4WinMR.Scripts.Unity
{
    /// <summary>
    /// <see cref="MRLogType"/>のための拡張メソッドを定義するクラス
    /// </summary>
    public static class LogType4WinMRExtension
    {
        /// <summary>
        /// <see cref="LogType"/>を<see cref="MRLogType"/>に変換します。
        /// </summary>
        /// <param name="type"><see cref="MRLogType"/></param>
        /// <param name="logType"><see cref="LogType"/></param>
        /// <returns></returns>
        public static MRLogType ConvertType(this MRLogType type, LogType logType)
        {
            var result = MRLogType.Debug;
            switch (logType)
            {
                case LogType.Log:
                case LogType.Assert:
                    result = MRLogType.Debug;
                    break;
                case LogType.Error:
                case LogType.Exception:
                    result = MRLogType.Error;
                    break;
                case LogType.Warning:
                    result = MRLogType.Warn;
                    break;
            }

            return result;
        }
    }
}