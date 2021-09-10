﻿using NUnit.Framework;
using System;
using _02.VaniPlanning;

public class Test20
{
    [TestCase]
    public void ThrowInvoiceInPeriod_Agency_Should_Not_Contain_Deleted()
    {
        //Arrange

        var agency = new Agency();
        var invoice = new Invoice("123", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 28), new DateTime(2000, 10, 28));
        var invoice2 = new Invoice("435", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 29), new DateTime(2000, 10, 28));
        var invoice3 = new Invoice("444", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 30), new DateTime(2001, 09, 28));
        var invoice4 = new Invoice("test3", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 28), new DateTime(2001, 10, 28));
        var invoice5 = new Invoice("test", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 11, 28), new DateTime(2001, 11, 27));


        //Act

        agency.Create(invoice);
        agency.Create(invoice2);
        agency.Create(invoice3);
        agency.Create(invoice4);
        agency.Create(invoice5);

        agency.ThrowInvoiceInPeriod(new DateTime(2001, 09, 20), new DateTime(2001, 11, 27));

     

        //Assert

        Assert.IsFalse(agency.Contains("444"));
        Assert.IsFalse(agency.Contains("test3"));
    }
}
