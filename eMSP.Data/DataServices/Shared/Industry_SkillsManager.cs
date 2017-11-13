using eMSP.Data.DataServices.Shared.Industry_Skills;
using eMSP.DataModel;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.Data.Extensions;

namespace eMSP.Data.DataServices.Shared
{
   
    public class Industry_SkillsManager
    {
        #region Initialization

        private bool IsDisposed = false;

        public Industry_SkillsManager()
        {

        }

        #endregion

        #region Get

        public async Task<IndustryCreateModel> GetIndustry(long Id)
        {
            try
            {
                IndustryCreateModel model = null;
                tblIndustry data = await Task.Run(() => ManageIndustry_Skills.GetIndustry(Id));
                model = data.ConvertToIndustry();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<IndustryCreateModel>> GetAllIndustries()
        {
            try
            {
                List<IndustryCreateModel> res = null;

                List<tblIndustry> dataCountry = await Task.Run(() => ManageIndustry_Skills.GetAllIndustries());
                res = dataCountry.Select(a => a.ConvertToIndustry()).ToList();

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IndustrySkillsCreateModel> GetIndustrySkill(long Id)
        {
            try
            {
                IndustrySkillsCreateModel model = null;
                tblIndustrySkill data = await Task.Run(() => ManageIndustry_Skills.GetIndustrySkill(Id));
                model = data.ConvertToIndustrySkill();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<IndustrySkillsCreateModel>> GetAllIndustrySkills(long IndustryId)
        {
            try
            {
                List<IndustrySkillsCreateModel> res = null;

                List<tblIndustrySkill> dataCountry = await Task.Run(() => ManageIndustry_Skills.GetAllIndustrySkills(IndustryId));
                res = dataCountry.Select(a => a.ConvertToIndustrySkill()).ToList();

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<IndustrySkillsCreateModel>> GetAllIndustrySkills()
        {
            try
            {
                List<IndustrySkillsCreateModel> res = null;

                List<tblIndustrySkill> dataCountry = await Task.Run(() => ManageIndustry_Skills.GetAllIndustrySkills());
                res = dataCountry.Select(a => a.ConvertToIndustrySkill()).ToList();

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Insert

        public async Task<IndustryCreateModel> CreateIndustry(IndustryCreateModel data)
        {
            try
            {

                tblIndustry dataIndustry = await Task.Run(() => ManageIndustry_Skills.InsertIndustry(data.ConvertTotblIndustry()));             

                return dataIndustry.ConvertToIndustry(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IndustrySkillsCreateModel> CreateIndustrySkill(IndustrySkillsCreateModel data)
        {
            try
            {
               tblIndustrySkill dataIndustrySkill = await Task.Run(() => ManageIndustry_Skills.InsertIndustrySkill(data.ConvertTotblIndustrySkill()));
                return dataIndustrySkill.ConvertToIndustrySkill();

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public async Task<IndustryCreateModel> UpdateIndustry(IndustryCreateModel model)
        {
            try
            {

                tblIndustry data = await Task.Run(() => ManageIndustry_Skills.UpdateIndustry(model.ConvertTotblIndustry()));
                return data.ConvertToIndustry();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IndustrySkillsCreateModel> UpdateIndustrySkill(IndustrySkillsCreateModel model)
        {
            try
            {

                tblIndustrySkill data = await Task.Run(() => ManageIndustry_Skills.UpdateIndustrySkill(model.ConvertTotblIndustrySkill()));
                return data.ConvertToIndustrySkill();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteIndustry(long Id)
        {
            try
            {
               
                await Task.Run(() => ManageIndustry_Skills.DeleteIndustry(Id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteIndustrySkill(long Id)
        {
            try
            {

                await Task.Run(() => ManageIndustry_Skills.DeleteIndustry(Id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Dispose

        //protected virtual void Dispose(bool dispose)
        //{
        //    if (!IsDisposed)
        //    {
        //        this.Dispose();
        //    }

        //    IsDisposed = true;
        //}

        //~Industry_SkillsManager()
        //{
        //    Dispose(false);
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        #endregion
    }
}
