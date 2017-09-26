using LetsChatAPI.Models;
using System;

namespace LetsChatAPI.Hub
{
    using Microsoft.AspNet.SignalR;

    public class LetsChatHub : Hub
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public void Send(string name, string message)
        {
            var currentClientId = Context.ConnectionId;
            PreChatRequest preChatRequest = new PreChatRequest { ChatRequestId = Guid.Parse(currentClientId), EmailAddress = string.Empty, Name = name };

            if (db.ChatRequests.Find(preChatRequest.ChatRequestId) != null)
            {
                db.ChatRequests.Add(preChatRequest);
                db.SaveChanges();
            }

            Clients.AllExcept(currentClientId).ReceiveMessage(name, message);
        }

        public void PreChat(PreChatRequest preChatRequest)
        {
            var currentClientId = Context.ConnectionId;
            preChatRequest = new PreChatRequest { ChatRequestId = Guid.Parse(currentClientId), EmailAddress = preChatRequest.EmailAddress, Name = preChatRequest.Name, Reason = preChatRequest.Reason };

            if (db.ChatRequests.Find(preChatRequest.ChatRequestId) == null)
            {
                db.ChatRequests.Add(preChatRequest);
                db.SaveChanges();
            }


        }
    }
}