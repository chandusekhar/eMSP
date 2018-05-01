using eMSP.ViewModel.Appointment;
using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class AppointmentExtensions
    {
        public static tblAppointmentStatu ConvertTotblAppointmentStatu(this AppointmentStatus data)
        {
            return new tblAppointmentStatu()
            {
                ID = Convert.ToInt64(data.id),
                Name = data.name,
                Description = data.description,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now

            };
        }

        public static AppointmentStatus ConvertToAppointmentStatus(this tblAppointmentStatu data)
        {
            return new AppointmentStatus()
            {
                id = data.ID,
                name = data.Name,
                description = data.Description,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblAppointmentType ConvertTotblAppointmentType(this AppointmentType data)
        {
            return new tblAppointmentType()
            {
                ID = Convert.ToInt64(data.id),
                Name = data.name,
                Description = data.description,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static AppointmentType ConvertToAppointmentType(this tblAppointmentType data)
        {
            return new AppointmentType()
            {
                id = data.ID,
                name = data.Name,
                description = data.Description,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblCandidateSubmissionAppointment ConvertTotblCandidateSubmissionAppointment(this CandidateSubmissionAppointment data)
        {
            return new tblCandidateSubmissionAppointment()
            {
                ID = Convert.ToInt64(data.id),
                AppintmentTypeID = data.appintmentTypeID,
                CandidateSubmissionID = data.candidateSubmissionID,
                AppointmentStatusID = data.appointmentStatusID,
                Name = data.name,
                Details = data.details,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CandidateSubmissionAppointment ConvertToCandidateSubmissionAppointment(this tblCandidateSubmissionAppointment data)
        {
            return new CandidateSubmissionAppointment()
            {
                id = data.ID,
                appintmentTypeID = data.AppintmentTypeID,
                candidateSubmissionID = data.CandidateSubmissionID,
                appointmentStatusID = data.AppointmentStatusID,
                name = data.Name,
                details = data.Details,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblCandidateSubmissionAppointmentSlot ConvertTotblCandidateSubmissionAppointmentSlot(this CandidateSubmissionAppointmentSlot data)
        {
            return new tblCandidateSubmissionAppointmentSlot()
            {
                ID = Convert.ToInt64(data.id),
                AppintmentID = data.appintmentID,
                StartDate = data.startDate,
                EndDate = data.endDate,
                IsFinalised = data.isFinalised,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now

            };
        }

        public static CandidateSubmissionAppointmentSlot ConvertToCandidateSubmissionAppointmentSlot(this tblCandidateSubmissionAppointmentSlot data)
        {
            return new CandidateSubmissionAppointmentSlot()
            {
                id = data.ID,
                appintmentID = data.AppintmentID,
                startDate = data.StartDate,
                endDate = data.EndDate,
                isFinalised = data.IsFinalised,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }


        public static tblCandidateSubmissionAppointmentUser ConvertTotblCandidateSubmissionAppointmentUser(this CandidateSubmissionAppointmentUser data)
        {
            return new tblCandidateSubmissionAppointmentUser()
            {
                ID = Convert.ToInt64(data.id),
                AppointmentID = data.appointmentID,
                UserID = data.userID,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now

            };
        }

        public static CandidateSubmissionAppointmentUser ConvertToCandidateSubmissionAppointmentUser(this tblCandidateSubmissionAppointmentUser data)
        {
            return new CandidateSubmissionAppointmentUser()
            {
                id = data.ID,
                appointmentID = data.AppointmentID,
                userID = data.UserID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblCandidateSubmissionAppointmentUserComment ConvertTotblCandidateSubmissionAppointmentUserComment(this CandidateSubmissionAppointmentUserComment data)
        {
            return new tblCandidateSubmissionAppointmentUserComment()
            {
                ID = Convert.ToInt64(data.id),
                CommentID = data.commentID,
                //UserID = data.userID,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CandidateSubmissionAppointmentUserComment ConvertToCandidateSubmissionAppointmentUserComment(this tblCandidateSubmissionAppointmentUserComment data)
        {
            return new CandidateSubmissionAppointmentUserComment()
            {
                id = data.ID,
                commentID = data.CommentID,
                //userID = data.UserID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        //public static AppointmentModel ConvertToCandidateSubmissionAppointmentUser(this tblCandidateSubmissionAppointment data)
        //{
        //    return new AppointmentModel()
        //    {
        //        id = data.ID,
        //        appointmentID = data.AppointmentID,
        //        userID = data.UserID,
        //        isActive = data.IsActive,
        //        isDeleted = data.IsDeleted,
        //        createdUserID = data.CreatedUserID,
        //        updatedUserID = data.UpdatedUserID,
        //        createdTimestamp = DateTime.Now,
        //        updatedTimestamp = DateTime.Now
        //    };
        //}



    }
}
