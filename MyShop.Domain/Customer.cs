﻿namespace MyShop.Domain;

public class Customer
{
    public Customer()
    {
        CustomerId = Guid.NewGuid();
    }

    public Guid CustomerId { get; set; }
    public string? Name { get; set; }
    public string? ShippingAddress { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
}