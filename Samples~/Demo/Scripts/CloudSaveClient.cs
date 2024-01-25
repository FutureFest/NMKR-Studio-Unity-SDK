using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Services.CloudSave;   // Download the 'com.unity.services.cloudsave@3.0.0' package
using Unity.Services.CloudSave.Internal;
using Unity.Services.CloudSave.Models;
using UnityEngine;

namespace Nmkr.Demo
{
    public class CloudSaveClient
    {
        private static readonly IPlayerDataService _player = CloudSaveService.Instance.Data.Player;

        public static async Task Save(string key, object value)
        {
            var data = new Dictionary<string, object> { { key, value } };
            await Call(_player.SaveAsync(data));
        }

        public static async Task Save(params (string key, object value)[] values)
        {
            var data = values.ToDictionary(item => item.key, item => item.value);
            await Call(_player.SaveAsync(data));
        }

        public static async Task<T> Load<T>(string key)
        {
            var query = await Call(_player.LoadAsync(new HashSet<string> { key }));
            return query.TryGetValue(key, out Item value) ? value.Value.GetAs<T>() : default;
        }

        public static async Task<IEnumerable<T>> Load<T>(params string[] keys)
        {
            var query = await Call(_player.LoadAsync(keys.ToHashSet()));

            return keys.Select(k =>
            {
                if (query.TryGetValue(k, out Item value))
                {
                    return value != null ? value.Value.GetAs<T>() : default;
                }
                return default;
            });
        }

        public static async Task Delete(string key)
        {
            await Call(_player.DeleteAsync(key));
        }

        public static async Task DeleteAll()
        {
            var keys = await Call(_player.ListAllKeysAsync());
            var tasks = keys.Select(k => _player.DeleteAsync(k.Key)).ToList();
            await Call(Task.WhenAll(tasks));
        }

        private static async Task Call(Task action)
        {
            try
            {
                await action;
            }
            catch (CloudSaveValidationException e)
            {
                Debug.LogError(e);
            }
            catch (CloudSaveRateLimitedException e)
            {
                Debug.LogError(e);
            }
            catch (CloudSaveException e)
            {
                Debug.LogError(e);
            }
        }

        private static async Task<T> Call<T>(Task<T> action)
        {
            try
            {
                return await action;
            }
            catch (CloudSaveValidationException e)
            {
                Debug.LogError(e);
            }
            catch (CloudSaveRateLimitedException e)
            {
                Debug.LogError(e);
            }
            catch (CloudSaveException e)
            {
                Debug.LogError(e);
            }

            return default;
        }
    }
}