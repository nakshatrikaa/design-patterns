﻿using DesignPatterns.Command.ShoppingCart.Models;
using DesignPatterns.Command.ShoppingCart.Repositories;

namespace DesignPatterns.Command.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    public readonly Dictionary<string, (Product Product, int Quantity)> LineItems = new();

    public IEnumerable<(Product Product, int Quantity)> All()
    {
        return LineItems.Values;
    }

    public (Product Product, int Quantity) Get(string articleId)
    {
        if (LineItems.ContainsKey(articleId)) return LineItems[articleId];

        return (default, default)!;
    }

    public void Add(Product product)
    {
        if (LineItems.ContainsKey(product.ArticleId))
            IncreaseQuantity(product.ArticleId);
        else
            LineItems[product.ArticleId] = (product, 1);
    }

    public void DecreaseQuantity(string articleId)
    {
        if (LineItems.ContainsKey(articleId))
        {
            var lineItem = LineItems[articleId];

            if (lineItem.Quantity == 1)
                LineItems.Remove(articleId);
            else
                LineItems[articleId] = (lineItem.Product, lineItem.Quantity - 1);
        }
        else
        {
            throw new KeyNotFoundException($"Product with article id {articleId} not in cart, please add first");
        }
    }

    public void IncreaseQuantity(string articleId)
    {
        if (LineItems.ContainsKey(articleId))
        {
            var lineItem = LineItems[articleId];
            LineItems[articleId] = (lineItem.Product, lineItem.Quantity + 1);
        }
        else
        {
            throw new KeyNotFoundException($"Product with article id {articleId} not in cart, please add first");
        }
    }

    public void RemoveAll(string articleId)
    {
        LineItems.Remove(articleId);
    }
}