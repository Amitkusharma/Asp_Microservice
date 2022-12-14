namespace EventBus.Messages
{
    public class IntegrationBaseEvent
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
        public IntegrationBaseEvent(Guid id, DateTime createdate)
        {
            Id = id;
            CreationDate=createdate;

        }
    }
}