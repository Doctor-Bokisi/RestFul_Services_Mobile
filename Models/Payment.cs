using System;
namespace MyAppServices.Models
{
    public class Payment
    {
        public int pay_Id { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public int cust_Id { get; set; }

        public Payment()
        {

        }



        public Payment(int id, string Cname, string cNumber, string cvv,int Cid)
        {
            pay_Id = id;
            CardName = Cname;
            CardNumber = cNumber;
            Cvv = cvv;
            cust_Id = Cid;

        }

        public Payment(string Cname, string cNumber, string cvv)
        {

            CardName = Cname;
            CardNumber = cNumber;
            Cvv = cvv;
        }

    }
}
