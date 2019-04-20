using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Appointment
{
    internal static class AppointmentHelpers
    {
        internal static eMSPEntities db;
        internal static async Task<tblCandidateSubmissionAppointment> saveAppointment(this AppointmentManager appointment, tblCandidateSubmissionAppointment data)
        {
            try
            {
                appointment.db.tblCandidateSubmissionAppointments.Add(data);
                await appointment.db.SaveChangesAsync();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static async Task<List<tblCandidateSubmissionAppointmentSlot>> saveAppointmentSlots(this AppointmentManager appointment, List<tblCandidateSubmissionAppointmentSlot> data)
        {
            try
            {
                appointment.db.tblCandidateSubmissionAppointmentSlots.AddRange(data);
                await appointment.db.SaveChangesAsync();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static async Task<List<tblCandidateSubmissionAppointmentUser>> saveAppointmentUser(this AppointmentManager appointment, List<tblCandidateSubmissionAppointmentUser> data)
        {
            try
            {
                appointment.db.tblCandidateSubmissionAppointmentUsers.AddRange(data);
                await appointment.db.SaveChangesAsync();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static async void updateAppointmentSlots(this AppointmentManager appointment, List<tblCandidateSubmissionAppointmentSlot> data,string updatedUserId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    data.ForEach(x =>
                    {
                        x.IsActive = false;
                        x.IsDeleted = true;
                        x.UpdatedUserID = updatedUserId;
                        x.UpdatedTimestamp = DateTime.Now;
                    });

                    await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async void updateAppointmentUser(this AppointmentManager appointment, List<tblCandidateSubmissionAppointmentUser> data, string updatedUserId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    data.ForEach(x =>
                    {
                        x.IsActive = false;
                        x.IsDeleted = true;
                        x.UpdatedUserID = updatedUserId;
                        x.UpdatedTimestamp = DateTime.Now;
                    });

                    await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Delete

        internal static async Task DeleteAppointmentUser(this AppointmentManager appointment, long appointmentId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var appointmentUsers = db.tblCandidateSubmissionAppointmentUsers
                                                                            .Where(rd => rd.AppointmentID == appointmentId)
                                                                            .ToList();
                    db.tblCandidateSubmissionAppointmentUsers.RemoveRange(appointmentUsers);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task DeleteAppointmentSlots(this AppointmentManager appointment, long appointmentId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var appointmentSlots = db.tblCandidateSubmissionAppointmentSlots
                                                                            .Where(rd => rd.AppintmentID == appointmentId)
                                                                            .ToList();
                    db.tblCandidateSubmissionAppointmentSlots.RemoveRange(appointmentSlots);
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
