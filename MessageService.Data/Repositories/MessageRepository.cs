using MessageService.Data.Context;
using MessageService.Data.DTO;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageService.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private MessageServiceContext _context;
        public bool disposed = false;

        public MessageRepository(MessageServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<UserContactsDTO> MyContacts(int UserID)
        {
            return _context.Messages
                .Where(x => (x.SentBy.UserID == UserID) || (x.SentTo.UserID == UserID))
                .DistinctBy(x => x.SentTo.UserID)
                .Select(s => new UserContactsDTO
                {
                    Name = s.SentTo.UserName,
                    ContactID = s.SentTo.UserID,
                    Sent = s.Sent
                })
                .OrderBy(x => x.Sent);
        }

        public IEnumerable<MessageDTO> GetMessages(int SentByID, int SentToID)
        {
            return _context.Messages
                .Where(m => (m.SentBy.UserID == SentByID && m.SentTo.UserID == SentToID) && (Deleted != true))
                .Select(m => new MessageDTO
                {
                    MessageID = m.MessageID,
                    SentByID = m.SentBy.UserID,
                    SentToID = m.SentTo.UserID,
                    Content = m.Content,
                    Sent = m.Sent                    
                })
               .OrderBy(s => s.Sent)
               .Take(50);
        }

        //public void DeleteMessage(int MessageID, string SentbyUserName)
        //{
        //    Message message = _context.Messages
        //          .Where(m => m.MessageID == MessageID && m.SentbyUserName == SentbyUserName)
        //          .First();
            
        //    message.LastUpdated = DateTime.Now;
        //    message.Deleted = true;

        //    _context.Entry(message).State = EntityState.Modified;

        //    Save();
        //}

        public void Save()
        {
            _context.SaveChanges();
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool Disposing)
        {
            if (!this.disposed)
            {
                if (Disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public interface IMessageRepository
    {
        IEnumerable<UserContactsDTO> MyContacts(int UserID);
        IEnumerable<MessageDTO> GetMessages(int SentByID, int SentToID);
        void Save();
    }
}
