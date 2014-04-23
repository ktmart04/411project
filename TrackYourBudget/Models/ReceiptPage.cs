using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrackYourBudget.Models
{
    public class ReceiptPage
    {
        [Key]
        public int rdiCode { get; set; }  //stands for Receipt Database Identifier Code, unique id to identify each receipt

        public string usercode { get; set; } //identifies the user, inputing the receipts

        [Display(Name = "Receipt Code ID")]
        public string rciCode { get; set; } //identifier on a receipt to use to identify that specific receipt

        [Display(Name = "Date of Transaction"), DataType(DataType.DateTime)]
        [Required]
        public DateTime dateTimePurchase { get; set; } //used to tell when the receipt was created

        [Display(Name = "Date of Entry"), DataType(DataType.Date)]
        [Required]
        public DateTime dateTime { get; set; } //entry used to tell when the receipt when was created

        [Display(Name = "Category")]
        [Required]
        public string Category { get; set; } //The category of the venue ex.fast food, gas, groceries

        [Display(Name = "Venue")]
        [Required]
        public string venueName { get; set; } //name of the retailer

        [Display(Name = "Amount Spent"), DataType(DataType.Currency)]
        [Required]
        public decimal amountSpent { get; set; }

        [Display(Name = "Payment Type")]
        [Required]
        public string PaymentType { get; set; }

        [Display(Name = "Comments")]
        [Required]
        public string descriptioninfo { get; set; } //tells a descriptive detail on what the receipt has been purchased for


    }

    public class ReceiptDbContext : DbContext
    {
        public DbSet<ReceiptPage> Receipts { get; set; }
    }
}

