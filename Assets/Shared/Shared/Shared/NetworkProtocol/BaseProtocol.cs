using DBModel;
using System;

namespace Shared.NetworkProtocol
{
    public enum Protocol
    {
        #region -9999 ~ 999 : System Protocol
        Common_Cheat = -9999,
        Error = -1,
        None = 0,
        System_Version,
        Session_Info,
        #endregion
    }

    public enum WebAPIErrorCode
    {
        #region system error code
        None,
        InvalidPacket,
        InvalidProtocol,
        InvalidSession,
        InvalidVersion,
        InternalServerError,
        DBError,
        #endregion
    }

    public abstract class BasePacket
    {
        /// <summary> Key </summary>
        public SessionKey SessionKey { get; set; }

        public abstract Protocol Protocol { get; }
    }

    public abstract class RequestPacket : BasePacket
    {
        public int ClientUpTime { get; set; }
    }

    public abstract class ResponsePacket : BasePacket
    {
        public int ServerTimestamp { get; set; }
    }

    public class ErrorPacket : ResponsePacket
    {
        public override Protocol Protocol => Protocol.Error;

        public string Reason { get; set; }

        public WebAPIErrorCode ErrorCode { get; set; }
    }
}
