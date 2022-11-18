var playfab = require('playfab-sdk')
var PlayFab = playfab.PlayFab
var PlayFabServer = playfab.PlayFabServer

PlayFabServer.settings.titleId = "E5D93";
PlayFabServer.settings.developerSecretKey = "NGO8JU7YWDHH7EDS893B9KRDJEC4FAXICFF1WHG3GF8MAQNZU3";

const ID = ''

const express = require('express')
const app = new express();
const bodyParser = require("body-parser")
const fs = require("fs");

app.get('/', (req, res) => {
  res.send('Health Check')
})
app.use(bodyParser.json());

app.listen(3000, () => {
  console.log(`Example app listening on port`);
})

//Adds a certain XP to the PlayerID
async function UpdateStat(StatName, AmountOfXP, PlayerID) {
  var update = PlayFabServer.UpdatePlayerStatistics({
    PlayFabId: PlayerID,
    Statistics: [{ StatisticName: StatName, Value: AmountOfXP },]
  });
}

//Called When A Player Creates an ID for the first Time
app.post("/Initialize", (req, res) => {
  ID = req.body[0].EntityId;

  UpdateStat(XP, 0, ID)
  UpdateStat(Level, 0, ID)

  console.log("Player Initialized")
})

//Called When XP is Updated For a Player
app.post("/XPReceived", (req, res) => {

  ID = req.body[0].EntityId;

  UpdateStat(XP, 0, ID)
  UpdateStat(Level, 0, ID)

  CheckForLevelUP();
  console.log("Player Levek Updated")
})


function CheckForLevelUP() {
  //Perform Calculations 
  // UpdateStat(Level, Whatever Level Player Is, ID)
}

app.post("/GiveInventoryItemToUser",(req,res)=>{
  ID = req.body[0].EntityId;
  GiveInventoryItemToUser(ID);
})

async function GiveInventoryItemToUser(PlayerID){
  var update = PlayFabServer.GrantItemsToUser({PlayFabId: PlayerID ,ItemIds:"DefaultBlock"});
}