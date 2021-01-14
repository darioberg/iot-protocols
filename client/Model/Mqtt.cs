using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;


namespace Client
{
    class Mqtt
    {   

        static MqttFactory factory = new MqttFactory(); // creo oggetto con al interno che fara la connesione
        static IMqttClient mqttClient = factory.CreateMqttClient();

        
       
        public static async Task MqttConnection()
        {
            
            var options = new MqttClientOptionsBuilder() // costruzione delle impostazione di connesione
                .WithClientId("client1") //  nome dispositivo
                .WithTcpServer("151.41.138.162", 1883) // ip e porta 
                .WithCleanSession()
                .WithWillMessage(new MqttApplicationMessageBuilder().WithPayload("disconnesso").WithTopic("lw").Build()) // ultimo desiderio quando si disconnette fa venire fuori nel broker withpayload
                .WithWillDelayInterval(15)
                .Build();

           await mqttClient.ConnectAsync(options); // connessione a mqtt "broker"
        }

        public static async Task SendMessage(string topic, string payload)
        {
            try
            {
                var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic) // nome topic
                .WithPayload(payload) // lo status del oggetto tutti i dati
                //.WithRetainFlag(true) // cosi se io mando un messaggio pero faccio la sub dopo il messagio arriva cmq
                .WithExactlyOnceQoS() // qos liv  2
                .Build(); // 
                
                await mqttClient.PublishAsync(message, CancellationToken.None);
            }
            catch (Exception)
            {
                Console.WriteLine("non ho voglia di lavorare :====) ");
            }
            
       }

       
    }

}
