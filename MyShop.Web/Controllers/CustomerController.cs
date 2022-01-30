﻿using Microsoft.AspNetCore.Mvc;
using MyShop.Domain;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers;

public class CustomerController : Controller
{
    private readonly IRepository<Customer> _customerRepository;

    public CustomerController(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IActionResult Index(Guid? id)
    {
        if (id == null)
        {
            var customers = _customerRepository.GetAll().ToList();

            return View(customers);
        }

        var customer = _customerRepository.Get(id.Value);

        return View(new[] { customer });
    }
}