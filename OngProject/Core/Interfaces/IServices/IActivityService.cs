using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetAllActivities();

        Task<Activity> GetActivityById(int id);

        Task<GenericResult> InsertActivity(ActivityInsertDto activity);

        Task<bool> Update(Activity entity);

        Task<bool> UpdateActivity(int id, ActivityUpdateDto activityUpdateDto);

        Task<bool> DeleteActivity(int id);
    }
}
