namespace  Capstone1.Models

{
    public interface ISweetRepository
    {
        IQueryable<Service> GetAllService { get; }
    }
}
