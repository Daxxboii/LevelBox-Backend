var playfab = require('playfab-sdk')
var PlayFab = playfab.PlayFab
var PlayFabServer = playfab.PlayFabServer

PlayFabServer.settings.titleId = "E5D93";
PlayFabServer.settings.developerSecretKey = "NGO8JU7YWDHH7EDS893B9KRDJEC4FAXICFF1WHG3GF8MAQNZU3";

var ID = ''

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


//#region 

//Called When A Player Creates an ID for the first Time
app.post("/Initialize", (req, res) => {
  ID = req.body[0].EntityId;
  UpdateStat(XP, 0, ID)
  UpdateStat(Level, 0, ID)

  console.log("Player Initialized")
  res.send("POST Request Called")
})

app.post("/GiveInventoryItemToUser", (req, res) => {
  ID = req.body[0].EntityId;
  GiveInventoryItemToUser(ID, "DefaultBlock");//'Admin' Function To Give A Certain Item to User
})


//Called When XP is Updated For a Player
app.post("/XPReceived", (req, res) => {

  ID = req.body[0].EntityId;

  UpdateStat(XP, 0, ID)
  UpdateStat(Level, 0, ID)

  CheckForLevelUP();


  console.log("Player Levek Updated")
  res.send("POST Request Called")
})

app.post("/FetchPlayerStats", (req, res) => {
  ID = req.body[0].EntityId;
  FetchPlayerStats(ID, 'XP');

  res.send("POST Request Called")
})

//#endregion

function CheckForLevelUP() {
  //Perform Calculations 
  // UpdateStat(Level, Whatever Level Player Is, ID)
}


//Sends An Item to PlayerInventory
async function GiveInventoryItemToUser(PlayerID, ItemID) {
  var update = PlayFabServer.GrantItemsToUser({ PlayFabId: PlayerID, ItemIds: ItemID });
}


//Updates the Stats of the PlayerID
async function UpdateStat(StatName, AmountOfXP, PlayerID) {
  var update = PlayFabServer.UpdatePlayerStatistics({
    PlayFabId: PlayerID,
    Statistics: [{ StatisticName: StatName, Value: AmountOfXP },]
  });
}

//Fetch Player Statistics
async function FetchPlayerStats(PlayerID, StatsToFetch) {
  let result = await PlayFabServer.GetPlayerStatistics({ PlayFabId: PlayerID, StatisticNames: [StatsToFetch]});
  console.log(result);
}

