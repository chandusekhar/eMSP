using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Appointment
{
  internal static class AppointmentHelpers
    {
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
    }
}
