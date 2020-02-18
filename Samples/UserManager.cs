using System;
using System.Collections.Concurrent;
using System.Threading;
using Samples.Entities;

namespace Samples
{
    public class UserManager
    {
        private static readonly ConcurrentDictionary<int, object> LockUsersObjects =
            new ConcurrentDictionary<int, object>();

        public void EditUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            try
            {
                var lockObject = LockUsersObjects.GetOrAdd(user.Id, new object());
                lock (lockObject)
                {
                    StoreUser(user);
                }
            }
            finally
            {
                LockUsersObjects.TryRemove(user.Id, out _);
            }
        }

        private static void StoreUser(User user)
        {
            user.ModifiedDate = DateTime.UtcNow;
            Thread.Sleep(2000);
        }
    }
}
