﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.Models;

namespace WebApiTask1.Services
{
   public interface IPersonService
   {
       //CRUD
       Person Create(Person person);
       List<Person> Read();
       Person Read(int id);
       Person Update(int id, Person person);
       void Delete(int id);



   }
}
