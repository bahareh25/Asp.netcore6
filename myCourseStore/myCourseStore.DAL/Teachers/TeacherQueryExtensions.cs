using myCourseStore.Model.Teachers.Dtos;
using myCourseStore.Model.Teachers.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCourseStore.DAL.Teachers
{
  public static class TeacherQueryExtensions
    {
        public static IQueryable<Teacher> Whereover(this IQueryable<Teacher> teachers,string firstName)
        {
            if (!string.IsNullOrEmpty(firstName))
                teachers = teachers.Where(t => t.FirstName.Contains(firstName));
            return teachers;
        }
        public static IQueryable<Teacher> Whereover1(this IQueryable<Teacher> teachers, string lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
                teachers = teachers.Where(t => t.LastName.Contains(lastName));
            return teachers;
        }


        public static List<TeacherQr> ToTeacherQr(this IQueryable<Teacher> teachers)
        {
            return teachers.Select(c => new TeacherQr
            {
                ID= c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
            }).ToList();
        }
        public static async Task<List<TeacherQr>> ToTeacherQrAsync(this IQueryable<Teacher> teachers)
        {
            return await teachers.Select(c => new TeacherQr
            {
                ID = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
            }).ToListAsync();
        }
    }
}
