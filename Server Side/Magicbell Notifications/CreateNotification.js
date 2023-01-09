const MagicBell = require('magicbell').default;

const magicbell = new MagicBell({
  apiKey: 'api key ',
  apiSecret: 'api secret',
});

magicbell.notifications
  .create({
    title: 'title',
    content: 'content',
    recipients: [{ external_id: 'Custom ID' }],
  })
  .then((notification) => console.log(notification.id))
  .catch((error) => console.error(error));
