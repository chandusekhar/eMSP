using eMSP.DataModel;
using eMSP.ViewModel.Appointment;
using eMSP.ViewModel.Comments;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Appointment
{
    public class AppointmentManager
    {

        #region Initialization

        private bool disposed = false;
        internal eMSPEntities db;

        public AppointmentManager()
        {
            db = new eMSPEntities();
        }

        #endregion

        #region AppointmentType

        public async Task<List<AppointmentTypeViewModel>> GetAppointmentTypeList()
        {
            try
            {

                return await db.tblAppointmentTypes.Select(x => new AppointmentTypeViewModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    isActive = x.IsActive,
                    isDeleted = x.IsDeleted,
                    createdTimestamp = x.CreatedTimestamp
                }).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AppointmentTypeViewModel> GetAppointmentType(long id)
        {
            try
            {

                return await db.tblAppointmentTypes.Where(s => s.ID == id).Select(x => new AppointmentTypeViewModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    isActive = x.IsActive,
                    isDeleted = x.IsDeleted,
                    createdTimestamp = x.CreatedTimestamp
                }).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AppointmentTypeViewModel> SaveType(AppointmentTypeViewModel data)
        {
            try
            {

                var obj = new tblAppointmentType()
                {
                    Name = data.Name,
                    Description = data.Description,
                    IsActive = data.isActive,
                    IsDeleted = data.isDeleted,
                    CreatedTimestamp = DateTime.UtcNow,
                    CreatedUserID = data.createdUserID
                };

                db.tblAppointmentTypes.Add(obj);
                await db.SaveChangesAsync();
                return new AppointmentTypeViewModel()
                {
                    ID = obj.ID,
                    Name = obj.Name,
                    Description = obj.Description,
                    isActive = obj.IsActive,
                    isDeleted = obj.IsDeleted
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AppointmentTypeViewModel> UpdateType(AppointmentTypeViewModel data)
        {
            try
            {

                var obj = await db.tblAppointmentTypes.Where(x => x.ID == data.ID).FirstOrDefaultAsync();

                if (obj != null)
                {
                    obj.Name = data.Name;
                    obj.Description = data.Description;
                    obj.IsActive = data.isActive;
                    obj.IsDeleted = data.isDeleted;
                    obj.UpdatedTimestamp = data.updatedTimestamp;
                }
                else
                {
                    throw new Exception("Update Failed ! Please check the data.");
                }

                await db.SaveChangesAsync();

                return new AppointmentTypeViewModel()
                {
                    ID = obj.ID,
                    Name = obj.Name,
                    Description = obj.Description,
                    isActive = obj.IsActive,
                    isDeleted = obj.IsDeleted
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ChangeAppointmentTypeStatus(long id, bool status)
        {
            try
            {

                var obj = await db.tblAppointmentTypes.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (obj != null)
                {
                    obj.IsActive = status;
                    obj.UpdatedTimestamp = DateTime.UtcNow;
                    await db.SaveChangesAsync();
                }
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region AppointmentStatus

        public async Task<List<AppointmentStatusViewModel>> GetAppointmentStatusList()
        {
            try
            {

                return await db.tblAppointmentStatus.Select(x => new AppointmentStatusViewModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    isActive = x.IsActive,
                    isDeleted = x.IsDeleted,
                    createdTimestamp = x.CreatedTimestamp
                }).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Appointment

        public async Task<CandidateSubmissionAppointmentViewModel> Save(CandidateSubmissionAppointmentViewModel data)
        {
            try
            {
                var objAppointment = new tblCandidateSubmissionAppointment()
                {
                    AppintmentTypeID = data.AppintmentTypeID,
                    AppointmentStatusID = data.AppointmentStatusID,
                    Name = data.Name,
                    Details = data.Details,
                    IsActive = data.isActive,
                    IsDeleted = data.isDeleted,
                    CreatedUserID = data.createdUserID,
                    CreatedTimestamp = DateTime.UtcNow,
                    CandidateSubmissionID = data.CandidateSubmissionID,
                    tblCandidateSubmissionAppointmentSlots = data.Slots.Select(x => new tblCandidateSubmissionAppointmentSlot()
                    {
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        IsActive = x.isActive,
                        IsDeleted = x.isDeleted,
                        CreatedUserID = data.createdUserID,
                        CreatedTimestamp = DateTime.UtcNow,
                        IsFinalised = x.IsFinalised
                    }).ToList(),
                    tblCandidateSubmissionAppointmentUsers = data.Users.Select(x => new tblCandidateSubmissionAppointmentUser()
                    {
                        UserID = x.UserID,
                        IsActive = x.isActive,
                        IsDeleted = x.isDeleted,
                        CreatedTimestamp = DateTime.UtcNow,
                        CreatedUserID = data.createdUserID
                    }).ToList()
                };

                var appointment = await this.saveAppointment(objAppointment);

                return new CandidateSubmissionAppointmentViewModel()
                {
                    ID = appointment.ID,
                    AppintmentTypeID = appointment.AppintmentTypeID,
                    AppointmentStatusID = appointment.AppointmentStatusID,
                    CandidateSubmissionID = appointment.CandidateSubmissionID,
                    Name = appointment.Name,
                    Details = appointment.Details,
                    isActive = appointment.IsActive,
                    createdTimestamp = appointment.CreatedTimestamp,
                    Status = new AppointmentStatusViewModel()
                    {
                        ID = appointment.tblAppointmentStatu.ID,
                        Name = appointment.tblAppointmentStatu.Name
                    },
                    Type = new AppointmentTypeViewModel()
                    {
                        ID = appointment.tblAppointmentType.ID,
                        Name = appointment.tblAppointmentType.Name
                    },
                    Slots = appointment.tblCandidateSubmissionAppointmentSlots.Select(x => new CandidateSubmissionAppointmentSlotViewModel()
                    {
                        ID = x.ID,
                        AppintmentID = x.AppintmentID,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        isActive = x.IsActive,
                        IsFinalised = x.IsFinalised
                    }).ToList(),
                    Users = appointment.tblCandidateSubmissionAppointmentUsers.Select(x => new CandidateSubmissionAppointmentUserViewModel()
                    {
                        ID = x.ID,
                        AppointmentID = x.AppointmentID,
                        UserID = x.UserID,
                        isActive = x.IsActive,
                        isDeleted = x.IsDeleted
                    }).ToList()
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CandidateSubmissionAppointmentViewModel> Get(long ID)
        {
            try
            {
                var appointment = await db.tblCandidateSubmissionAppointments.Where(x => x.ID == ID).FirstOrDefaultAsync();

                CandidateSubmissionAppointmentViewModel obj = null;

                if (appointment != null)
                {
                    obj = new CandidateSubmissionAppointmentViewModel()
                    {
                        ID = appointment.ID,
                        AppintmentTypeID = appointment.AppintmentTypeID,
                        AppointmentStatusID = appointment.AppointmentStatusID,
                        CandidateSubmissionID = appointment.CandidateSubmissionID,
                        Name = appointment.Name,
                        Details = appointment.Details,
                        isActive = appointment.IsActive,
                        createdTimestamp = appointment.CreatedTimestamp,
                        Status = new AppointmentStatusViewModel()
                        {
                            ID = appointment.tblAppointmentStatu.ID,
                            Name = appointment.tblAppointmentStatu.Name
                        },
                        Type = new AppointmentTypeViewModel()
                        {
                            ID = appointment.tblAppointmentType.ID,
                            Name = appointment.tblAppointmentType.Name
                        },
                        Slots = appointment.tblCandidateSubmissionAppointmentSlots.Select(x => new CandidateSubmissionAppointmentSlotViewModel()
                        {
                            ID = x.ID,
                            AppintmentID = x.AppintmentID,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            isActive = x.IsActive,
                            IsFinalised = x.IsFinalised
                        }).ToList(),
                        Users = appointment.tblCandidateSubmissionAppointmentUsers.Select(x => new CandidateSubmissionAppointmentUserViewModel()
                        {
                            ID = x.ID,
                            AppointmentID = x.AppointmentID,
                            UserID = x.UserID,
                            isActive = x.IsActive,
                            isDeleted = x.IsDeleted
                        }).ToList(),
                        UserComments = appointment.tblCandidateSubmissionAppointmentUserComments.Select(x => new CandidateSubmissionAppointmentUserCommentViewModel()
                        {
                            ID = x.ID,
                            AppointmentID = x.AppointmentID,
                            Comment = new CommentModel()
                            {
                                comment = x.tblComment.Comment,
                                isActive = x.tblComment.IsActive,
                                isDeleted = x.tblComment.IsDeleted,
                                showToAll = x.tblComment.ShowToAll,
                                id = x.CommentID,
                                createdTimestamp = x.CreatedTimestamp
                            }
                        }).ToList()
                    };
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CandidateSubmissionAppointmentViewModel>> GetList(long SubmissionID)
        {
            try
            {
                var appointmentlist = await db.tblCandidateSubmissionAppointments.Where(x => x.CandidateSubmissionID == SubmissionID).ToListAsync();

               List<CandidateSubmissionAppointmentViewModel> objList = null;

                if (appointmentlist != null)
                {
                    objList = appointmentlist.Select(appointment=> new CandidateSubmissionAppointmentViewModel()
                    {
                        ID = appointment.ID,
                        AppintmentTypeID = appointment.AppintmentTypeID,
                        AppointmentStatusID = appointment.AppointmentStatusID,
                        CandidateSubmissionID = appointment.CandidateSubmissionID,
                        Name = appointment.Name,
                        Details = appointment.Details,
                        isActive = appointment.IsActive,
                        createdTimestamp = appointment.CreatedTimestamp,
                        Status = new AppointmentStatusViewModel()
                        {
                            ID = appointment.tblAppointmentStatu.ID,
                            Name = appointment.tblAppointmentStatu.Name
                        },
                        Type = new AppointmentTypeViewModel()
                        {
                            ID = appointment.tblAppointmentType.ID,
                            Name = appointment.tblAppointmentType.Name
                        },
                        Slots = appointment.tblCandidateSubmissionAppointmentSlots.Select(x => new CandidateSubmissionAppointmentSlotViewModel()
                        {
                            ID = x.ID,
                            AppintmentID = x.AppintmentID,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            isActive = x.IsActive,
                            IsFinalised = x.IsFinalised
                        }).ToList(),
                        Users = appointment.tblCandidateSubmissionAppointmentUsers.Select(x => new CandidateSubmissionAppointmentUserViewModel()
                        {
                            ID = x.ID,
                            AppointmentID = x.AppointmentID,
                            UserID = x.UserID,
                            isActive = x.IsActive,
                            isDeleted = x.IsDeleted
                        }).ToList(),
                        UserComments = appointment.tblCandidateSubmissionAppointmentUserComments.Select(x => new CandidateSubmissionAppointmentUserCommentViewModel()
                        {
                            ID = x.ID,
                            AppointmentID = x.AppointmentID,
                            Comment = new CommentModel()
                            {
                                comment = x.tblComment.Comment,
                                isActive = x.tblComment.IsActive,
                                isDeleted = x.tblComment.IsDeleted,
                                showToAll = x.tblComment.ShowToAll,
                                id = x.CommentID,
                                createdTimestamp = x.CreatedTimestamp
                            }
                        }).ToList()
                    }).ToList();
                }
                return objList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CandidateSubmissionAppointmentViewModel> Update(long id, CandidateSubmissionAppointmentViewModel data, string loggedInUserID)
        {
            try
            {

                var appointment = await db.tblCandidateSubmissionAppointments.Where(x => x.ID == id).FirstOrDefaultAsync();
                CandidateSubmissionAppointmentViewModel obj = null;
                if (appointment != null)
                {
                    appointment.Name = data.Name;
                    appointment.Details = data.Details;
                    appointment.IsActive = data.isActive;
                    await db.SaveChangesAsync();

                    obj = new CandidateSubmissionAppointmentViewModel()
                    {
                        ID = appointment.ID,
                        AppintmentTypeID = appointment.AppintmentTypeID,
                        AppointmentStatusID = appointment.AppointmentStatusID,
                        CandidateSubmissionID = appointment.CandidateSubmissionID,
                        Name = appointment.Name,
                        Details = appointment.Details,
                        isActive = appointment.IsActive,
                        createdTimestamp = appointment.CreatedTimestamp,
                        Status = new AppointmentStatusViewModel()
                        {
                            ID = appointment.tblAppointmentStatu.ID,
                            Name = appointment.tblAppointmentStatu.Name
                        },
                        Type = new AppointmentTypeViewModel()
                        {
                            ID = appointment.tblAppointmentType.ID,
                            Name = appointment.tblAppointmentType.Name
                        },
                        Slots = appointment.tblCandidateSubmissionAppointmentSlots.Select(x => new CandidateSubmissionAppointmentSlotViewModel()
                        {
                            ID = x.ID,
                            AppintmentID = x.AppintmentID,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            isActive = x.IsActive,
                            IsFinalised = x.IsFinalised
                        }).ToList(),
                        Users = appointment.tblCandidateSubmissionAppointmentUsers.Select(x => new CandidateSubmissionAppointmentUserViewModel()
                        {
                            ID = x.ID,
                            AppointmentID = x.AppointmentID,
                            UserID = x.UserID,
                            isActive = x.IsActive,
                            isDeleted = x.IsDeleted
                        }).ToList()
                    };

                }
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<CandidateSubmissionAppointmentUserViewModel> AddAppointmentuser(string userID, long appointmentID, string loggedInUserID)
        {
            try
            {
                var obj = await db.tblCandidateSubmissionAppointmentUsers.Where(x => x.AppointmentID == appointmentID && x.UserID == userID).FirstOrDefaultAsync();

                if (obj == null)
                {
                    var data = new tblCandidateSubmissionAppointmentUser()
                    {
                        AppointmentID = appointmentID,
                        UserID = userID,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedTimestamp = DateTime.UtcNow,
                        CreatedUserID = loggedInUserID
                    };
                    db.tblCandidateSubmissionAppointmentUsers.Add(data);
                    await db.SaveChangesAsync();

                    return new CandidateSubmissionAppointmentUserViewModel()
                    {
                        ID = data.ID,
                        AppointmentID = data.AppointmentID,
                        UserID = data.UserID,
                        isActive = data.IsActive,
                        isDeleted = data.IsDeleted,
                        createdTimestamp = data.CreatedTimestamp,
                        createdUserID = data.CreatedUserID
                    };
                }
                else
                {
                    throw new Exception("User already added to this appointment");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> RemoveAppointmentuser(long id,string userID)
        {
            try
            {
                var obj = await db.tblCandidateSubmissionAppointmentUsers.Where(x => x.ID==id).FirstOrDefaultAsync();

                if (obj != null)
                {
                    db.tblCandidateSubmissionAppointmentUsers.Remove(obj);
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("User isn't found in this appointment");
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> SetFinalizeAppointmentSlots(long slotID, long appointmentID, string loggedInUserID)
        {
            try
            {
                var obj = await db.tblCandidateSubmissionAppointmentSlots.Where(x => x.AppintmentID == appointmentID).ToListAsync();

                if (obj != null && obj.Count != 0)
                {
                    obj.All(x => { x.IsFinalised = false; x.UpdatedUserID = loggedInUserID; x.UpdatedTimestamp = DateTime.UtcNow; return true; });
                    await db.SaveChangesAsync();

                    var objj = await db.tblCandidateSubmissionAppointmentSlots.Where(x => x.AppintmentID == appointmentID && x.ID == slotID).FirstOrDefaultAsync();
                    if (objj != null)
                    {
                        objj.IsFinalised = !objj.IsFinalised;
                        objj.UpdatedTimestamp = DateTime.UtcNow;
                        objj.UpdatedUserID = loggedInUserID;
                    }
                    await db.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CandidateSubmissionAppointmentSlotViewModel> UpdateSlots(long slotID, long appointnmentID, CandidateSubmissionAppointmentSlotViewModel data)
        {
            try
            {
                var obj = await db.tblCandidateSubmissionAppointmentSlots.Where(x => x.AppintmentID == appointnmentID && x.ID == slotID).FirstOrDefaultAsync();

                CandidateSubmissionAppointmentSlotViewModel returnDate = null;
                if (obj != null)
                {
                    obj.StartDate = data.StartDate;
                    obj.EndDate = data.EndDate;
                    obj.IsActive = data.isActive;
                    obj.IsFinalised = data.IsFinalised;
                    await db.SaveChangesAsync();

                    returnDate = new CandidateSubmissionAppointmentSlotViewModel()
                    {
                        ID = obj.ID,
                        AppintmentID = obj.AppintmentID,
                        StartDate = obj.StartDate,
                        EndDate = obj.EndDate,
                        isActive = obj.IsActive,
                        isDeleted = obj.IsDeleted,
                        IsFinalised = obj.IsFinalised,
                        createdTimestamp = obj.CreatedTimestamp
                    };
                }
                return returnDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CandidateSubmissionAppointmentSlotViewModel> AddSlots(long appointnmentID, CandidateSubmissionAppointmentSlotViewModel data)
        {
            try
            {
                var obj = await db.tblCandidateSubmissionAppointmentSlots.Where(x => x.AppintmentID == appointnmentID && x.StartDate == data.StartDate && x.EndDate == data.EndDate).FirstOrDefaultAsync();

                CandidateSubmissionAppointmentSlotViewModel returnDate = null;
                if (obj == null)
                {
                    var xdata = new tblCandidateSubmissionAppointmentSlot()
                    {
                        StartDate = data.StartDate,
                        EndDate = data.EndDate,
                        IsActive = data.isActive,
                        IsDeleted = data.isDeleted,
                        CreatedUserID = data.createdUserID,
                        CreatedTimestamp = DateTime.UtcNow,
                        IsFinalised = data.IsFinalised
                    };

                    db.tblCandidateSubmissionAppointmentSlots.Add(xdata);
                    await db.SaveChangesAsync();

                    returnDate = new CandidateSubmissionAppointmentSlotViewModel()
                    {
                        ID = xdata.ID,
                        AppintmentID = xdata.AppintmentID,
                        StartDate = xdata.StartDate,
                        EndDate = xdata.EndDate,
                        isActive = xdata.IsActive,
                        isDeleted = xdata.IsDeleted,
                        IsFinalised = xdata.IsFinalised,
                        createdTimestamp = xdata.CreatedTimestamp
                    };
                }
                else
                {
                    throw new Exception("Already An Appointment added with same date");
                }
                return returnDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposed = true;
            }
        }

        ~AppointmentManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
