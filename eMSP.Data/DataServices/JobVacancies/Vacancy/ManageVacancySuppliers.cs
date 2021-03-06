﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancySuppliers
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancySuppliers()
        { }

        #endregion

        #region Get
        internal static async Task<List<tblVacancySupplier>> GetVacancySuppliers(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancySuppliers
                                                  .Include(x => x.tblSupplier)
                                                  .Where(x => x.VacancyID == Id && (x.IsDeleted ?? false) == false).OrderByDescending(x => x.ID).ToList());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblVacancySupplier> InsertVacancySupplier(string a, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancySupplier model = new tblVacancySupplier();
                    model = db.tblVacancySuppliers.Add(new tblVacancySupplier
                    {
                        VacancyID = vacancy.ID,
                        SupplierID = Convert.ToInt16(a),
                        IsReleased = true,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedTimestamp = vacancy.CreatedTimestamp,
                        CreatedUserID = vacancy.CreatedUserID,
                        UpdatedTimestamp = vacancy.UpdatedTimestamp,
                        UpdatedUserID = vacancy.UpdatedUserID
                    });

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

        internal static async Task UpdateVacancySupplier(long VacancyId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblVacancySupplier> model = await Task.Run(() => db.tblVacancySuppliers.Where(q => q.VacancyID == VacancyId)
                                                                           .ToList());
                    model.All(vs => { vs.IsDeleted = true; return true; });

                    await Task.Run(() => db.SaveChangesAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        internal static async Task DeleteVacancySupplier(long VacancyId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblVacancySupplier> vacancySupplierList = db.tblVacancySuppliers.Where(q => q.VacancyID == VacancyId)
                                                                           .ToList();
                    db.tblVacancySuppliers.RemoveRange(vacancySupplierList);
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
