var playfab = require('playfab-sdk')
var PlayFab = playfab.PlayFab
var PlayFabServer = playfab.PlayFabServer

PlayFabServer.settings.titleId = "E5D93";
PlayFabServer.settings.developerSecretKey = "NGO8JU7YWDHH7EDS893B9KRDJEC4FAXICFF1WHG3GF8MAQNZU3";

const ID = '6019B424DDF702FC'

const express = require('express')
const app = new express();

app.get('/', (req, res) => {
  res.send('Health Check')
})

app.listen(3000, () => {
  console.log(`Example app listening on port`);
})

//Adds a certain XP to the PlayerID
async function UpdateXP(AmountOfXP,PlayerID){
   var update = PlayFabServer.UpdatePlayerStatistics({PlayFabId : PlayerID,
Statistics : [{StatisticName: "XP",Value : AmountOfXP},]
});
}

//Called When A Player Creates an ID for the first Time
app.get('/Initialize', (req, res) => {
    
  })
