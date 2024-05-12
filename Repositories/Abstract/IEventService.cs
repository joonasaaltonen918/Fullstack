using EventPlan1.Models.Domain;
using EventPlan1.Models.DTO;

namespace EventPlan1.Repositories.Abstract
{
    public interface IEventService
    {
        bool Add(Event model);
        bool Update(Event model);
        Event GetById(int id);
        bool Delete(int id);
        IQueryable<Event> List();
        //void AddParticipant(int id, object);

    }
}
