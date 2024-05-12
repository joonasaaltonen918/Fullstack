using EventPlan1.Models.Domain;
using EventPlan1.Repositories.Abstract;

namespace EventPlan1.Repositories.Implement
{
    public class EventService : IEventService
    {
        private readonly DatabaseContext ctx;
        public EventService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Event model)
        {
            try
            {
                ctx.Event.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.Event.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Event GetById(int id)
        {
            return ctx.Event.Find(id);

        }

        public IQueryable<Event> List()
        {
            var data = ctx.Event.AsQueryable();
            return data;


        }

        public bool Update(Event model)
        {
            try
            {
                ctx.Event.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
