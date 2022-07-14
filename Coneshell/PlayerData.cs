using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elements;
using Cute;
using LitJson;
using Coneshell;

namespace Unpacker
{
    public class PlayerData
    {
        private static string APP_VER = "6.3.0";
        private static int RES_VER = 10039800;
        private static string DEVICE_ID = "5c2c26ca4b77f867cbdfd059f7c3d95d9ec80ba2";
        private static string DEVICE_NAME = "Zephyrus S GX531GWR (ASUSTeK COMPUTER INC.)";


        public string dmm_viewer_id = "321915083";
        public string dmm_onetime_token = "2f13ae24fff8c538d304919eb82fbd91";

        public string udid = "";
        public int viewer_id = 0;
        public int short_udid = 0;//"000915?166=811?678B361A234:284>615=871>867128315126341722273856572288817";


        public Dictionary<string, string> Head = new Dictionary<string, string>();
        public string sessionId = "";
        private Cute.FEAAIACPLOH data = new FEAAIACPLOH();
        public byte[] body;
        public void Init()
        {
            PrepareHeadAtFirst();

        }

        private void PrepareHeadAtFirst()
        {
            //Head.Add("Host", "api-priconne-redive.cygames.jp");
            Head.Add("User-Agent", "UnityPlayer/2018.4.21f1 (UnityWebRequest/1.0, libcurl/7.52.0-DEV)");
            Head.Add("Accept", "*/*");
            Head.Add("Accept-Encoding", "identity");

            Head.Add("SHORT-UDID", NAPGOPBJNMP.encode(short_udid.ToString()));
            Head.Add("SID", sessionId);
            Head.Add("PARAM", "");
            Head.Add("DEVICE", "3");
            //Head.Add("APP-VER", APP_VER);
            //Head.Add("RES-VER", RES_VER.ToString());
            Head.Add("DEVICE-ID", DEVICE_ID);
            Head.Add("DEVICE-NAME", DEVICE_NAME);
            Head.Add("GRAPHICS-DEVICE-NAME", "NVIDIA GeForce RTX 4060 with Max-Q Design");
            Head.Add("IP-ADDRESS", "192.168.1.154");
            Head.Add("PLATFORM-OS-VERSION", "Windows 10  (10.0.0) 64bit");
            Head.Add("PLATFORM", "3");
            Head.Add("LOCALE", "Jpn");
            Head.Add("BATTLE-LOGIC-VERSION", "4");
            
            //Head.Add("Content-Type", "application/octet-stream");
            Head.Add("X-Unity-Version", "2018.4.21f1");
            //Head.Add("Content-Length", "320");

        }
        public void UpdateHead(string URL)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                sessionId = viewer_id + udid;
            }
            else
            {
                sessionId = NAPGOPBJNMP.MakeMd5(sessionId);
            }
            Head["SID"] = sessionId;
            AddHeaderParam(URL);

            string str = JsonMapper.ToJson(Head);
            Console.WriteLine($"Head:{str}");
        }
        private void AddHeaderParam(string URL)
        {
            Cute.FEAAIACPLOH data = new FEAAIACPLOH();
            data.viewer_id = viewer_id.ToString();
            data.dmm_viewer_id = dmm_viewer_id;
            data.dmm_onetime_token = dmm_onetime_token;
            string str = JsonMapper.ToJson(data);
            Uri uri = new Uri(URL.Trim());
            string text = udid + uri.AbsolutePath + str;
            if (viewer_id != 0)
            {
                text += viewer_id;
            }
            string param = NAPGOPBJNMP.ComputeSHA1(text);
            Head["PARAM"] = param;
        }
        public byte[] CreateBody()
        {
            string text = JsonMapper.ToJson(data);
            byte[] array = NLAMANJEALE.Pack(Encoding.UTF8.GetBytes(text));
            body = Encoding.ASCII.GetBytes(Convert.ToBase64String(array));
            //CreateBodyJson = string.Copy(text);
            //CreateBodyConeshellPacked = array.CopyAsNewInstance();
            //CreateBodyBase64 = body.CopyAsNewInstance();
            return body;
        }
    }
}
