using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;


namespace LoadGeneratorDotnetCore
{
    public abstract class LoadGenerateeClass
    {
        protected string connectionString;
        public LoadGenerateeClass(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public byte[] GeneratePayload(bool generateJsonPayload, int payloadSize)
        {
            string payload = "";

            if (generateJsonPayload)
            {
                string utcTimeStamp = ((long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString();
                string randomString = new Bogus.Randomizer().ClampString("", payloadSize, payloadSize);
                payload = $"{{'dt':{utcTimeStamp},'payload':'{randomString}'}}";
            }
            else
            {
                payload = new Bogus.Randomizer().ClampString("", payloadSize, payloadSize);
            }
            return Encoding.UTF8.GetBytes(payload);
        }

        public byte[] GeneratePayload()
        {
            dynamic signal = new JObject();
            signal.ReceiverId = "1afb3a5a-d4e8-432c-9808-36836a52c12e";
            signal.BeaconId = "6E64356144A8675DABB6";
            signal.SignalStrength = 185;
            signal.TimeStampUtc = ((long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString();
            signal.Name = "ReceiverBeaconSignal";
            signal.Version = "1";

            return Encoding.UTF8.GetBytes(signal.ToString());
        }

        public abstract Task GenerateBatchAndSend(int batchSize, bool dryRun, CancellationToken cancellationToken, Func<byte[]> loadGenerator);
    }
}