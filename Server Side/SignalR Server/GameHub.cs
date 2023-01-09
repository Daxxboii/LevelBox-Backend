using Microsoft.AspNetCore.SignalR;

public class GameHub : Hub
{
    #region Testing
    //Called From Azure Functions
    public async Task SendDataToAll(string data)
    {
        await Clients.All.SendAsync("Data", data);
    }

    public async Task SendDataToSelf(string data, string ClientID)
    {
        await Clients.Client(ClientID).SendAsync("PrivateData", data);
    }

    public async Task SendDataToGroup(string data, string GroupName)
    {
        await Clients.Group(GroupName).SendAsync("PrivateGroupData", data);
    }
    #endregion

    //Called From Clients
    public async Task AddToGroup(string ChannelName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, ChannelName);
    }

    public async Task RemoveFromGroup(string ChannelName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, ChannelName);
    }

    public async Task SendSignalRIDToClient()
    {
        await Clients.Client(Context.ConnectionId).SendAsync("SignalRID", Context.ConnectionId);
    }

    public async Task RequestBlocks(string ClanName, string Data)
    {
        await Clients.Group(ClanName).SendAsync("BlockRequest", Data);
    }

    public async Task DonateBlocks(string PlayerUsernameOrID, string Data)
    {
        await Clients.Client(PlayerUsernameOrID).SendAsync("BlockResult", Data);
    }
}