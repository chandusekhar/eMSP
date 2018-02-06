using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;
using eMSP.ViewModel.JobVacancies;
using eMSP.Data.Extensions;
using eMSP.Data.DataServices.Comments;
using eMSP.ViewModel.Comments;
using eMSP.ViewModel.Shared;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.LocationBranch;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancy
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancy()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblVacancy> GetVacancyDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancies
                                                  .Include(a => a.tblCustomer)
                                                  .Include(a => a.tblMSPVacancieType)
                                                  .Where(x => x.ID == Id).SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }


        internal static async Task<List<tblVacancy>> GetAllVacancies(CompanyModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    long companyId = Convert.ToInt64(model.id);

                    if (companyId != 0 && model.companyType == "Customer")
                    {
                        return await Task.Run(() => db.tblVacancies
                                                      .Include(a => a.tblCustomer)
                                                      .Include(a => a.tblMSPVacancieType)
                                                      .Include(a => a.tblVacancyComments.Select(b => b.tblComment))
                                                      .Include(a => a.tblVacancyFiles)
                                                      .Include(a => a.tblVacancyLocations.Select(b => b.tblCustomerLocationBranch).Select(c => c.tblLocation).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancyLocations.Select(b => b.tblCustomerLocationBranch).Select(c => c.tblLocation).Select(d => d.tblCountryState).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountryState))
                                                      .Include(a => a.tblVacancieSkills.Select(b => b.tblIndustrySkill))
                                                      .Where(x => x.tblCustomer.ID == companyId)
                                                      .OrderByDescending(x => x.ID).ToList());
                    }
                    else if (companyId != 0 && model.companyType == "Supplier")
                    {
                        return await Task.Run(() => db.tblVacancies
                                                      .Include(a => a.tblCustomer)
                                                      .Include(a => a.tblMSPVacancieType)
                                                      .Include(a => a.tblVacancyComments.Select(b => b.tblComment))
                                                      .Include(a => a.tblVacancyFiles)
                                                      .Include(a => a.tblVacancyLocations.Select(b => b.tblCustomerLocationBranch).Select(c => c.tblLocation).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancyLocations.Select(b => b.tblCustomerLocationBranch).Select(c => c.tblLocation).Select(d => d.tblCountryState).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountryState))
                                                      .Include(a => a.tblVacancieSkills.Select(b => b.tblIndustrySkill))
                                                      .Where(x => x.tblVacancySuppliers.Any(r => r.SupplierID == companyId))
                                                      .OrderByDescending(x => x.ID).ToList());
                    }
                    else
                    {
                        return await Task.Run(() => db.tblVacancies
                                                      .Include(a => a.tblCustomer)
                                                      .Include(a => a.tblMSPVacancieType)
                                                      .Include(a => a.tblVacancieSkills.Select(b => b.tblIndustrySkill))
                                                      .Include(a => a.tblVacancyComments.Select(b => b.tblComment))
                                                      .Include(a => a.tblVacancyFiles)
                                                      .Include(a => a.tblVacancyLocations.Select(b => b.tblCustomerLocationBranch).Select(c => c.tblLocation).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancyLocations.Select(b => b.tblCustomerLocationBranch).Select(c => c.tblLocation).Select(d => d.tblCountryState).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountryState))
                                                      .OrderByDescending(x => x.ID).ToList());
                    }
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<VacancyCreateModel> Insert(VacancyCreateModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {

                    tblVacancy vacancy = await Task.Run(() => InsertVacancy(model.Vacancy.ConvertTotblVacancy()));

                    foreach (IndustrySkillsCreateModel a in model.VacancySkills)
                    {
                        tblVacancieSkill vacancySkill = await Task.Run(() => ManageVacancySkills.AddVacancySkills(a.id, vacancy));
                    }

                    foreach (CompanyCreateModel a in model.VacancySuppliers)
                    {
                        tblVacancySupplier vacancySupplier = await Task.Run(() => ManageVacancySuppliers.InsertVacancySupplier(a.id, vacancy));
                    }

                    foreach (LocationCreateModel a in model.VacancyLocations)
                    {
                        tblVacancyLocation vacancyLocation = await Task.Run(() => ManageVacancyLocations.AddVacancyLocation(a.id, vacancy));
                    }

                    foreach (VacancyFileModel a in model.VacancyFiles)
                    {
                        tblVacancyFile vacancyFile = await Task.Run(() => ManageVacancyFiles.InsertVacancyFiles(a.ConvertTotblVacancyFile(), vacancy));
                    }

                    //Comments
                    foreach (CommentModel c in model.VacancyComment)
                    {
                        if (!string.IsNullOrEmpty(c.comment))
                        {
                            tblComment comment = await Task.Run(() => ManageComments.InsertComment(c.ConvertTotblComment()));
                            tblVacancyComment vacancyComment = await Task.Run(() => ManageVacancyComments.InsertComment(vacancy, comment));
                        }
                    }

                    return model;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static async Task<VacancyCreateModel> Update(VacancyCreateModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {

                    tblVacancy vacancy = await Task.Run(() => UpdateVacancy(model.Vacancy.ConvertTotblVacancy()));

                    foreach (IndustrySkillsCreateModel a in model.VacancySkills)
                    {
                        tblVacancieSkill vacancySkill = await Task.Run(() => ManageVacancySkills.UpdateVacancySkills(a.id, vacancy));
                    }

                    foreach (CompanyCreateModel a in model.VacancySuppliers)
                    {
                        tblVacancySupplier vacancySupplier = await Task.Run(() => ManageVacancySuppliers.UpdateVacancySupplier(a.id, vacancy));
                    }

                    foreach (LocationCreateModel a in model.VacancyLocations)
                    {
                        tblVacancyLocation vacancyLocation = await Task.Run(() => ManageVacancyLocations.UpdateVacancyLocation(a.id, vacancy));
                    }

                    foreach (VacancyFileModel a in model.VacancyFiles)
                    {
                        tblVacancyFile vacancyFile = await Task.Run(() => ManageVacancyFiles.UpdateVacancyFile(a.ConvertTotblVacancyFile(), vacancy));
                    }

                    //Comments
                    foreach (CommentModel c in model.VacancyComment)
                    {
                        if (!string.IsNullOrEmpty(c.comment))
                        {
                            tblComment comment = await Task.Run(() => ManageComments.InsertComment(c.ConvertTotblComment()));
                            tblVacancyComment vacancyComment = await Task.Run(() => ManageVacancyComments.InsertComment(vacancy, comment));
                        }
                    }

                    return model;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static async Task<tblVacancy> InsertVacancy(tblVacancy model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblVacancies.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;

            }
        }



        #endregion

        #region Update

        internal static async Task<tblVacancy> UpdateVacancy(tblVacancy model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Delete

        internal static async Task DeleteVacancy(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancy obj = await db.tblVacancies.FindAsync(Id);
                    db.tblVacancies.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }


        #endregion
    }
}
