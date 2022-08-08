﻿using Core.Entities;
using DataAcces.Context;
using DataAcces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repositories.Implementations
{
    public class AdminRepository : IRepository<Admin>
    {
        private static int id;
        public Admin Create(Admin entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Admins.Add(entity);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Admin entity)
        {
            try
            {
                DbContext.Admins.Remove(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Admins[0];
            }
            else
            {
                return DbContext.Admins.Find(filter);
            }
        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Admins;
            }
            else
            {
                return DbContext.Admins.FindAll(filter);
            }
        }

        public void Update(Admin entity)
        {
            try
            {

                var admin = DbContext.Admins.Find(g => g.Id == entity.Id);
                if (admin != null)
                {
                    admin.Username = admin.Username;
                    admin.Password = admin.Password;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}