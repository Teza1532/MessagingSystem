using MessageService.Data.Context;
using MessageService.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using MessageService.Data.DTO;
using System.Linq;

namespace MessageService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MessageServiceContext _context;
        private bool disposed = false;

        public UserRepository(MessageServiceContext context)
        {
            _context = context;
        }

        public UserDTO GetUser(int UserID)
        {
            return _context.User.Select(c => new UserDTO
            {
                UserID = c.UserID,
                UserName = c.UserName
            })
            .Where(c => c.UserID == UserID).First();
        }

        public void InsertUser(UserDTO User)
        {
            _context.User.Add(new User
            {
                UserID = User.UserID,
                UserName = User.UserName,
                LastUpdated = DateTime.Now,
                Deleted = false
            });

            Save();
        }

        public void UpdateUser(UserDTO User)
        {   
            _context.Entry(new User
            {
                UserID = User.UserID,
                UserName = User.UserName
            }).State = EntityState.Modified;

            Save();
        }

        public void DeleteUser(int UserID)
        {
            User user = _context.User.Find(UserID);

            user.Deleted = true;
            user.LastUpdated = DateTime.Now;

            _context.Entry(user).State = EntityState.Modified;

            Save();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public interface IUserRepository : IDisposable
    {
        UserDTO GetUser(int userID);
        void InsertUser(UserDTO user);
        void DeleteUser(int userID);
        void UpdateUser(UserDTO user);
        void Save();
    }
}

