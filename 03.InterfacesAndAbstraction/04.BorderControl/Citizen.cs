﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public string Id { get; private set; }
    }
}
