using OngProject.Core.Entities;
using OngProject.Core.Interfaces.IRepositories;
using System;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Comment> CommentRepository { get; }
        IRepository<Member> MemberRepository { get; }
        
        IRepository<Organization> OrganizationRepository { get; }

        IRepository<Testimonial> TestimonialRepository { get; }
        IRepository<News> NewsRepository { get; }
        
        //IRepository<Rol> RolesRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Activity> ActivityRepository { get; }
        IRepository<Slide> SlideRepository { get; }

        IRepository<Contact> ContactRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}