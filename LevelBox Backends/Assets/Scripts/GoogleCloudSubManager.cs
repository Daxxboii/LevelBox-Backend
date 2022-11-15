using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Cloud.PubSub.V1;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyBox;

public class GoogleCloudSubManager : MonoBehaviour
{
    public IEnumerable<string> alo;
    [ButtonMethod]
    public async void PublishMessages()
    {
        PublishMessagesAsync("united-time-368420", "Testing", "hello");
    }

    [ButtonMethod]
    public async void ReceiveMessages()
    {

    }


    public async void PublishMessagesAsync(string projectId, string topicId, string messageTexts)
    {
        TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);
        PublisherClient publisher = await PublisherClient.CreateAsync(topicName);

        int publishedMessageCount = 0;
        
            try
            {
                string message = await publisher.PublishAsync(messageTexts);
                Console.WriteLine($"Published message {message}");
                Interlocked.Increment(ref publishedMessageCount);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error ocurred when publishing message {messageTexts}: {exception.Message}");
            }
        
       // await Task.WhenAll(publishTasks);
        //  return publishedMessageCount;
        Debug.Log(publishedMessageCount);
    }


    public async void PullMessagesAsync(string projectId, string subscriptionId, bool acknowledge)
    {
        SubscriptionName subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
        SubscriberClient subscriber = await SubscriberClient.CreateAsync(subscriptionName);
        // SubscriberClient runs your message handle function on multiple
        // threads to maximize throughput.
        int messageCount = 0;
        Task startTask = subscriber.StartAsync((PubsubMessage message, CancellationToken cancel) =>
        {
            string text = System.Text.Encoding.UTF8.GetString(message.Data.ToArray());
            Console.WriteLine($"Message {message.MessageId}: {text}");
            Interlocked.Increment(ref messageCount);
            return Task.FromResult(acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);
        });
        // Run for 5 seconds.
        await Task.Delay(5000);
        await subscriber.StopAsync(CancellationToken.None);
        // Lets make sure that the start task finished successfully after the call to stop.
        await startTask;
       // return messageCount;
        Debug.Log(messageCount);
    }
}
