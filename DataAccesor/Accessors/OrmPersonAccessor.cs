﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using DataAccessor.Entity;
using DataAccessor.ORM;
using System.Data.SqlServerCe;
using System.Configuration;

namespace DataAccessor.Accessors
{
    public class OrmPersonAccessor: IAccessor<Person>
    {
        private MyORM orm;

        public OrmPersonAccessor()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLServerService"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["SQLServerService"].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

            orm = new MyORM(factory, connectionString, typeof(Person), typeof(Phone));
        }

        public ICollection<Person> GetAll()
        {
            
            return orm.SelectAll<Person>();
        }

        public Person GetById(object id)
        {
            //Phone p = orm.SelectById<Phone>(1);
            var v = orm.SelectById<Person>(id);
            return orm.SelectById<Person>(id);
        }

        public void DeleteById(object id)
        {
            orm.Delete<Person>(id);
        }

        public void Insert(Person p)
        {
            orm.Insert(p);
        }
    }
}
