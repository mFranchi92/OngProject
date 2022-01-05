using OngProject.Core.Entities;
using OngProject.Core.Interfaces.IRepositories;
using OngProject.Core.Interfaces.IUnitOfWork;
using System.Threading.Tasks;
using OngProject.Infrastructure.Data;

namespace OngProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Organization> _organizationRepository;
        
        private readonly IRepository<Testimonial> _testimonialRepository;
        private readonly IRepository<News> _newsRepository;
        //private readonly IRepository<Rol> _rolesRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Activity> _activityRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Slide> _slideRepository;
        private readonly IRepository<Contact> _contactRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_context);
        public IRepository<Organization> OrganizationRepository => _organizationRepository ?? new BaseRepository<Organization>(_context);
        public IRepository<News> NewsRepository => _newsRepository ?? new BaseRepository<News>(_context);
        
        public IRepository<Testimonial> TestimonialRepository => _testimonialRepository ?? new BaseRepository<Testimonial>(_context);

        //public IRepository<Rol> RolesRepository => _rolesRepository ?? new BaseRepository<Rol>(_context);
        public IRepository<Category> CategoryRepository => _categoryRepository ?? new BaseRepository<Category>(_context);
        public IRepository<Member> MemberRepository => _memberRepository ?? new BaseRepository<Member>(_context);

        public IRepository<Activity> ActivityRepository => _activityRepository ?? new BaseRepository<Activity>(_context);
        public IRepository<Slide> SlideRepository => _slideRepository ?? new BaseRepository<Slide>(_context);

        public IRepository<Contact> ContactRepository => _contactRepository ?? new BaseRepository<Contact>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();

            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}