﻿using Project.Domain.Entities;
using System;

namespace labMpp.Domain
{
    public class Artist : IHasID<int>
    {
        public int Id { get; set; }

        public String Nume { get; set; }


        public Artist(String nume)
        {
            Nume = nume;
            Id = -1;
        }

        public Artist(int id, String nume)
        {
            Nume = nume;
            Id = id;
        }




    }
}
