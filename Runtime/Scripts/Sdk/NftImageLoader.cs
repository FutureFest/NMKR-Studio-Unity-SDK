using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Nmkr.Sdk
{
    public class NftImageLoader
    {
        public async Task<Texture2D> LoadTextureFromIPFSAsync(string ipfsGatewayAddress)
        {
            string url = ipfsGatewayAddress;
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
            {
                var operation = uwr.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError(uwr.error);
                    return null;
                }
                else
                {
                    return DownloadHandlerTexture.GetContent(uwr);
                }
            }
        }
    }
}