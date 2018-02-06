using eMSP.DataModel;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class Industry_SkillsExtentions
    {
        public static tblIndustry ConvertTotblIndustry(this IndustryCreateModel data)
        {
            return new tblIndustry()
            {
                ID = Convert.ToInt64(data.id),
                Description = data.industryDescription,
                Name = data.industryName,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static IndustryCreateModel ConvertToIndustry(this tblIndustry data)
        {
            return new IndustryCreateModel()
            {
                id = data.ID,
                industryDescription = data.Description,
                industryName = data.Name,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblIndustrySkill ConvertTotblIndustrySkill(this IndustrySkillsCreateModel data)
        {
            return new tblIndustrySkill()
            {
                ID = Convert.ToInt64(data.id),
                IndustryID = data.industryId,
                Name = data.skillName,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static IndustrySkillsCreateModel ConvertToIndustrySkill(this tblIndustrySkill data)
        {
            return new IndustrySkillsCreateModel()
            {
                id = data.ID,
                industryId = data.IndustryID,
                skillName = data.Name,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }
    }
}
