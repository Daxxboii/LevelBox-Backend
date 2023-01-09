// To Be Added to unity client 

const MagicBell = require('magicbell').default;

const magicbell = new MagicBell({
  apiKey: '6c5497d03c10bc1772684244aa7461aa89ce3d8b',
  apiSecret: '55csGbZSSg15DDO2U0Plw/lLJOoWtcEmp3m3Ne1X',
});

async function Fetch(){
    const notification = await magicbell.notifications.list({
        
        userExternalId: 'Custom ID',
      });
    
      console.log(notification.notifications);

  }