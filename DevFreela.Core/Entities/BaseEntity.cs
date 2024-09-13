namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        //protected BaseEntity()
        //{
        //CreatedAt = DateTime.Now;
        //IsDeleted = false;

        //}
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool IsDeleted { get; private set; } = false;

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
