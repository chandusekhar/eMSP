using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.MSP;
using System.Data.Entity;
using eMSP.Data.Extensions;

namespace eMSP.Data.DataServices.Candidate
{

    internal static class ManageCandidate
    {

        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidate()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblCandidate> Get(long Id)
        {
            IQueryable<tblCandidate> list = null;
            try
            {
                using (db = new eMSPEntities())
                {
                    list = db.tblCandidates
                        .Include(a => a.tblCandidateContacts)
                       .Include(a => a.tblCandidateContacts.Select(b => b.tblContact))
                      .Include(a => a.tblCandidateContacts.Select(b => b.tblContact).Select(c => c.tblCountry))
                      .Include(a => a.tblCandidateContacts.Select(b => b.tblContact).Select(c => c.tblCountryState))
                      .Include(b => b.tblCandidateFiles.Select(a => a.tblFile))
                      .Include(b => b.tblCandidateSkills.Select(a => a.tblIndustrySkill))
                      .Include(b => b.tblCandidateIndustries.Select(a => a.tblIndustry))
                      .Where(x => x.ID == Id && x.IsActive == true && x.IsDeleted == false);
                    return await Task.Run(() => list.FirstOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblCandidate>> GetAll(long supplierId)
        {
            try
            {
                using (db = new eMSPEntities())
                {

                    return await Task.Run(() => db.tblSupplierCandidates

                    .Where(x => x.SupplierID == supplierId && x.tblCandidate.IsActive == true && x.tblCandidate.IsDeleted == false)
                    .Select(a => a.tblCandidate)
                    .Include(b => b.tblCandidateSkills.Select(a => a.tblIndustrySkill))
                    .Include(b => b.tblCandidateIndustries.Select(a => a.tblIndustry))
                    .Include(a => a.tblCandidateContacts.Select(b => b.tblContact))
                    .Include(a => a.tblCandidateContacts.Select(b => b.tblContact).Select(c => c.tblCountry))
                    .Include(a => a.tblCandidateContacts.Select(b => b.tblContact).Select(c => c.tblCountryState))
                    .Include(a => a.tblCandidateFiles.Select(b => b.tblFile)).ToList());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<CandidateCreateModel> Insert(CandidateCreateModel model)
        {
            try
            {
                int x = 0;
                tblContact contact = null;
                tblFile file = null;

                tblCandidate candidate = await Task.Run(() => InsertCandidate(model.Candidate.ConvertTotblCandidate()));
                x = await Task.Run(() => InsertSupplierCandidate(candidate, model.SupplierId));

                foreach (CandidateContactModel a in model.CandidateContact)
                {
                    contact = await Task.Run(() => InsertContacts(a.ConvertTotblContact()));
                    x = await Task.Run(() => InsertCandidateContacts(candidate, contact, a.IsPrimary));
                }

                foreach (FileModel a in model.CandidateFile)
                {
                    file = await Task.Run(() => InsertFiles(a.ConvertTotblFile()));
                    x = await Task.Run(() => InsertCandidateFiles(candidate, file, Convert.ToInt64(a.FileTypeId)));
                }

                x = await Task.Run(() => InsertCandidateIndustries(model.CandidateIndustries, candidate));
                x = await Task.Run(() => InsertCandidateSkills(model.CandidateSkills, candidate));

                candidate = await Task.Run(() => Get(candidate.ID));

                return candidate.ConvertToCandidateCreateModel();


            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblCandidate> InsertCandidate(tblCandidate model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var candidate = db.tblCandidates.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return candidate;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<int> InsertSupplierCandidate(tblCandidate can, long supplierId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var scandidate = db.tblSupplierCandidates.Add(new tblSupplierCandidate
                    {
                        SupplierID = supplierId,
                        CandidateID = can.ID,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedTimestamp = can.CreatedTimestamp,
                        CreatedUserID = can.CreatedUserID,
                        UpdatedTimestamp = can.UpdatedTimestamp,
                        UpdatedUserID = can.UpdatedUserID
                    });
                    return await Task.Run(() => db.SaveChangesAsync());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblContact> InsertContacts(tblContact model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var contact = db.tblContacts.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return contact;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<int> InsertCandidateContacts(tblCandidate can, tblContact con, bool isPrimary)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var scandidate = db.tblCandidateContacts.Add(new tblCandidateContact
                    {
                        ContactID = con.ID,
                        CandidateID = can.ID,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedTimestamp = can.CreatedTimestamp,
                        CreatedUserID = can.CreatedUserID,
                        UpdatedTimestamp = can.UpdatedTimestamp,
                        UpdatedUserID = can.UpdatedUserID,
                        IsPrimary = isPrimary
                    });
                    return await Task.Run(() => db.SaveChangesAsync());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblFile> InsertFiles(tblFile model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var file = db.tblFiles.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return file;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<int> InsertCandidateFiles(tblCandidate can, tblFile file, long fileTypeid)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var scandidate = db.tblCandidateFiles.Add(new tblCandidateFile
                    {
                        FileID = file.ID,
                        FileTypeID = fileTypeid,
                        CandidateID = can.ID,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedTimestamp = can.CreatedTimestamp,
                        CreatedUserID = can.CreatedUserID,
                        UpdatedTimestamp = can.UpdatedTimestamp,
                        UpdatedUserID = can.UpdatedUserID

                    });
                    return await Task.Run(() => db.SaveChangesAsync());


                }
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        internal static async Task<int> InsertCandidateIndustries(List<int> Industries, tblCandidate can)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    foreach (int i in Industries)
                    {
                        var ind = db.tblCandidateIndustries.Add(
                            new tblCandidateIndustry
                            {
                                CandidateID = can.ID,
                                IndustryID = i,
                                IsActive = true,
                                IsDeleted = false,
                                CreatedTimestamp = can.CreatedTimestamp,
                                CreatedUserID = can.CreatedUserID,
                                UpdatedTimestamp = can.UpdatedTimestamp,
                                UpdatedUserID = can.UpdatedUserID
                            });
                    }

                    return await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<int> InsertCandidateSkills(List<int> Skills, tblCandidate can)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    foreach (int i in Skills)
                    {
                        var ind = db.tblCandidateSkills.Add(
                            new tblCandidateSkill
                            {
                                CandidateID = can.ID,
                                SkillsID = i,
                                IsActive = true,
                                IsDeleted = false,
                                CreatedTimestamp = can.CreatedTimestamp,
                                CreatedUserID = can.CreatedUserID,
                                UpdatedTimestamp = can.UpdatedTimestamp,
                                UpdatedUserID = can.UpdatedUserID
                            });
                    }

                    return await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Update

        internal static async Task<CandidateCreateModel> Update(CandidateCreateModel model)
        {
            try
            {
                int x = 0;
                tblContact contact = null;
                tblFile file = null;

                await UpdateCandidate(model.Candidate.ConvertTotblCandidate());

                if (model.CandidateContact.Count > 0)
                {
                    foreach (CandidateContactModel c in model.CandidateContact)
                    {
                        if(c.ID > 0)
                        {
                            await UpdateContacts(c.ConvertTotblContact());
                        }
                        else
                        {
                            contact = await Task.Run(() => InsertContacts(c.ConvertTotblContact()));
                            x = await Task.Run(() => InsertCandidateContacts(model.Candidate.ConvertTotblCandidate(), contact, c.IsPrimary));

                        }

                    }
                }              

                
                await UpdateCandidateFiles(model.CandidateFile, model.Candidate.ConvertTotblCandidate());
                    
                
                await UpdateCandidateIndustries(model.CandidateIndustries, model.Candidate.ConvertTotblCandidate());
                await UpdateCandidateSkills(model.CandidateSkills, model.Candidate.ConvertTotblCandidate());

                tblCandidate t = await Task.Run(() => Get(Convert.ToInt64(model.Candidate.id)));

                return t.ConvertToCandidateCreateModel();
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateCandidate(tblCandidate model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    //return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateSupplierCandidate(tblSupplierCandidate model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    //return model;


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateContacts(tblContact model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    //return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateCandidateContacts(tblCandidateContact model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    //return model;


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateFiles(tblFile model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    //return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateCandidateFiles(tblCandidateFile model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    //return model;


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateCandidateFiles(List<FileModel> model,tblCandidate Candidate)
        {
            try
            {


                int x = 0;
                tblFile fi = null;
                using (db = new eMSPEntities())
                {
                    foreach(FileModel file in model)
                    {
                        await db.tblFiles.Where(a => a.ID == file.ID).ForEachAsync(a => { a.IsActive = false; a.IsDeleted = true; });

                    }
                    await Task.Run(() => db.SaveChangesAsync());

                    foreach (FileModel a in model)
                    {
                        fi  = await Task.Run(() => InsertFiles(a.ConvertTotblFile()));
                        x = await Task.Run(() => InsertCandidateFiles(Candidate, fi, Convert.ToInt64(a.FileTypeId)));
                    }
                     

                    //return model;


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateCandidateIndustries(List<int> Industries, tblCandidate can)
        {
            try
            {
                await DeleteCandidateIndustries(Convert.ToInt32(can.ID));
                await Task.Run(() => InsertCandidateIndustries(Industries, can));
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task UpdateCandidateSkills(List<int> Skills, tblCandidate can)
        {
            try
            {
                await DeleteCandidateSkills(Convert.ToInt32(can.ID));
                await Task.Run(() => InsertCandidateSkills(Skills, can));
            }
            catch (Exception)
            {
                throw;

            }
        }
        #endregion

        #region Delete

        internal static async Task DeleteSupplier(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblSupplier obj = await db.tblSuppliers.FindAsync(Id);
                    db.tblSuppliers.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task DeleteSupplierBranchLocation(long Id, string type)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblSupplierLocationBranch obj = new tblSupplierLocationBranch();
                    switch (type)
                    {
                        case "Location":
                            obj = await db.tblSupplierLocationBranches.Where(a => a.LocationID == Id).SingleAsync();
                            break;
                        case "Branch":
                            obj = await db.tblSupplierLocationBranches.Where(a => a.BranchID == Id).SingleAsync();
                            break;
                    }

                    db.tblSupplierLocationBranches.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task DeleteCandidateIndustries(int canId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    await db.tblCandidateIndustries.Where(a => a.CandidateID == canId).ForEachAsync(a => { a.IsActive = false; a.IsDeleted = true; });


                    await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task DeleteCandidateIndustry(int Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    await db.tblCandidateIndustries.Where(a => a.ID == Id).ForEachAsync(a => { a.IsActive = false; a.IsDeleted = true; });


                    await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task DeleteCandidateSkills(int canId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    await db.tblCandidateSkills.Where(a => a.CandidateID == canId).ForEachAsync(a => { a.IsActive = false; a.IsDeleted = true; });


                    await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task DeleteCandidateSkill(int Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    await db.tblCandidateSkills.Where(a => a.ID == Id).ForEachAsync(a => { a.IsActive = false; a.IsDeleted = true; });


                    await Task.Run(() => db.SaveChangesAsync());

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
