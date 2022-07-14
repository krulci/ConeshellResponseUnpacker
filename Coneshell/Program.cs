using System.Net;
using System.Text;
using Cute;
using Elements;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace Unpacker
{
    public class Program
    {
        const int TimeOutSecond = 30;
        private static byte[] randomBytes = new byte[32] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
        private static string GameStartUrl = @"https://api-priconne-redive.cygames.jp/check/game_start";
        private static PlayerData playerData = new PlayerData();
        public static void Main(string[] args)
        {
            playerData.udid = GetUdid();
            Console.WriteLine($"UDID:{playerData.udid}");
            playerData.viewer_id = GetViewerID();
            Console.WriteLine($"viewer_id:{playerData.viewer_id}");
            playerData.short_udid = GetShortUDID();
            Console.WriteLine($"short_udid:{playerData.short_udid}");


            playerData.Init();
            Coneshell.NLAMANJEALE.InitializeContext(randomBytes, playerData.udid.Replace("-", "").HexString2ByteArray());

            //byte[] array = Convert.FromBase64String("wN4AAyR83ruiqqs7E8/cKiNfG34erFL6duLFhZOth6uXVADalGHP/mpy0tDRHgMiGH99ehNi4oW2Dxj5icly7sTK86biDvzwoSEC06OLizUZviv9cn07qtxtxKCf/b0lM9WSSNTAYqe/sazCP83/ChegxTG9+Bue371qIgieCrkAv9Rtt10Zcn77qZaIRlEt1FGeSQk/oWnFKfG9cTgdkEGww0otWlhuix7/cix/z3zGgEU+cbfRd4s8xPKgujrfiadRwYbjLF3JWBzGhKdjG+D/Ly8FB7HEcov8Nw9/LtXjw9+mXPQ4APvun2AshKKr30Twbzkrv3pQbpwUz2Y24XpMIhAUh2Fjtq3asYr3vCt8OjFRHBzKPoidD5ewThNh4yq97DModqnkrC+U+O27nXiVQZwhTvlsSmmi/jryTK3ryKSRj7kdP5dojv9tvkC1U/ss/GDecuN5amBY19kaPm4ZHgFCnJnCHCpPfkFMk9yvyBWZEpBCiRnwk3fmh6qZddzRnbK0IOVSeUrvmmFKPvZ/6PFqENiKFbxEWJzVuOLAIuP+VNIDPqoRCkZvmf3eNZM9tbXRLRB34pYcLen1pCsb58eAvhiNuXOoPg==");
            //byte[] array2 = Coneshell.NLAMANJEALE.Unpack(array);
            //Console.WriteLine(Encoding.UTF8.GetString(array2));
            GameStartTask();
            Console.ReadKey();
        }
        private static async void GameStartTask()
        {
            playerData.UpdateHead(GameStartUrl);
            //var req = GenerateRequest(GameStartUrl, playerData.CreateBody(), playerData.Head);
            await PostAsync(GameStartUrl, playerData.CreateBody(), playerData.Head);
        }

        static readonly HttpClient client = new HttpClient();
        static HttpRequestMessage GenerateRequest(string URL, byte[] body, Dictionary<string, string> head)
        {
            HttpRequestMessage result = new HttpRequestMessage();
            result.Method = HttpMethod.Post;
            result.RequestUri = new Uri(URL);
            foreach (var pair in head)
                result.Headers.Add(pair.Key, pair.Value);
            result.Content = new ByteArrayContent(body);
            return result;
        }
        static async Task PostAsync(string URL, byte[] body, Dictionary<string, string> head)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                //HttpResponseMessage response = await client.SendAsync(requestMessage);
                foreach (var pair in head)
                    client.DefaultRequestHeaders.Add(pair.Key, pair.Value);
                HttpResponseMessage response = await client.PostAsync(URL, new ByteArrayContent(body));
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                if (!string.IsNullOrEmpty(responseBody))
                {
                    Console.WriteLine(responseBody);
                    byte[] array = Convert.FromBase64String(responseBody);
                    Console.WriteLine(Encoding.UTF8.GetString(array));

                    byte[] array2 = Coneshell.NLAMANJEALE.Unpack(array);
                    Console.WriteLine(Encoding.UTF8.GetString(array2));

                }
                else
                {
                    Console.WriteLine("返回结果为空！");
                }
                Console.WriteLine("finish!");

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public static void SignUp(string dmm_view_id, string dmm_onetime_token)
        {

        }
        
        public static string GetUdid()
        {
            return NAPGOPBJNMP.decode(GetPlayerPrefabValue("UDID"));
        }
        public static int GetViewerID()
        {
            return GetPlayerPrefabValueInt("VIEWER_ID");
        }
        public static int GetShortUDID()
        {
            return GetPlayerPrefabValueInt("SHORT_UDID");
        }
        public static string GetPlayerPrefabValue(string key)
        {
            try
            {
                return AntiCheat.GetString(key, ReadRegedit(AntiCheat.EncryptKey(key)));
            }
            catch
            {
                Console.WriteLine($"读取{key}出错！");
                return "";
            }
        }
        public static int GetPlayerPrefabValueInt(string key)
        {
            try
            {
                return AntiCheat.GetInt(key, ReadRegedit(AntiCheat.EncryptKey(key)));
            }
            catch
            {
                Console.WriteLine($"读取{key}出错！");
                return 0;
            }
        }
        public static string ReadRegedit(string key)
        {
            RegistryKey rk = Registry.CurrentUser;
            RegistryKey softWare = rk.OpenSubKey("Software");
            RegistryKey cygames = softWare.OpenSubKey("Cygames");
            RegistryKey pcr = cygames.OpenSubKey("PrincessConnectReDive");

            List<string> allNames = new List<string>(pcr.GetValueNames());
            string exectName = allNames.Find(a => a.Contains(key));
            byte[] res = (byte[])pcr.GetValue(exectName);
            //return Encoding.UTF8.GetString(res);
            string decoded = System.Text.Encoding.UTF8.GetString(res);//将字节数组转换成字符串
            decoded = decoded.Replace("\0", String.Empty);//由于将字节数组转换成字符串的过程中，一般会包含\0字符，所以要将它替换成空字符串，
            return decoded;

        }
    }
}