namespace Nmkr.Sdk
{
    public static partial class Api
    {
        public struct ResponseError
        {
            public ErrorType type;
            public string message;
            public string apiMessage;
            public long responseCode;
        }

        public enum ErrorType
        {
            // Summary:
            //     Failed to communicate with the server. For example, the request couldn't connect
            //     or it could not establish a secure channel.
            ConnectionError,
            //
            // Summary:
            //     The server returned an error response. The request succeeded in communicating
            //     with the server, but received an error as defined by the connection protocol.
            //     The error comes from the NMKR API.
            ProtocolError,
            //
            // Summary:
            //     Error processing data. The request succeeded in communicating with the server,
            //     but encountered an error when processing the received data. For example, the
            //     data was corrupted or not in the correct format.
            DataProcessingError,

            Unknown
        }
    }
}