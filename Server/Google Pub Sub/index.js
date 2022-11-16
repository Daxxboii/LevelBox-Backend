const express = require('express');
const {PubSub} = require('@google-cloud/pubsub');

const topicNameOrId = 'Testing';
const data = JSON.stringify({foo: 'bar'});


const pubSubClient = new PubSub();
app = express();

app.listen(80, function() {
    console.log("Server is listening on port 80...");
});

app.get('/', function(req, res) {
    res.send("Hello world!")
});


  async function publishMessage() {
    const dataBuffer = Buffer.from(data);
  
    try {
      const messageId = await pubSubClient
        .topic(topicNameOrId)
        .publishMessage({data: dataBuffer});
      console.log(`Message ${messageId} published.`);
    } catch (error) {
      console.error(`Received error while publishing: ${error.message}`);
      process.exitCode = 1;
    }
  }
  
  publishMessage();