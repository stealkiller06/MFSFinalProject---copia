﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MFSFinalProject.Infra;

namespace MFSFinalProject.Model
{
    public class Product : NotificationClass
    {

        private string name;
        private int minStock;
        private Category category;
        public Product()
        {
            Category = new Category();
            User = new User();
        }


        public int ProductId { get; set; }
        [Required]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public decimal SellPrice { get; set; }
        [Required]
        public int MinStock
        {
            get { return minStock; }
            set
            {
                minStock = value;
                OnPropertyChanged();
            }
        }
        public int Remove { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        //RelationShips
        public virtual Category Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged();
            }
        }
        public virtual User User { get; set; }


    }
}
