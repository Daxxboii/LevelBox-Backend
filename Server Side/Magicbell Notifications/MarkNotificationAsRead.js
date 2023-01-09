//To Be added to client
const MagicBell = require('magicbell').default;

const magicbell = new MagicBell({
  apiKey: 'api key ',
  apiSecret: 'api secret',
});

async function markAsRead(id){
    await magicbell.notifications.markAsRead(id, {
        userEmail: 'person@example.com',
      });
}

