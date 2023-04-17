public abstract class User
{
    public string Name {get;}
    private User() { }

    protected User(string name)
    {
        Name = name;
    }

    public sealed class ActiveUser
    {
        private User _innerUser;
        public IEnumerable<Subscription> Subscriptions {get;}

        public ActiveUser(string name,
                IEnumerable<Subscription> subs) : base(name)
        {
            _innerUser = new User(name);
            Subscriptions = subs;
        }
    }

    public sealed class DeletedUser
    {
        private User _innerUser;
        public DeletedUser(string name,
                DateTime deletionDate) : base(name)
        {
            _innerUser = new User(name);
            DeletionDate = deletionDate;
        }
        public DateTime? DeletionDate {get;}
    }

    public static ActiveUser Undelete(DeletedUser user)
    {
        return new ActiveUser(user.name);
    }

    public static DeletedUser Delete(ActiveUser user, DateTime deleteDate)
    {
        return new DeletedUser(user.name, deleteDate);
    }

    public static ActiveUser AddSubscription(ActiveUser user, Subscription sub)
    {
        return new ActiveUser(user.name, user.Subscriptions.Concat(sub));
    }
}
